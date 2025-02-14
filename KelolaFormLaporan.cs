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
    public partial class KelolaFormLaporan : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private Timer timer;
        public KelolaFormLaporan()
        {
            InitializeComponent();
            InitializeTimer();
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
            MessageBox.Show("You are in this form right now.");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FLog logForm = new FLog();
            logForm.Show();
            this.Hide();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbl_transaksi WHERE tgl_transaksi BETWEEN @dateStart AND @dateEnd";
            using (conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dateStart", dateStart.Value.Date);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd.Value.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewTransaksi.DataSource = dt;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }
    }
}
