using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FynBuuus
{
    class Vogne
    {
        public string HjemVej { get; set; }

        public string HjemVejNummer { get; set; }

        public string HjemPostNummer { get; set; }

        public string HjemBy { get; set; }

        public string HjemKommune { get; set; }

        public string KommuTilPlanet_tlf { get; set; }

        public string RegNummer { get; set; }

        public string FV_CVRnr { get; set; }

        public string BS_Vogntype { get; set; }

        public List<string> Stole { get; set; }
    }
}
