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

namespace MenuControl
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        public event BtnClicked btnClicked;

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            string btnName = "NewGame";
            bool isClicked = true;
            btnClicked(isClicked, btnName);
        }
        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            string btnName = "Score";
            bool isClicked = true;
            btnClicked(isClicked, btnName);
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

        public delegate void BtnClicked(bool isClicked, string btnName);
    }
}
