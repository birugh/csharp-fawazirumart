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
            cboxSearch.SelectedIndex = 0;
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

        private bool ValidateDate()
        {
            if (dateExpired.Value < DateTime.Today)
            {
                MessageBoxHelper.ShowWarning("Tanggal expired tidak boleh kurang dari hari ini.");
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
            if (!ValidateDate()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin, ingin melakukan ini?")) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("@key", "id_user", DbType.String);
                p.Add("@value", FormLogin.userId, DbType.Int32);

                var res = await db.ExecuteAsyncSP(conn, "sp_set_session_context", p);

                p = new DynamicParameters();

                p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
                p.Add("kode_barang", txtKodeBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("jumlah_barang", txtJumlahBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("nama_barang", txtNamaBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("satuan", txtSatuan.Text, DbType.String, ParameterDirection.Input);
                p.Add("expired_date", dateExpired.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
                p.Add("harga_satuan", txtHargaSatuan.Text, DbType.String, ParameterDirection.Input);
                p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

                res = await db.ExecuteAsyncSP(conn, "usp_insert_m_barang", p);

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

            p = new DynamicParameters();
            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            p.Add("id_barang", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("kode_barang", txtKodeBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("jumlah_barang", txtJumlahBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("nama_barang", txtNamaBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("satuan", txtSatuan.Text, DbType.String, ParameterDirection.Input);
            p.Add("expired_date", dateExpired.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("harga_satuan", txtHargaSatuan.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            await db.ExecuteAsyncSP(conn, "usp_update_m_barang", p);

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

            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            p.Add("id_barang", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_delete_m_barang", p);

            int status = p.Get<int>("status");
            if (status == 2)
            {
                MessageBoxHelper.ShowWarning("Data gagal dihapus.");
                return;
            }
            else if (status == 1)
            {
                MessageBoxHelper.ShowInformation("Data berhasil dihapus.");
                LoadData();
                return;
            }
            else
            {
                MessageBoxHelper.ShowError("Terjadi kesalahan.");
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
            if (e.RowIndex < 0)
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

            if (cboxSearch.SelectedIndex == 0)
            {
                txtCari.Text = row.Cells["id_barang"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 1)
            {
                txtCari.Text = row.Cells["kode_barang"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 2)
            {
                txtCari.Text = row.Cells["nama_barang"].Value.ToString();
            }

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
            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();
            List<MBarang> res = null;

            if (cboxSearch.SelectedIndex == 0)
            {
                if (!int.TryParse(txtCari.Text, out int id))
                {
                    return;
                }
                p.Add("func", "id", DbType.String, ParameterDirection.Input);
                p.Add("id_barang", id, DbType.String, ParameterDirection.Input);
            }
            else if (cboxSearch.SelectedIndex == 1)
            {
                p.Add("func", "kode", DbType.String, ParameterDirection.Input);
                p.Add("kode_barang", txtCari.Text, DbType.String, ParameterDirection.Input);
            }
            else if (cboxSearch.SelectedIndex == 2)
            {
                p.Add("func", "nama", DbType.String, ParameterDirection.Input);
                p.Add("nama_barang", txtCari.Text, DbType.String, ParameterDirection.Input);
            }
            else
            {
                MessageBoxHelper.ShowError("Pencarian tidak valid, silahkan coba lagi.");
                return;
            }

            var result = await db.ToModelSP<MBarang>(conn, "usp_search_m_barang", p);
            res = result?.ToList();

            if (res == null || res.Count == 0)
            {
                dataGridViewBarang.DataSource = null;
                return;
            }

            dataGridViewBarang.DataSource = res;

            var first = res.FirstOrDefault();
            if (first != null)
            {
                txtHargaSatuan.Text = first.harga_satuan.ToString();
                txtJumlahBarang.Text = first.jumlah_barang.ToString();
                txtKodeBarang.Text = first.kode_barang;
                txtNamaBarang.Text = first.nama_barang;
                txtSatuan.Text = first.satuan;
                dateExpired.Value = first.expired_date;
                hasilCari = first.id_barang.ToString();
            }
        }

    }
}