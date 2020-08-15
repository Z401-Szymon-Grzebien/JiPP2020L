using DataBaseM;
using GLogic;
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
using System.Windows.Threading;

namespace Snek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private members
        SQLQueries q;
        DispatcherTimer time;
        List<Snake> snakebody;
        List<Fruit> food;
        Random rd = new Random();
        double x = 100;
        double y = 100;
        int direction = 0;
        int left = 4;
        int right = 6;
        int up = 8;
        int down = 2;
        int score = 0;
        int count = 0;
        DateTime date;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            menuControl.btnClicked += MenuControl_btnClicked;
            time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 0, 0, 0, 100);  
            time.Tick += Time_Tick;

        }

        private void Time_Tick(object sender, EventArgs e)
        {
            if (direction != 0)
            {
                for (int i = snakebody.Count - 1; i > 0; i--)
                {
                    snakebody[i] = snakebody[i - 1];
                }
            }


            if (direction == up)
                y -= 10;
            if (direction == down)
                y += 10;
            if (direction == left)
                x -= 10;
            if (direction == right)
                x += 10;


            if (snakebody[0].x == food[0].x && snakebody[0].y == food[0].y)
            {
                snakebody.Add(new Snake(food[0].x, food[0].y));
                food[0] = new Fruit(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10);
                gmCanvas.Children.RemoveAt(0);
                addfoodincanvas();
                score++;
                txbScore.Text = score.ToString();
            }


            snakebody[0] = new Snake(x, y);

            if (snakebody[0].x > 370 || snakebody[0].y > 350 || snakebody[0].x < 0 || snakebody[0].y < 0)
            {
                x = 100;
                y = 100;
                direction = 0;
                food.Clear();
                snakebody.Clear();
                time.Stop();

                date = DateTime.Now;
                q = new SQLQueries();
                q.save_to_db(Int32.Parse(txbScore.Text), date);
                txbScore.Text = "0";
                menuControl.Visibility = Visibility.Visible;
            }


            for (int i = 1; i < snakebody.Count; i++)
            {
                if (snakebody[0].x == snakebody[i].x && snakebody[0].y == snakebody[i].y)
                {
                    x = 100;
                    y = 100;
                    direction = 0;
                    food.Clear();
                    snakebody.Clear();
                    time.Stop();

                    date = DateTime.Now;
                    q.save_to_db(Int32.Parse(txbScore.Text), date);
                    txbScore.Text = "0";
                    menuControl.Visibility = Visibility.Visible;
                }
            }


            for (int i = 0; i < gmCanvas.Children.Count; i++)
            {
                if (gmCanvas.Children[i] is Rectangle)
                    count++;
            }
            gmCanvas.Children.RemoveRange(1, count);
            count = 0;
            addsnakeincanvas();
        }

        private void MenuControl_btnClicked(bool isClicked, string btnName)
        {
            if (isClicked == true && btnName == "NewGame")
            {
                Console.WriteLine("NewGame");
                snakebody = new List<Snake>();
                food = new List<Fruit>();
                snakebody.Add(new Snake(x, y));
                food.Add(new Fruit(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10));
                addsnakeincanvas();
                addfoodincanvas();
                menuControl.Visibility = Visibility.Hidden;
                time.Start();

            }
            else
            {
                ScoreBoard scoreBoard = new ScoreBoard();
                scoreBoard.Show();
            }
        }

        void addfoodincanvas()
        {
            food[0].Setposition();
            gmCanvas.Children.Insert(0, food[0].ell);
        }


        void addsnakeincanvas()
        {
            foreach (Snake snake in snakebody)
            {
                snake.Setposition();
                gmCanvas.Children.Add(snake.rec);
            }
        }

        private void gmCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && direction != down)
                direction = up;
            if (e.Key == Key.Down && direction != up)
                direction = down;
            if (e.Key == Key.Left && direction != right)
                direction = left;
            if (e.Key == Key.Right && direction != left)
                direction = right;
        }

    }
}
