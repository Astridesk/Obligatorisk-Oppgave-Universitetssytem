using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    //Inneholder Kurs-klassen og defaultkurs.
    //
    public class Kurs
    {
        public string KursKode { get; set; }
        public string KursNavn { get; set; }
        public int Studiepoeng { get; set; }
        public int MaksAntallPlasser { get; set; }

        public List<Student> Studenter { get; private set; } = new();
        public List<Bok> Pensum { get; set; } = new();
        public Dictionary<Student, string> Karakterer { get; set; } = new();




        public Kurs(string kurskode, string kursnavn, int studiepoeng, int maksAntallPlasser)
        {
            KursKode = kurskode;
            KursNavn = kursnavn;
            Studiepoeng = studiepoeng;
            MaksAntallPlasser = maksAntallPlasser;

            // Studenter = new List<Student>();

        }

        public static List<Kurs> DefaultKurs()      //må ha antall ledige plasser
        {
            return new List<Kurs>
            {
                new Kurs("IS-110", "Objektorientert programmering", 10, 30),
                new Kurs("IS-105", "Datasystemer og systemarkitektur", 10, 30)
            };
        }



        public bool HarLedigPlass()
        {
            return Studenter.Count < MaksAntallPlasser;
        }

        public bool LeggTilStudent(Student student)
        {
            if (HarLedigPlass())
            {
                Studenter.Add(student);
                return true;
            }
            return false;
        }


    }
}
