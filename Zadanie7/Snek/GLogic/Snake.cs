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
    public class Snake : ISpawn
    {
        public double x, y;
        public Rectangle rec = new Rectangle();
        public Snake(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Setposition()
        {
            rec.Width = rec.Height = 10;
            rec.Fill = Brushes.Green;
            Canvas.SetLeft(rec, x);
            Canvas.SetTop(rec, y);
        }
    }
}
