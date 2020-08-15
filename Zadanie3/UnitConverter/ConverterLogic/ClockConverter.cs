using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public class ClockConverter : IConvert
    {
        public string Name => "Konwerter Zegara";

        public List<string> Units => new List<string> { "12", "24" };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            DateTime date;
            string result = "";
            switch (unitFrom)
            {
                case "12":
                    if (unitTo.Equals("24"))
                    {
                        try
                        {
                            date = DateTime.Parse(valueToConvert);
                            result = date.ToString("HH:mm");
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.ToString());
                        }
                    }
                    break;
                case "24":
                    if (unitTo.Equals("12"))
                    {
                        try
                        {
                            date = DateTime.Parse(valueToConvert);
                            result = date.ToString("hh:mm tt");
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine(err.ToString());
                        }
                    }
                    break;
            }
            return result;
        }

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
