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
        public FLog()
        {
            InitializeComponent();
            LoadData();
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

        }
    }
}
