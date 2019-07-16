using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Grupa
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int An { get; set; }
        public List<GrupareStudenti> GrupeStudenti { get; set; }
        public List<Orar> Ore { get; set; }
    }
}
