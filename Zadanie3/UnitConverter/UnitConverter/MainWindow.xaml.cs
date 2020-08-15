using ConverterLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float angleM;
        private float angleH;

        public MainWindow()
        {
            InitializeComponent();
            Zegar.Visibility = Visibility.Hidden;
            ConverterComboBox.ItemsSource = new List<IConvert>
            {
                new ConverterLogic.LengthConverter(),
                new TempratureConverter(),
                new MassConverter(),
                new ClockConverter(),
                new EnergyConverter()
            };

        }

        private void ConverterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFromComboBox.ItemsSource = ((IConvert)ConverterComboBox.SelectedItem).Units;
            UnitToComboBox.ItemsSource = ((IConvert)ConverterComboBox.SelectedItem).Units;
            if(((IConvert)ConverterComboBox.SelectedItem).Name == "Konwerter Zegara")
            {
                Zegar.Visibility = Visibility.Visible;
            }
            else
            {
                Zegar.Visibility = Visibility.Hidden;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            string result = "";
            ((Storyboard)Resources["ButtonAnimation"]).Begin();
            if (ConverterComboBox.SelectedItem != null)
            {
                if (((IConvert)ConverterComboBox.SelectedItem).Name == "Konwerter Zegara")
                {
                    result = ((IConvert)ConverterComboBox.SelectedItem).Convert(
                        UnitFromComboBox.SelectedItem.ToString(),
                        UnitToComboBox.SelectedItem.ToString(),
                        inputText);
                    string minutes;
                    string hours;
                    minutes = result[3].ToString() + result[4].ToString();
                    hours = result[0].ToString() + result[1].ToString();
                    angleH = float.Parse(hours) / 12 * 360;
                    angleM = float.Parse(minutes) / 60 * 360;
                    AngleM.Angle = angleM;
                    AngleH.Angle = angleH;

                }
                else
                {
                    decimal inputValue = decimal.Parse(inputText);
                    result = ((IConvert)ConverterComboBox.SelectedItem).Convert(
                        UnitFromComboBox.SelectedItem.ToString(),
                        UnitToComboBox.SelectedItem.ToString(),
                        inputValue).ToString();
                }
            }
            outputTextBlock.Text = result;
        }
    }
}
