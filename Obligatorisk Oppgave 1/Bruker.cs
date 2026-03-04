using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Bruker     //hvorfor ikke internal?
    {
        //instansvariabler
        private string Navn { get; set; } = string.Empty;
        private string Epost {  get; set; } = string.Empty;

        //konstruktør med paraametere
        public Bruker(string navn, string epost)
        {
            Navn = navn;
            Epost = epost;
        }

        public void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn} \nEpost: { Epost}"); //string interpolation
            
        }

    }
}
