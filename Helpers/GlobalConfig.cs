using System.Configuration;
using System.Data.SqlClient;

namespace csharp_lksmart
{
    public class GlobalConfig
    {
        private static readonly string connString = ConfigurationManager.AppSettings["connString"].ToString();

        public static string GetConnection()
        {
            return connString;
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connString);
        }
    }
}
