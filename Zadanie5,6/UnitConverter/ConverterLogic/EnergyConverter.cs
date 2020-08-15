using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public class EnergyConverter : IConvert
    {
        public string Name => "Energia";

        public List<string> Units => new List<string>() { "J", "KGm" };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal result = 0;
            switch (unitFrom)
            {
                case "J":
                    if (unitTo.Equals("KGm"))
                    {
                        result = valueToConvert * (decimal)0.1019716213;
                    }
                    else
                    {
                        result = valueToConvert;
                    }
                    break;
                case "KGm":
                    if (unitTo.Equals("J"))
                    {
                        result = valueToConvert / (decimal)0.1019716213;
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
