using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusanBigbikeShop
{
    public class DBConnection
    {
        public static string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SusanBigBikeShop;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}