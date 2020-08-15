using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class LengthConverter
    {
        public double Convert(double input, string type)
        {
            double tmp = 0;
            switch (type)
            {
                case "Km":
                    tmp = input / 0.62137;
                    break;
                case "Mi":
                    tmp = input * 0.62137;
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            return tmp;
        }
    }
}
