using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace FynBuuus {
    class DB_Connection {
        public static SqlConnection connectToSql(){
            SqlConnection con = new SqlConnection(
                "Server=ealdb1.eal.local;" +
                "Database=EJL05_DB;" +
                "User Id=ejl05_usr;" +
                "Password=Baz1nga5"
                );
            return con;
        }
        public static List<Firma> GetFirmaPriser(string CVRnr)
        {
            SqlConnection con = connectToSql();
            List<Firma> firmaprisListe = new List<Firma>();
            List<Priser> prisliste = new List<Priser>();
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("GetFirmaPriser", con);
                sqlCmd.Parameters.Add(new SqlParameter("@CVRnr", CVRnr));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    Priser priser = new Priser();
                    Firma firma = new Firma();
                    firma.CVRnr = reader["CVRnr"].ToString();
                    firma.Navn = reader["Navn"].ToString();
                    firma.YderligOplys = reader["YderligOplys"].ToString();
                    firma.SekundFirma = reader["SekunFirma"].ToString();
                    priser.CVRnr = reader["F_CVRnr"].ToString();
                    priser.SGebyrH = Convert.ToInt32(reader["OpstartsGebyrH"]);
                    priser.PrisVenteH = Convert.ToInt32(reader["TimeprisVentetidH"]);
                    priser.PrisKøreH = Convert.ToInt32(reader["TimepriskoretidH"]);
                    priser.SGebyrAN = Convert.ToInt32(reader["OpstartsGebyrAN"]);
                    priser.PrisVenteAN = Convert.ToInt32(reader["TimeprisVentetidAN"]);
                    priser.PrisKøreAN = Convert.ToInt32(reader["TimeprisKoretidAN"]);
                    priser.SGebyrWH = Convert.ToInt32(reader["OpstartsGebyrWH"]);
                    priser.PrisVenteWH = Convert.ToInt32(reader["TimeprisVentetidWH"]);
                    priser.PriserKøreWH = Convert.ToInt32(reader["TimeprisKoretidWH"]);
                    priser.TypeVogn = reader["Vogntype"].ToString();
                    prisliste.Add(priser);
                    firma.Prisliste = prisliste;
                    firmaprisListe.Add(firma);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return firmaprisListe;
        }
        public static List<Firma> GetFirmaTilladelser(string CVRnr)
        {
            SqlConnection con = connectToSql();
            List<Firma> firmaTillListe = new List<Firma>();
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("GetFirmaTilladelser", con);
                sqlCmd.Parameters.Add(new SqlParameter("@CVRnr", CVRnr));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                List<Tilladelser> tilladelsesliste = new List<Tilladelser>();
                while (reader.Read())
                {
                    Tilladelser tilladelse = new Tilladelser();
                    Firma firma = new Firma();
                    firma.CVRnr = reader["CVRnr"].ToString();
                    firma.Navn = reader["Navn"].ToString();
                    firma.YderligOplys = reader["YderligOplys"].ToString();
                    firma.SekundFirma = reader["SekunFirma"].ToString();
                    tilladelse.TilladelseType = reader["TilladelseType"].ToString();
                    tilladelse.TilladelsesNr = reader["TilladelsesNr"].ToString();
                    tilladelse.FT_CVRnr = reader["FT_CVRnr"].ToString(); //Navn skal sikkert ændres i databasen
                    tilladelse.UdstedendeMyndighed = reader["UdstedendeMyndighed"].ToString();
                    tilladelse.RegNummer = reader["RegNummer"].ToString();
                    tilladelse.BemaerkningerTilDoku = reader["BemaerkningerTilDoku"].ToString();
                    tilladelse.KlarTilDrift = reader["KlarTilDrift"].ToString();
                    tilladelse.TrafikSelskab = reader["TrafikSelskab"].ToString();
                    tilladelse.GyldigTil = Convert.ToDateTime(reader["GyldigTil"]);
                    tilladelse.DatoForKoretojsForsteReg = Convert.ToDateTime(reader["DatoForKoretojsForsteReg"]);
                    tilladelsesliste.Add(tilladelse);
                    firma.Tilladelsesliste = tilladelsesliste;
                    firmaTillListe.Add(firma);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return firmaTillListe;
        }
    }
}
