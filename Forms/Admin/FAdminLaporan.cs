using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;
using csharp_lksmart.Models;
using Dapper;

namespace csharp_lksmart
{
    public partial class FormAdminLaporan : Form
    {
        public FormAdminLaporan()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            dateStart.ValueChanged -= dateStart_ValueChanged;
            dateEnd.ValueChanged -= dateEnd_ValueChanged;
            dateStart.Value = DateTime.Now.Date.AddDays(-1);
            dateEnd.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
            dateStart.ValueChanged += dateStart_ValueChanged;
            dateEnd.ValueChanged += dateEnd_ValueChanged;
            LoadData();
        }

        private bool ValidateDate()
        {
            if (dateStart.Value > dateEnd.Value)
            {
                MessageBoxHelper.ShowWarning("Batas waktu awal tid%ak valid!" + dateStart.Value + " " + dateEnd.Value);
                ResetInput();
                return false;
            }
            else if (dateEnd.Value < dateStart.Value)
            {
                MessageBoxHelper.ShowWarning("Batas waktu terakhir tidak valid!");
                ResetInput();
                return false;
            }
            return true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private async void LoadData()
        {
            var data = await LoadDataHelper.LoadDataModelSP<MTransaksi>("usp_m_transaksi");
            dataGridViewLaporan.DataSource = data.ToList();
        }

        private void ResetInput()
        {
            dateStart.ValueChanged -= dateStart_ValueChanged;
            dateEnd.ValueChanged -= dateEnd_ValueChanged;

            dateEnd.Value = DateTime.Now;
            dateStart.Value = DateTime.Now;
            dateStart.Focus();
            ResetChart();
            LoadData();

            dateStart.ValueChanged += dateStart_ValueChanged;
            dateEnd.ValueChanged += dateEnd_ValueChanged;
        }

        private void ResetChart()
        {
            chartOmset.DataSource = null;
            chartOmset.Series.Clear();
            chartOmset.Series.Add("Omset");
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminKelolaUser>(this);
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            MessageBoxHelper.ShowWarning("Anda saat ini berada di formnya!");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FormAdminLogActivity>(this);
        }

        private async void GenerateChart()
        {
            if (!ValidateDate()) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("dateStart", dateStart.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);

            var data = await db.ToModelSP<MLaporan>(conn, "usp_group_m_transaksi", p);

            dataGridViewLaporan.DataSource = null;
            dataGridViewLaporan.DataSource = data.ToList();

            ResetChart();
            foreach (var item in data)
            {
                chartOmset.Series["Omset"].Points.AddXY(item.tgl_transaksi, item.total_bayar);
            }
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this, FormLogin.userName);
        }

        private void KelolaFormLaporan_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingHelper.FormClosing(e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            GenerateChart();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            GenerateChart();
        }

        private void btnKelolaPelanggan_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FAdminPelanggan>(this);
        }

        private void dataGridViewLaporan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}