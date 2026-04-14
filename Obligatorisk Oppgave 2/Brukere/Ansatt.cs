using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public class Ansatt : Bruker
    {
        public int AnsattID { get; set; }
        public string Stilling { get; set; }
        public string Avdeling { get; set; }
        public override string Rolle => "Ansatt";

        public Ansatt(string navn, string epost, int ansattID, string stilling, string avdeling)    //base???
        {
            AnsattID = ansattID;
            Stilling = stilling;
            Avdeling = avdeling;
        }

        public static List<Ansatt> DefaultAnsatte()
        {
            return new List<Ansatt>
            {
                new Ansatt("Kinger", "kinger@uia.no", 120, "Professor", "institutt for informasjonssystemer")
            };
        }
    }
}
