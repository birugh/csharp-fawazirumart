using csharp_lksmart.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace csharp_lksmart.Forms.Admin
{
    public partial class FAdminPelanggan : Form
    {
        private string hasilCari;
        private bool isFillingData;

        public FAdminPelanggan()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            cboxSearch.SelectedIndex = 0;
            LoadData();
        }

        private async void LoadData()
        {
            var data = await LoadDataHelper.LoadDataModelSP<MPelanggan>("usp_m_pelanggan");
            dataGridViewPelanggan.DataSource = data.ToList();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
               string.IsNullOrWhiteSpace(txtNama.Text) ||
               string.IsNullOrWhiteSpace(txtAlamat.Text) ||
               !long.TryParse(txtTelepon.Text, out _) ||
               (txtTelepon.Text.Length < 10) ||
               (txtTelepon.Text.Length > 13) ||
               !Regex.IsMatch(txtTelepon.Text, @"^\d+$") ||
               !txtTelepon.Text.StartsWith("08"))
            {
                MessageBoxHelper.ShowWarning("Input anda tidak valid");
                return false;
            }
            return true;
        }

        private bool ValidateSearch()
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBoxHelper.ShowWarning("Isi kolom cari dengan nama.");
                return false;
            }
            return true;
        }

        private void ResetInput()
        {
            txtNama.Clear();
            txtTelepon.Text = "08";
            txtAlamat.Clear();
            txtCari.Clear();
            txtNama.Focus();
            cboxSearch.SelectedIndex = 0;
            LoadData();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("id_user", FormLogin.userId.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("alamat", txtAlamat.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_insert_m_pelanggan", p);

            int status = p.Get<int>("status");
            if (status == 2)
            {
                MessageBox.Show("Nama atau telepon sudah digunakan.");
                return;
            }
            else if (status == 1)
            {
                MessageBox.Show("Data berhasil ditambahkan.");
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan.");
            }

            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (int.TryParse(hasilCari, out int id))
            {
                MessageBoxHelper.ShowWarning("Silahkan pilih filter pencarian ID.");
                return;
            }

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin?")) return;


            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("id_user", FormLogin.userId.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("alamat", txtAlamat.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_update_m_pelanggan", p);

            int status = p.Get<int>("status");
            if (status == 2)
            {
                MessageBox.Show("Username atau telepon sudah digunakan.");
                return;
            }
            else if (status == 1)
            {
                MessageBox.Show("Data berhasil diupdate.");
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan.");
            }

            LoadData();
            btnReset_Click(null, null);
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (!ValidateInput() || !ValidateSearch()) return;
            
            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("id_user", FormLogin.userId.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("id_pelanggan", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_delete_m_pelanggan", p);

            int status = p.Get<int>("status");
            if (status == 0)
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
            }


            MessageBoxHelper.ShowWarning("Data berhasil di hapus!");
            LoadData();
        }

        private async void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (isFillingData) return;

            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                LoadData();
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();
            List<MPelanggan> res = null;

            if (cboxSearch.SelectedIndex == 0)
            {
                if (!int.TryParse(txtCari.Text, out int id)) return;
                p.Add("func", "id", DbType.String, ParameterDirection.Input);
                p.Add("id_pelanggan", txtCari.Text, DbType.String, ParameterDirection.Input);
            }
            else if (cboxSearch.SelectedIndex == 1)
            {
                p.Add("func", "nama", DbType.String, ParameterDirection.Input);
                p.Add("nama", txtCari.Text, DbType.String, ParameterDirection.Input);
            }
            else if (cboxSearch.SelectedIndex == 2)
            {
                p.Add("func", "telepon", DbType.String, ParameterDirection.Input);
                p.Add("telepon", txtCari.Text, DbType.String, ParameterDirection.Input);
            }
            else
            {
                MessageBoxHelper.ShowError("Filter pencarian tidak valid.");
                return;
            }

            var result = await db.ToModelSP<MPelanggan>(conn, "usp_search_m_pelanggan", p);
            res = result?.ToList();

            if (res == null || res.Count == 0)
            {
                dataGridViewPelanggan.DataSource = null;
                return;
            }

            dataGridViewPelanggan.DataSource = res;

            var first = res.FirstOrDefault();
            if (first != null)
            {
                txtNama.Text = first.nama;
                txtTelepon.Text = first.telepon;
                txtAlamat.Text = first.alamat;
                hasilCari = first.id_pelanggan.ToString();
            }
        }

        private void dataGridViewPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            isFillingData = true;
            DataGridViewRow row = dataGridViewPelanggan.Rows[e.RowIndex];
            txtNama.Text = row.Cells["nama"].Value.ToString();
            txtTelepon.Text = row.Cells["telepon"].Value.ToString();
            txtAlamat.Text = row.Cells["alamat"].Value.ToString();

            if (cboxSearch.SelectedIndex == 0)
            {
                txtCari.Text = row.Cells["id_pelanggan"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 1)
            {
                txtCari.Text = row.Cells["nama"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 2)
            {
                txtCari.Text = row.Cells["telepon"].Value.ToString();
            }

            hasilCari = row.Cells["id_pelanggan"].Value.ToString();
            isFillingData = false;
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminKelolaUser>(this);
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminLaporan>(this);
        }

        private void btnLogActivity_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminLogActivity>(this);
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this, FormLogin.userName);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private void btnKelolaPelanggan_Click(object sender, EventArgs e)
        {
            MessageBoxHelper.ShowWarning("Anda sedang berada di form ini.");
        }

        private void cboxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCari.Focus();
        }
    }
}