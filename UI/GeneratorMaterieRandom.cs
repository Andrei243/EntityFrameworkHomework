using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace UI
{
    static class GeneratorMaterieRandom
    {
        static private List<string> materiiPosibile = new List<string>
        {
            "Programare procedurala",
            "Programare orientata obiect",
            "Programare logica",
            "Algebra",
            "Analiza",
            "Logica",
            "Arhitectura sistemelor de calcul",
            "Algoritmi si structuri de date",
            "Algoritmica grafurilor",
            "Limbaje formale si automate",
            "Geometrie",
            "Tehnici Web",
            "Calculabilitate si complexitate",
            "Probabilitati si statistica",
            "Tehnici de programare",
            "Geometrie computationala",
            "Inteligenta artificiala",
            "Metode de dezvoltare software",
            "Tehnici de simulare",
            "Ecuatii diferentiale"
        };

        static private List<string> nivelePosibile = new List<string>
        {
            "Incepator",
            "Mediu",
            "Avansat",
            "Profesional",
            "Expert"
        };
        static private Random random = new Random();

        static public Materie GenereazaMaterieRandom()
        {
            Materie materie = new Materie();
            materie.Denumire = materiiPosibile[random.Next(materiiPosibile.Count)] + " - " + nivelePosibile[random.Next(nivelePosibile.Count)];

            return materie;
        }

    }
}
