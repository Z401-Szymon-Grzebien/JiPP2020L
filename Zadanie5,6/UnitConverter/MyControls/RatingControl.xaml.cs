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

namespace MyControls
{
    /// <summary>
    /// Interaction logic for RatingControl.xaml
    /// </summary>
    public partial class RatingControl : UserControl
    {
        public RatingControl()
        {
            InitializeComponent();
        }

        public event EventHandler<RatedEventArgs> RateValueChanged;

        private int? _ratevalue = 0;

        public int? RateValue { 
            get => _ratevalue;
            set
            {
                _ratevalue = value;
                UpdateButtons();
                RateValueChanged?.Invoke(this, new RatedEventArgs() { Value = _ratevalue });
            } 
        }

        private void UpdateButtons()
        {
            foreach (var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (_ratevalue > 0)
            {
                for (int i = 0; i <= _ratevalue - 1; ++i)
                {
                    ((Button)ratesGrid.Children[i]).Background = new SolidColorBrush(Colors.Blue);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
    }

    public class RatedEventArgs: EventArgs
    {
        public int? Value { get; set; }
    }
}
