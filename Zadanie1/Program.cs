using System;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Konwersja temperatura = new Konwersja();
            temperatura.PodajDane(21.5, "c");
            temperatura.PokazWynik();
            temperatura.PodajDane(92, "f");
            temperatura.PokazWynik();

            Konwersja odleglosc = new Konwersja();
            odleglosc.PodajDane(215, "km");
            odleglosc.PokazWynik();
            odleglosc.PodajDane(380, "mi");
            odleglosc.PokazWynik();

            Konwersja waga = new Konwersja();
            waga.PodajDane(5, "kg");
            waga.PokazWynik();
            waga.PodajDane(35, "fun");
            waga.PokazWynik();

        }
    }
}
