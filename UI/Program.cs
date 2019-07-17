using System;
using Domain;
using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int nrStudenti;
            int nrGrupe;
            int nrMaterii;
            int nrProfesori;
            int nrGrupari;
            int nrCursuri;
            int nrOre;
            int nrNote;
            Console.WriteLine("Cati studenti vrei sa se adauge?");
            nrStudenti = int.Parse(Console.ReadLine());
            Console.WriteLine("Cate grupe vrei sa se adauge?");
            nrGrupe = int.Parse(Console.ReadLine());
            Console.WriteLine("Cate materii vrei sa se adauge?");
            nrMaterii = int.Parse(Console.ReadLine());
            Console.WriteLine("Cati profesori vrei sa se adauge?");
            nrProfesori = int.Parse(Console.ReadLine());
            Console.WriteLine("Cate grupari vrei sa se adauge?");
            nrGrupari = int.Parse(Console.ReadLine());
            Console.WriteLine("Cate cursuri vrei sa se adauge?");
            nrCursuri = int.Parse(Console.ReadLine());
            Console.WriteLine("Cate ore vrei sa se adauge?");
            nrOre = int.Parse(Console.ReadLine());
            Console.WriteLine("Cate note vrei sa se adauge");
            nrNote = int.Parse(Console.ReadLine());

            List<Student> studenti = new List<Student>();
            List<Adresa> adrese = new List<Adresa>();
            for(int i = 0; i< nrStudenti; i++)
            {
                Adresa adresa = GeneratorAdresaRandom.GenereazaAdresa();
                adrese.Add(adresa);
                Student student = GeneratorStudentRandom.GenereazaStudentRandom(adresa);
                studenti.Add(student);
            }
            List<Grupa> grupe = new List<Grupa>();
            for(int i = 0; i < nrGrupe; i++)
            {
                grupe.Add(GeneratorGrupaRandom.GenereazaGrupaRandom());
            }
            List<Materie> materii = new List<Materie>();
            for(int i = 0; i < nrMaterii; i++)
            {
                materii.Add(GeneratorMaterieRandom.GenereazaMaterieRandom());
            }
            List<Profesor> profesori = new List<Profesor>();
            for(int i = 0; i < nrProfesori; i++)
            {
                profesori.Add(GeneratorProfesorRandom.GenereazaProfesorRandom());
            }

            using(FacultateDbContext ctx=new FacultateDbContext())
            {
                foreach (var adresa in adrese.Distinct()) ctx.Adrese.Add(adresa);
                foreach (var student in studenti.Distinct()) ctx.Add(student);
                foreach (var grupa in grupe.Distinct()) ctx.Add(grupa);
                foreach (var materie in materii.Distinct()) ctx.Add(materie);
                foreach (var profesor in profesori.Distinct()) ctx.Add(profesor);
                ctx.SaveChanges();
            }

            List<GrupareStudenti> grupari = new List<GrupareStudenti>();
            for(int i = 0; i < nrGrupari; i++)
            {
                GrupareStudenti grupare = GeneratorGrupareStudent.GenereazaGrupareStudent();
                if (!(grupare is null)) grupari.Add(grupare);
            }

            List<Curs> cursuri = new List<Curs>();
            for(int i = 0; i < nrCursuri; i++)
            {
                Curs curs = GeneratorCursRandom.GenereazaCursRandom();
                if (!(curs is null)) cursuri.Add(curs);
            }

            using(FacultateDbContext ctx = new FacultateDbContext())
            {
                foreach (var grupare in grupari.Distinct()) ctx.Add(grupare);
                foreach (var curs in cursuri.Distinct()) ctx.Add(curs);
                ctx.SaveChanges();
            }

            List<Orar> ore = new List<Orar>();
            for(int i = 0; i < nrOre; i++)
            {
                Orar ora = GeneratorOrarRandom.GenereazaOrarRandom();
                if (!(ora is null)) ore.Add(ora);
            }
            using(FacultateDbContext ctx=new FacultateDbContext())
            {
                foreach (var ora in ore.Distinct()) ctx.Add(ora);
                ctx.SaveChanges();
            }
            List<Nota> note = new List<Nota>();
            for(int i = 0; i < nrNote; i++)
            {
                Nota nota = GeneratorNotaRandom.GenereazaNotaRandom();
                if (!(nota is null)) note.Add(nota);
            }
            using(FacultateDbContext ctx = new FacultateDbContext())
            {
                foreach (var nota in note.Distinct()) ctx.Add(nota);
                ctx.SaveChanges();
            }

            //using(FacultateDbContext ctx = new FacultateDbContext())
            //{
              
            //    foreach (var elem in ctx.Grupe) if (elem.Nume is null) ctx.Remove(elem);
            //    foreach (var elem in ctx.Materii) if (elem.Denumire is null) ctx.Remove(elem);
            //    foreach (var elem in ctx.Profesori) if (elem.Nume is null) ctx.Remove(elem);
            //    foreach (var elem in ctx.Students) if (elem.Nume is null) ctx.Remove(elem);
            //    ctx.SaveChanges();

            //}

        }
    }
}
