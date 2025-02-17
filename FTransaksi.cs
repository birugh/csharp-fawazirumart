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
    public partial class FTransaksi : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private DataTable dtKeranjang;
        private string currentNoTransaksi;
        public FTransaksi()
        {
            InitializeComponent();
            LoadMenu();
            LoadPelanggan();
            InitializeKeranjang();
            GenerateNoTransaksi();
        }
        private void LoadMenu()
        {
            string query = "SELECT id_barang, nama_barang, harga_satuan FROM tbl_barang";
            using (conn = new SqlConnection(connString))
            {
                adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboxPilihMenu.DataSource = dt;
                cboxPilihMenu.DisplayMember = "nama_barang";
                cboxPilihMenu.ValueMember = "id_barang";
            }
        }
        private void LoadPelanggan()
        {
            string query = "SELECT id_pelanggan, nama FROM tbl_pelanggan";
            using (conn = new SqlConnection(connString))
            {
                adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboxNamaPelanggan.DataSource = dt;
                cboxNamaPelanggan.DisplayMember = "nama";
                cboxNamaPelanggan.ValueMember = "id_pelanggan";
            }
        }
        private void InitializeKeranjang()
        {
            dtKeranjang = new DataTable();
            dtKeranjang.Columns.Add("No Transaksi");
            dtKeranjang.Columns.Add("Kode Barang");
            dtKeranjang.Columns.Add("Nama Barang");
            dtKeranjang.Columns.Add("Harga Satuan");
            dtKeranjang.Columns.Add("Qty");
            dtKeranjang.Columns.Add("Total Harga");
            dataGridViewKeranjang.DataSource = dtKeranjang;
        }

        private void GenerateNoTransaksi()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string query = "SELECT MAX(no_transaksi) FROM tbl_transaksi WHERE CONVERT(VARCHAR, tgl_transaksi, 112) = @datePart";
            using (conn = new SqlConnection(connString))
            {
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@datePart", datePart);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                if (result != DBNull.Value && result != null)
                {
                    string lastNoTransaksi = result.ToString();
                    int lastNumber = int.Parse(lastNoTransaksi.Substring(10));
                    currentNoTransaksi = "TR" + datePart + (lastNumber + 1).ToString("D3");
                }
                else
                {
                    currentNoTransaksi = "TR" + datePart + "001";
                }
            }
        }
        private void UpdateTotalKeseluruhan()
        {
            decimal totalKeseluruhan = dtKeranjang.AsEnumerable().Sum(r => Convert.ToDecimal(r["Total Harga"]));
            labelTotalKeseluruhan.Text = totalKeseluruhan.ToString();
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (cboxPilihMenu.SelectedValue != null && int.TryParse(txtQuantitas.Text, out int qty) && decimal.TryParse(txtTotalHarga.Text, out decimal totalHarga))
            {
                DataRow row = dtKeranjang.NewRow();
                row["No Transaksi"] = currentNoTransaksi;
                row["Kode Barang"] = cboxPilihMenu.SelectedValue;
                row["Nama Barang"] = cboxPilihMenu.Text;
                row["Harga Satuan"] = txtHargaSatuan.Text;
                row["Qty"] = txtQuantitas.Text;
                row["Total Harga"] = txtTotalHarga.Text;
                dtKeranjang.Rows.Add(row);

                UpdateTotalKeseluruhan();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtKeranjang.Clear();
            cboxPilihMenu.SelectedIndex = -1;
            cboxNamaPelanggan.SelectedIndex = -1;
            txtTelepon.Clear();
            txtHargaSatuan.Clear();
            txtQuantitas.Clear();
            txtTotalHarga.Clear();
            txtUang.Clear();
            labelTotalKeseluruhan.Text = "0";
            GenerateNoTransaksi();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "INSERT INTO tbl_log (waktu, aktivitas, id_user) VALUES (@Waktu, @Aktivitas, @IdUser)";
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    using (conn)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Waktu", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Aktivitas", "Logout");
                        cmd.Parameters.AddWithValue("@IdUser", FormLogin.id_user);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    throw;
                }

                FormLogin.id_user = null;

                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtUang.Text, out decimal uang) && decimal.TryParse(labelTotalKeseluruhan.Text, out decimal totalKeseluruhan))
            {
                if (uang >= totalKeseluruhan)
                {
                    decimal kembalian = uang - totalKeseluruhan;
                    labelKembalian.Text = kembalian.ToString();
                    MessageBox.Show("Pembayaran berhasil!");
                }
                else
                {
                    MessageBox.Show("Uang tidak cukup!");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tbl_transaksi (no_transaksi, tgl_transaksi, nama_kasir, total_bayar, id_user, id_pelanggan, id_barang) VALUES (@no_transaksi, @tgl_transaksi, @nama_kasir, @total_bayar, @id_user, @id_pelanggan, @id_barang)";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                foreach (DataRow row in dtKeranjang.Rows)
                {
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@no_transaksi", currentNoTransaksi);
                    cmd.Parameters.AddWithValue("@tgl_transaksi", DateTime.Now);
                    cmd.Parameters.AddWithValue("@nama_kasir", "Kasir 1");
                    cmd.Parameters.AddWithValue("@total_bayar", row["Total Harga"]);
                    cmd.Parameters.AddWithValue("@id_user", FormLogin.id_user);
                    cmd.Parameters.AddWithValue("@id_pelanggan", cboxNamaPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@id_barang", row["Kode Barang"]);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            btnReset_Click(sender, e);
        }

        private void cboxPilihMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPilihMenu.SelectedItem != null)
            {
                DataRowView selectedRow = cboxPilihMenu.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string idBarang = selectedRow["id_barang"].ToString();
                    string query = "SELECT harga_satuan FROM tbl_barang WHERE id_barang = @id_barang";
                    using (conn = new SqlConnection(connString))
                    {
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_barang", idBarang);
                        conn.Open();
                        txtHargaSatuan.Text = cmd.ExecuteScalar().ToString();
                        conn.Close();
                    }
                }
            }
        }

        private void txtQuantitas_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantitas.Text, out int qty) && decimal.TryParse(txtHargaSatuan.Text, out decimal hargaSatuan))
            {
                txtTotalHarga.Text = (qty * hargaSatuan).ToString();
            }
        }
    }
}
