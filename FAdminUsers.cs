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

namespace csharp_lksmart
{
    public partial class FormAdminUser : Form
    {
        private static string conString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn = new SqlConnection();
        private static SqlDataAdapter adp;
        private static SqlDataReader dr;
        private static SqlCommand cmd;
        private static DataTable dt;
        private static string query;
        private Timer timer;
        public FormAdminUser()
        {
            InitializeComponent();
            LoadUserData();
            InitializeTimer();
        }
        private void LoadUserData()
        {
            try
            {
                using (conn = new SqlConnection(conString))
                {
                    query = "SELECT * FROM tbl_user";
                    adp = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridViewUsers.DataSource = dt;
                }
            }
            catch
            {
                return;
            }
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
            if (string.IsNullOrWhiteSpace(txtTipeUser.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtAlamat.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtTelepon.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ResetInput()
        {
            txtTipeUser.Text = "";
            txtNama.Text = "";
            txtTelepon.Text = "";
            txtAlamat.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtSearch.Text = "Search by Id";
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                using (conn = new SqlConnection(conString))
                {
                    query = "INSERT INTO tbl_user VALUES (@tipe_user, @nama, @alamat, @username, @telepon, @password, @email)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tipe_user", txtTipeUser.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetInput();
                    LoadUserData();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search by Id")
            {
                MessageBox.Show("Please fill out all fields and provide a valid Search Id.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtSearch.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    using (conn = new SqlConnection(conString))
                    {
                        if (MessageBox.Show("Please check your data again, are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            query = "UPDATE tbl_user SET tipe_user=@tipe_user, nama=@nama, alamat=@alamat, username=@username, telepon=@telepon, password=@Password, email=@email WHERE id_user=@id_user";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id_user", txtSearch.Text);
                            cmd.Parameters.AddWithValue("@tipe_user", txtTipeUser.Text);
                            cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                            cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData();
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search by Id")
            {
                MessageBox.Show("Please provide a valid user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtSearch.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure to delete this data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (conn = new SqlConnection(conString))
                        {
                            query = "DELETE FROM tbl_user WHERE id_user=@id_user";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id_user", txtSearch.Text);

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInput();
                            LoadUserData();
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to switch the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetInput();
                FAdminLaporan laporanForm = new FAdminLaporan();
                laporanForm.Show();
                this.Hide();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to switch the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetInput();
                FormAdminLog logForm = new FormAdminLog();
                logForm.Show();
                this.Hide();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search by Id")
            {
                MessageBox.Show("Please provide a valid user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtSearch.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    using (conn = new SqlConnection(conString))
                    {
                        query = "SELECT * FROM tbl_user WHERE id_user=@id_user";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_user", txtSearch.Text);

                        conn.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            txtTipeUser.Text = dr["tipe_user"].ToString();
                            txtNama.Text = dr["nama"].ToString();
                            txtAlamat.Text = dr["alamat"].ToString();
                            txtUsername.Text = dr["username"].ToString();
                            txtTelepon.Text = dr["telepon"].ToString();
                            txtPassword.Text = dr["password"].ToString();
                            txtEmail.Text = dr["email"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];
                txtSearch.Text = row.Cells["id_user"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
                txtTipeUser.Text = row.Cells["tipe_user"].Value.ToString();

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (conn = new SqlConnection(conString))
                    {
                        query = "INSERT INTO tbl_log (waktu, aktivitas, id_user) VALUES (@Waktu, @Aktivitas, @IdUser)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Waktu", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Aktivitas", "Logout");
                        cmd.Parameters.AddWithValue("@IdUser", FormLogin.id_user);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    return;
                }

                ResetInput();
                FormLogin.id_user = null;
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
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
            txtSearch.Text = (txtSearch.Text == "Search by Id") ? "" : txtSearch.Text;
        }

        private void txtSearchId_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = (txtSearch.Text == "") ? "Search by Id" : txtSearch.Text;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
    }
}
