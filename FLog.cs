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
    public partial class FLog : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private Timer timer;
        public FLog()
        {
            InitializeComponent();
            LoadData();
            InitializeTimer();
        }
        private void LoadData()
        {
            string query = "SELECT id_log, waktu, aktivitas, id_user FROM tbl_log";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (conn)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
            FKelolaUser kelolaUserForm = new FKelolaUser();
            kelolaUserForm.Show();
            this.Hide();
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            KelolaFormLaporan kelolaLaporanForm = new KelolaFormLaporan();
            kelolaLaporanForm.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_log, waktu, aktivitas, id_user FROM tbl_log WHERE waktu BETWEEN @DateStart AND @DateEnd";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DateStart", dateStart.Value);
                    cmd.Parameters.AddWithValue("@DateEnd", dateEnd.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tbl_log (waktu, aktivitas, id_user) VALUES (@Waktu, @Aktivitas, @IdUser)";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Waktu", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Aktivitas", "Logout");
                    cmd.Parameters.AddWithValue("@IdUser", FormLogin.id_user);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            // Add logic to handle the actual logout process, e.g., closing the form or redirecting to a login form
            this.Close();
        }
    }
}
