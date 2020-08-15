using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ConverterLogic
{
    public class TempratureConverter : IConvert
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string> { "C","F","K" };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal result = 0;
            switch (unitFrom)
            {
                case "F":
                    if(unitTo.Equals("C"))
                    {
                        result = (valueToConvert - 32) * (decimal)1.8;
                    }
                    else if (unitTo.Equals("K"))
                    {
                        result = (valueToConvert + (decimal)459.67) * (decimal)1.8;
                    }
                    else
                    {
                        result = valueToConvert;
                    }
                    break;
                case "K":
                    if (unitTo.Equals("C"))
                    {
                        result = valueToConvert - (decimal)273.15;
                    }
                    else if (unitTo.Equals("F"))
                    {
                        result = (valueToConvert * (decimal)1.8) - (decimal)459.67;
                    }
                    else
                    {
                        result = valueToConvert;
                    }
                    break;
                case "C":
                    if (unitTo.Equals("F"))
                    {
                        result = (valueToConvert * (decimal)1.8) + 32;
                    }
                    else if (unitTo.Equals("K"))
                    {
                        result = valueToConvert + (decimal)273.15;
                    }
                    else
                    {
                        result = valueToConvert;
                    }
                    break;
            }
            return result;
        }

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
