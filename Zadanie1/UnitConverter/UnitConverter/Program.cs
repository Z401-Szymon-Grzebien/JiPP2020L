using System;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            TempratureConverter t;
            MassConverter m;
            LengthConverter l;

            bool status = true;
            double wynik = 0;
            double in_d;
            string in_s;
            string in_c;

            while(status == true)
            {
                Console.WriteLine("1 - Konwersja dlugosci\n"+"2 - Konwersja Temperatury\n"+"3 - Konwersja Masy\n"+"q - Wyjscie");
                Console.Write("Twoj wybor: ");
                in_s = Console.ReadLine();
                Console.Clear();
                switch(in_s)
                {
                    case "1":
                        Console.WriteLine("Km - Miles -> Kilometers");
                        Console.WriteLine("Mi - Kilometers -> Miles");
                        Console.Write("Twoj wybor: ");
                        in_c = Console.ReadLine();
                        Console.Write("Podaj wartosc: ");
                        if (!double.TryParse(Console.ReadLine(), out in_d)) { }
                        l = new LengthConverter();
                        wynik = l.Convert(in_d, in_c);
                        Console.WriteLine("Wynik konwersji: " + wynik + " {0}", in_c);
                        Console.WriteLine("... click any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("C - Fahrenheit -> Celsius");
                        Console.WriteLine("F - Celsius -> Fahrenheit");
                        Console.Write("Twoj wybor: ");
                        in_c = Console.ReadLine();
                        Console.Write("Podaj wartosc: ");
                        if (!double.TryParse(Console.ReadLine(), out in_d)) { }
                        t = new TempratureConverter();
                        wynik = t.Convert(in_d, in_c);
                        Console.WriteLine("Wynik konwersji: " + wynik + " {0}", in_c);
                        Console.WriteLine("... click any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("kg - pounds -> kilograms");
                        Console.WriteLine("lbs - kilograms -> pounds");
                        Console.Write("Twoj wybor konwertera: ");
                        in_c = Console.ReadLine();
                        Console.Write("Podaj wartosc: ");
                        if (!double.TryParse(Console.ReadLine(), out in_d)) { }
                        m = new MassConverter();
                        wynik = m.Convert(in_d, in_c);
                        Console.WriteLine("Wynik konwersji: " + wynik + " {0}", in_c);
                        Console.WriteLine("... click any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "q":
                        status = false;
                        break;

                    default:
                        Console.WriteLine("err");
                        Console.Clear();
                        break;
                }

            }
            
        }
    }
}
