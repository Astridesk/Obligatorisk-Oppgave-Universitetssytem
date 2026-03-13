using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Student : Bruker
    {
        public int StudentID { get; set; }
        public string Kurs { get; set; } = string.Empty;        //skal det være en Liste?   //Kommer Kurs til å krasje med Kurs.cs? 

        public Student (string navn, string epost, int studentID, string kurs) : base(navn, epost)  //hvorfor navn og epost 2 ganger?
        {
            StudentID = studentID;
            Kurs = kurs;
        }
    }
}
