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
using System.Configuration;

namespace csharp_lksmart
{
    public partial class FKelolaUser : Form
    {
        private static string conString = ConfigurationManager.AppSettings["connString"].ToString();
        private Timer timer;
        public FKelolaUser()
        {
            InitializeComponent();
            LoadUserData();
            InitializeTimer();

        }
        private void LoadUserData()
        {
            SqlConnection conn = new SqlConnection(conString);
            using (conn)
            {
                string query = "SELECT * FROM tbl_user";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }
        private void UpdateDateTime()
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTipeUser.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtAlamat.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }
            return true;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            SqlConnection conn = new SqlConnection(conString);
            using (conn)
            {
                string query = "INSERT INTO tbl_user VALUES (@tipe_user, @nama, @alamat, @username, @telepon, @password, @email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tipe_user", txtTipeUser.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User added successfully!");
                LoadUserData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput() || string.IsNullOrWhiteSpace(txtSearchId.Text))
            {
                return;
            }
            SqlConnection conn = new SqlConnection(conString);
            using (conn)
            {
                string query = "UPDATE tbl_user SET tipe_user=@tipe_user, nama=@nama, alamat=@alamat, username=@username, telepon=@telepon, password=@Password, email=@email WHERE id_user=@id_user";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", txtSearchId.Text);
                cmd.Parameters.AddWithValue("@tipe_user", txtTipeUser.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User updated successfully!");
                LoadUserData();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchId.Text))
            {
                MessageBox.Show("Please provide a valid user ID.");
                return;
            }
            SqlConnection conn = new SqlConnection(conString);
            using (conn)
            {
                string query = "DELETE FROM tbl_user WHERE id_user=@id_user";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", txtSearchId.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User deleted successfully!");
                LoadUserData();
            }
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.");
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            KelolaFormLaporan laporanForm = new KelolaFormLaporan();
            laporanForm.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FLog logForm = new FLog();
            logForm.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchId.Text))
            {
                MessageBox.Show("Please provide a valid user ID.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "SELECT * FROM tbl_user WHERE id_user=@id_user";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_user", txtSearchId.Text);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTipeUser.Text = reader["tipe_user"].ToString();
                    txtNama.Text = reader["nama"].ToString();
                    txtAlamat.Text = reader["alamat"].ToString();
                    txtUsername.Text = reader["username"].ToString();
                    txtTelepon.Text = reader["telepon"].ToString();
                    txtPassword.Text = reader["password"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtSearchId.Text = row.Cells["id_user"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
                txtTipeUser.Text = row.Cells["tipe_user"].Value.ToString();

            }
        }
        private void FKelolaUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
