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
    public partial class FormAdminLog : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlDataAdapter adp;
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static DataTable dt;
        private static string query;
        private Timer timer;
        public FormAdminLog()
        {
            InitializeComponent();
            LoadData();
            InitializeTimer();
        }
        private void LoadData()
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    query = "SELECT id_log, waktu, aktivitas, id_user FROM tbl_log";
                    adp = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridViewLogActivity.DataSource = dt;
                }
            }
            catch (Exception ex)
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
        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to switch the form?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetInput();
                FormAdminUser kelolaUserForm = new FormAdminUser();
                kelolaUserForm.Show();
                this.Hide();
            }
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
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dateStart.Value > dateEnd.Value)
            {
                MessageBox.Show("Start date cannot be higher than end date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateStart.Text == dateEnd.Text)
            {
                MessageBox.Show("Date cannot be the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (conn = new SqlConnection(connString))
                    {
                        query = "SELECT id_log, waktu, aktivitas, id_user FROM tbl_log WHERE waktu BETWEEN @DateStart AND @DateEnd";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@DateStart", dateStart.Value);
                        cmd.Parameters.AddWithValue("@DateEnd", dateEnd.Value);

                        adp = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        adp.Fill(dt);
                        dataGridViewLogActivity.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
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

                FormLogin.id_user = null;
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
        }
        private void ResetInput()
        {
            dateStart.ResetText();
            dateEnd.ResetText();
            dateStart.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
    }
}
