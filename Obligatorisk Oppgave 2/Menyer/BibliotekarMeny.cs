using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2.Menyer
{
    public class BibliotekarMeny : MenyBase
    {
        public override void Vis()
        {
            Console.WriteLine("\n--- Bibliotekarmeny ---");
            Console.WriteLine("[1] Søk på bok");
            Console.WriteLine("[2] Lån bok");
            Console.WriteLine("[3] Returner bok");
            Console.WriteLine("[4] Registrer bok");
            Console.WriteLine("[0] Logg ut");
        }

        public override void BehandleValg(string valg)
        {
            switch (valg)
            {
                case "1":
                    Program.SøkBok();
                    break;
                case "2":
                    Program.LånBokFraMeny();
                    break;
                case "3":
                    Program.Returner();
                    break;
                case "4":
                    Program.RegistrerBok();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
