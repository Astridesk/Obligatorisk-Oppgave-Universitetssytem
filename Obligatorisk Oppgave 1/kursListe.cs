// See https://aka.ms/new-console-template for more information
namespace Obligatorisk_Oppgave_1
{
    internal class kursListe
    {
        public List<Kurs> KursListe { get; set; }

        public kursListe()
        {
            KursListe = new List<Kurs>
            {
                new Kurs("IS-110", "Objektorientert programmering", 10, 30),
                new Kurs("IS-105", "Datasystemer og systemarkitektur", 10, 30)
            };
        }
    }
}