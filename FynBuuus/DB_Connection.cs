using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        public void GetFirmaPriser(string CVRnr)
        {
            SqlConnection con = connectToSql();
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("GetFirmaPriser", con);
                sqlCmd.Parameters.Add(new SqlParameter("@CVRnr", CVRnr));
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                Firma firma = new Firma();
                while (reader.Read())
                {
                    Person Person = new Person();
                    Person.CPRNR = reader["P_CPRNR"].ToString();
                    Person.Name = reader["P_Name"].ToString();
                    PersonList.Add(Person);
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
        }
    }
}
