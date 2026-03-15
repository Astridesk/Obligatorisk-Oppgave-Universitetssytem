using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Bibliotek
    {
        List<Bok> Bøker = new List<Bok>();
        List<Bruker> Brukere = new List<Bruker>();
        List<BibliotekLån> LånListe = new List<BibliotekLån>();

        public void RegistrerBok(Bok bok)
        {
            Bøker.Add(bok);
            Console.WriteLine("Boken er registrert i biblioteket.");
        }

        public void RegistrerBruker(Bruker bruker)
        {
            Brukere.Add(bruker);
            Console.WriteLine("Brukeren er registrert i biblioteket.");
        }



        public void LånUtBok(Bok bok, Bruker bruker)       //Liten bok er et objekt?
        {
            if (!bok.Ledig())
            {
                Console.WriteLine("Boken er ikke tilgjengelig for utlån.");
            }
            else
            {
                bok.LånUt();

                BibliotekLån biblioteklån = new BibliotekLån(bok, bruker);

                Console.WriteLine("Boken er lånt ut.");
            }


        }

        public void LeverInnBok(Bok bok, BibliotekLån biblioteklån)
        {
            foreach (var lån in LånListe)
            {
                if (lån.Bok == bok && lån.ReturneringsDato == null)
                {
                    lån.ReturneringsDato = DateTime.Now;
                    bok.Returner();
                    Console.WriteLine("Boken er levert inn.");
                    return;
                }
            }
        }

        public void VisAktiveLån()
        {
            Console.WriteLine("Aktive lån:");
            foreach (var biblioteklån in LånListe)
            {
                if (biblioteklån.ReturneringsDato == null)
                {
                    Console.WriteLine($"Bok: {biblioteklån.Bok.Tittel}, Lånt av: {biblioteklån.bruker.Navn}, Lånedato: {biblioteklån.LåneDato}");
                }
            }
        }
        
        
    }
}
