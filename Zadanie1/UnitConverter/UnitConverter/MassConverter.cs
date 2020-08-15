using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class MassConverter
    {
        public double Convert(double input, string type)
        {
            double tmp = 0;
            switch (type)
            {
                case "kg":
                    tmp = input * 1.8 + 32.0;
                    break;
                case "lbs":
                    tmp = (input - 32) / 1.8;
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            return tmp;
        }
    }
}
