using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace UI
{
    static class GeneratorProfesorRandom
    {
        static public Profesor GenereazaProfesorRandom()
        {
            Profesor profesor = new Profesor();
            profesor.Nume = GeneratorNumeRandom.GenereazaNumeRandom();
            profesor.Prenume = GeneratorPrenumeRandom.GenereazaPrenumeRandom();
            return profesor;

        }
    }
}
