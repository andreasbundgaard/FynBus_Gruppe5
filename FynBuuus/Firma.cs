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
        public List<Firma> GetFullFirmaInfo(string CVRnr)
        {
            List<Firma> fullList = new List<Firma>();
            fullList = DB_Connection.GetFirmaPriser(CVRnr);
            List<Firma> tempList = new List<Firma>();
            tempList = DB_Connection.GetFirmaTilladelser(CVRnr);
            for (int i = 0; i < fullList.Count; i++)
            {
                for (int j = 0; j < tempList.Count; j++)
                if (fullList[i].CVRnr == tempList[j].CVRnr)
                {
                    fullList[i].Tilladelsesliste = tempList[j].Tilladelsesliste;
                }
            }
            return fullList;
        }
    }
}
