using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace UnitConverter
{
    public class TempratureConverter
    {
        public double Convert(double input, string type)
        {
            double tmp = 0;
            switch (type)
            {
                case "F":
                    tmp = input * 1.8 + 32.0;
                    break;
                case "C":
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
