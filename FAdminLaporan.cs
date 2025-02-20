using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FAdminLaporan : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn;
        private static SqlDataAdapter adp;
        private static SqlCommand cmd;
        private static string query;
        private static DataTable dt;
        private Timer timer;
        public FAdminLaporan()
        {
            InitializeComponent();
            InitializeTimer();
            LoadData();
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
        private void LoadData()
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    query = "SELECT * FROM tbl_transaksi";
                    adp = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridViewTransaksi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to switch the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormAdminUser kelolaUserForm = new FormAdminUser();
                kelolaUserForm.Show();
                this.Hide();
            }
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to switch the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormAdminLog logForm = new FormAdminLog();
                logForm.Show();
                this.Hide();
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dateStart.Text == dateEnd.Text)
            {
                MessageBox.Show("Date cannot be the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateStart.Value > dateEnd.Value)
            {
                MessageBox.Show("Date cannot be the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (conn = new SqlConnection(connString))
                    {
                        query = "SELECT * FROM tbl_transaksi WHERE tgl_transaksi BETWEEN @dateStart AND @dateEnd";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@dateStart", dateStart.Value.Date);
                        cmd.Parameters.AddWithValue("@dateEnd", dateEnd.Value.Date);
                        adp = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        adp.Fill(dt);
                        dataGridViewTransaksi.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    string query = "SELECT tgl_transaksi, SUM(total_bayar) AS total_bayar FROM tbl_transaksi GROUP BY tgl_transaksi";
                    cmd = new SqlCommand(query, conn);
                    adp = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adp.Fill(dt);

                    chartOmset.Series.Clear();
                    chartOmset.Series.Add("Omset");
                    chartOmset.Series["Omset"].XValueMember = "tgl_transaksi";
                    chartOmset.Series["Omset"].YValueMembers = "total_bayar";
                    chartOmset.DataSource = dt;
                    chartOmset.DataBind();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                FormLogin.id_user = null;
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
        }

        private void KelolaFormLaporan_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
