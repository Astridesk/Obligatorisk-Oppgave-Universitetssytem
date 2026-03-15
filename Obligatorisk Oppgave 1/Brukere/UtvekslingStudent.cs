using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class UtvekslingsStudent : Student
    {
        public string HjemUniversitet { get; set; }
        public string HjemLand { get; set; }
        public string Periode { get; set; }

        public UtvekslingsStudent(string navn, string epost, int studentID, string hjemuniversitet, string hjemland, string periode) : base(navn, epost, studentID)
        {
            HjemUniversitet = hjemuniversitet;
            HjemLand = hjemland;
            Periode = periode;
        }
    }
}
