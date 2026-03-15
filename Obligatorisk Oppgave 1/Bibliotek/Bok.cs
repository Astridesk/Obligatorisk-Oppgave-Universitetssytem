using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Bok
    {
        public int BokID { get; set; } 
        public string Tittel { get; set; }
        public string Forfatter { get; set; } 
        public int År { get; set; } 
        public int Antall { get; set; }
        

        public Bok(int bokID, string tittel, string forfatter, int år,  int antall)
            {
                BokID = bokID;
                Tittel = tittel;
                Forfatter = forfatter;
                År = år;
                Antall = antall;
               
        }


        public bool Ledig()
        {
            return Antall > 0;
        }

        public void LånUt()
        {
            if (Ledig())
            {
                Antall--;
            }

        }

        public void Returner()
        {
            Antall++;
        }
        public string SkrivUtInfo()
        {
            return $"BokID: {BokID} \nTittel: {Tittel} \nForfatter: {Forfatter} \nÅr: {År} \nAntall Eksemplarer: {Antall}";
        }
    }
}
