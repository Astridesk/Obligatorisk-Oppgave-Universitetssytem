using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public class Student : Bruker
    {
        public int StudentID { get; init; }
        public string Karakter { get; set }
        public override string Rolle => "Student";

        public Student(string navn, string epost, string brukernavn, int studentID, string karakter)
        {
            StudentID = studentID;
            Navn = navn;
            Epost = epost;
            Karakter = karakter;        /*kan karakter være her? siden en student kan ha flere kurs,
                                         * og derfor flere karakterer. Koble kurs og karakter?*/
        }

        //Default studenter

        public static List<Student> DefaultStudent()
        {
            return new List<Student>
            {
                new Student("Ola Nordmann", "ola.nordmann@uia.no", "OlaNor", 12345, /*karakter*/ )
            };
        }
    }
}
