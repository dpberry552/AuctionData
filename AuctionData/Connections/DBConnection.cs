using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AuctionData.Connections
{
    public static class DBConnection
    {
        public static IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString);
            return conn;
        }
    }
}
