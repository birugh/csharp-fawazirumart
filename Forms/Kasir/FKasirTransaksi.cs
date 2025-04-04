using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using System.Text.RegularExpressions;
using Dapper;
using System.Threading.Tasks;
using System.Drawing;

namespace csharp_lksmart
{
    public partial class FormKasirTransaksi : Form
    {
        private DataTable dtKeranjang;
        private string currentNoTransaksi;
        private string namaPelanggan;
        private string noTelpPelanggan;
        private decimal totalKeseluruhan;
        private decimal pajak;
        private int idPelanggan;
        private int idBarang;

        public FormKasirTransaksi()
        {
            InitializeComponent();
            InitializeKeranjang();
            LoadMenu();
            LoadKasir();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtKuantitas.Text) ||
                string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                !long.TryParse(txtTelepon.Text, out long telepon) ||
                !int.TryParse(txtKuantitas.Text, out int qty) ||
                !txtTelepon.Text.StartsWith("08") ||
                !Regex.IsMatch(txtTelepon.Text, @"^\d+$") ||
                cboxPilihMenu.SelectedIndex == -1)
            {
                MessageBox.Show("All fields must be filled out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void LoadMenu()
        {
            var connString = GlobalConfig.GetConn();
            var db = new DBHelpers();
            var barang = await db.ToModelSP<MBarang>(connString, "usp_generate_no_transaksi_m_transaksi");
            cboxPilihMenu.DataSource = barang.ToList();
            cboxPilihMenu.ValueMember = "id_barang";
            cboxPilihMenu.DisplayMember = "nama_barang";
        }

        private void LoadKasir()
        {
            if (FormLogin.userId == null || FormLogin.userId == "")
            {
                labelKasir.Text = "Kasir: Tidak dikenali";
            }
            else
            {
                labelKasir.Text = "Kasir: " + FormLogin.userId + " - " + FormLogin.userName;
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

        private async Task<string> GenerateNoTransaksi()
        {
            var connString = GlobalConfig.GetConn();
            var db = new DBHelpers();
            return await db.ToSingleModelSP<string>(connString, "usp_generate_no_transaksi_m_transaksi", null);
        }

        private void ResetInput()
        {
            cboxPilihMenu.SelectedIndex = -1;
            txtHargaSatuan.Clear();
            txtKuantitas.Clear();
            txtTotalHarga.Clear();
            txtCash.Clear();
            dtKeranjang.Clear();
            labelTotalKeseluruhan.Text = "Total Keseluruhan: Rp?";
            labelJumlahKembalian.Text = "Jumlah Kembalian: Rp?";
        }

        private void ResetComponents()
        {
            btnTambah.Enabled = true;
            btnBayar.Enabled = false;
            btnSimpan.Enabled = false;
            btnPrint.Enabled = false;
            txtTelepon.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
            ResetComponents();
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            if (cboxPilihMenu.SelectedValue != null && int.TryParse(txtKuantitas.Text, out int qty) && decimal.TryParse(txtTotalHarga.Text, out decimal totalHarga))
            {
                DataRow row = dtKeranjang.NewRow();
                row["No Transaksi"] = currentNoTransaksi;
                row["ID Barang"] = cboxPilihMenu.SelectedValue;
                row["Nama Barang"] = cboxPilihMenu.Text;
                row["Harga Satuan"] = txtHargaSatuan.Text;
                row["Qty"] = txtKuantitas.Text;
                row["Total Harga"] = txtTotalHarga.Text;
                dtKeranjang.Rows.Add(row);

                snackBar.Show(this, "Barang berhasil di tambahkan!",
                Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                UpdateTotalKeseluruhan();
                ResetInput();
            }
        }


        private async void btnLogout_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Are you sure to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var p = new DynamicParameters();
            p.Add("@waktu", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
            p.Add("@aktivitas", "Logout", DbType.String, ParameterDirection.Input);
            p.Add("@id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            var affected = await db.ExecuteAsyncSP(conn, "usp_insert_m_log", p);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string defaultFileName = "ExportedDataKeranjang.pdf";

            if (dataGridViewKeranjang.Rows.Count > 0)
            {
                ExportGridToPdf(dataGridViewKeranjang, defaultFileName);
                snackBar.Show(this, "Data berhasil di print!",
                Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }
            else
            {
                MessageBox.Show("Please input something to cart!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!(dataGridViewKeranjang.Rows.Count > 0))
            {
                MessageBox.Show("Please input something to cart!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (currentNoTransaksi == null || currentNoTransaksi == "")
            {
                currentNoTransaksi = await GenerateNoTransaksi();
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var p = new DynamicParameters();

            p.Add("no_transaksi", currentNoTransaksi, DbType.String, ParameterDirection.Input);
            p.Add("tgl_transaksi", DateTime.Now, DbType.String, ParameterDirection.Input);
            p.Add("nama_kasir", FormLogin.userName, DbType.String, ParameterDirection.Input);
            p.Add("total_bayar", totalKeseluruhan, DbType.String, ParameterDirection.Input);
            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            p.Add("id_pelanggan", idPelanggan, DbType.String, ParameterDirection.Input);
            p.Add("id_barang", cboxPilihMenu.SelectedValue, DbType.String, ParameterDirection.Input);
            var res = await db.ExecuteAsync(conn, "INSERT INTO tbl_transaksi VALUES (@no_transaksi, @tgl_transaksi, @nama_kasir, @total_bayar, @id_user, @id_pelanggan, @id_barang)", p);

            if (!(res > 0))
            {
                snackBar.Show(this, "Data gagal di simpan!",
                Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error,
                3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return;
            }

            snackBar.Show(this, "Data berhasil di simpan!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
            3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            btnReset_Click(null, null);
        }

        private void cboxPilihMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPilihMenu.SelectedIndex > -1)
            {
                MBarang barang = (MBarang)cboxPilihMenu.SelectedItem;
                txtHargaSatuan.Text = barang.harga_satuan.ToString();
                txtQuantitas_TextChanged(null, null);
            }
        }

        private void txtQuantitas_TextChanged(object sender, EventArgs e)
        {
            long harga = 0;
            if (!long.TryParse(txtKuantitas.Text, out long qty) && !long.TryParse(txtHargaSatuan.Text, out harga))
            {
                MessageBox.Show("Masukkan nilai kuantitas yang valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qty <= 0)
            {
                MessageBox.Show("Kuantitas tidak boleh kurang dari 1!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKuantitas.Clear();
                txtKuantitas.Focus();
                return;
            }

            txtTotalHarga.Text = (qty * harga).ToString();
        }

        private void FormTransaksi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtCash.Text, out long uang))
            {
                MessageBox.Show("Masukkan jumlah uang yang valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            long kembalian = (long)(uang - totalKeseluruhan);
            if (!(uang >= totalKeseluruhan))
            {
                MessageBox.Show("Uang tidak cukup! \nUang anda: Rp" + uang.ToString() + "\nKurang: Rp." + kembalian +"\nTotal Keseluruhan: Rp" + totalKeseluruhan.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            labelJumlahKembalian.Text = "Jumlah Kembalian: Rp" + kembalian.ToString();
            snackBar.Show(this, "Pembayaran berhasil!",
            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
            3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            btnTambah.Enabled = false;
            btnBayar.Enabled = false;
            btnSimpan.Enabled = true;
            txtTelepon.Enabled = false;
            txtTelepon.Text = noTelpPelanggan;

            if (MessageBox.Show("Do you want to save it?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnSimpan_Click(sender, e);
                btnSimpan.Enabled = false;
            }
        }

        private void UpdateTotalKeseluruhan()
        {
            totalKeseluruhan = 0m;
            foreach (DataRow row in dtKeranjang.Rows)
            {
                totalKeseluruhan += Convert.ToDecimal(row["Total"]);
            }
            labelTotalKeseluruhan.Text = "Total Keseluruhan: Rp." + totalKeseluruhan.ToString();
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
            catch
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

        private async void txtTelepon_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(txtTelepon.Text, out long telepon) &&
                !txtTelepon.Text.StartsWith("08") &&
                !Regex.IsMatch(txtTelepon.Text, @"^\d+$"))
            {
                MessageBox.Show("Kolom telepon tidak valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var connString = GlobalConfig.GetConn();
            var db = new DBHelpers();
            var p = new DynamicParameters();
            p.Add("telepon", txtTelepon.Text + "%", DbType.String, ParameterDirection.Input);
            var res = await db.ToSingleModel<MPelanggan>(connString, "SELECT * FROM tbl_pelanggan WHERE telepon LIKE @telepon", p);

            if (res == null && string.IsNullOrWhiteSpace(res.nama))
            {
                txtNamaPelanggan.Clear();
                return;
            }

            txtNamaPelanggan.Text = res.nama;
            idPelanggan = res.id_pelanggan;
            namaPelanggan = res.nama;
            noTelpPelanggan = "0" + res.telepon;
        }
    }
}