using System;
using System.Collections.Generic;
using System.Text;

namespace ConverterLogic
{
    public class LengthConverter : IConvert
    {
        public string Name => "Dlugosc";

        public List<string> Units => new List<string> { "Km", "Mi" };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal result = 0;
            switch (unitFrom)
            {
                case "Km":
                    if(unitTo.Equals("Mi"))
                    {
                        result = valueToConvert * (decimal)1.609344;
                    }
                    else
                    {
                        result = valueToConvert;
                    }
                    break;
                case "Mi":
                    if (unitTo.Equals("Km"))
                    {
                        result = valueToConvert / (decimal)1.609344;
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
