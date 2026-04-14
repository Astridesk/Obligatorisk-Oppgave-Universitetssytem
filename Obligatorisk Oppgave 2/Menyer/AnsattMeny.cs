using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2.Menyer
{
    public class AnsattMeny : MenyBase
    {
        public override void Vis()
        {
            Console.WriteLine("\n--- Ansattmeny ---");

            Console.WriteLine("[1] Opprett kurs");
            Console.WriteLine("[2] Søk på kurs");
            Console.WriteLine("[3] Meld student til kurs");
            Console.WriteLine("[4] Print kurs og deltagere");
            Console.WriteLine("[5] Sett karakter");

            Console.WriteLine("[6] Søk på bok");
            Console.WriteLine("[7] Returner bok");

            Console.WriteLine("[0] Logg ut");

        }

        public override void BehandleValg(string valg)
        {
            switch (valg)
            {
                case "1":
                    Program.OpprettKurs();
                    break;
                case "2":
                    Program.SøkKurs();
                    break;
                case "3":
                    Program.MeldPåEllerAvStudent();
                    break;
                case "4":
                    Program.SkrivUtKursOgStudentInfo();
                    break;
                case "5":
                    Console.WriteLine("Karaktersetting mangler.");
                    break;
                case "6":
                    Program.SøkBok();
                    break;
                case "7":
                    Program.Returner();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }

        }

    }
}
