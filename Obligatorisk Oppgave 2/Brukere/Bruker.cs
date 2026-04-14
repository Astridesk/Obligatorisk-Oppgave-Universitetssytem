using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public enum Rolle
    {
        Student,
        Ansatt,
        Bibliotekar
    }
    public abstract class Bruker
    {


        //instansvariabler
        public string Navn { get; set; }       //sett som protected?
        public string Epost { get; set; }
        public string Brukernavn { get; private set; }      //brukernavn bli satt sammen av navnet
        public string Passord { private get; set; }         //sett krav til passordet

        public Rolle Rolle { get; set; }     //rolle for å skille mellom ulike typer brukere, og gi tilgang til forskjellige menyer

    }
}

