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
    public partial class FormGudangBarang : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adp;
        private static SqlDataReader dr;
        private static DataTable dt;
        private static DataView dv;
        private static string query;
        private Timer timer;
        public FormGudangBarang()
        {
            InitializeComponent();
            LoadBarangData();
            InitializeTimer();
        }
        private void LoadBarangData()
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    query = "SELECT * FROM tbl_barang";
                    adp = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridViewBarang.DataSource = dt;
                    dv = new DataView(dt);
                    dataGridViewBarang.DataSource = dv;
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
            if (string.IsNullOrWhiteSpace(txtKodeBarang.Text) ||
                string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahBarang.Text) ||
                string.IsNullOrWhiteSpace(txtSatuan.Text) ||
                string.IsNullOrWhiteSpace(txtHargaSatuan.Text) ||
                dateExpiredDate.Value == null)
            {
                MessageBox.Show("All fields must be filled out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool ValidateLogout()
        {
            if (!string.IsNullOrWhiteSpace(txtKodeBarang.Text) ||
                !string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                !string.IsNullOrWhiteSpace(txtJumlahBarang.Text) ||
                !string.IsNullOrWhiteSpace(txtSatuan.Text) ||
                !string.IsNullOrWhiteSpace(txtHargaSatuan.Text))
            {
                return true;
            }
            return false;
        }
        private void ResetInput()
        {
            txtKodeBarang.Text = "";
            txtNamaBarang.Text = "";
            txtJumlahBarang.Text = "";
            txtSatuan.Text = "";
            txtHargaSatuan.Text = "";
            txtSearch.Text = "Search by Id";
            dateExpiredDate.Value = DateTime.Now;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            else if (!int.TryParse(txtSearch.Text, out _) || !int.TryParse(txtHargaSatuan.Text, out _) || !int.TryParse(txtJumlahBarang.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    query = "INSERT INTO tbl_barang (kode_barang, nama_barang, jumlah_barang, satuan, expired_date, harga_satuan) VALUES (@kode_barang, @nama_barang, @jumlah_barang, @satuan, @expired_date, @harga_satuan)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kode_barang", txtKodeBarang.Text);
                    cmd.Parameters.AddWithValue("@nama_barang", txtNamaBarang.Text);
                    cmd.Parameters.AddWithValue("@jumlah_barang", txtJumlahBarang.Text);
                    cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text);
                    cmd.Parameters.AddWithValue("@expired_date", dateExpiredDate.Value);
                    cmd.Parameters.AddWithValue("@harga_satuan", txtHargaSatuan.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Barang added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetInput();
                    LoadBarangData();
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
            else if (!int.TryParse(txtSearch.Text, out _) || !int.TryParse(txtHargaSatuan.Text, out _) || !int.TryParse(txtJumlahBarang.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Please check your data again, are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (conn = new SqlConnection(connString))
                        {
                            query = "UPDATE tbl_barang SET kode_barang=@kode_barang, nama_barang=@nama_barang, jumlah_barang=@jumlah_barang, satuan=@satuan, expired_date=@expired_date, harga_satuan=@harga_satuan WHERE id_barang=@id_barang";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id_barang", txtSearch.Text);
                            cmd.Parameters.AddWithValue("@kode_barang", txtKodeBarang.Text);
                            cmd.Parameters.AddWithValue("@nama_barang", txtNamaBarang.Text);
                            cmd.Parameters.AddWithValue("@jumlah_barang", txtJumlahBarang.Text);
                            cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text);
                            cmd.Parameters.AddWithValue("@expired_date", dateExpiredDate.Value);
                            cmd.Parameters.AddWithValue("@harga_satuan", txtHargaSatuan.Text);

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Barang updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInput();
                            LoadBarangData();
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search by Id")
            {
                MessageBox.Show("Please provide a valid Kode Barang.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        using (conn = new SqlConnection(connString))
                        {
                            query = "DELETE FROM tbl_barang WHERE id_barang=@id_barang";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id_barang", txtSearch.Text);

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Barang deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetInput();
                            LoadBarangData();
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (ValidateLogout() == true)
            {
                if (MessageBox.Show("There is unsaved data, continue to switch form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (conn = new SqlConnection(connString))
                        {
                            query = "INSERT INTO tbl_log (waktu, aktivitas, id_user) VALUES (@Waktu, @Aktivitas, @IdUser)";
                            SqlCommand cmd = new SqlCommand(query, conn);
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
            else
            {
                ResetInput();
                FormLogin.id_user = null;
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please provide a valid Kode Barang.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtSearch.Text, out _))
            {
                MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dv.RowFilter = $"id_barang   = {txtSearch.Text}";
                try
                {
                    using (conn = new SqlConnection(connString))
                    {
                        query = "SELECT * FROM tbl_barang WHERE id_barang=@id_barang";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_barang", txtSearch.Text);

                        conn.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            txtKodeBarang.Text = dr["kode_barang"].ToString();
                            txtNamaBarang.Text = dr["nama_barang"].ToString();
                            dateExpiredDate.Value = Convert.ToDateTime(dr["expired_date"]);
                            txtJumlahBarang.Text = dr["jumlah_barang"].ToString();
                            txtSatuan.Text = dr["satuan"].ToString();
                            txtHargaSatuan.Text = dr["harga_satuan"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Barang not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = (txtSearch.Text == "Search by Id") ? "" : txtSearch.Text;
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = (txtSearch.Text == "") ? "Search by Id" : txtSearch.Text;
        }

        private void FormGudang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBarangData();
        }

        private void dataGridViewBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewBarang.Rows[e.RowIndex];
                txtKodeBarang.Text = row.Cells["kode_barang"].Value.ToString();
                txtNamaBarang.Text = row.Cells["nama_barang"].Value.ToString();
                txtJumlahBarang.Text = row.Cells["jumlah_barang"].Value.ToString();
                txtSatuan.Text = row.Cells["satuan"].Value.ToString();
                dateExpiredDate.Value = Convert.ToDateTime(row.Cells["expired_date"].Value);
                txtHargaSatuan.Text = row.Cells["harga_satuan"].Value.ToString();
                txtSearch.Text = row.Cells["id_barang"].Value.ToString();
            }
        }
    }
}
