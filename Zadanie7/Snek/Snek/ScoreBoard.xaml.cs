using DataBaseM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Snek
{
    /// <summary>
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Window
    {
        SQLQueries q;
        public ScoreBoard()
        {
            InitializeComponent();
        }

        private void btnLoad_Clicked(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => load_db());
            thread.Start();
        }
        private void btnTop10_Clicked(object sender, RoutedEventArgs e)
        {
            get_top_score();
        }
        void load_db()
        {
            q = new SQLQueries();
            for (int i = 0; i < 100; i++)
            {
                Dispatcher.Invoke(() => pbStatus.Value++);
                Thread.Sleep(100);
            }

            Dispatcher.Invoke(() => DBGrid.ItemsSource = q.GetData());
        }

        void get_top_score()
        {
            q = new SQLQueries();
            DBGrid.ItemsSource = q.GetTop10Scores();
        }
    }
}
