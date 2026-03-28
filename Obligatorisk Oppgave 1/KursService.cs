using Obligatorisk_Oppgave_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
//oppretter, melder på og av studenter til kurs, har en oversikt over kurs og studenter som er oppmeldt.

    public class KursService        
    {
        
        public static void OpprettKurs(List<Kurs> kurs)        
        {
            Console.Write("Kode: ");
            string kurskode = Console.ReadLine();

            Console.Write("Navn: ");
            string kursnavn = Console.ReadLine();

            Console.Write("Studiepoeng: ");
            int studiepoeng = int.Parse(Console.ReadLine());

            Console.Write("Maks plasser: ");
            int maksAntallPlasser = int.Parse(Console.ReadLine());

            kurs.Add(new Kurs(kurskode, kursnavn, studiepoeng, maksAntallPlasser));
        }

       


        public bool MeldPåEllerAvStudent(Student student, Kurs kurs, bool meldPå)
        {
            if (meldPå)
            {
                if (kurs.Studenter.Count >= kurs.MaksAntallPlasser)
                    return false;

                kurs.Studenter.Add(student);
                return true;
            }
            else
            {
                kurs.Studenter.Remove(student);
                return true;
            }
        }


        //print liste over kurs og studenter som er oppmeldt.

        public void SkrivUtKursOgStudentInfo(Kurs kurs)
        {
            Console.WriteLine($"Kurskode: {kurs.KursKode}, Kursnavn: {kurs.KursNavn}, Studiepoeng: {kurs.Studiepoeng}, Maks plasser: {kurs.MaksAntallPlasser}");
            Console.WriteLine("Oppmeldte studenter:");
            foreach (var student in kurs.Studenter)
            {
                Console.WriteLine($"Student ID: {student.StudentID}, Navn: {student.Navn}");
            }
        }


    }
}
