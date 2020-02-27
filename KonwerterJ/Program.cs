using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace KonwerterJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Co będziesz przeliczał? \n 1) temperaturę \n 2) długość \n 3) masę");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1: // Temperatura                   
                    Console.WriteLine("1) C -> F \n2) F -> C");
                    Temperature temp = new Temperature();                  
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Podaj wartość  w stopniach celciusza");
                        temp.Celcius = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Podaj wartość w stopniach fahrenheita");
                        temp.Fahrenheit = double.Parse(Console.ReadLine());
                    }
                    Console.WriteLine($"temperatura w stopniach celciusza: {temp.Celcius}");
                    Console.WriteLine($"temperatura w stopniach fahrenheita: {temp.Fahrenheit}");
                    break;

                case 2: // Długość
                    Console.WriteLine("1) Km -> Mile \n2) Mile -> Km");
                    Lenght lenght = new Lenght();
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Podaj wartość w kilometrach");
                        lenght.Kilometers = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Podaj wartość w milach");
                        lenght.Miles = double.Parse(Console.ReadLine());
                    }
                    Console.WriteLine($"długość w kilometrach: {lenght.Kilometers}");
                    Console.WriteLine($"długość w milach: {lenght.Miles}");
                    break;

                case 3: //Masa
                    Console.WriteLine("1) Kg -> Lbs \n2) Lbs -> Kg");
                    Mass mass = new Mass();
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("Podaj wartość kilogramach");
                        mass.Kilograms = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Podaj wartość w funtach");
                        mass.Pounds = double.Parse(Console.ReadLine());
                    }
                    Console.WriteLine($"masa w kilogramach: {mass.Kilograms}");
                    Console.WriteLine($"masa w funtach: {mass.Pounds}");
                    break;
            }
            Console.ReadKey();
        }
    }
    struct Temperature
    {
        double celcius;
        public double Celcius
        {
            get
            {
                return celcius;
            }
            set
            {
                celcius = value;
                fahrenheit = value * 1.8 + 32;
            }
        }
        double fahrenheit;
        public double Fahrenheit
        {
            get
            {
                return fahrenheit;
            }
            set
            {
                fahrenheit = value;
                celcius = (value - 32) / 1.8;
            }
        }
    }
    struct Lenght
    {
        double kilometers;
        public double Kilometers
        {
            get
            {
                return kilometers;
            }
            set
            {
                kilometers = value;
                miles = value * 0.62137;
            }
        }
        double miles;
        public double Miles
        {
            get
            {
                return miles;
            }
            set
            {
                miles = value;
                kilometers = value / 0.62137;
            }
        }

    }
    struct Mass
    {
        double kilograms;
        public double Kilograms
        {
            get
            {
                return kilograms;
            }
            set
            {
                kilograms = value;
                pounds = value * 2.20462262;
            }
        }
        double pounds;
        public double Pounds
        {
            get
            {
                return pounds;
            }
            set
            {
                pounds = value;
                kilograms = value / 2.20462262;
            }
        }
    }
}
