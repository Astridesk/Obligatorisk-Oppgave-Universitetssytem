using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public abstract class MenyBase

    {
        public abstract void Vis();
        public abstract void BehandleValg(string valg);
    }
}


//gammel meny, beholdes for referanse:

//public void VisMeny()
//{
//    Console.WriteLine("\n--- Universitetssystem ---");
//    Console.WriteLine("[1] Opprett kurs");
//    Console.WriteLine("[2] Meld student til kurs");
//    Console.WriteLine("[3] Print kurs og deltagere");
//    Console.WriteLine("[4] Søk på kurs");
//    Console.WriteLine("[5] Søk på bok");
//    Console.WriteLine("[6] Lån bok");
//    Console.WriteLine("[7] Returner bok");
//    Console.WriteLine("[8] Registrer bok");
//    Console.WriteLine("[0] Avslutt");
//}