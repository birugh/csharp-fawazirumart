using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FormKasirTransaksi : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlDataAdapter adapter;
        private static DataTable dtKeranjang;
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static DataTable dt;
        private static string currentNoTransaksi;
        private static string query;
        private static decimal totalKeseluruhan;
        private static decimal uang;

        public FormKasirTransaksi()
        {
            InitializeComponent();
            LoadMenu();
            LoadPelanggan();
            InitializeKeranjang();
            GenerateNoTransaksi();
            ResetInput();
            cboxNamaPelanggan.SelectedIndex = -1;
            LoadKasir();
        }
        private void LoadKasir()
        {
            if (FormLogin.id_user == null || FormLogin.id_user == "")
            {
                labelKasir.Text = "Kasir ?";
            }
            else
            {
                labelKasir.Text = "Kasir " + FormLogin.id_user;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtQuantitas.Text) ||
                string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                cboxPilihMenu.SelectedIndex == -1 ||
                cboxNamaPelanggan.SelectedIndex == -1)
            {
                MessageBox.Show("All fields must be filled out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void LoadMenu()
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    query = "SELECT id_barang, nama_barang, harga_satuan FROM tbl_barang";
                    adapter = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    cboxPilihMenu.DataSource = dt;
                    cboxPilihMenu.DisplayMember = "nama_barang";
                    cboxPilihMenu.ValueMember = "id_barang";
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void LoadPelanggan()
        {
            using (conn = new SqlConnection(connString))
            {
                query = "SELECT id_pelanggan, nama FROM tbl_pelanggan";
                adapter = new SqlDataAdapter(query, conn);
                dt = new DataTable();
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
            dtKeranjang.Columns.Add("ID Barang");
            dtKeranjang.Columns.Add("Nama Barang");
            dtKeranjang.Columns.Add("Harga Satuan");
            dtKeranjang.Columns.Add("Qty");
            dtKeranjang.Columns.Add("Total Harga");
            dataGridViewKeranjang.DataSource = dtKeranjang;
        }

        private void GenerateNoTransaksi()
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    string datePart = DateTime.Now.ToString("yyyyMMdd");
                    query = "SELECT MAX(no_transaksi) FROM tbl_transaksi WHERE CONVERT(VARCHAR, tgl_transaksi, 112) = @datePart";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@datePart", datePart);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
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
            catch (Exception ex)
            {
                return;
            }
        }
        private void ResetInput()
        {
            cboxPilihMenu.SelectedIndex = -1;

            txtHargaSatuan.Clear();
            txtQuantitas.Clear();
            txtTotalHarga.Clear();
            txtUang.Clear();
            labelTotalKeseluruhan.Text = "Total Keseluruhan: Rp0";
            labelKembalian.Text = "Jumlah Kembalian: Rp0";
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (cboxPilihMenu.SelectedValue != null && int.TryParse(txtQuantitas.Text, out int qty) && decimal.TryParse(txtTotalHarga.Text, out decimal totalHarga))
            {
                DataRow row = dtKeranjang.NewRow();
                row["No Transaksi"] = currentNoTransaksi;
                row["ID Barang"] = cboxPilihMenu.SelectedValue;
                row["Nama Barang"] = cboxPilihMenu.Text;
                row["Harga Satuan"] = txtHargaSatuan.Text;
                row["Qty"] = txtQuantitas.Text;
                row["Total Harga"] = txtTotalHarga.Text;

                dtKeranjang.Rows.Add(row);
                MessageBox.Show("Item successfully added to cart", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInput();
                UpdateTotalKeseluruhan();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
            dtKeranjang.Clear();
            cboxNamaPelanggan.SelectedIndex = -1;
            txtTelepon.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (conn = new SqlConnection(connString))
                    {
                        query = "INSERT INTO tbl_log (waktu, aktivitas, id_user) VALUES (@Waktu, @Aktivitas, @IdUser)";
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
                    return;
                }

                FormLogin.id_user = null;
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            string defaultFileName = "ExportedDataKeranjang.pdf";

            if (dataGridViewKeranjang.Rows.Count > 0)
            {
                ExportGridToPdf(dataGridViewKeranjang, defaultFileName);
            }
            else
            {
                MessageBox.Show("Please input something to cart!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (dataGridViewKeranjang.Rows.Count > 0)
            {
                try
                {
                    using (conn = new SqlConnection(connString))
                    {
                        query = "INSERT INTO tbl_transaksi (no_transaksi, tgl_transaksi, nama_kasir, total_bayar, id_user, id_pelanggan, id_barang) VALUES (@no_transaksi, @tgl_transaksi, @nama_kasir, @total_bayar, @id_user, @id_pelanggan, @id_barang)";
                        conn.Open();
                        foreach (DataRow row in dtKeranjang.Rows)
                        {
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@no_transaksi", currentNoTransaksi);
                            cmd.Parameters.AddWithValue("@tgl_transaksi", DateTime.Now);
                            cmd.Parameters.AddWithValue("@nama_kasir", "Kasir "+FormLogin.id_user);
                            cmd.Parameters.AddWithValue("@total_bayar", row["Total Harga"]);
                            cmd.Parameters.AddWithValue("@id_user", FormLogin.id_user);
                            cmd.Parameters.AddWithValue("@id_pelanggan", cboxNamaPelanggan.SelectedValue);
                            cmd.Parameters.AddWithValue("@id_barang", row["ID Barang"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                    throw;
                }

                MessageBox.Show("Transaction saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnReset_Click(sender, e);
                GenerateNoTransaksi();
            }
            else
            {
                MessageBox.Show("Please input something to cart!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboxPilihMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPilihMenu.SelectedItem != null)
            {
                txtQuantitas.Enabled = true;
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
                        txtQuantitas_TextChanged(sender, e);
                        conn.Close();
                    }
                }
            }
            else
            {
                txtQuantitas.Enabled = false;
            }
        }

        private void txtQuantitas_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantitas.Text, out int qty) && decimal.TryParse(txtHargaSatuan.Text, out decimal hargaSatuan))
            {
                txtTotalHarga.Text = (qty * hargaSatuan).ToString();
            }
        }

        private void cboxNamaPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxNamaPelanggan.SelectedValue != null && cboxNamaPelanggan.SelectedValue is int)
            {
                string idPelanggan = cboxNamaPelanggan.SelectedValue.ToString();
                string query = "SELECT telepon FROM tbl_pelanggan WHERE id_pelanggan = @id_pelanggan";
                using (conn = new SqlConnection(connString))
                {
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_pelanggan", idPelanggan);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();
                    if (result != null)
                    {
                        txtTelepon.Text = result.ToString();
                    }
                }
            }
        }

        private void FormTransaksi_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtUang.Text, out uang))
            {
                if (uang >= totalKeseluruhan)
                {
                    decimal kembalian = uang - totalKeseluruhan;
                    labelKembalian.Text = "Jumlah Kembalian: Rp" + kembalian.ToString();
                    MessageBox.Show("Pembayaran berhasil!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Do you want to save it?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnSimpan_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Uang tidak cukup! \nUang anda: Rp" + uang.ToString() + "\nTotal Keseluruhan: Rp" + totalKeseluruhan.ToString());
                }
            }
            else
            {
                MessageBox.Show("Masukkan jumlah uang yang valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateTotalKeseluruhan()
        {
            totalKeseluruhan = dtKeranjang.AsEnumerable().Sum(r => Convert.ToDecimal(r["Total Harga"]));
            labelTotalKeseluruhan.Text = "Total Keseluruhan: Rp"+totalKeseluruhan.ToString();
        }

        public void ExportGridToPdf(DataGridView dgv, string filename)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Please input something to cart.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                iTextSharp.text.Font pdfFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                PdfPTable pdfTable = CreatePdfTable(dgv, pdfFont);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = filename;
                    saveFileDialog.DefaultExt = ".pdf";
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SavePdfToFile(saveFileDialog.FileName, pdfTable);
                        MessageBox.Show("File saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private PdfPTable CreatePdfTable(DataGridView dgv, iTextSharp.text.Font pdfFont)
        {
            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count)
            {
                DefaultCell = { Padding = 3, BorderWidth = 1 },
                WidthPercentage = 100,
                HorizontalAlignment = Element.ALIGN_LEFT
            };

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, pdfFont))
                {
                    BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240)
                };
                pdfTable.AddCell(headerCell);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value?.ToString() ?? "";
                        pdfTable.AddCell(new Phrase(cellValue, pdfFont));
                    }
                }
            }

            return pdfTable;
        }

        private void SavePdfToFile(string filePath, PdfPTable pdfTable)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDocument, stream);

                pdfDocument.Open();
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();
            }
        }

    }
}
