using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace csharp_lksmart
{
    public partial class FormLogin : Form
    {

        private static string query;
        public static string id_user;

        public FormLogin()
        {
            InitializeComponent();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            var connString = GlobalConfig.getConnection();
            var conn = new SqlConnection(connString);
            var db = new DBHelpers();
            var p = new DynamicParameters();

            if (!ValidateInput()) return;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                p.Add("@username", txtUsername.Text, DbType.String, ParameterDirection.Input);
                p.Add("@password", txtPassword.Text, DbType.String, ParameterDirection.Input);
                var res = await db.ToSingleModel<MUser>(connString, "usp_auth_m_user", p);
                if (res != null && !string.IsNullOrEmpty(res.username))
                {
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
                    p.Add("@id_user", FormLogin.id_user, DbType.String, ParameterDirection.Input);
                    var affected = await db.ExecuteAsyncSP(connString, "usp_insert_m_log", p);
                    this.Hide();
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetInput();
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
