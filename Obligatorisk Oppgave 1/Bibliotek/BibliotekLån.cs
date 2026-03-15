using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public class BibliotekLån : ILånerOgGirTilbake
    {
        public Bok Bok { get; set; }
        public Bruker Bruker { get; }
        public Bruker bruker { get; set; }
        public DateTime LåneDato { get; set; }
        public bool Returnert { get; set; }
        public object ReturneringsDato { get; internal set; }

        public BibliotekLån(Bok bok, Bruker bruker)
        {
            Bok = bok;
            Bruker = bruker;
            LåneDato = DateTime.Now;   
            Returnert = false;
        }


        public bool Ledig()
        {
            return Bok.Antall > 0;
        }

        public void LånUt()
        {
            if (Ledig())
            {
                Bok.Antall--;
            }

        }

        public void Returner()
        {
            Bok.Antall++;
            Returnert = true;
        }
      
    }
}
