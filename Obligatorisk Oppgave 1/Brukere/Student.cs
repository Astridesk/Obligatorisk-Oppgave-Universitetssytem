using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Student : Bruker
    {
        public int StudentID { get; set; }
        public List<Kurs> KursListe { get; set; }

        public Student (string navn, string epost, int studentID) : base(navn, epost)  //hvorfor navn og epost 2 ganger?
        {
            StudentID = studentID;
            KursListe = new List<Kurs>();
        }
    }
}
