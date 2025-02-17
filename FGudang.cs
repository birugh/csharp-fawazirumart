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
    public partial class FormGudang : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        public FormGudang()
        {
            InitializeComponent();
            LoadBarangData();
            UpdateDateTime();
        }
        private void LoadBarangData()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "SELECT * FROM tbl_barang";
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
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtKodeBarang.Text) ||
                string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahBarang.Text) ||
                string.IsNullOrWhiteSpace(txtSatuan.Text) ||
                string.IsNullOrWhiteSpace(txtHargaSatuan.Text) ||
                dateExpiredDate.Value == null)
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }
            return true;
        }
        private void ResetInput()
        {
            txtKodeBarang.Text = "";
            txtNamaBarang.Text = "";
            txtJumlahBarang.Text = "";
            txtSatuan.Text = "";
            txtHargaSatuan.Text = "";
            dateExpiredDate.Value = DateTime.Now;
            txtSearch.Text = "";
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "INSERT INTO tbl_barang (kode_barang, nama_barang, jumlah_barang, satuan, expired_date, harga_satuan) VALUES (@kode_barang, @nama_barang, @jumlah_barang, @satuan, @expired_date, @harga_satuan)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@kode_barang", txtKodeBarang.Text);
                cmd.Parameters.AddWithValue("@nama_barang", txtNamaBarang.Text);
                cmd.Parameters.AddWithValue("@jumlah_barang", txtJumlahBarang.Text);
                cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text);
                cmd.Parameters.AddWithValue("@expired_date", dateExpiredDate.Value);
                cmd.Parameters.AddWithValue("@harga_satuan", txtHargaSatuan.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Barang added successfully!");
                LoadBarangData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput() || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please fill out all fields and provide a valid Search Id.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "UPDATE tbl_barang SET kode_barang=@kode_barang, nama_barang=@nama_barang, jumlah_barang=@jumlah_barang, satuan=@satuan, expired_date=@expired_date, harga_satuan=@harga_satuan WHERE id_barang=@id_barang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_barang", txtSearch.Text);
                cmd.Parameters.AddWithValue("@kode_barang", txtKodeBarang.Text);
                cmd.Parameters.AddWithValue("@nama_barang", txtNamaBarang.Text);
                cmd.Parameters.AddWithValue("@jumlah_barang", txtJumlahBarang.Text);
                cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text);
                cmd.Parameters.AddWithValue("@expired_date", dateExpiredDate.Value);
                cmd.Parameters.AddWithValue("@harga_satuan", txtHargaSatuan.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Barang updated successfully!");
                LoadBarangData();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please provide a valid Kode Barang.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "DELETE FROM tbl_barang WHERE id_barang=@id_barang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_barang", txtKodeBarang.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Barang deleted successfully!");
                LoadBarangData();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtKodeBarang.Text = row.Cells["kode_barang"].Value.ToString();
                txtNamaBarang.Text = row.Cells["nama_barang"].Value.ToString();
                txtJumlahBarang.Text = row.Cells["jumlah_barang"].Value.ToString();
                txtSatuan.Text = row.Cells["satuan"].Value.ToString();
                dateExpiredDate.Value = Convert.ToDateTime(row.Cells["expired_date"].Value);
                txtHargaSatuan.Text = row.Cells["harga_satuan"].Value.ToString();
                txtSearch.Text = row.Cells["id_barang"].Value.ToString();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please provide a valid Kode Barang.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                string query = "SELECT * FROM tbl_barang WHERE id_barang=@id_barang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_barang", txtSearch.Text);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtKodeBarang.Text = reader["kode_barang"].ToString();
                    txtNamaBarang.Text = reader["nama_barang"].ToString();
                    dateExpiredDate.Value = Convert.ToDateTime(reader["expired_date"]);
                    txtJumlahBarang.Text = reader["jumlah_barang"].ToString();
                    txtSatuan.Text = reader["satuan"].ToString();
                    txtHargaSatuan.Text = reader["harga_satuan"].ToString();
                }
                else
                {
                    MessageBox.Show("Barang not found.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
    }
}
