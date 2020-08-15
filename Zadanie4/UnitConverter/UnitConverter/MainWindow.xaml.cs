using ConverterLogic;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using DBModule;


namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float angleM;
        private float angleH;
        SQLQueries q;
        DateTime date;

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
            q = new SQLQueries();
            DBGrid.ItemsSource = q.GetData();

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

                    date = DateTime.Now;
                    q = new SQLQueries();
                    q.save_to_DB(((IConvert)ConverterComboBox.SelectedItem).Name,
                                 UnitFromComboBox.SelectedItem.ToString(),
                                 UnitToComboBox.SelectedItem.ToString(),
                                 inputText,
                                 result,
                                 date);
                    DBGrid.ItemsSource = q.GetData();
                }
                else
                {
                    decimal inputValue = decimal.Parse(inputText);
                    result = ((IConvert)ConverterComboBox.SelectedItem).Convert(
                        UnitFromComboBox.SelectedItem.ToString(),
                        UnitToComboBox.SelectedItem.ToString(),
                        inputValue).ToString();

                    date = DateTime.Now;
                    q = new SQLQueries();
                    q.save_to_DB(((IConvert)ConverterComboBox.SelectedItem).Name,
                                 UnitFromComboBox.SelectedItem.ToString(),
                                 UnitToComboBox.SelectedItem.ToString(),
                                 inputText,
                                 result,
                                 date);
                    DBGrid.ItemsSource = q.GetData();
                }
            }
            outputTextBlock.Text = result;
        }

        private void SortClick(object sender, RoutedEventArgs e)
        {
            q = new SQLQueries();
            DateTime from, to;

            if (ConverterTextBox == null)
            {
                from = DateTime.Parse(FromTextBox.Text);
                to = DateTime.Parse(ToTextBox.Text);
                DBGrid.ItemsSource = q.SortFromToDate(from, to);
            }
            else if (FromTextBox == null && ToTextBox == null)
            {
                DBGrid.ItemsSource = q.SortByConverter(ConverterTextBox.Text);
            }
            else if (FromTextBox != null && ToTextBox != null && ConverterTextBox != null)
            {
                from = DateTime.Parse(FromTextBox.Text);
                to = DateTime.Parse(ToTextBox.Text);
                DBGrid.ItemsSource = q.GetTop3ResultsOfConverter(from, to, ConverterTextBox.Text);
            }
        }
    }
}
