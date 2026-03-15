using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorisk_Oppgave_1
{
    public interface ILånerOgGirTilbake     //kan brukes igjen til utlån av film, spill osv. senere.
    {
        bool Ledig();
        void LånUt();
        void Returner();
    }
}
