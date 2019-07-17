using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    static class GeneratorNumeRandom
    {
        static private List<string> numePosibile = new List<string>{
            "Nitu",
            "Popa",
            "Verman",
            "Popescu",
            "Ionescu",
            "Pop",
            "Constantinescu",
            "Stan",
            "Stanciu",
            "Dumitrescu",
            "Dima",
            "Gheorghiu",
            "Marin",
            "Tudor",
            "Dobre",
            "Barbu",
            "Nistor",
            "Florea",
            "Dinu",
            "Dinescu",
            "Georgescu"
        };

        static private Random random = new Random();

        static public string GenereazaNumeRandom()
        {
            return numePosibile[random.Next(numePosibile.Count)];
        }

    }
}
