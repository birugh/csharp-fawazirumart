using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_lksmart
{
    public partial class FGudang : Form
    {
        public FGudang()
        {
            InitializeComponent();
            LoadBarangData();
            UpdateDateTime();
        }
        private void LoadBarangData()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnector.ConnectionString))
            {
                string query = "SELECT * FROM tbl_barang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void UpdateDateTime()
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtKodeBarang.Text) ||
                string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahBarang.Text) ||
                string.IsNullOrWhiteSpace(txtSatuan.Text) ||
                string.IsNullOrWhiteSpace(txtHargaSatuan.Text) ||
                dateTimePickerExpiredDate.Value == null)
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }
            return true;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {

        }
    }
}
