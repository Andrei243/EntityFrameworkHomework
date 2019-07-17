using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Student
    {
        public Student()
        {
            Adresa = new Adresa();
            Note = new List<Nota>();
            GrupareStudenti = new List<GrupareStudenti>();
        }
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNastere { get; set; }
        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }
        public List<Nota> Note { get; set; }
        public List<GrupareStudenti> GrupareStudenti { get; set; }
    }
}
