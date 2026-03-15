using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Ansatt : Bruker
    {
        public int AnsattID { get; set; }
        public string Stilling { get; set; }
        public string Avdeling { get; set; }

        public Ansatt(string navn, string epost, int ansattid, string stilling, string avdeling) : base(navn, epost)  
        {
            AnsattID = ansattid;
            Stilling = stilling;
            Avdeling = avdeling;
        }
    }
}
