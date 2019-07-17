using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace UI
{
    static class GeneratorGrupaRandom
    {
        static private Random random = new Random();
        static public Grupa GenereazaGrupaRandom()
        {
            Grupa grupa = new Grupa();
            grupa.Nume = random.Next(100, 500).ToString();
            grupa.An = (int)grupa.Nume.ToCharArray()[0];
            return grupa;
        }

    }
}
