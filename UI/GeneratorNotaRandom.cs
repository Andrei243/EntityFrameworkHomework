using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    static class GeneratorNotaRandom
    {
        private static Random random = new Random();

        public static Nota GenereazaNotaRandom()
        {
            List<(int, int, int, int)> noteExistente = new List<(int, int, int, int)>();
            List<Student> studenti=new List<Student>();
            List<Orar> ore = new List<Orar>();

            using(FacultateDbContext ctx = new FacultateDbContext())
            {
                foreach(var elem in ctx.Note)
                {
                    noteExistente.Add((elem.StudentId, elem.GrupaId, elem.MaterieId, elem.ProfesorId));
                }

                foreach(var elem in ctx.Students)
                {
                    studenti.Add(elem);
                }

                foreach(var elem in ctx.Ore.Include(c => c.Grupa).Include(c => c.Materie).Include(c => c.Profesor))
                {
                    ore.Add(elem);
                }

            }


            Nota nota = new Nota();

            if (noteExistente.Count == studenti.Count * ore.Count) return null;
            else
            {

                (Student, Orar) notaNoua = (studenti[random.Next(studenti.Count)], ore[random.Next(ore.Count)]);

                while (noteExistente.Contains((notaNoua.Item1.Id, notaNoua.Item2.GrupaId, notaNoua.Item2.MaterieId, notaNoua.Item2.ProfesorId)))
                {
                    notaNoua = (studenti[random.Next(studenti.Count)], ore[random.Next(ore.Count)]);
                }

                nota.StudentId = notaNoua.Item1.Id;
                nota.GrupaId = notaNoua.Item2.Grupa.Id;
                nota.MaterieId = notaNoua.Item2.Materie.Id;
                nota.ProfesorId = notaNoua.Item2.Profesor.Id;
                nota.Valoare = random.Next(1, 11);
                return nota;

            }



        }

    }
}
