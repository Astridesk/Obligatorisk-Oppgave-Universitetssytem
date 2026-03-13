using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorisk_Oppgave_1
{
    public class KursSystem
    {
        private List<Kurs> KursListe { get; set; }

        public KursSystem()         //fungerer som et register for kursene, og inneholder metoder for å legge til kurs, finne kurs, melde på og av studenter, og printe ut kursinformasjon.
        {
            KursListe = new List<Kurs>
            {
                new Kurs("IS-110", "Objektorientert programmering", 10, 30),
                new Kurs("IS-105", "Datasystemer og systemarkitektur", 10, 30)
            };
        }

        public void LeggTilKurs(Kurs kurs)
        {
            if (kurs == null) throw new ArgumentNullException(nameof(kurs));

            if (KursListe.Any(k => k.KursKode.Equals(kurs.KursKode, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Et kurs med samme kode finnes allerede.");
                return;
            }

            KursListe.Add(kurs);
        }

        public Kurs? FinnKurs(string kurskode)
        {
            if (string.IsNullOrWhiteSpace(kurskode)) return null;
            return KursListe.FirstOrDefault(k => k.KursKode.Equals(kurskode, StringComparison.OrdinalIgnoreCase));
        }

        public bool MeldPåStudent(string kurskode, Student student)
        {
            var kurs = FinnKurs(kurskode);
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurset.");
                return false;
            }

            if (!kurs.LedigePlasser())
            {
                Console.WriteLine("Kurset er fullt.");
                return false;
            }

            kurs.MeldPåStudent(student);
            return true;
        }

        public bool MeldAvStudent(string kurskode, Student student)
        {
            var kurs = FinnKurs(kurskode);
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurset.");
                return false;
            }

            kurs.MeldAvStudent(student);
            return true;
        }

        public void PrintKurs()
        {
            if (!KursListe.Any())
            {
                Console.WriteLine("Ingen kurs registrert.");
                return;
            }

            foreach (var kurs in KursListe.OrderBy(k => k.KursKode))
            {
                Console.WriteLine($"{kurs.KursKode} - {kurs.KursNavn} ({kurs.Studiepoeng} stp) - Maks: {kurs.MaksAntallPlasser}");
                kurs.PrintStudenter();
            }
        }
    }
}