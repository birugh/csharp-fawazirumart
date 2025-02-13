using System;
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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) {}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT tipe_user FROM tbl_user WHERE email=@Email AND password=@Password";
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    connection.Open();
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string userType = result.ToString();
                        MessageBox.Show("Login successful!");

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

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email or Password is incorrect.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }
    }
}
