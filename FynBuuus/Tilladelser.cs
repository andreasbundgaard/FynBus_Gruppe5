using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FynBuuus
{
    class Tilladelser
    {
        public string TilladelsesNr { get; set; }
        public string TilladelseType { get; set; }
        public DateTime GyldigTil { get; set; }
        public string UdstedendeMyndighed { get; set; }
        public string RegNummer { get; set; }
        public DateTime DatoForKoretojsForsteReg { get; set; }
        public string BemaerkningerTilDoku { get; set; }
        public string KlarTilDrift { get; set; }
        public string TrafikSelskab { get; set; }
        public string FT_CVRnr { get; set; }
    }
}
