using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class Kurs           //Modellerer ett kurs. Har operasjoner for å melde på og av studenter, sjekke ledige plasser, og printe ut kursinformasjon.
    {
        public string KursKode { get; set; }
        public string KursNavn { get; set; }
        public int Studiepoeng { get; set; }
        public int MaksAntallPlasser { get; set; }
        static List<Kurs> KursListe { get; set; }

        public List<Student> Studenter { get; set; }

        public Kurs(string kurskode, string kursnavn, int studiepoeng, int maksAntallPlasser, List<Kurs> kursListe)
        {
            KursKode = kurskode;
            KursNavn = kursnavn;
            Studiepoeng = studiepoeng;
            MaksAntallPlasser = maksAntallPlasser;
            Studenter = new List<Student>();
            
        }

        public Kurs(string? kurskode, string? kursnavn, int studiepoeng, int maksAntallPlasser)
        {
            KursKode = kurskode;
            KursNavn = kursnavn;
            Studiepoeng = studiepoeng;
            MaksAntallPlasser = maksAntallPlasser;
        }

        static void OpprettKurs()
        {
            Console.Write("Kode: ");
            string kurskode = Console.ReadLine();

            Console.Write("Navn: ");
            string kursnavn = Console.ReadLine();

            Console.Write("Studiepoeng: ");
            int studiepoeng = int.Parse(Console.ReadLine());

            Console.Write("Maks plasser: ");
            int maksAntallPlasser = int.Parse(Console.ReadLine());

            KursListe.Add(new Kurs(kurskode, kursnavn, studiepoeng, maksAntallPlasser));
        }


        public bool MeldPåStudent(Student student)
        {
            if (Studenter.Count >= MaksAntallPlasser)
                return false;
            

            Studenter.Add(student);
            student.KursListe.Add(this);
            return true;                
         
        }
        public void MeldAvStudent(Student student)
        {    
            Studenter.Remove(student);
            student.KursListe.Remove(this);
           
        }


    }
}
