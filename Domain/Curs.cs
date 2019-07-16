using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Curs
    {
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public List<Orar> Ore { get; set; }
    }
}
