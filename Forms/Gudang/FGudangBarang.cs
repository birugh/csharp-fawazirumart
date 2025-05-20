using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FormGudangBarang : Form
    {
        private bool isFillingData;
        private string hasilCari;

        public FormGudangBarang()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            LoadData();
        }

        private async void LoadData()
        {
            var data = await LoadDataHelper.LoadDataModelSP<MBarang>("usp_m_barang");
            dataGridViewBarang.DataSource = data.ToList();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHargaSatuan.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahBarang.Text) ||
                string.IsNullOrWhiteSpace(txtKodeBarang.Text) ||
                string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtSatuan.Text) ||
                !long.TryParse(txtHargaSatuan.Text, out _) ||
                !long.TryParse(txtJumlahBarang.Text, out _) ||
                int.Parse(txtHargaSatuan.Text) <= 0 ||
                int.Parse(txtJumlahBarang.Text) <= 0)
            {
                MessageBoxHelper.ShowWarning("Input tidak valid.");
                return false;
            }
            return true;
        }

        private bool ValidateSearch()
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBoxHelper.ShowWarning("Isi kolom cari dengan Nama barang.");
                return false;
            }
            return true;
        }

        private void ResetInput()
        {
            txtKodeBarang.Clear();
            txtNamaBarang.Clear();
            txtJumlahBarang.Clear();
            txtSatuan.Clear();
            txtHargaSatuan.Clear();
            txtCari.Clear();
            dateExpired.Value = DateTime.Now;
            LoadData();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin, ingin melakukan ini?")) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("func", "create", DbType.String, ParameterDirection.Input);
                p.Add("kode_barang", txtKodeBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("jumlah_barang", txtJumlahBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("nama_barang", txtNamaBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("satuan", txtSatuan.Text, DbType.String, ParameterDirection.Input);
                p.Add("expired_date", dateExpired.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
                p.Add("harga_satuan", txtHargaSatuan.Text, DbType.String, ParameterDirection.Input);
                p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

                var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_barang", p);

                int status = p.Get<int>("status");
                if (status == 2)
                {
                    MessageBoxHelper.ShowWarning("Username atau telepon sudah digunakan.");
                    return;
                }
                else if (status == 1)
                {
                    MessageBoxHelper.ShowInformation("Data berhasil ditambahkan.");
                    LoadData();
                    return;
                }
                else
                {
                    MessageBoxHelper.ShowError("Terjadi kesalahan.");
                    return;
                }

                LoadData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateSearch() || !ValidateInput()) return;
            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin, ingin melakukan ini?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "update", DbType.String, ParameterDirection.Input);
            p.Add("id_barang", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("kode_barang", txtKodeBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("jumlah_barang", txtJumlahBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("nama_barang", txtNamaBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("satuan", txtSatuan.Text, DbType.String, ParameterDirection.Input);
            p.Add("expired_date", dateExpired.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("harga_satuan", txtHargaSatuan.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_barang", p);

            int status = p.Get<int>("status");
            if (status == 2)
            {
                MessageBoxHelper.ShowWarning("Nama barang telah digunakan.");
                return;
            }
            else if (status == 1)
            {
                MessageBoxHelper.ShowInformation("Data berhasil ditambahkan.");
                LoadData();
                return;
            }
            else

            {
                MessageBoxHelper.ShowError("Terjadi kesalahan.");
                return;
            }

            LoadData();
            btnReset_Click(sender, e);
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (!ValidateSearch() || !ValidateInput()) return;
            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin, ingin melakukan ini?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "delete", DbType.String, ParameterDirection.Input);
            p.Add("id_barang", hasilCari, DbType.String, ParameterDirection.Input);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_barang", p);

            if (res > 0)
            {
                MessageBoxHelper.ShowWarning("Data gagal ditambahkan!");
                return;
            }

            MessageBoxHelper.ShowInformation("Data berhasil ditambahkan.");
            LoadData();
        }

        private void FormGudang_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridViewBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                return;
            }

            isFillingData = true;
            DataGridViewRow row = dataGridViewBarang.Rows[e.RowIndex];
            txtKodeBarang.Text = row.Cells["kode_barang"].Value.ToString();
            txtNamaBarang.Text = row.Cells["nama_barang"].Value.ToString();
            txtJumlahBarang.Text = row.Cells["jumlah_barang"].Value.ToString();
            txtSatuan.Text = row.Cells["satuan"].Value.ToString();
            dateExpired.Value = Convert.ToDateTime(row.Cells["expired_date"].Value);
            txtHargaSatuan.Text = row.Cells["harga_satuan"].Value.ToString();
            txtCari.Text = row.Cells["nama_barang"].Value.ToString();
            hasilCari = row.Cells["id_barang"].Value.ToString();
            isFillingData = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this, FormLogin.userName);
        }

        private async void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (isFillingData == true) return;

            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                LoadData();
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("nama_barang", txtCari.Text + "%", DbType.String, ParameterDirection.Input);

            var res = await db.ToSingleModel<MBarang>(conn, "SELECT * FROM tbl_barang WHERE nama_barang LIKE @nama_barang", p);

            if (res == null)
            {
                return;
            }

            dataGridViewBarang.DataSource = new List<MBarang> { res };
            txtHargaSatuan.Text = res.harga_satuan.ToString();
            txtJumlahBarang.Text = res.jumlah_barang.ToString();
            txtKodeBarang.Text = res.kode_barang;
            txtNamaBarang.Text = res.nama_barang;
            txtSatuan.Text = res.satuan;
            dateExpired.Value = res.expired_date;
            hasilCari = res.id_barang.ToString();
        }
    }
}