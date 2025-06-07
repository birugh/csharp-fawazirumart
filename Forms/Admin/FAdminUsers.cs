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
            cboxSearch.SelectedIndex = 0;
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
            if (
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBoxHelper.ShowWarning("Semua kolom harus diisi!");
                return false;
            }
            else if (txtUsername.Text.Length < 5 ||
                     txtNama.Text.Length < 5 ||
                     txtPassword.Text.Length < 5)
            {
                MessageBoxHelper.ShowWarning("Kolom minimal harus 5 karakter!");
                return false;
            }

            if (cboxTipeUser.Text == "Admin")
            {

            }
            else if (cboxTipeUser.SelectedIndex > -1)
            {
                MessageBoxHelper.ShowWarning("Tipe user harus valid!");
                cboxTipeUser.Focus();
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
            cboxTipeUser.Text = null;
            cboxTipeUser.SelectedIndex = -1;
            txtNama.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtCari.Text = "";
            cboxTipeUser.Enabled = true;
            hasilCari = null;
            LoadData();
        }

        private void ToggleButton(string typeToggle)
        {
            if (typeToggle == "false")
            {
                btnEdit.Enabled = false;
                btnHapus.Enabled = false;
            }
            else if (typeToggle == "true")
            {
                btnEdit.Enabled = true;
                btnHapus.Enabled = true;
            }
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin ingin melakukan ini?")) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("id_user", FormLogin.userId.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("tipe_user", cboxTipeUser.Text.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_insert_m_user", p);

            int status = p.Get<int>("status");
            if (status == 2)
            {
                MessageBoxHelper.ShowInformation("Data berhasil dikembalikan.");
                ResetInput();
            }
            else if (status == 1)
            {
                MessageBoxHelper.ShowInformation("Data berhasil ditambahkan.");
                ResetInput();
            }
            else if (status == 0)
            {
                MessageBoxHelper.ShowInformation("Data gagal ditambahkan.");
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

            p.Add("id_user", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("tipe_user", cboxTipeUser.Text, DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);
            
            var res = await db.ExecuteAsyncSP(conn, "usp_update_m_user", p);

            int status = p.Get<int>("status");
            if (status == 1)
            {
                MessageBoxHelper.ShowInformation("Data berhasil diedit.");
                ResetInput();
            }
            else if (status == 0)
            {
                MessageBoxHelper.ShowInformation("Data gagal diedit.");
            }
            else
            {
                MessageBoxHelper.ShowError("Terjadi kesalahan.");
            }

            LoadData();
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (!ValidateSearch()) return;

            if (!MessageBoxHelper.ComparisonMsgBox("Apakah anda yakin ingin melakukan ini?")) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("id_user", hasilCari, DbType.String, ParameterDirection.Input);
                p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

                var res = await db.ExecuteAsyncSP(conn, "usp_delete_m_user", p);

                int status = p.Get<int>("status");
                if (status == 0)
                {
                    MessageBoxHelper.ShowWarning("Data gagal dihapus.");
                }
                else if (status == 1)
                {
                    MessageBoxHelper.ShowInformation("Data berhasil dihapus.");
                    ResetInput();
                }
                else
                {
                    MessageBoxHelper.ShowError("Terjadi kesalahan.");
                }

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
            FormClosingHelper.FormChanging<FAdminPelanggan>(this);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminLogActivity>(this);
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this, FormLogin.userName);
        }

        private void FKelolaUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
            ToggleButton("false");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            txtCari.Clear();
            ToggleButton("false");
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            isFillingData = true;
            DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];
            txtCari.Text = row.Cells["username"].Value.ToString();
            if (row.Cells["tipe_user"].Value.ToString() == "Admin")
            {
                cboxTipeUser.Text = "Admin";
                cboxTipeUser.Enabled = false;
            }
            else
            {
                cboxTipeUser.SelectedItem = row.Cells["tipe_user"].Value.ToString();
                cboxTipeUser.Enabled = Enabled;
            }
            txtNama.Text = row.Cells["nama"].Value.ToString();
            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();

            if (cboxSearch.SelectedIndex == 0)
            {
                txtCari.Text = row.Cells["id_user"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 1)
            {
                txtCari.Text = row.Cells["tipe_user"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 2)
            {
                txtCari.Text = row.Cells["nama"].Value.ToString();
            }
            else if (cboxSearch.SelectedIndex == 3)
            {
                txtCari.Text = row.Cells["username"].Value.ToString();
            }

            hasilCari = row.Cells["id_user"].Value.ToString();
            ToggleButton("true");
            isFillingData = false;
        }

        private async void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (isFillingData == true) return;

            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                ToggleButton("false");
                LoadData();
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();
            List<MUser> res = null;
            
            switch (cboxSearch.SelectedIndex)
            {
                case 0:
                    if (!int.TryParse(txtCari.Text, out int id)) return;
                    p.Add("func", "id", DbType.String);
                    p.Add("id_user", txtCari.Text, DbType.String);
                    break;
                case 1:
                    p.Add("func", "tipe user", DbType.String);
                    p.Add("tipe_user", txtCari.Text, DbType.String);
                    break;
                case 2:
                    p.Add("func", "nama", DbType.String);
                    p.Add("nama", txtCari.Text, DbType.String);
                    break;
                case 3:
                    p.Add("func", "username", DbType.String);
                    p.Add("username", txtCari.Text, DbType.String);
                    break;
                default:
                    MessageBoxHelper.ShowError("Filter tidak valid, silakan pilih filter yang tersedia.");
                    return;
            }

            var result = await db.ToModelSP<MUser>(conn, "usp_search_m_user", p);
            res = result?.ToList();

            if (res == null || res.Count == 0)
            {
                dataGridViewUsers.DataSource = null;
                ToggleButton("false");
                return;
            }

            dataGridViewUsers.DataSource = res;
            ToggleButton("true");
            if (txtCari.Text == "1")
            {
                cboxTipeUser.Text = "Admin";
                cboxTipeUser.Enabled = false;
            }
            else
            {
                cboxTipeUser.Enabled = true;
            }
            var first = res.FirstOrDefault();
            if (first != null)
            {
                cboxTipeUser.SelectedItem = first.tipe_user;
                txtNama.Text = first.nama;
                txtPassword.Text = first.password;
                txtUsername.Text = first.username;
                hasilCari = first.id_user.ToString();
            }
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

        private void cboxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCari.Focus();
        }

        private void FormAdminKelolaUser_Load(object sender, EventArgs e)
        {

        }
    }
}