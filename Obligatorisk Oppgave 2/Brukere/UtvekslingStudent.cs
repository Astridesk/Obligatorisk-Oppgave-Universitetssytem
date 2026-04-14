using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_2
{
    public class UtvekslingsStudent : Student
    {
        public string HjemUniversitet { get; set; }
        public string HjemLand { get; set; }
        public string Periode { get; set; }        //(fra-til)


        public UtvekslingsStudent(string navn, string epost, int studentID, string hjemuniversitet, string hjemland, string periode) : base(navn, epost, studentID)     //public eller private?
        {
            HjemUniversitet = hjemuniversitet;
            HjemLand = hjemland;
            Periode = periode;
        }

        public static List<UtvekslingsStudent> DefaultUtvekslingsStudenter()
        {
            return new List<UtvekslingsStudent>
                {
                    new UtvekslingsStudent("Itachi Uchiha", "itachi.uchiha@uia.no", 54321, "University of Konohagakure", "Land of Fire", "høst 2026-vår2027")
                };
        }
    }
}
