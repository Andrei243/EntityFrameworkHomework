using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class GrupareStudenti
    {
        public GrupareStudenti()
        {
            Student = new Student();
            Grupa = new Grupa();
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GrupaId { get; set; }
        public Grupa Grupa { get; set; }
        public bool Curent { get; set; }

    }
}
