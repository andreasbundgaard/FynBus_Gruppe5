using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FynBuuus
{
    class Controller
    {
        SqlConnection myConnection = new SqlConnection("user id=ejl05_usr;" +
                                       "password=Baz1nga5;server=ealdb1.eal.local;" +
                                       "Trusted_Connection=yes;" +
                                       "database=EJL05_DB; " +
                                       "connection timeout=30");
    }
}
