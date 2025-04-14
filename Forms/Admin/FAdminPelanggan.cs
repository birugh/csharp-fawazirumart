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

        private void ResetInput()
        {
            txtNama.Clear();
            txtTelepon.Text = "08";
            txtCari.Clear();
            txtNama.Focus();
            LoadData();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "create", DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_pelanggan", p);

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
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBox.Show("Please provide a valid user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin?")) return;


            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "update", DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

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
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBox.Show("Please provide a valid user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;
            
            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin?")) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("func", "delete", DbType.String, ParameterDirection.Input);
                p.Add("id_pelanggan", hasilCari, DbType.String, ParameterDirection.Input);

                var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_pelanggan", p);

                if (res == null)
                {
                    MessageBox.Show("Proses hapus data gagal");
                    return;
                }

                MessageBox.Show("Data berhasil di hapus");
                LoadData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (isFillingData == true) return;

            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                LoadData();
                return;
            }

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("nama", txtCari.Text + "%", DbType.String, ParameterDirection.Input);

                var res = await db.ToSingleModel<MPelanggan>(conn, "SELECT * FROM tbl_pelanggan WHERE nama LIKE @nama", p);

                if (res == null)
                {
                    return;
                }

                dataGridViewPelanggan.DataSource = new List<MPelanggan> { res };
                txtNama.Text = res.nama;
                txtTelepon.Text = res.telepon;
                hasilCari = res.id_pelanggan.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridViewPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isFillingData = true;
                DataGridViewRow row = dataGridViewPelanggan.Rows[e.RowIndex];
                txtCari.Text = row.Cells["nama"].Value.ToString();
                txtNama.Text = row.Cells["nama"].Value.ToString();
                txtTelepon.Text = row.Cells["telepon"].Value.ToString();
                hasilCari = row.Cells["id_pelanggan"].Value.ToString();
                isFillingData = false;
            }
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
            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin ingin logout?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();
            p.Add("waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
            p.Add("aktivitas", "Logout", DbType.String, ParameterDirection.Input);
            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            var affected = await db.ExecuteAsyncSP(conn, "usp_insert_m_log", p);
            var formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private void btnKelolaPelanggan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}