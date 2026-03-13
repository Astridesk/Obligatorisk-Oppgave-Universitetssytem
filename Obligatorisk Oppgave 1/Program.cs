// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;

using System;

namespace Obligatorisk_Oppgave_1
{
    class Program                           //meny viser selv etter valg er tatt. Og går ikke å melde på student til kurs, eller søke etter bok. Må fikse det.
    {
        static void Main(string[] args)     //hva betyr args?
        {
            Bibliotek bibliotek = new Bibliotek();
            KursSystem kursSystem = new KursSystem();

            Meny meny = new Meny();

            bool kjører = true;

            while (kjører)
            {
                meny.VisMeny();

                string? valg = Console.ReadLine();      //hvorfor ? etter string?

                switch (valg)
                {
                    case "1":
                        Console.WriteLine("Opprett kurs");
                        break;

                    case "2":
                        Console.WriteLine("Meld student til kurs");
                        break;

                    case "3":
                        kursSystem.PrintKurs();
                        break;

                    case "5":
                        Console.WriteLine("Søk bok");
                        break;

                    case "6":
                        Console.WriteLine("Lån bok");
                        break;

                    case "7":
                        Console.WriteLine("Returner bok");
                        break;

                    case "8":
                        Console.WriteLine("Registrer bok");
                        break;

                    case "0":                       
                        kjører = false;
                        break;
                }
            }
        }
    }
}
