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

namespace csharp_lksmart
{
    public partial class FormAdminLogActivity : Form
    {
        private Timer timer;
        public FormAdminLogActivity()
        {
            InitializeComponent();
            LoadData();
            InitializeTimer();
        }
        private async void LoadData()
        {
            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var a = await db.ToModelSP<MLog>(conn, "usp_m_log", null);
            dataGridViewLogActivity.DataSource = a.ToList();
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
            ResetInput();
            FormAdminKelolaUser kelolaUserForm = new FormAdminKelolaUser();
            kelolaUserForm.Show();
            this.Hide();
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            ResetInput();
            FormAdminLaporan laporanForm = new FormAdminLaporan();
            laporanForm.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are in this form right now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (dateStart.Value > dateEnd.Value || dateEnd.Value < dateStart.Value)
            {
                MessageBox.Show("Data tidak value");
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConn();
            var p = new DynamicParameters();
            p.Add("dateStart", dateStart.Value.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString(), DbType.String, ParameterDirection.Input);
            var a = await db.ToModel<MLog>(conn, "select id_log, waktu, aktivitas, username from tbl_log inner join tbl_user on tbl_log.id_user = tbl_user.id_user WHERE waktu BETWEEN @dateStart AND @dateEnd", p);
            dataGridViewLogActivity.DataSource = a.ToList();
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

        private void FormAdminLogActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
