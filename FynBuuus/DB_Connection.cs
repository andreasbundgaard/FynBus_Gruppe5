using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows

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
        public static Firma GetFirmaPriser(string CVRnr)
        {
            SqlConnection con = connectToSql();
            Firma firma = new Firma();
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("GetFirmaPriser", con);
                sqlCmd.Parameters.Add(new SqlParameter("@CVRnr", CVRnr));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                Priser priser = new Priser();
                List<Priser> prisliste = new List<Priser>();
                while (reader.Read())
                {

                    firma.CVRnr = reader["CVRnr"].ToString();
                    firma.Navn = reader["Navn"].ToString();
                    firma.YderligOplys = reader["YderligOplys"].ToString();
                    firma.SekundFirma = reader["SekunFirma"].ToString();
                    priser.SGebyrH = Convert.ToInt32(reader["OpstartsGebyrH"]);
                    priser.PrisVenteH = Convert.ToInt32(reader["TimeprisVentetidH"]);
                    priser.PrisKøreH = Convert.ToInt32(reader["TimepriskoretidH"]);
                    priser.SGebyrAN = Convert.ToInt32(reader["OpstartsGebyrAN"]);
                    priser.PrisVenteAN = Convert.ToInt32(reader["TimeprisVentetidAN"]);
                    priser.PrisKøreAN = Convert.ToInt32(reader["TimeprisKoretidAN"]);
                    priser.SGebyrWH = Convert.ToInt32(reader["OpstartsGebyrWH"]);
                    priser.PrisVenteWH = Convert.ToInt32(reader["TimeprisVentetidWH"]);
                    priser.PriserKøreWH = Convert.ToInt32(reader["TimeprisKoretidWH"]);
                    prisliste.Add(priser);
                    firma.Prisliste = prisliste;
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
            return firma;
        }
        public static Firma GetFirmaTilladelser(string CVRnr)
        {
            SqlConnection con = connectToSql();
            Firma firma = new Firma();
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("GetFirmaTilladelser", con);
                sqlCmd.Parameters.Add(new SqlParameter("@CVRnr", CVRnr));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                Tilladelser tilladelse = new Tilladelser();
                List<Tilladelser> tilladelsesliste = new List<Tilladelser>();
                while (reader.Read())
                {

                    firma.CVRnr = reader["CVRnr"].ToString();
                    firma.Navn = reader["Navn"].ToString();
                    firma.YderligOplys = reader["YderligOplys"].ToString();
                    firma.SekundFirma = reader["SekunFirma"].ToString();
                    tilladelse.TilladelsesType = Convert.ToInt32(reader["TilladelsesType"]);
                    tilladelse.TilladelsesNr = Convert.ToInt32(reader["TilladelseNr"]);
                    tilladelse.CVRnr = Convert.ToInt32(reader["CVRnr"]); //Navn skal sikkert ændres i databasen
                    tilladelse.UdstedendeMyndighed = Convert.ToInt32(reader["UdstedendeMyndighed"]);
                    tilladelse.RegNummer = Convert.ToInt32(reader["RegNummer"]);
                    tilladelse.BemærkningerTilDoku = Convert.ToInt32(reader["BemaerkningerTilDoku"]);
                    tilladelse.KlarTilDrift = Convert.ToInt32(reader["KlarTilDrift"]);
                    tilladelse.TrafikSelskab = Convert.ToInt32(reader["TrafikSelskab"]);
                    tilladelse.GyldigTil = Convert.ToDateTime(reader["GyldigTil"]);
                    tilladelse.DatoForKøretøjsFørsteReg = Convert.ToDateTime(reader["DatoForKoretojsForsteReg"])
                    tilladelsesliste.Add(tilladelse);
                    firma.Tilladelsesliste = tilladelsesliste;
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
            return firma;
        }
    }
}
