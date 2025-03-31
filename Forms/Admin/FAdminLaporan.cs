using Dapper;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace csharp_lksmart
{
    public partial class FormAdminLaporan : Form
    {
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static SqlConnection conn;
        private static SqlDataAdapter adp;
        private static SqlCommand cmd;
        private static string query;
        private static DataTable dt;
        private Timer timer;
        public FormAdminLaporan()
        {
            InitializeComponent();
            InitializeTimer();
            LoadData();
        }
        private bool ValidateInput()
        {
            if (dateStart.Value > dateEnd.Value || dateEnd.Value < dateStart.Value)
            {
                MessageBox.Show("Date tidak valid");
                return false;
            }
            return true;
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
        private async void LoadData()
        {
            var db = new DBHelpers();
            var conn = GlobalConfig.getConn();
            var a = await db.ToModelSP<MTransaksi>(conn, "usp_m_transaksi", null);
            dataGridViewLaporan.DataSource = a.ToList();
        }
        private void ResetInput()
        {
            dateStart.ResetText();
            dateEnd.ResetText();
            ResetChart();
        }
        private void ResetChart()
        {
            chartOmset.Series.Clear();
            chartOmset.DataSource = null;
            chartOmset.Series.Add("Omset");
        }
        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            FormAdminKelolaUser kelolaUserForm = new FormAdminKelolaUser();
            kelolaUserForm.Show();
            this.Hide();
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormAdminLogActivity logForm = new FormAdminLogActivity();
            logForm.Show();
            this.Hide();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterTable();
        }

        private async void FilterTable()
        {
            if (!ValidateInput()) return;
            var db = new DBHelpers();
            var conn = GlobalConfig.getConn();
            var p = new DynamicParameters();

            p.Add("dateStart", dateStart.Value.ToString("yyyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString("yyyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            var affected = await db.ToModel<MTransaksi>(conn, "SELECT tgl_transaksi, SUM(total_bayar) AS total_bayar FROM tbl_transaksi WHERE waktu BETWEEN @dateStart AND @dateEnd GROUP BY tgl_transaksi", p);
            dataGridViewLaporan.DataSource = affected.ToList();
        }
        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var db = new DBHelpers();
            var conn = GlobalConfig.getConn();
            var p = new DynamicParameters();

            p.Add("dateStart", dateStart.Value.ToString("yyyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString("yyyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            var affected = await db.ToModel<MTransaksi>(conn, "SELECT tgl_transaksi, SUM(total_bayar) AS total_bayar FROM tbl_transaksi WHERE waktu BETWEEN @dateStart AND @dateEnd GROUP BY tgl_transaksi", p);
            chartOmset.DataSource = affected.ToList();

            foreach (var item in affected)
            {
                chartOmset.Series["Omset"].Points.AddXY(item.tgl_transaksi, item.total_bayar);
            }
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Apakah anda yakin?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.getConn();
            var p = new DynamicParameters();
            p.Add("waktu", DateTime.Now, DbType.String, ParameterDirection.Input);
            p.Add("aktivitas", "Logout", DbType.String, ParameterDirection.Input);
            p.Add("id_user", FormLogin.userId, DbType.String, ParameterDirection.Input);
            var affected = await db.ExecuteAsyncSP(conn, "usp_insert_m_log", p);
            var formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void KelolaFormLaporan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetInput();
        }
    }
}
