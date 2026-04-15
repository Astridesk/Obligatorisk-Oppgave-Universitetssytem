// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Obligatorisk_Oppgave_2;
using Obligatorisk_Oppgave_2.Menyer;

public class Program
{
    private static readonly List<Bruker> Brukere = new();
    private static readonly List<Student> Studenter = new();
    private static readonly List<Kurs> KursListe = new();
    private static readonly List<Bok> Bøker = new();
    public static Bibliotek bibliotek = new();

    private static void KjørMeny(Bruker innlogget)
    {
        MenyBase meny = innlogget.Rolle switch
        {
            Rolle.Student => new StudentMeny(),
            Rolle.Ansatt => new AnsattMeny(),
            Rolle.Bibliotekar => new BibliotekarMeny(),
            _ => null
        };

        if (meny == null)
        {
            Console.WriteLine("Ukjent rolle.");
            return;
        }

        bool kjører = true;
        while (kjører)
        {
            meny.Vis();
            Console.Write("Valg: ");
            string valg = Console.ReadLine();
            kjører = meny.BehandleValg(valg, innlogget);
        }
    }

    public static void Main(string[] args) 
    {
        TestData();

        Bruker innlogget = SpørOmLoggInn();
        if (innlogget == null)
        {
            Console.WriteLine("Avslutter.");
            return;
        }

        KjørMeny(innlogget);
    }

    private static void TestData()
    {
        // Eksempeldata
        var s = new Student("Ola Nordmann", "ola@uia.no", "ola", "passord", 123);
        Studenter.Add(s);
        Brukere.Add(s);

        //utvekslingsstudent
        var u = new UtvekslingsStudent("Itachi Uchiha", "itachi.uchiha@uia.no","itauchi","sasuke1", 54321, "University of Konohagakure", "Land of Fire", "høst 2026-vår2027");
        Studenter.Add(u);
        Brukere.Add(u);

        var ansatt = new Ansatt("Kinger", "kinger@uia.no", "kinger", "passord",
                                120, "Professor", "Institutt for informasjonssystemer");
        Brukere.Add(ansatt);

        var bib = new Bibliotekar("Bente", "bente@uia.no", "bente", "passord",
                                  200, "Bibliotekar", "Bibliotek");
        Brukere.Add(bib);

        Bøker.Add(new Bok(1, "1984", "George Orwell", 1949, 2));
        Bøker.Add(new Bok(2, "The Silmarillion", "J.R.R. Tolkien", 1977, 1));
    }

    private static Bruker SpørOmLoggInn()
    {
        while (true)
        {
            Console.WriteLine("Har du bruker?");
            Console.WriteLine("[1] Logg inn");
            Console.WriteLine("[2] Registrer ny");
            Console.WriteLine("[0] Avslutt");

            string valg = Console.ReadLine();

            switch (valg)
            {
                case "1":
                    return LoggInn();
                case "2":
                    return RegistrerNyBruker();
                case "0":
                    return null;
                default:
                    Console.WriteLine("Ugyldig valg.");
                    break;
            }
        }
    }

    private static Bruker LoggInn()
    {
        Console.Write("Brukernavn: ");
        string brukernavn = Console.ReadLine();
        Console.Write("Passord: ");
        string passord = Console.ReadLine();

        var bruker = Brukere.FirstOrDefault(b =>
            b.Brukernavn == brukernavn && b.Passord == passord);

        if (bruker == null)
        {
            Console.WriteLine("Feil brukernavn eller passord.");
            return null;
        }

        return bruker;
    }

    private static Bruker RegistrerNyBruker()
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

        Bruker ny = rolleValg switch
        {
            "1" => RegistrerStudent(brukernavn, passord),
            "2" => RegistrerAnsatt(brukernavn, passord),
            "3" => RegistrerBibliotekar(brukernavn, passord),
            _ => null
        };

        if (ny != null)
        {
            Brukere.Add(ny);
            if (ny is Student s) Studenter.Add(s);
            Console.WriteLine("Bruker registrert.");
        }

        return ny;
    }

    private static Student RegistrerStudent(string brukernavn, string passord)
    {
        Console.Write("Navn: ");
        string navn = Console.ReadLine();
        Console.Write("E-post: ");
        string epost = Console.ReadLine();
        Console.Write("StudentID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ugyldig ID.");
            return null;
        }

        return new Student(navn, epost, brukernavn, passord, id);
    }

    private static Ansatt RegistrerAnsatt(string brukernavn, string passord)
    {
        Console.Write("Navn: ");
        string navn = Console.ReadLine();
        Console.Write("E-post: ");
        string epost = Console.ReadLine();
        Console.Write("AnsattID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ugyldig ID.");
            return null;
        }
        Console.Write("Stilling: ");
        string stilling = Console.ReadLine();
        Console.Write("Avdeling: ");
        string avdeling = Console.ReadLine();

        return new Ansatt(navn, epost, brukernavn, passord, id, stilling, avdeling);
    }

    private static Bibliotekar RegistrerBibliotekar(string brukernavn, string passord)
    {
        Console.Write("Navn: ");
        string navn = Console.ReadLine();
        Console.Write("E-post: ");
        string epost = Console.ReadLine();
        Console.Write("AnsattID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ugyldig ID.");
            return null;
        }
        Console.Write("Stilling: ");
        string stilling = Console.ReadLine();
        Console.Write("Avdeling: ");
        string avdeling = Console.ReadLine();

        return new Bibliotekar(navn, epost, brukernavn, passord, id, stilling, avdeling);
    }

    public static void OpprettKurs()
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
        if (!int.TryParse(Console.ReadLine(), out int studiepoeng))
        {
            Console.WriteLine("Ugyldig tall.");
            return;
        }

        Console.Write("Maks plasser: ");
        if (!int.TryParse(Console.ReadLine(), out int maksAntallPlasser))
        {
            Console.WriteLine("Ugyldig tall.");
            return;
        }

        KursListe.Add(new Kurs(kurskode, kursnavn, studiepoeng, maksAntallPlasser));
        Console.WriteLine("Kurs opprettet.");
    }

    public static void MeldPåEllerAvStudent(Student student = null)
    {
        if (student == null)
        {
            Console.Write("StudentID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ugyldig ID.");
                return;
            }
            student = Studenter.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                Console.WriteLine("Fant ikke student.");
                return;
            }
        }

        Console.Write("Kurskode: ");
        string kode = Console.ReadLine();
        var kurs = KursListe.FirstOrDefault(k => k.KursKode == kode);
        if (kurs == null)
        {
            Console.WriteLine("Fant ikke kurs.");
            return;
        }

        Console.WriteLine("[1] Meld på  [2] Meld av");
        string valg = Console.ReadLine();

        if (valg == "1")
        {
            if (kurs.LeggTilStudent(student))
                Console.WriteLine("Student meldt på.");
            else
                Console.WriteLine("Kunne ikke melde på (fullt eller allerede påmeldt).");
        }
        else if (valg == "2")
        {
            if (kurs.MeldAvStudent(student))
                Console.WriteLine("Student meldt av.");
            else
                Console.WriteLine("Student var ikke påmeldt.");
        }
    }

    public static void LånBok(Bruker låner)
    {
        Console.Write("BokID: ");
        if (!int.TryParse(Console.ReadLine(), out int bokID))
        {
            Console.WriteLine("Ugyldig ID.");
            return;
        }

        var bok = Bøker.FirstOrDefault(b => b.BokID == bokID);
        if (bok == null)
        {
            Console.WriteLine("Fant ikke bok.");
            return;
        }

        if (bibliotek.LånUt(bok, låner))
            Console.WriteLine("Bok lånt ut.");
        else
            Console.WriteLine("Ingen eksemplarer tilgjengelig.");
    }

    public static void Returner(Bruker låner)
    {
        Console.Write("BokID: ");
        if (!int.TryParse(Console.ReadLine(), out int bokID))
        {
            Console.WriteLine("Ugyldig ID.");
            return;
        }

        var bok = Bøker.FirstOrDefault(b => b.BokID == bokID);
        if (bok == null)
        {
            Console.WriteLine("Fant ikke bok.");
            return;
        }

        if (bibliotek.Returner(bok, låner))
            Console.WriteLine("Bok returnert.");
        else
            Console.WriteLine("Fant ikke aktivt lån for denne boken og brukeren.");
    }
    public static void RegistrerPensum()
    {
        Kurs.RegistrerPensum(KursListe, Bøker);
    }

    public static void SettKarakter()
    {
        Kurs.SettKarakter(KursListe, Studenter);
    }

}
