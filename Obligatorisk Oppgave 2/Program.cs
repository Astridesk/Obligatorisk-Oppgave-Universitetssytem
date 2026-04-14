// See https://aka.ms/new-console-template for more information
using Obligatorisk_Oppgave_2;
using Obligatorisk_Oppgave_2.Menyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

public class Program
{

    //legg inn alle lister som brukes av hele programmet her:
    static List<Kurs> KursListe = new List<Kurs>();
    static List<Student> Studenter = new();
    static Bibliotek bibliotek = new Bibliotek();
    static List<Bok> Bøker = Bok.DefaultBøker();
    static List<Bruker> Brukere = new();

    //enum BrukerType   //fjern siden den er i bruker?  //brukes for å skille mellom ulike typer brukere, og hvilken meny som skal vises.
    //{
    //    Student,
    //    Ansatt,
    //    Bibliotekar,
    //    Ingen
    //}


    static Bruker SpørOmLoggInn()
    {
        Console.WriteLine("Har du bruker?");
        Console.WriteLine("[1] Logg inn");
        Console.WriteLine("[2] Registrer ny");

        string valg = Console.ReadLine();

        if (valg == "1")
            return LoggInn();
        else if (valg == "2")
            return RegistrerNyBruker();

        Console.WriteLine("Ugyldig valg.");
        return null;
    }

    static Bruker LoggInn()
    {
        Console.Write("Brukernavn: ");
        string brukernavn = Console.ReadLine();
        Console.Write("Passord: ");
        string passord = Console.ReadLine();

        Bruker bruker = Brukere.FirstOrDefault(b =>
            b.Brukernavn == brukernavn && b.Passord == passord);

        if (bruker == null)
            Console.WriteLine("Feil brukernavn eller passord.");

        return bruker;
    }

    static Bruker RegistrerNyBruker()
    {
        Console.Write("Velg brukernavn: ");
        string brukernavn = Console.ReadLine();

        if (Brukere.Any(b => b.Brukernavn == brukernavn))
        {
            Console.WriteLine("Brukernavn er allerede i bruk.");
            return null;
        }

        Console.Write("Velg passord: ");
        string passord = Console.ReadLine();

        Console.WriteLine("Velg rolle: [1] Student [2] Faglærer [3] Bibliotekansatt");
        string rolleValg = Console.ReadLine();

        Rolle rolle = rolleValg switch
        {
            "1" => Rolle.Student,
            "2" => Rolle.Ansatt,
            "3" => Rolle.Bibliotekar,
            _ => Rolle.Student
        };

        var bruker = new Bruker { Brukernavn = brukernavn, Passord = passord, Rolle = rolle };
        Brukere.Add(bruker);
        Console.WriteLine("Bruker registrert.");
        return bruker;
    }



    private static void Main(string[] args)
    {



        //---------------Meny-------------------

        static void KjørMeny(Bruker innlogget)
        {
            bool kjører = true;

            while (kjører)
            {
                switch (innlogget.Rolle)
                {
                    case Rolle.Student:
                        VisStudentMeny();
                        BehandleStudentValg(innlogget);
                        break;

                    case Rolle.Ansatt:
                        VisAnsattMeny();
                        BehandleAnsattValg(innlogget);
                        break;

                    case Rolle.Bibliotekar:
                        VisBibliotekarMeny();
                        BehandleBibliotekarValg(innlogget);
                        break;
                    default:
                        throw new Exception("Ingen bruker innlogget.");
                }
            }
        }







        Studenter.Add(new Student("Ola", "ola@epost", "olabruker", 1, "tall"));







        //--------------------------------------
        //---------------KURS-------------------
        //--------------------------------------


        void OpprettKurs()
        {
            Console.Write("Kode: ");
            string kurskode = Console.ReadLine();
            if (KursListe.Any(k => k.KursKode == kurskode))
            {
                Console.WriteLine("Kurskode finnes allerede.");
                return;
            }

            Console.Write("Navn: ");
            string kursnavn = Console.ReadLine();
            if (KursListe.Any(k => k.KursNavn == kursnavn))
            {
                Console.WriteLine("Kursnavn finnes allerede.");
                return;
            }

            Console.Write("Studiepoeng: ");
            int studiepoeng = int.Parse(Console.ReadLine());

            Console.Write("Maks plasser: ");
            int maksAntallPlasser = int.Parse(Console.ReadLine());

            KursListe.Add(new Kurs(kurskode, kursnavn, studiepoeng, maksAntallPlasser));
        }

        static void RegistrerPensum()
        {
            Console.Write("Kurskode: ");
            string kode = Console.ReadLine();
            var kurs = KursListe.FirstOrDefault(k => k.KursKode == kode);
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            Console.Write("Bok ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bokID))
            {
                Console.WriteLine("Ugyldig bok ID.");
                return;
            }

            var bok = Bøker.FirstOrDefault(b => b.BokID == bokID);
            if (bok == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            if (!kurs.Pensum.Contains(bok))
                kurs.Pensum.Add(bok);

            Console.WriteLine("Bok lagt til som pensum.");
        }

        static void SettKarakter()
        {
            Console.Write("Kurskode: ");
            string kode = Console.ReadLine();
            var kurs = KursListe.FirstOrDefault(k => k.KursKode == kode);
            if (kurs == null) { Console.WriteLine("Fant ikke kurs."); return; }

            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentID))
            {
                Console.WriteLine("Ugyldig ID.");
                return;
            }

            var student = Studenter.FirstOrDefault(s => s.StudentID == studentID);
            if (student == null) { Console.WriteLine("Fant ikke student."); return; }

            Console.Write("Karakter: ");
            string karakter = Console.ReadLine();

            kurs.Karakterer[student] = karakter;
            Console.WriteLine("Karakter registrert.");
        }



        static void MeldPåEllerAvStudent()
        {

            Console.Write("Student ID: ");
            int studentID = int.Parse(Console.ReadLine());

            Console.Write("Kurs kode: ");
            string kurskode = Console.ReadLine();

            Student student = Studenter.FirstOrDefault(s => s.StudentID == studentID);
            Kurs kurs = KursListe.FirstOrDefault(k => k.KursKode == kurskode);

            if (student != null && kurs != null)
            {
                if (kurs.HarLedigPlass())
                {
                    kurs.LeggTilStudent(student);
                    //kurs.Studenter.Add(student);
                    Console.WriteLine("Student meldt på.");
                }
                else
                {
                    Console.WriteLine("Kurset er fullt.");
                }

            }
            if (kurs.Studenter.Contains(student))
            {
                Console.WriteLine("Student er allerede påmeldt dette kurset.");
                return;
            }

        }

        static void SkrivUtKursOgStudentInfo()
        {
            foreach (var kurs in KursListe)
            {
                Console.WriteLine(kurs.KursKode + " - " + kurs.KursNavn);

                foreach (var student in kurs.Studenter)
                {
                    Console.WriteLine(student.Navn);
                }
            }
        }

        static void SøkKurs()
        {
            Console.Write("Søk: ");
            string søk = Console.ReadLine();

            var resultat = KursListe
                .Where(k => k.KursKode.Contains(søk) || k.KursNavn.Contains(søk));

            foreach (var kurs in resultat)
            {
                Console.WriteLine(kurs.KursKode + " - " + kurs.KursNavn);
            }
        }


        //-------------------------------------------
        //-----------------BIBLIOTEK-----------------
        //-------------------------------------------


        void RegistrerBok()
        {
            Console.Write("ID: ");
            int bokID = int.Parse(Console.ReadLine());

            Console.Write("Tittel: ");
            string tittel = Console.ReadLine() ?? string.Empty;

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine() ?? string.Empty;

            Console.Write("År: ");
            int år = int.Parse(Console.ReadLine());

            Console.Write("Antall: ");
            int antall = int.Parse(Console.ReadLine());

            Bøker.Add(new Bok(bokID, tittel, forfatter, år, antall));
        }

        void SøkBok()
        {
            Console.Write("Søk tittel: ");
            string søk = Console.ReadLine();
            //SøkBok(søkBok);

            var resultat = Bøker.Where(b => b.Tittel.Contains(søk, StringComparison.OrdinalIgnoreCase));

            foreach (var bok in resultat)
            {
                Console.WriteLine($"{bok.Tittel} ({bok.Antall} stk)");
            }
        }

        void LånBok()           //må endres til alle brukere ikke bare student
        {

            Console.Write("Student ID: ");
            int studentID = int.Parse(Console.ReadLine());

            Console.Write("Bok ID: ");                      //både tittel og bokID burde kunne brukes for å søke opp
            int bokID = int.Parse(Console.ReadLine());


            Student student = Studenter.FirstOrDefault(s => s.StudentID == studentID);
            Bok bok = Bøker.FirstOrDefault(b => b.BokID == bokID);

            if (student == null)
            {
                Console.WriteLine("Fant ikke student.");
                return;
            }

            if (bok != null && bok.Antall > 0)
            {
                bibliotek.LånUt(bok, student);
                Console.WriteLine("Bok lånt ut.");
            }
            else
            {
                Console.WriteLine("Ingen eksemplarer tilgjengelig.");
            }

        }


        void Returner()
        {
            Console.Write("Bok ID: ");
            int bokID = int.Parse(Console.ReadLine());

            Bok bok = Bøker.FirstOrDefault(b => b.BokID == bokID);

            if (bok != null)
            {
                bibliotek.Returner(bok);
                Console.WriteLine("Bok returnert.");
            }
        }
    }
}