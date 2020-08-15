using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GLogic
{
    public class Fruit : ISpawn
    {
        public double x, y;
        public Ellipse ell = new Ellipse();
        public Fruit(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Setposition()
        {
            ell.Width = ell.Height = 10;
            ell.Fill = Brushes.Yellow;
            Canvas.SetLeft(ell, x);
            Canvas.SetTop(ell, y);
        }
    }
}
