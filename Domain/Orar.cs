using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Orar
    {
        public Orar()
        {
            Grupa = new Grupa();
            Materie = new Materie();
            Profesor = new Profesor();
            Note = new List<Nota>();
            Curs = new Curs();
        }
        public int GrupaId { get; set; }
        public Grupa Grupa { get; set; }
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public List<Nota> Note { get; set; }
        public Curs Curs { get; set; }

    }
}
