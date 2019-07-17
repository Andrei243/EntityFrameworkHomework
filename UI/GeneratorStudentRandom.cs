using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace UI
{
    static class GeneratorStudentRandom
    {
        static public Student GenereazaStudentRandom(Adresa adresa)
        {
            Student student = new Student();
            student.Adresa = adresa;
            adresa.Student = student;
            student.DataNastere = DateTime.Now;
            student.Nume = GeneratorNumeRandom.GenereazaNumeRandom();
            student.Prenume = GeneratorPrenumeRandom.GenereazaPrenumeRandom();
            return student;
        }

    }
}
