using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Kurs           //Modellerer ett kurs. Har operasjoner for å melde på og av studenter, sjekke ledige plasser, og printe ut kursinformasjon.
    {
        public string KursKode { get; set; } = string.Empty;
        public string KursNavn { get; set; } = string.Empty;
        public int Studiepoeng { get; set; }
        public int MaksAntallPlasser { get; set; }

        List<Student> Studenter { get; set; }

        public Kurs(string kurskode, string kursnavn, int studiepoeng, int maksAntallPlasser)
        {
            KursKode = kurskode;
            KursNavn = kursnavn;
            Studiepoeng = studiepoeng;
            MaksAntallPlasser = maksAntallPlasser;

            Studenter = new List<Student>();
        }
        public bool LedigePlasser()
        {
            return Studenter.Count < MaksAntallPlasser;
        }

        public void MeldPåStudent(Student student)
        {
            if (LedigePlasser())
            {
                Studenter.Add(student);
                Console.WriteLine($"{student.Navn} er meldt på {KursNavn}");
            }
            else
            {
                Console.WriteLine("Kurset er fullt.");
            }
        }
        public void MeldAvStudent(Student student)
        {
            if (Studenter.Contains(student))
            {
                Studenter.Remove(student);
                Console.WriteLine($"{student.Navn} er meldt av {KursNavn}");
            }
        }
         
        public void PrintStudenter()
        {
            Console.WriteLine($"\nKurs: {KursKode} - {KursNavn}");

            foreach (var student in Studenter)
            {
                Console.WriteLine($"- {student.Navn}");
            }
        }


    }
}
