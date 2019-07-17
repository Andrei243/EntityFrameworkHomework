using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Nota
    {
        public Nota()
        {
            Student = new Student();
            Grupa = new Grupa();
            Materie = new Materie();
            Profesor = new Profesor();
            Ora = new Orar();
        }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GrupaId { get; set; }
        public Grupa Grupa { get; set; }
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public Orar Ora { get; set; }
        public int Valoare { get; set; }

    }
}
