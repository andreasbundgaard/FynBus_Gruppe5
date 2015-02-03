using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FynBuuus 
{
    class Controller 
    {
        public List<Firma> Firmaliste;
        public void FirmaPriserTilladelser(string CVRnr)
        {
            Firma firma = new Firma();
            Firmaliste = new List<Firma>(firma.GetFullFirmaInfo(CVRnr));
        }
    }
}
