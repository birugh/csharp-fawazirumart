using csharp_lksmart.Helpers;
using Dapper;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    internal class LogoutHelper
    {
        public static async Task LogoutAsync(Form currentForm, string username)
        {
            if (!(MessageBox.Show("Apakah anda yakin?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var logParam = new DynamicParameters();

            logParam.Add("waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
            logParam.Add("aktivitas_detail", "Username: "+ username + " telah logout", DbType.String, ParameterDirection.Input);
            logParam.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);

            var affected = await db.ExecuteAsyncSP(conn, "usp_logout_m_log", logParam);

            FormClosingHelper.FormChanging<FormLogin>(currentForm);
        }
    }
}