using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    static class GeneratorOrarRandom
    {
        private static Random random = new Random();

        public static Orar GenereazaOrarRandom()
        {
            List<(int, int, int)> oreExistente = new List<(int, int, int)>();
            List<Curs> cursuri = new List<Curs>();
            List<Grupa> grupe = new List<Grupa>();

            using(FacultateDbContext ctx = new FacultateDbContext())
            {
                foreach(var elem in ctx.Ore)
                {
                    oreExistente.Add((elem.GrupaId, elem.MaterieId, elem.ProfesorId));
                }

                foreach(var elem in ctx.Cursuri.Include(c=>c.Materie).Include(c=>c.Profesor))
                {
                    cursuri.Add(elem);
                }

                foreach(var elem in ctx.Grupe)
                {
                    grupe.Add(elem);
                }

            }

            Orar orar = new Orar();
            if (oreExistente.Count == cursuri.Count * grupe.Count) return null;
            else
            {
                (Grupa, Curs) oraNoua = (grupe[random.Next(grupe.Count)], cursuri[random.Next(cursuri.Count)]);

                while (oreExistente.Contains((oraNoua.Item1.Id, oraNoua.Item2.MaterieId, oraNoua.Item2.ProfesorId)))
                {
                    oraNoua = (grupe[random.Next(grupe.Count)], cursuri[random.Next(cursuri.Count)]);
                }
                orar.GrupaId = oraNoua.Item1.Id;
                orar.MaterieId = oraNoua.Item2.Materie.Id;
                orar.ProfesorId = oraNoua.Item2.Profesor.Id;
                return orar;

            }

        } 


    }
}
