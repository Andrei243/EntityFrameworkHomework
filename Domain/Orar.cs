using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Orar
    {
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
