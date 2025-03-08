using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lksmart
{
    public class GlobalConfig
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];
        
        public static string getConnection()
        {
            return connString;
        }
    }
}
