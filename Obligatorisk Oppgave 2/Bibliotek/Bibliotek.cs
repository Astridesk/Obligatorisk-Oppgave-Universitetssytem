using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    //koble bok og bruker/Låner, utlån/innlevering, tilgjengelighet, og historikk

    public class Lån      //skal denne i en egen klasse? eller skal den være en del av biblioteket?
    {
        public Bruker Låner { get; set; }
        public Bok Bok { get; set; }
        public DateTime Lånedato { get; init; }
        public bool Returnert { get; set; }
        public DateTime? ReturDato { get; set; }
        public Lån(Bruker låner, Bok bok)
        {
            Låner = låner;
            Bok = bok;
            Lånedato = DateTime.Now;
            Returnert = false;
        }
    }

    public class Bibliotek

    {
        List<Bok> Bøker = new List<Bok>();
        List<Bruker> Lånere = new List<Bruker>();
        List<Lån> LånListe = new List<Lån>();


        public void RegistrerBok(Bok bok)
        {
            Bøker.Add(bok);
            Console.WriteLine("Boken er registrert i biblioteket.");
        }

        public void RegistrerLåner(Bruker bruker)
        {
            Lånere.Add(bruker);
            Console.WriteLine("Låneren er registrert i biblioteket.");
        }

        public void SøkBok(List<Bok> bøker)
        {
            Console.Write("Søk tittel: ");
            string søk = Console.ReadLine();

            var resultat = bøker
                .Where(b => b.Tittel.Contains(søk, StringComparison.OrdinalIgnoreCase));

            foreach (var bok in resultat)
            {
                Console.WriteLine($"{bok.Tittel} ({bok.Antall} stk)");
            }
        }

        public bool Ledig(Bok bok)
        {
            return bok.Antall > 0;

        }


        public void LånUt(Bok bok, Bruker låner)
        {
            if (Ledig(bok))
            {
                bok.Antall--;

                Lån nyttLån = new Lån(låner, bok);
                LånListe.Add(nyttLån);
            }
            else
            {
                Console.WriteLine("Boken er ikke tilgjengelig for utlån.");
            }

        }

        public void Returner(Bok bok)
        {
            bok.Antall++;
        }

        public string SkrivUtInfo(Bok bok)
        {
            return $"BokID: {bok.BokID} \nTittel: {bok.Tittel} \nForfatter: {bok.Forfatter} \nÅr: {bok.År} \nAntall Eksemplarer: {bok.Antall}";
        }

        public void VisAktiveLån()
        {
            foreach (var lån in LånListe)
            {
                if (!lån.Returnert)
                {
                    Console.WriteLine($"Låner: {lån.Låner.Navn}, Bok: {lån.Bok.Tittel}, Lånedato: {lån.Lånedato}");
                }
            }


        }


    }
}
