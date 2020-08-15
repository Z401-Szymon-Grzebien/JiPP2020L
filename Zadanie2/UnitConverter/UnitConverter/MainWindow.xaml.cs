using ConverterLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
        public MainWindow()
        {
            InitializeComponent();

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
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            string result = "";
            if (ConverterComboBox.SelectedItem != null)
            {
                if (((IConvert)ConverterComboBox.SelectedItem).Name == "Konwerter Zegara")
                {
                    result = ((IConvert)ConverterComboBox.SelectedItem).Convert(
                        UnitFromComboBox.SelectedItem.ToString(),
                        UnitToComboBox.SelectedItem.ToString(),
                        inputText);
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
