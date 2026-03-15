using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public abstract class Bruker  
    {
        //instansvariabler
        public string Navn { get; set; }
        private string Epost {  get; set; }

        //legg til passord?

        //konstruktør med parametere
        public Bruker(string navn, string epost)
        {
            Navn = navn;
            Epost = epost;
        }        
    }
}
