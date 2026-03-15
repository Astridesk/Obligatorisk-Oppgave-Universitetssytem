using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class UniversitetSystem 
    {
        public static List<Kurs> KursListe = new List<Kurs>();
        private static List<Student> StudentListe = new List<Student>();
        private static List<Bok> Bøker = new List<Bok>();
        private static List<BibliotekLån> LånListe = new List<BibliotekLån>();

        public List<Kurs> KursListePublic => KursListe;
        public List<Student> Studenter => StudentListe;
        public List<Bok> Boker => Bøker;
        public List<BibliotekLån> LånListePublic => LånListe;
    }
}