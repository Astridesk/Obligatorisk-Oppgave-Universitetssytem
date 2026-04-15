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
            Console.WriteLine("[3] Meld student på/av kurs");
            Console.WriteLine("[4] Print kurs og deltagere");
            Console.WriteLine("[5] Sett karakter");
            Console.WriteLine("[6] Registrer pensum");

            Console.WriteLine("[7] Søk på bok");
            Console.WriteLine("[8] Lån bok");
            Console.WriteLine("[9] Returner bok");

            Console.WriteLine("[0] Logg ut");

        }

        public override bool BehandleValg(string valg, Bruker innlogget)
        {
            switch (valg)
            {
                case "1":
                    Program.OpprettKurs();
                    break;
                case "2":
                    Kurs.SøkKurs();
                    break;
                case "3":
                    Program.MeldPåEllerAvStudent();
                    break;
                case "4":
                    Kurs.SkrivUtKursOgStudentInfo();
                    break;
                case "5":
                    Program.SettKarakter();
                    break;
                case "6":
                    Program.RegistrerPensum();
                    break;
                case "7":
                    Program.bibliotek.SøkBok();
                    break;
                case "8":
                    Program.LånBok(innlogget);
                    break;
                case "9":
                    Program.Returner(innlogget);
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Ugyldig valg.");
                    break;
            }
            return true;
        }

        

    }
}
