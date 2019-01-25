using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
    public class MSSQHelper : SQLHelper
    {
        public override IDbConnection GetDbConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["T4"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
