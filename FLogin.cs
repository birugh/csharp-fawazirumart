using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace csharp_lksmart
{
    public partial class FormLogin : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn;
        private static SqlDataAdapter adp;
        private static SqlCommand cmd;
        private static DataTable dt;
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
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    query = "SELECT * FROM tbl_user WHERE username=@username AND password=@password";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    adp = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        id_user = dt.Rows[0]["id_user"].ToString();
                        string userType = dt.Rows[0]["tipe_user"].ToString();

                        MessageBox.Show("Login successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        switch (userType)
                        {
                            case "Admin":
                                FormAdminKelolaUser adminForm = new FormAdminKelolaUser();
                                adminForm.Show();
                                break;
                            case "Gudang":
                                FormGudangBarang gudangForm = new FormGudangBarang();
                                gudangForm.Show();
                                break;
                            case "Kasir":
                                FormKasirTransaksi transaksiForm = new FormKasirTransaksi();
                                transaksiForm.Show();
                                break;
                            default:
                                MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }

                        conn.Open();
                        query = "INSERT INTO tbl_log VALUES (@waktu, @aktivitas, @id_user)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@waktu", DateTime.Now);
                        cmd.Parameters.AddWithValue("@aktivitas", "Login");
                        cmd.Parameters.AddWithValue("@id_user", FormLogin.id_user);
                        cmd.ExecuteNonQuery();
                        ResetInput();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetInput();
                    }
                }
            }
            catch
            {
                return;
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
