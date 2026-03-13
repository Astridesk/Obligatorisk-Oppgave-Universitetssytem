using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Bruker     //hvorfor ikke internal?
    {
        //instansvariabler
        public string Navn { get; set; } = string.Empty;
        private string Epost {  get; set; } = string.Empty;

        //legg til passord?

        //konstruktør med parametere
        public Bruker(string navn, string epost)
        {
            Navn = navn;
            Epost = epost;
        }

        public void SkrivUtInfo()       //trengs denne her? Siden den ikke er i Student-klassen, og det er der vi skal bruke den?
        {
            Console.WriteLine($"Navn: {Navn} \nEpost: { Epost}"); //string interpolation
            
        }

    }
}
