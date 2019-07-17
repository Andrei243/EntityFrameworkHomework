using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataAccess;

namespace UI
{
    static class GeneratorGrupareStudent
    {
        static private Random random = new Random();

        static public GrupareStudenti GenereazaGrupareStudent()
        {
            List<(int, int)> grupariExistente = new List<(int, int)>();
            List<Student> studenti = new List<Student>();
            List<Grupa> grupe = new List<Grupa>();

            using (FacultateDbContext ctx = new FacultateDbContext())
            {
                foreach (var elem in ctx.GrupareStudenti)
                {
                    grupariExistente.Add((elem.StudentId, elem.GrupaId));
                }
                foreach (var elem in ctx.Students)
                {
                    studenti.Add(elem);
                }
                foreach (var elem in ctx.Grupe)
                {
                    grupe.Add(elem);
                }
            }
                GrupareStudenti grupareStudenti = new GrupareStudenti();

                if (grupariExistente.Count == studenti.Count * grupe.Count) return null;

                else
                {
                    (Student, Grupa) grupare = (studenti[random.Next(studenti.Count)], grupe[random.Next(grupe.Count)]);
                    while(grupariExistente.Contains((grupare.Item1.Id,grupare.Item2.Id) ))
                    {
                        grupare = (studenti[random.Next(studenti.Count)], grupe[random.Next(grupe.Count)]);

                    }
                    grupareStudenti.GrupaId = grupare.Item2.Id;
                    grupareStudenti.StudentId = grupare.Item1.Id;
                    grupareStudenti.Curent = true;
                    return grupareStudenti;

                }


            


        }

    }
}
