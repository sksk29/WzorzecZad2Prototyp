using System;
using System.Collections.Generic;

// Abstrakcyjna klasa KolorPrototyp
abstract class KolorPrototyp
{
    public abstract KolorPrototyp Klonuj();
}

// Klasa Kolor implementująca KolorPrototyp
class Kolor : KolorPrototyp
{
    private int czerwony;
    private int zielony;
    private int niebieski;

    public Kolor(int czerwony, int zielony, int niebieski)
    {
        this.czerwony = czerwony;
        this.zielony = zielony;
        this.niebieski = niebieski;
    }

    // Implementacja metody Klonuj
    public override KolorPrototyp Klonuj()
    {
        Console.WriteLine($"Klonowanie koloru: R={czerwony}, G={zielony}, B={niebieski}");
        return (Kolor)MemberwiseClone();
    }
}

// Klasa KolorSerwis zawierająca słownik kolorów
class KolorSerwis
{
    private Dictionary<string, KolorPrototyp> _kolory = new Dictionary<string, KolorPrototyp>();

    // Metoda dodająca kolory do słownika
    public void DodajKolor(string nazwa, KolorPrototyp kolor)
    {
        _kolory.Add(nazwa, kolor);
    }

    // Metoda zwracająca kolor z wartoscia
    public KolorPrototyp PobierzKolor(string nazwa)
    {
        return _kolory[nazwa].Klonuj();
    }
}

// Główna klasa programu
class Program
{
    static void Main(string[] args)
    {
        // tk kolor
        Kolor kolorCzerwony = new Kolor(255, 0, 0);
        Kolor kolorZielony = new Kolor(128, 210, 127);
        Kolor kolorNiebieski = new Kolor(211, 33, 19);

        //instancja KolorSerwis
        KolorSerwis serwisKolorow = new KolorSerwis();

        // slownik
        serwisKolorow.DodajKolor("czerwony", kolorCzerwony);
        serwisKolorow.DodajKolor("zielony", kolorZielony);
        serwisKolorow.DodajKolor("niebieski", kolorNiebieski);

        // Klonowanie kol
        KolorPrototyp klonCzerwony = serwisKolorow.PobierzKolor("czerwony");
        KolorPrototyp klonZielony = serwisKolorow.PobierzKolor("zielony");
        KolorPrototyp klonNiebieski = serwisKolorow.PobierzKolor("niebieski");

        Console.ReadKey();
    }
}
