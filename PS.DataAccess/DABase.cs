using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace PS.DataAccess
{
    public class DABase
    {
        String connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        protected  SqlConnection connection;

        private Context _context;


        public DABase()
        {
            connection = new SqlConnection(connectionString);
        }
    }
}
