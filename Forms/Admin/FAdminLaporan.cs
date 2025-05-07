using csharp_lksmart.Forms.Admin;
using csharp_lksmart.Helpers;
using csharp_lksmart.Models;
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
        public FormAdminLaporan()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            LoadData();
        }

        private bool ValidateDate()
        {
            if (dateStart.Value > dateEnd.Value)
            {
                MessageBoxHelper.ShowWarning("Batas waktu awal tidak valid!"+ dateStart.Value + " "+dateEnd.Value);
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

        private async void FilterData()
        {
            if (!ValidateDate()) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("dateStart", dateStart.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            
            var data = await db.ToModel<MLaporan>(conn, "SELECT tgl_transaksi, SUM(total_bayar) AS total_bayar FROM tbl_transaksi WHERE tgl_transaksi BETWEEN @dateStart AND @dateEnd GROUP BY tgl_transaksi", p);

            dataGridViewLaporan.DataSource = null;
            dataGridViewLaporan.DataSource = data.ToList();
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!ValidateDate()) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("dateStart", dateStart.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("dateEnd", dateEnd.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);

            var data = await db.ToModel<MLaporan>(conn, "SELECT tgl_transaksi, SUM(total_bayar) AS total_bayar FROM tbl_transaksi WHERE tgl_transaksi BETWEEN @dateStart AND @dateEnd GROUP BY tgl_transaksi", p);
            chartOmset.DataSource = data.ToList();

            ResetChart();
            foreach (var item in data)
            {
                chartOmset.Series["Omset"].Points.AddXY(item.tgl_transaksi, item.total_bayar);
            }
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await LogoutHelper.LogoutAsync(this);
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
            FilterData();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnKelolaPelanggan_Click(object sender, EventArgs e)
        {
            FormClosingHelper.FormChanging<FAdminPelanggan>(this);
        }
    }
}