using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;
using Dapper;
using System;
using System.Data;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FormLogin : Form
    {
        public static string userId = "ID tidak dikenali";
        public static string userName = "Username tidak dikenali";

        public FormLogin()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBoxHelper.ShowWarning("Kolom tidak boleh kosong!");
                return false;
            }
            return true;
        }

        private void ResetInput()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
            userId = "ID tidak dikenali";
            userName = "Username tidak dikenali";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var conn = GlobalConfig.GetConnection();
            var db = new DBHelpers();
            var p = new DynamicParameters();

            p.Add("@username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("@password", txtPassword.Text, DbType.String, ParameterDirection.Input);

            var res = await db.ToSingleModelSP<MUser>(conn, "usp_auth_m_user", p);

            if (res == null || string.IsNullOrWhiteSpace(res.username))
            {
                MessageBoxHelper.ShowWarning("Username atau password salah!");
                txtUsername.Focus();
                return;
            }

            Form targetForm = null;
            switch (res.tipe_user.ToLower())
            {
                case "admin":
                    targetForm = new FormAdminLogActivity();
                    break;

                case "gudang":
                    targetForm = new FormGudangBarang();
                    break;

                case "kasir":
                    targetForm = new FormKasirTransaksi();
                    break;
            }

            MessageBoxHelper.ShowInformation("Login berhasil!");
            targetForm.Show();

            userId = res.id_user.ToString();
            userName = res.username;

            p = new DynamicParameters();
            p.Add("waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
            p.Add("aktivitas", "Login", DbType.String, ParameterDirection.Input);
            p.Add("id_user", userId, DbType.String, ParameterDirection.Input);

            var affected = await db.ExecuteAsyncSP(conn, "usp_insert_m_log", p);

            this.Hide();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.icon_eye_disable_outline;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.icon_eye_outline_png;
                txtPassword.PasswordChar = '*';
            }
        }
    }
}