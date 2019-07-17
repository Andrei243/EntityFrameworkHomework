using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace UI
{
    static class GeneratorAdresaRandom
    {
        static private Random random = new Random();

        static private List<(string,string)> oraseCuTari = new List<(string,string)>
        {
            ("Bucuresti","Romania"),
            ("Cluj-Napoca","Romania"),
            ("Iasi","Romania"),
            ("Piatra-Neamt","Romania"),
            ("Sibiu","Romania"),
            ("Timisoara","Romania"),
            ("Chisinau","Republica Moldova"),
            ("Sofia","Bulgaria"),
            ("Paris","Franta"),
            ("Berlin","Germania"),
            ("Dusseldorf","Germania"),
            ("Mogosoaia","Romania"),
            ("Vaslui","Romania"),
        };

        static public Adresa GenereazaAdresa()
        {
            Adresa adresa = new Adresa();
            (adresa.Oras, adresa.Tara) = oraseCuTari[random.Next(oraseCuTari.Count)];
            adresa.Strada = GeneratorPrenumeRandom.GenereazaPrenumeRandom();
            return adresa;

        }
      


    }
}
