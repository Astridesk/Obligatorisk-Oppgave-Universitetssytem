using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1.Menyer
{
    public class StudentMeny : MenyBase
    {
        public override void Vis()
        {   
            Console.WriteLine("\n--- Studentmeny ---");

            Console.WriteLine("[1] Søk på kurs");
            Console.WriteLine("[2] Meld deg på kurs");          //kan den melde seg av?
            Console.WriteLine("[3] Se oppmeldte kurs");
            Console.WriteLine("[4] Se karakterer");

            Console.WriteLine("[5] Søk på bok");
            Console.WriteLine("[6] Lån bok");
            Console.WriteLine("[7] Returner bok");

            Console.WriteLine("[0] Logg ut");
        }

        public override void BehandleValg(string valg)
        {
            case "1": Program.SøkKurs();
                break;
            case "2": Program.MeldPåEllerAvStudent();
                break;
            case "3": Program.SkrivUtKursOgStudentInfo();
                break;
            case "4": Console.WriteLine("Karakterfunksjon mangler.");
                break;
            case "5": Program.SøkBok();
                break;
            case "6": Program.LånBokFraMeny();
                break;
            case "7": Program.Returner();
                break;
            case "0": Environment.Exit(0);
                break;
            }
    }

    
}
