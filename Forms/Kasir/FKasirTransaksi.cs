using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Dapper;
using System.Threading.Tasks;
using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;

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
                MessageBoxHelper.ShowWarning("Semua kolom harus diisi!");
                return false;
            }
            return true;
        }

        private async void LoadMenu()
        {
            var barang = await LoadDataHelper.LoadDataModelSP<MBarang>("usp_m_barang");
            cboxPilihMenu.DataSource = barang.ToList();
            cboxPilihMenu.ValueMember = "id_barang";
            cboxPilihMenu.DisplayMember = "nama_barang";
        }

        private void LoadKasir()
        {
            if (string.IsNullOrWhiteSpace(FormLogin.userId))
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
            var conn = GlobalConfig.GetConnection();
            var db = new DBHelpers();
            return await db.ToSingleModelSP<string>(conn, "usp_generate_no_transaksi", null);
        }

        private void ResetAll()
        {
            ClearInput();
            ResetComponents();
            dtKeranjang.Clear();
            txtNamaPelanggan.Clear();
            txtTelepon.Enabled = true;
            txtTelepon.Text = "08";
            labelStok.Text = "Stok tersedia: ?";
        }

        private void ClearInput()
        {
            cboxPilihMenu.SelectedIndex = -1;
            txtHargaSatuan.Clear();
            txtKuantitas.Clear();
            txtTotalHarga.Clear();
            txtCash.Clear();
        }

        private void ResetComponents()
        {
            labelTotalKeseluruhan.Text = "Total Keseluruhan: Rp?";
            labelJumlahKembalian.Text = "Jumlah Kembalian: Rp?";
            btnBayar.Enabled = false;
            txtCash.Enabled = false;
            btnTambah.Enabled = true;
            btnSimpan.Enabled = false;
            btnPrint.Enabled = false;
            txtKuantitas.Enabled = false;
            cboxPilihMenu.Enabled = true;
            txtCash.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
            ClearInput();
            ResetComponents();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (string.IsNullOrWhiteSpace(currentNoTransaksi))
            {
                currentNoTransaksi = await GenerateNoTransaksi();
            }

            MBarang barang = (MBarang)cboxPilihMenu.SelectedItem;
            if (barang.jumlah_barang <= 0)
            {
                MessageBoxHelper.ShowWarning("Stok barang tidak tersedia!");
                return;
            }

            DataRow row = dtKeranjang.NewRow();
            row["No Transaksi"] = currentNoTransaksi;
            row["ID Barang"] = cboxPilihMenu.SelectedValue;
            row["Nama Barang"] = cboxPilihMenu.Text;
            row["Harga Satuan"] = txtHargaSatuan.Text;
            row["Qty"] = txtKuantitas.Text;
            row["Total Harga"] = txtTotalHarga.Text;
            dtKeranjang.Rows.Add(row);

            SnackBarHelper.ShowSuccessInformation(this, "Barang berhasil di tambahkan!");

            UpdateTotalKeseluruhan();

            labelStok.Text = "Stok Tersedia: ?";
            txtCash.Enabled = true;
            btnBayar.Enabled = true;
            btnSimpan.Enabled = false;
            btnPrint.Enabled = false;

            ClearInput();
            LockPelangganData();
        }

        private void LockPelangganData()
        {
            txtTelepon.Enabled = false;
            txtTelepon.Text = noTelpPelanggan;
            txtNamaPelanggan.Text = namaPelanggan;
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this, FormLogin.userName);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            const string defaultFileName = "ExportedDataKeranjang.pdf";

            if (!(dataGridViewKeranjang.Rows.Count > 0) || dataGridViewKeranjang == null)
            {
                MessageBoxHelper.ShowWarning("Masukan suatu produk ke dalam keranjang!");
                return;
            }

            ExportGridToPdf(dataGridViewKeranjang, defaultFileName);

            SnackBarHelper.ShowSuccessInformation(this, "Data berhasil di print!");

            btnPrint.Enabled = false;
            this.AcceptButton = btnReset;
        }

        public void ExportGridToPdf(DataGridView dgv, string filename)
        {
            try
            {
                string fontPath = Path.Combine(Application.StartupPath, "Poppins-Regular.ttf");
                string fontPathBold = Path.Combine(Application.StartupPath, "Poppins-Bold.ttf");
                string fontPathSemiBold = Path.Combine(Application.StartupPath, "Poppins-SemiBold.ttf");

                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                BaseFont baseFontBold = BaseFont.CreateFont(fontPathBold, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                BaseFont baseFontSemiBold = BaseFont.CreateFont(fontPathSemiBold, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                Font fontH1 = new Font(baseFontBold, 20);
                Font fontH2 = new Font(baseFont, 16);
                Font fontSemiBoldH2 = new Font(baseFontSemiBold, 16);
                Font fontH3 = new Font(baseFont, 14);
                Font fontText = new Font(baseFont, 12);

                PdfPTable pdfTable = CreatePdfTable(dgv, fontText);

                using (FileStream stream = new FileStream(filename, FileMode.Create))
                {
                    Document pdfDocument = new Document(PageSize.A4, 72f, 72f, 72f, 72f);
                    PdfWriter.GetInstance(pdfDocument, stream);

                    pdfDocument.Open();

                    pdfDocument.Add(new Paragraph("\n\n\n\n\n\n\nLKS Mart", fontH1) { Alignment = Element.ALIGN_CENTER });
                    Image logo = Image.GetInstance("logo-lksmart.png");
                    logo.ScaleToFit(100f, 100f);
                    logo.Alignment = Element.ALIGN_CENTER;
                    pdfDocument.Add(logo);
                    pdfDocument.Add(new Paragraph("E-Catalog Store", fontSemiBoldH2) { Alignment = Element.ALIGN_CENTER });
                    pdfDocument.Add(new Paragraph("Jl. Raya Karadenan No.7", fontH2) { Alignment = Element.ALIGN_CENTER });
                    pdfDocument.Add(new Paragraph("Telp: 088-0922-0821", fontH2) { Alignment = Element.ALIGN_CENTER });
                    pdfDocument.Add(new Paragraph("Email: lksmart@gmail.com", fontH2) { Alignment = Element.ALIGN_CENTER });

                    pdfDocument.NewPage();

                    pdfDocument.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));

                    pdfDocument.Add(new Paragraph("Informasi Transaksi", fontSemiBoldH2));
                    pdfDocument.Add(new Paragraph($"Nomor Transaksi : {currentNoTransaksi}", fontText));
                    pdfDocument.Add(new Paragraph($"Tanggal         : {DateTime.Now.ToString("dd MMMM yyyy")}", fontText));
                    pdfDocument.Add(new Paragraph($"Waktu           : {DateTime.Now.ToString("HH:mm")} WIB", fontText));
                    pdfDocument.Add(new Paragraph($"Kasir           : {FormLogin.userName}", fontText));

                    pdfDocument.Add(new Paragraph("Informasi Pelanggan", fontSemiBoldH2));
                    pdfDocument.Add(new Paragraph($"Nama Pelanggan  : {namaPelanggan}", fontText));
                    pdfDocument.Add(new Paragraph($"No. Telepon     : {noTelpPelanggan}", fontText));
                    pdfDocument.Add(new Paragraph("Alamat          : Jl. Melati No. 45, Bandung", fontText));

                    pdfDocument.Add(new Paragraph("Daftar Produk", fontSemiBoldH2));
                    pdfDocument.Add(new Paragraph("\n"));
                    pdfDocument.Add(pdfTable);

                    pdfDocument.Add(new Paragraph("Ringkasan Pembayaran", fontSemiBoldH2));
                    pdfDocument.Add(new Paragraph($"Subtotal        : Rp {totalKeseluruhan - pajak}", fontText));
                    pdfDocument.Add(new Paragraph($"Pajak (10%)     : + Rp {pajak}", fontText));
                    pdfDocument.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));
                    pdfDocument.Add(new Paragraph($"Total Bayar     : Rp {totalKeseluruhan}", fontText));
                    pdfDocument.Add(new Paragraph($"Dibayar         : Rp {txtCash.Text}", fontText));
                    pdfDocument.Add(new Paragraph($"Kembalian       : Rp {labelJumlahKembalian.Text.Replace("Jumlah Kembalian: Rp", "")}", fontText));

                    pdfDocument.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));
                    pdfDocument.Add(new Paragraph("Terima kasih telah berbelanja di E-Catalog Store!", fontText));
                    pdfDocument.Add(new Paragraph("Barang yang sudah dibeli tidak dapat ditukar/dikembalikan.", fontText));
                    pdfDocument.Add(new Paragraph($"Dicetak oleh E-Catalog System | {DateTime.Now.ToString("dd MMMM yyyy - HH:mm")} WIB", fontText));

                    pdfDocument.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private PdfPTable CreatePdfTable(DataGridView dgv, Font pdfFont)
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
                    BackgroundColor = new BaseColor(240, 240, 240)
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

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!(dataGridViewKeranjang.Rows.Count > 0) || dataGridViewKeranjang == null)
            {
                MessageBoxHelper.ShowWarning("Masukan suatu produk ke dalam keranjang!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelepon.Text) && string.IsNullOrWhiteSpace(txtNamaPelanggan.Text) && !txtTelepon.Text.StartsWith("08"))
            {
                MessageBoxHelper.ShowWarning("Nama pelanggan atau nomor telepon tidak boleh kosong!");
                btnReset_Click(sender, e);
                return;
            }

            if (string.IsNullOrWhiteSpace(currentNoTransaksi))
            {
                currentNoTransaksi = await GenerateNoTransaksi();
            }

            MessageBoxHelper.ShowWarning(currentNoTransaksi);

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("no_transaksi", currentNoTransaksi, DbType.String, ParameterDirection.Input);
            p.Add("tgl_transaksi", DateTime.Now, DbType.String, ParameterDirection.Input);
            p.Add("nama_kasir", FormLogin.userName, DbType.String, ParameterDirection.Input);
            p.Add("total_bayar", Convert.ToInt64(totalKeseluruhan), DbType.String, ParameterDirection.Input);
            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            p.Add("id_pelanggan", idPelanggan, DbType.String, ParameterDirection.Input);

            var res = await db.ExecuteAsyncSP(conn, "usp_insert_m_transaksi", p);

            var getLastId = await db.ToSingleModel<int>(conn, "SELECT MAX(id_transaksi) FROM tbl_transaksi;", null);

            if (!(res > 0))
            {
                MessageBoxHelper.ShowWarning("Data gagal di simpan.");
                return;
            }

            int idTransaksi = getLastId;

            foreach (DataRow row in dtKeranjang.Rows)
            {
                p = new DynamicParameters();

                p.Add("id_transaksi", idTransaksi, DbType.Int32, ParameterDirection.Input);
                p.Add("id_barang", row["ID Barang"], DbType.Int32, ParameterDirection.Input);
                p.Add("harga_barang", Convert.ToInt64(row["Harga Satuan"]), DbType.Int64, ParameterDirection.Input);
                p.Add("kuantitas", Convert.ToInt64(row["Qty"]), DbType.Int64, ParameterDirection.Input);
                p.Add("total_harga", Convert.ToInt64(row["Total Harga"]), DbType.Int64, ParameterDirection.Input);

                await db.ExecuteAsyncSP(conn, "usp_insert_m_detail_transaksi", p);
            }

            SnackBarHelper.ShowSuccessInformation(this, "Data berhasil di simpan!");

            currentNoTransaksi = null;
            btnSimpan.Enabled = false;
            this.AcceptButton = btnPrint;

            cboxPilihMenu.SelectedIndexChanged -= cboxPilihMenu_SelectedIndexChanged;
            LoadMenu();
        }

        private void cboxPilihMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxPilihMenu.SelectedIndexChanged += cboxPilihMenu_SelectedIndexChanged;
            if (cboxPilihMenu.SelectedIndex > -1)
            {
                MBarang barang = (MBarang)cboxPilihMenu.SelectedItem;
                txtHargaSatuan.Text = barang.harga_satuan.ToString();
                txtKuantitas.Enabled = true;

                labelStok.Text = "Stok Tersedia: " + barang.jumlah_barang.ToString();
            }
        }

        private void txtKuantitas_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKuantitas.Text))
            {
                txtTotalHarga.Clear();
                return;
            }

            long harga;
            if (!long.TryParse(txtKuantitas.Text, out long qty) || !long.TryParse(txtHargaSatuan.Text, out harga))
            {
                MessageBoxHelper.ShowWarning("Masukkan nilai kuantitas yang valid!");

                txtKuantitas.Clear();
                txtKuantitas.Focus();
                return;
            }

            if (!(qty > 0))
            {
                MessageBoxHelper.ShowWarning("Kuantitas tidak boleh kurang dari 1!");

                txtKuantitas.Clear();
                txtKuantitas.Focus();
                return;
            }

            harga = Convert.ToInt64(txtHargaSatuan.Text);
            txtTotalHarga.Text = (qty * harga).ToString();
            this.AcceptButton = btnTambah;
        }

        private void FormTransaksi_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtCash.Text, out long uang))
            {
                MessageBoxHelper.ShowWarning("Masukkan jumlah uang yang valid!");
                return;
            }

            long kembalian = (long)(uang - totalKeseluruhan);
            if (!(uang >= totalKeseluruhan))
            {
                MessageBoxHelper.ShowWarning("Uang tidak cukup! \nUang anda: Rp" + uang.ToString() + 
                                             "\nKurang: Rp." + kembalian + 
                                             "\nTotal Keseluruhan: Rp" + totalKeseluruhan.ToString());
                return;
            }

            labelJumlahKembalian.Text = "Jumlah Kembalian: Rp" + kembalian.ToString();
            SnackBarHelper.ShowSuccessInformation(this, "Pembayaran berhasil!");

            btnTambah.Enabled = false;
            btnBayar.Enabled = false;
            txtCash.Enabled = false;
            cboxPilihMenu.Enabled = false;
            txtKuantitas.Enabled = false;
            btnSimpan.Enabled = true;
            btnPrint.Enabled = true;
            txtTelepon.Enabled = false;
            txtTelepon.Text = noTelpPelanggan;

            if (MessageBoxHelper.ComparisonMsgBox("Apakah anda ingin menyimpan transaksi ini?"))
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
                totalKeseluruhan += Convert.ToDecimal(row["Total Harga"]);
            }

            pajak = totalKeseluruhan * 0.10m;
            totalKeseluruhan += pajak;
            labelTotalKeseluruhan.Text = $"Total Keseluruhan: Rp.{Convert.ToInt64(totalKeseluruhan)}";
            labelPajak.Text = $"Pajak: Rp.{Convert.ToInt64(pajak)}";
        }

        private async void txtTelepon_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelepon.Text))
            {
                return;
            }

            if (!long.TryParse(txtTelepon.Text, out long telepon) ||
                !txtTelepon.Text.StartsWith("08") ||
                !Regex.IsMatch(txtTelepon.Text, @"^\d+$"))
            {
                MessageBoxHelper.ShowWarning("Kolom telepon tidak valid!");

                txtTelepon.Text = "08";
                txtTelepon.Focus();
                return;
            }

            var conn = GlobalConfig.GetConnection();
            var db = new DBHelpers();
            var p = new DynamicParameters();

            p.Add("telepon", txtTelepon.Text + "%", DbType.String, ParameterDirection.Input);

            var res = await db.ToSingleModel<MPelanggan>(conn, "SELECT * FROM tbl_pelanggan WHERE telepon LIKE @telepon", p);

            if (res == null || string.IsNullOrWhiteSpace(res.nama))
            {
                txtNamaPelanggan.Clear();
                return;
            }

            txtNamaPelanggan.Text = res.nama;
            idPelanggan = res.id_pelanggan;
            namaPelanggan = res.nama;
            noTelpPelanggan = res.telepon;
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnBayar;
        }

        private void txtTelepon_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter))
            {
                return;
            }

            LockPelangganData();
            txtKuantitas.Focus();
            return;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private void bunifuLabel20_Click(object sender, EventArgs e)
        {

        }
    }
}