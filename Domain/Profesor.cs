﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public List<Curs> Cursuri { get; set; }
    }
}
