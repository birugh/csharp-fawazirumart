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

namespace csharp_lksmart
{
    public partial class FormLogin : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public static string id_user;

        public FormLogin()
        {
            InitializeComponent();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }
            return true;
        }
        private void ResetInput()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbl_user WHERE email=@email AND password=@password";
            string queryLog = "INSERT INTO tbl_log VALUES (@waktu, @aktivitas, @id_user)";
            if (!ValidateInput()) return;
            connection = new SqlConnection(connString);
            try
            {
                using (connection)
                {
                    cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        id_user = dt.Rows[0]["id_user"].ToString();
                        string userType = dt.Rows[0]["tipe_user"].ToString();

                        MessageBox.Show("Login successful!"+id_user);

                        switch (userType)
                        {
                            case "Admin":
                                FKelolaUser adminForm = new FKelolaUser();
                                adminForm.Show();
                                break;
                            case "Gudang":
                                FGudang gudangForm = new FGudang();
                                gudangForm.Show();
                                break;
                            case "Kasir":
                                FTransaksi transaksiForm = new FTransaksi();
                                transaksiForm.Show();
                                break;
                            default:
                                MessageBox.Show("Unknown user type.");
                                break;
                        }

                        connection.Open();
                        cmd = new SqlCommand(queryLog, connection);
                        cmd.Parameters.AddWithValue("@waktu", DateTime.Now);
                        cmd.Parameters.AddWithValue("@aktivitas", "Login");
                        cmd.Parameters.AddWithValue("@id_user", FormLogin.id_user);
                        cmd.ExecuteNonQuery();
                        ResetInput();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email or Password is incorrect.");
                        ResetInput();
                    }
                }
            }
            catch (Exception) 
            {
                return;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
    }
}
