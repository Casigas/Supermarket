using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SupermarketMVP.Models.DataAccesLayer
{

    public class ConnectionSQL
    {
        // private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;
        private static readonly string connectionString = "Server= DESKTOP-MO84SP5; Database= dbSupermarket;User ID=sa1;Password=Admin123";

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
