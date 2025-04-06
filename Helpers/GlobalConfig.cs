using System.Configuration;

namespace csharp_lksmart
{
    public class GlobalConfig
    {
        private static readonly string connString = ConfigurationManager.AppSettings["connString"].ToString();

        public static string GetConnection()
        {
            return connString;
        }
    }
}