using Dapper;
using System;
using System.Data;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FormLogin : Form
    {
        public static string userId;
        public static string userName;

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
        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var connString = GlobalConfig.getConn();
            var db = new DBHelpers();
            var p = new DynamicParameters();

            p.Add("@username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("@password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            var res = await db.ToSingleModelSP<MUser>(connString, "usp_auth_m_user", p);

            if (res == null && string.IsNullOrEmpty(res.username))
            {
                MessageBox.Show("Username atau password salah!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Login successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            switch (res.tipe_user.ToLower())
            {
                case "admin":
                    FormAdminKelolaUser formAdmin = new FormAdminKelolaUser();
                    formAdmin.Show();
                    break;

                case "gudang":
                    FormGudangBarang formGudang = new FormGudangBarang();
                    formGudang.Show();
                    break;

                case "kasir":
                    FormKasirTransaksi formKasir = new FormKasirTransaksi();
                    formKasir.Show();
                    break;
            }

            p = new DynamicParameters();
            p.Add("@waktu", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
            p.Add("@aktivitas", "Login", DbType.String, ParameterDirection.Input);
            p.Add("@id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            var affected = await db.ExecuteAsyncSP(connString, "usp_insert_m_log", p);
            this.Hide();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin keluar?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
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
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.Eye_Outline;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.Eye_Disable_Outline;
                txtPassword.PasswordChar = '*';
            }
        }
    }
}