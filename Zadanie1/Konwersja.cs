using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    class Konwersja
    {
        protected double war;
        protected string j;
        protected string new_j;
        protected double wynik;

        public void PodajDane(double wartosc, string jednostka)
        {
            war = wartosc;
            j = jednostka;
        }

        protected double Oblicz()
        {
            double wynik = 0;

            switch (j)
            {
                case "c": wynik = (war * 1.8) + 32; break;
                case "f": wynik = (war-32)/1.8; break;
                case "km": wynik = war*0.62137; break;
                case "mi": wynik = war/0.62137; break;
                case "kg": wynik = war * 2.2046; break;
                case "fun": wynik = war / 2.2046; break;
            }
            return wynik;

        }

        public void PokazWynik()
        {
            string new_j = "";
            wynik = Oblicz();
            switch (j)
            {
                case "c": new_j="f"; break;
                case "f": new_j="c"; break;
                case "km": new_j="mi"; break;
                case "mi": new_j="km"; break;
                case "kg": new_j="fun"; break;
                case "fun": new_j="kg"; break;
            }

            Console.WriteLine(war + " " + j + "= " + wynik + " " + new_j);

        }
    }
}
