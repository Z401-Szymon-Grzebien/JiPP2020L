using System;
using System.Collections.Generic;
using System.Text;

namespace ConverterLogic
{
    public class MassConverter : IConvert
    {
        public string Name => "Masa";

        public List<string> Units => new List<string> { "kg","lbs" };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal result = 0;
            switch(unitFrom)
            {
                case "kg":
                    if (unitTo.Equals("lbs"))
                    {
                        result = valueToConvert / (decimal)0.45359237;
                    }
                    else
                    {
                        result = valueToConvert;
                    }
                    break;
                case "lbs":
                    if (unitTo.Equals("kg"))
                    {
                        result = valueToConvert * (decimal)0.45359237;
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
