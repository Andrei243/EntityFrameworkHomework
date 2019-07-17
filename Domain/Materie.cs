using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Materie
    {
        public Materie()
        {
            Cursuri = new List<Curs>();
        }
        public int Id { get; set; }
        public string Denumire { get; set; }

        public List<Curs> Cursuri { get; set; }
    }
}
