using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    public class LoadDataHelper
    {
        public static async Task<IEnumerable<T>> LoadDataModelSP<T>(string storedProcedure)
        {
            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            return await db.ToModelSP<T>(conn, storedProcedure, null);
        }

        public static async Task<IEnumerable<T>> LoadDataModel<T>(string query)
        {
            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            return await db.ToModel<T>(conn, query, null);
        }
    }
}