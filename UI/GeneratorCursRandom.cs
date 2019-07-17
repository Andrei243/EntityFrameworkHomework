using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataAccess;

namespace UI
{
    
    static class GeneratorCursRandom
    {
        private static Random random = new Random();

        public static Curs GenereazaCursRandom()
        {
            List<(int, int)> cursuriExistente = new List<(int, int)>();
            List<Materie> materii = new List<Materie>();
            List<Profesor> profesori = new List<Profesor>();

            using(FacultateDbContext ctx = new FacultateDbContext())
            {
                foreach(var elem in ctx.Cursuri)
                {
                    cursuriExistente.Add((elem.MaterieId, elem.ProfesorId));
                }

                foreach(var elem in ctx.Materii)
                {
                    materii.Add(elem);
                }

                foreach(var elem in ctx.Profesori)
                {
                    profesori.Add(elem);
                }

            }

            Curs curs = new Curs();
            if (cursuriExistente.Count == materii.Count * profesori.Count) return null;
            else
            {
                (Materie, Profesor) cursNou = (materii[random.Next(materii.Count)], profesori[random.Next(profesori.Count)]);

                while (cursuriExistente.Contains((cursNou.Item1.Id, cursNou.Item2.Id)))
                {
                    cursNou = (materii[random.Next(materii.Count)], profesori[random.Next(profesori.Count)]);
                }
                curs.MaterieId = cursNou.Item1.Id;
                curs.ProfesorId = cursNou.Item2.Id;

                return curs;

            }


        }

    }
}
