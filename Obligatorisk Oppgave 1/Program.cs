// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

using Obligatorisk_Oppgave_1;

internal class Program
{
    private static void Main(string[] args)
    {
        UniversitetSystem system = new UniversitetSystem();

        Meny meny = new Meny();

        bool kjører = true;

        while (kjører)
        {
            meny.VisMeny();

            string valg = Console.ReadLine();

            switch (valg)
            {
                case "1":
                    OpprettKurs(system);
                    break;

                case "2":
                    MeldPåStudent(system);
                    break;

                case "3":
                    PrintKurs(system);
                    break;

                case "4":
                    SøkKurs(system);
                    break;

                case "5":
                    SøkBok(system);
                    break;

                case "6":
                    LånBok(system);
                    break;

                case "7":
                    ReturnerBok(system);
                    break;

                case "8":
                    RegistrerBok(system);
                    break;

                case "0":
                    return;
            }
        }

        void OpprettKurs(UniversitetSystem system)
        {
            Console.Write("Kode: ");
            string kurskode = Console.ReadLine();

            Console.Write("Navn: ");
            string kursnavn = Console.ReadLine();

            Console.Write("Studiepoeng: ");
            int studiepoeng = int.Parse(Console.ReadLine());

            Console.Write("Maks plasser: ");
            int maksAntallPlasser = int.Parse(Console.ReadLine());

            system.KursListePublic.Add(new Kurs(kurskode, kursnavn, studiepoeng, maksAntallPlasser));
        }

        void MeldPåStudent(UniversitetSystem system)
        {
            Console.Write("Student ID: ");
            int studentID = int.Parse(Console.ReadLine());

            Console.Write("Kurs kode: ");
            string kurskode = Console.ReadLine();

            Student student = system.Studenter.FirstOrDefault(s => s.StudentID == studentID);
            Kurs kurs = UniversitetSystem.KursListe.FirstOrDefault(k => k.KursKode == kurskode);

            if (student != null && kurs != null)
            {
                bool ok = kurs.MeldPåStudent(student);

                if (ok)
                    Console.WriteLine("Student meldt på kurs.");
                else
                    Console.WriteLine("Kurset er fullt.");
            }
        }

        void PrintKurs(UniversitetSystem system)
        {
            foreach (var kurs in UniversitetSystem.KursListe)
            {
                Console.WriteLine(kurs.KursKode + " - " + kurs.KursNavn);

                foreach (var student in kurs.Studenter)
                {
                    Console.WriteLine("  " + student.Navn);
                }
            }
        }

        void SøkKurs(UniversitetSystem system)
        {
            Console.Write("Søk: ");
            string søk = Console.ReadLine();

            var resultat = UniversitetSystem.KursListe
                .Where(k => k.KursKode.Contains(søk) || k.KursNavn.Contains(søk));

            foreach (var kurs in resultat)
            {
                Console.WriteLine(kurs.KursKode + " - " + kurs.KursNavn);
            }
        }

        void RegistrerBok(UniversitetSystem system)
        {
            Console.Write("ID: ");
            int bokID = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Tittel: ");
            string tittel = Console.ReadLine() ?? string.Empty;

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine() ?? string.Empty;

            Console.Write("År: ");
            int år = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Antall: ");
            int antall = int.Parse(Console.ReadLine() ?? "0");

            system.Boker.Add(new Bok(bokID, tittel, forfatter, år, antall));
        }

        void SøkBok(UniversitetSystem system)
        {
            Console.Write("Søk tittel: ");
            string søk = Console.ReadLine();

            var resultat = system.Boker.Where(b => b.Tittel.Contains(søk));

            foreach (var bok in resultat)
            {
                Console.WriteLine(bok);
            }
        }

        void LånBok(UniversitetSystem system)
        {
            Console.Write("Bok ID: ");
            int bokID = int.Parse(Console.ReadLine());

            Bok bok = system.Boker.FirstOrDefault(b => b.BokID == bokID);

            if (bok != null && bok.Antall > 0)
            {
                Bruker bruker = system.Studenter.First();

                BibliotekLån lån = new BibliotekLån(bok, bruker);
                lån.LånUt();
                HentLånListe(system).Add(lån);

                Console.WriteLine("Bok lånt ut.");
            }
            else
            {
                Console.WriteLine("Ingen eksemplarer tilgjengelig.");
            }
        }

        void ReturnerBok(UniversitetSystem system)
        {
            Console.Write("Bok ID: ");
            int bokID = int.Parse(Console.ReadLine());

            var lån = system.LånListePublic
                .FirstOrDefault(l => l.Bok.BokID == bokID && !l.Returnert);

            if (lån != null)
            {
                lån.Returner();
                Console.WriteLine("Bok returnert.");
            }
        }
    }

    private static List<BibliotekLån> HentLånListe(UniversitetSystem system)
    {
        return system.LånListePublic;
    }
}