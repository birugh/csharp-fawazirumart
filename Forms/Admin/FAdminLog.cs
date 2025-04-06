using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;
using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FormAdminLogActivity : Form
    {
        public FormAdminLogActivity()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            LoadData();
        }

        private async void LoadData()
        {
            var data = await LoadDataHelper.LoadDataModelSP<MLog>("usp_m_log");
            dataGridViewLogActivity.DataSource = data.ToList();
        }

        private void ResetInput()
        {
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
            dateStart.Focus();
            LoadData();
        }

        private bool ValidateDate()
        {
            if (dateStart.Value > dateEnd.Value)
            {
                MessageBoxHelper.ShowWarning("Batas waktu awal tidak valid!");
                dateStart.Focus();
                return false;
            }
            else if (dateEnd.Value < dateStart.Value)
            {
                MessageBoxHelper.ShowWarning("Batas waktu terakhir tidak valid!");
                dateEnd.Focus();
                return false;
            }
            return true;
        }

        private async void FilterDate()
        {
            if (!ValidateDate()) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("dateStart", dateStart.Value.ToString(), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString(), DbType.String, ParameterDirection.Input);
            var a = await db.ToModel<MLog>(conn, "select id_log, waktu, aktivitas, username from tbl_log inner join tbl_user on tbl_log.id_user = tbl_user.id_user WHERE waktu BETWEEN @dateStart AND @dateEnd", p);

            dataGridViewLogActivity.DataSource = a.ToList();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            FilterDate();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            FilterDate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminKelolaUser>(this);
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminKelolaUser>(this);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            MessageBoxHelper.ShowWarning("Anda saat ini berada di formnya!");
        }

        private void FormAdminLogActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }
    }
}