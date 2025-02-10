using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lksmart
{
    internal class DatabaseConnector
    {
        public static class DatabaseConfig
        {
            public static string ConnectionString { get; } = "Data Source=DESKTOP-GC4N26G\\SQLEXPRESS;Initial Catalog=db_lksmart;Integrated Security=True";
        }
    }
}
