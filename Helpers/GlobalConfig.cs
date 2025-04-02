using System.Configuration;

namespace csharp_lksmart
{
    public class GlobalConfig
    {
        public readonly static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        public static string GetConn()
        {
            return connString;
        }
    }
}
