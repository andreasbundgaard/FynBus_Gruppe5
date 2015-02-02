using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FynBuuus
{
    class Firma
    {
        public string Navn { get; set; }
        public string CVRnr { get; set; }
        public string YderligOplys { get; set; }
        public string SekundFirma { get; set; }
        public List<Priser> Prisliste { get; set; }
        public List<Tilladelser> Tilladelsesliste { get; set; }
        public List<Vogne> Vognliste { get; set; }
        public void GetFullFirmaInfo(string CVRnr)
        {
            Firma fullFirma = new Firma();
            fullFirma = DB_Connection.GetFirmaPriser(CVRnr);
            fullFirma.Tilladelsesliste = DB_Connection.GetFirmaTilladelser(CVRnr).Tilladelsesliste;
        }
    }
}
