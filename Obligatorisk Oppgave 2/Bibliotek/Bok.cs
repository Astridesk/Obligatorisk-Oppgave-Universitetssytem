using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public class Bok
    {
        public int BokID { get; init; }
        public string Tittel { get; set; }
        public string Forfatter { get; set; }
        public int År { get; set; }
        public int Antall { get; set; }


        public Bok(int bokID, string tittel, string forfatter, int år, int antall)
        {
            BokID = bokID;
            Tittel = tittel;
            Forfatter = forfatter;
            År = år;
            Antall = antall;

        }

        public static List<Bok> DefaultBøker()
        {
            return new List<Bok>
            {
                new Bok(1, "1984", "George Orwell", 1949, 2),
                new Bok(2, "The Silmarillion", "J.R.R. Tolkien", 1977, 1),
                new Bok(3, "The Mysterious Affair at Styles", "Agatha Christie", 1920, 2)
            };
        }


        //legg låning over til biblitek klassen.

        //public bool Ledig()
        //{
        //    return Antall > 0;
        //}

        //public void LånUt()
        //{
        //    if (Ledig())
        //    {
        //        Antall--;
        //    }

        //}

        //public void Returner()
        //{
        //    Antall++;
        //}
        //public string SkrivUtInfo()
        //{
        //    return $"BokID: {BokID} \nTittel: {Tittel} \nForfatter: {Forfatter} \nÅr: {År} \nAntall Eksemplarer: {Antall}";
        //}
    }
}
