using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using Dapper;

namespace csharp_lksmart
{
    public partial class FormAdminKelolaUser : Form
    {
        private string hasilCari;
        private Timer timer;
        public FormAdminKelolaUser()
        {
            InitializeComponent();
            LoadUserData();
            InitializeTimer();
        }
        private async void LoadUserData()
        {
            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var a = await db.ToModelSP<MUser>(conn, "usp_m_user", null);
            dataGridViewUsers.DataSource = a.ToList();
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }
        private void UpdateDateTime()
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
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
                    txtTelepon.Text.Length < 10 ||
                    txtTelepon.Text.Length > 13 ||
                    !Regex.IsMatch(txtTelepon.Text, @"^\d+$") ||
                    !txtTelepon.Text.StartsWith("08"))
            {
                MessageBox.Show("Input tidak valid");
                return false;
            }
            return true;
        }
        private bool ValidateSwitch()
        {
            if (!(cboxTipeUser.SelectedItem == null) ||
                !string.IsNullOrWhiteSpace(txtNama.Text) ||
                !string.IsNullOrWhiteSpace(txtAlamat.Text) ||
                !string.IsNullOrWhiteSpace(txtUsername.Text) ||
                !string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                return true;
            }
            return false;
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
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (!int.TryParse(txtTelepon.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelepon.Clear();
                txtTelepon.Focus();
                return;
            }

            if (!(MessageBox.Show("Apakah anda yakin ingin melakukan ini?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var p = new DynamicParameters();
            p.Add("func", "create", DbType.String, ParameterDirection.Input);
            p.Add("tipe_user", cboxTipeUser.SelectedItem.ToString().ToLower(), DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("alamat", txtAlamat.Text, DbType.String, ParameterDirection.Input);
            p.Add("username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

            if (res == null)
            {
                MessageBox.Show("Proses membuat data gagal");
                return;
            }

            MessageBox.Show("Data berhasil di tambahkan");
            LoadUserData();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBox.Show("Please fill out all fields and provide a valid Search Id.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtCari.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(MessageBox.Show("Apakah anda yakin ingin melakukan ini?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)) return;

            string tipeUser = null;

            if (cboxTipeUser.SelectedIndex == 0 || cboxTipeUser.SelectedIndex == 1)
            {
                tipeUser = cboxTipeUser.SelectedItem.ToString();
            }
            else if (cboxTipeUser.Text == "admin")
            {
                tipeUser = "admin";
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var p = new DynamicParameters();
            p.Add("func", "update", DbType.String, ParameterDirection.Input);
            p.Add("id_user", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("tipe_user", tipeUser, DbType.String, ParameterDirection.Input);
            p.Add("nama", txtNama.Text, DbType.String, ParameterDirection.Input);
            p.Add("telepon", txtTelepon.Text, DbType.String, ParameterDirection.Input);
            p.Add("alamat", txtAlamat.Text, DbType.String, ParameterDirection.Input);
            p.Add("username", txtUsername.Text, DbType.String, ParameterDirection.Input);
            p.Add("password", txtPassword.Text, DbType.String, ParameterDirection.Input);
            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

            if (res == null)
            {
                MessageBox.Show("Proses update data gagal");
                return;
            }

            MessageBox.Show("Data berhasil di update");
            LoadUserData();
            btnReset_Click(null, null);
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text) || txtCari.Text == "Search by Id")
            {
                MessageBox.Show("Please provide a valid user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtCari.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(MessageBox.Show("Apakah anda yakin ingin melakukan ini?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConn();
                var p = new DynamicParameters();
                p.Add("func", "delete", DbType.String, ParameterDirection.Input);
                p.Add("id_user", hasilCari, DbType.String, ParameterDirection.Input);
                var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_user", p);

                if (res == null)
                {
                    MessageBox.Show("Proses hapus data gagal");
                    return;
                }

                MessageBox.Show("Data berhasil di hapus");
                LoadUserData();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            if (ValidateSwitch() == true)
            {
                if (MessageBox.Show("There is unsaved data, continue to switch form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetInput();
                    FormAdminLaporan laporanForm = new FormAdminLaporan();
                    laporanForm.Show();
                    this.Hide();
                }
            }
            else
            {
                ResetInput();
                FormAdminLaporan laporanForm = new FormAdminLaporan();
                laporanForm.Show();
                this.Hide();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetInput();
                FormAdminLogActivity logForm = new FormAdminLogActivity();
                logForm.Show();
                this.Hide();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBox.Show("Please provide a valid user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtCari.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConn();
                var p = new DynamicParameters();
                p.Add("username", txtCari.Text + "%", DbType.String, ParameterDirection.Input);
                var res = await db.ToSingleModel<MUser>(conn, "SELECT * FROM tbl_user WHERE username LIKE @username", p);

                if (res == null)
                {
                    return;
                }

                dataGridViewUsers.DataSource = new List<MUser> { res };
                txtAlamat.Text = res.alamat;
                txtNama.Text = res.nama;
                txtPassword.Text = res.password;
                txtTelepon.Text = res.telepon.ToString();
                txtUsername.Text = res.username;
                hasilCari = res.id_user.ToString();
                switch (res.tipe_user)
                {
                    case "admin":
                        cboxTipeUser.Text = "admin";
                        break;
                    case "gudang":
                        cboxTipeUser.SelectedIndex = 0;
                        break;
                    case "kasir":
                        cboxTipeUser.SelectedIndex = 1;
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Apakah anda yakin?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var p = new DynamicParameters();
            p.Add("waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
            p.Add("aktivitas", "Logout", DbType.String, ParameterDirection.Input);
            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            var affected = await db.ExecuteAsyncSP(conn, "usp_insert_m_log", p);
            var formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void FKelolaUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void txtSearchId_Enter(object sender, EventArgs e)
        {
        }

        private void txtSearchId_Leave(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];
                txtCari.Text = row.Cells["id_user"].Value.ToString();
                cboxTipeUser.SelectedItem = row.Cells["tipe_user"].Value.ToString();
                txtNama.Text = row.Cells["nama"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                txtUsername.Text = row.Cells["username"].Value.ToString();
                txtTelepon.Text = row.Cells["telepon"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.icon_eye_outline_png;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.IconRight = csharp_lksmart.Properties.Resources.icon_eye_disable_outline;
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
