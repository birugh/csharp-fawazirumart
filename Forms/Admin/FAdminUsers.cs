using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FormAdminKelolaUser : Form
    {
        private string hasilCari;
        private bool isFillingData;

        public FormAdminKelolaUser()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            LoadData();
        }

        private async void LoadData()
        {
            var data = await LoadDataHelper.LoadDataModelSP<MUser>("usp_m_user");
            dataGridViewUsers.DataSource = data.ToList();
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
            if (cboxTipeUser.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtAlamat.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                !long.TryParse(txtTelepon.Text, out _) ||
                (txtTelepon.Text.Length < 10) ||
                (txtTelepon.Text.Length > 13) ||
                !Regex.IsMatch(txtTelepon.Text, @"^\d+$") ||
                !txtTelepon.Text.StartsWith("08"))
            {
                MessageBoxHelper.ShowWarning("Semua kolom harus diisi!");
                return false;
            }
            return true;
        }

        private bool ValidateSearch()
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBoxHelper.ShowWarning("Isi kolom cari dengan Nama user.");
                return false;
            }
            return true;
        }

        private void ResetInput()
        {
            cboxTipeUser.SelectedIndex = -1;
            txtNama.Text = "";
            txtTelepon.Text = "";
            txtAlamat.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtCari.Text = "";
            LoadData();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin ingin melakukan ini?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "create", DbType.String, ParameterDirection.Input);
            p.Add("tipe_user", cboxTipeUser.SelectedItem.ToString().ToLower(), DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("alamat", txtAlamat.Text, DbType.String, ParameterDirection.Input);
            p.Add("username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

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
            }

            LoadData();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput() || !ValidateSearch()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin ingin melakukan ini?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "update", DbType.String, ParameterDirection.Input);
            p.Add("id_user", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("tipe_user", cboxTipeUser.SelectedItem, DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("alamat", txtAlamat.Text, DbType.String, ParameterDirection.Input);
            p.Add("username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

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
            }

            MessageBox.Show("Data berhasil di update");
            LoadData();
            btnReset_Click(null, null);
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (!ValidateInput() || !ValidateSearch()) return;
            
            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin ingin melakukan ini?")) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("func", "delete", DbType.String, ParameterDirection.Input);
                p.Add("id_user", hasilCari, DbType.String, ParameterDirection.Input);

                var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

                if (res == null)
                {
                    MessageBoxHelper.ShowWarning("Data gagal di hapus.");
                    return;
                }

                MessageBoxHelper.ShowInformation("Data berhasil di hapus.");
                LoadData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            MessageBoxHelper.ShowWarning("Anda sedang berada di form ini.");
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminLaporan>(this);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminLogActivity>(this);
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this);
        }

        private void FKelolaUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                return;
            }

            isFillingData = true;
            DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];
            txtCari.Text = row.Cells["username"].Value.ToString();
            cboxTipeUser.SelectedItem = row.Cells["tipe_user"].Value.ToString();
            txtNama.Text = row.Cells["nama"].Value.ToString();
            txtAlamat.Text = row.Cells["alamat"].Value.ToString();
            txtAlamat.Text = row.Cells["alamat"].Value.ToString();
            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtTelepon.Text = row.Cells["telepon"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();
            hasilCari = row.Cells["id_user"].Value.ToString();
            isFillingData = false;
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

            p.Add("username", txtCari.Text + "%", DbType.String, ParameterDirection.Input);

            var res = await db.ToSingleModel<MUser>(conn, "SELECT * FROM tbl_user WHERE username LIKE @username", p);

            if (res == null)
            {
                return;
            }

            dataGridViewUsers.DataSource = new List<MUser> { res };
            cboxTipeUser.SelectedItem = res.tipe_user;
            txtAlamat.Text = res.alamat;
            txtNama.Text = res.nama;
            txtPassword.Text = res.password;
            txtTelepon.Text = res.telepon;
            txtUsername.Text = res.username;
            hasilCari = res.id_user.ToString();
        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.icon_eye_disable_outline;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.icon_eye_outline_png;
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnKelolaPelanggan_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FAdminPelanggan>(this);
        }
    }
}