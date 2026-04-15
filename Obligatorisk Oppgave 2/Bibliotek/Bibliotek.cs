using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Obligatorisk_Oppgave_2
{

    public class Bibliotek
    {
        private readonly List<Bok> _bøker = new();
        private readonly List<Bruker> _lånere = new();
       


        public List<Lån> AktiveLån { get; } = new();
        public List<Lån> Historikk { get; } = new();

        public void RegistrerBok(Bok bok)
        {
            _bøker.Add(bok);
            Console.WriteLine("Boken er registrert i biblioteket.");
        }
        public List<Bok> HentBøker()
        {
            return _bøker;
        }

        // Brukes av menyen
        public void RegistrerBokFraMeny()
        {
            Console.Write("ID: ");
            int bokID = int.Parse(Console.ReadLine());

            Console.Write("Tittel: ");
            string tittel = Console.ReadLine();

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine();

            Console.Write("År: ");
            int år = int.Parse(Console.ReadLine());

            Console.Write("Antall: ");
            int antall = int.Parse(Console.ReadLine());

            var bok = new Bok(bokID, tittel, forfatter, år, antall);
            RegistrerBok(bok);
        }

        public void RegistrerLåner(Bruker bruker)
        {
            if (!_lånere.Contains(bruker))
                _lånere.Add(bruker);
        }

        public bool Ledig(Bok bok) => bok.Antall > 0;

        public bool LånUt(Bok bok, Bruker låner)
        {
            if (!Ledig(bok)) return false;

            bok.Antall--;
            var lån = new Lån(låner, bok);
            AktiveLån.Add(lån);
            return true;
        }

        public bool Returner(Bok bok, Bruker bruker)
        {
            var lån = AktiveLån
                .FirstOrDefault(l => l.Bok == bok && l.Låner == bruker && !l.Returnert);

            if (lån == null) return false;

            lån.Returnert = true;
            lån.ReturDato = DateTime.Now;
            AktiveLån.Remove(lån);
            Historikk.Add(lån);
            bok.Antall++;
            return true;
        }

        public void VisAktiveLån()
        {
            foreach (var lån in AktiveLån)
            {
                Console.WriteLine($"Låner: {lån.Låner.Navn}, Bok: {lån.Bok.Tittel}, Lånedato: {lån.LåneDato}");
            }
        }

        public void VisHistorikk()
        {
            foreach (var lån in Historikk)
            {
                Console.WriteLine($"Låner: {lån.Låner.Navn}, Bok: {lån.Bok.Tittel}, Lånedato: {lån.LåneDato}, Retur: {lån.ReturDato}");
            }
        }
        public void SøkBok()
        {
            Console.Write("Søk tittel: ");
            string søk = Console.ReadLine();
           

            var resultat = _bøker
                .Where(b => b.Tittel.Contains(søk, StringComparison.OrdinalIgnoreCase));

            foreach (var bok in resultat)
            {
                Console.WriteLine($"{bok.Tittel} ({bok.Antall} stk tilgjengelig)");
          }
        }

    }

}
