using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FKelolaUser : Form
    {
        public FKelolaUser()
        {
            InitializeComponent();
            LoadUserData();
            UpdateDateTime();
        }
        private void LoadUserData()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnector.ConnectionString))
            {
                string query = "SELECT * FROM tbl_user";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void UpdateDateTime()
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnector.ConnectionString))
            {
                string query = "INSERT INTO tbl_user (tipe_user, nama, alamat, username, telepon, password, email) VALUES (@tipe_user, @nama, @alamat, @username, @telepon, @password, @email)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@tipe_user", txtTipeUser.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User added successfully!");
                LoadUserData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {

        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {

        }
    }
}
