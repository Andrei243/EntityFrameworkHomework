using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Oras { get; set; }
        public string Tara { get; set; }
        public string Strada { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
