using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public class Bibliotekar : Ansatt       //kan den ikke egentlig bare arve fra ansatt siden det er en type ansatt?
    {
        public int AnsattID { get; set; }
        public string Stilling { get; set; }
        public override string Rolle => "Bibliotekar";

        public Bibliotekar(string navn, string epost, int ansattID, string stilling)
        {
            AnsattID = ansattID;
            Stilling = stilling;
        }
    }
}

