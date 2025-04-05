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
        private bool isFormOpened = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Semua kolom harus diisi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            userName = "Unknown Username";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var connString = GlobalConfig.GetConn();
            var db = new DBHelpers();
            var p = new DynamicParameters();

            p.Add("@username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("@password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            var res = await db.ToSingleModelSP<MUser>(connString, "usp_auth_m_user", p);

            if (res == null || string.IsNullOrWhiteSpace(res.username))
            {
                MessageBox.Show("Username atau password salah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }

            if (isFormOpened)
                return;

            Form targetForm = null;
            switch (res.tipe_user.ToLower())
            {
                case "admin":
                    targetForm = new FormAdminKelolaUser();
                    break;

                case "gudang":
                    targetForm = new FormGudangBarang();
                    break;

                case "kasir":
                    targetForm = new FormKasirTransaksi();
                    break;
            }

            MessageBox.Show("Login successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            userId = res.id_user.ToString();
            userName = res.username;

            isFormOpened = true;

            targetForm.FormClosed += async delegate
            {
                var logoutParams = new DynamicParameters();
                logoutParams.Add("@waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
                logoutParams.Add("@aktivitas", "Logout", DbType.String, ParameterDirection.Input);
                logoutParams.Add("@id_user", userId, DbType.String, ParameterDirection.Input);
                await db.ExecuteAsyncSP(connString, "usp_insert_m_log", logoutParams);

                isFormOpened = false;
                this.Show();
            };

            var logParams = new DynamicParameters();
            logParams.Add("@waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
            logParams.Add("@aktivitas", "Login", DbType.String, ParameterDirection.Input);
            logParams.Add("@id_user", userId, DbType.String, ParameterDirection.Input);
            await db.ExecuteAsyncSP(connString, "usp_insert_m_log", logParams);

            this.Hide();
            targetForm.Show();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin keluar?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
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