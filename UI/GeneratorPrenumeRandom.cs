using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    static class GeneratorPrenumeRandom
    {

        static private List<string> prenumeFata = new List<string>
        {
            "Andreea",
            "Ada",
            "Alexandra",
            "Adriana",
            "Beatrice",
            "Bogdana",
            "Cristina",
            "Crina",
            "Diana",
            "Daria",
            "Elena",
            "Gabriela",
            "Ioana",
            "Ilinca",
            "Larisa",
            "Laura",
            "Loredana",
            "Oana",
            "Olga",
            "Otilia",
            "Nicoleta"
        };
        static private List<string> prenumeBaiat = new List<string>
        {
            "Andrei",
            "Adrian",
            "Alexandru",
            "Adelin",
            "Aurel",
            "Catalin",
            "Calin",
            "Codrin",
            "Corneliu",
            "Cezar",
            "Constantin",
            "Carol",
            "Cristian",
            "Darius",
            "David",
            "Dumitru",
            "Dragos",
            "Eugen",
            "Filip",
            "Felix",
            "Gabriel",
            "George",
            "Gheorghe",
            "Horea"
        };

        static private Random randomPrenume = new Random();
        static private Random randomNumar = new Random();
        static private Random randomGen = new Random();

        static private string Join(List<string> componente)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(componente[0]);
            for(int i = 1; i < componente.Count; i++)
            {
                stringBuilder.Append('-');
                stringBuilder.Append(componente[i]);
            }
            return stringBuilder.ToString();
        }
        static public string GenereazaPrenumeRandom()
        {
            List<string> sursa;
            {
                double probabilitateGen = randomGen.NextDouble();
                if (probabilitateGen < 0.5) sursa = prenumeBaiat;
                else sursa = prenumeFata;
            }

            List<string> componenteNume = new List<string>();
            componenteNume.Add(sursa[randomPrenume.Next(sursa.Count)]);
            decimal probabilitateNumar = 0.5M;

            while((decimal)randomNumar.NextDouble()<probabilitateNumar)
            {
                if (componenteNume.Count == sursa.Count) break;
                string componentaNoua = sursa[randomPrenume.Next(sursa.Count)];
                while (componenteNume.Contains(componentaNoua))
                {
                    componentaNoua = sursa[randomPrenume.Next(sursa.Count)];
                }
                componenteNume.Add(componentaNoua);
                probabilitateNumar /= 4;
            }

            return Join(componenteNume);
        }

    }
}
