using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using csharp_lksmart.Forms.Admin;
using Dapper;

namespace csharp_lksmart
{
    public partial class FormGudangBarang : Form
    {
        private bool isFillingData;
        private string hasilCari;

        public FormGudangBarang()
        {
            InitializeComponent();
            TimerHelper.InitializeTimer(Timer_Tick);
            LoadData();
        }

        private async void LoadData()
        {
            var data = await LoadDataHelper.LoadDataModelSP<MBarang>("usp_m_barang");
            dataGridViewBarang.DataSource = data.ToList();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            TimerHelper.InitializeDateTime(labelDate, labelTime);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHargaSatuan.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahBarang.Text) ||
                string.IsNullOrWhiteSpace(txtKodeBarang.Text) ||
                string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtSatuan.Text) ||
                !long.TryParse(txtHargaSatuan.Text, out _) ||
                !long.TryParse(txtJumlahBarang.Text, out _) ||
                int.Parse(txtHargaSatuan.Text) <= 0 ||
                int.Parse(txtJumlahBarang.Text) <= 0)
            {
                MessageBox.Show("Input tidak valid.");
                return false;
            }
            return true;
        }

        private void ResetInput()
        {
            txtKodeBarang.Text = "";
            txtNamaBarang.Text = "";
            txtJumlahBarang.Text = "";
            txtSatuan.Text = "";
            txtHargaSatuan.Text = "";
            txtCari.Text = "Search by Id";
            dateExpired.Value = DateTime.Now;
            LoadData();
        }

        private async void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (!(MessageBox.Show("Apakah anda yakin ingin melakukan ini?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)) return;

            try
            {
                var db = new DBHelpers();
                var conn = GlobalConfig.GetConnection();
                var p = new DynamicParameters();

                p.Add("func", "create", DbType.String, ParameterDirection.Input);
                p.Add("kode_barang", txtKodeBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("jumlah_barang", txtJumlahBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("nama_barang", txtNamaBarang.Text, DbType.String, ParameterDirection.Input);
                p.Add("satuan", txtSatuan.Text, DbType.String, ParameterDirection.Input);
                p.Add("expired_date", dateExpired.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
                p.Add("harga_satuan", txtHargaSatuan.Text, DbType.String, ParameterDirection.Input);
                p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

                var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_barang", p);

                int status = p.Get<int>("status");
                if (status == 2)
                {
                    MessageBox.Show("Username atau telepon sudah digunakan.");
                    return;
                }
                else if (status == 1)
                {
                    MessageBox.Show("Data berhasil ditambahkan.");
                    LoadData();
                    return;
                }
                else
                {
                    MessageBox.Show("Terjadi kesalahan.");
                }

                LoadData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBox.Show("Please fill out all fields and provide a valid Search Id.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            //if (!int.TryParse(txtCari.Text, out _) || !int.TryParse(txtHargaSatuan.Text, out _) || !int.TryParse(txtJumlahBarang.Text, out _))
            //{
            //    MessageBox.Show("Input must be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (!(MessageBox.Show("Apakah anda yakin ingin melakukan ini?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "update", DbType.String, ParameterDirection.Input);
            p.Add("id_barang", hasilCari, DbType.String, ParameterDirection.Input);
            p.Add("kode_barang", txtKodeBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("jumlah_barang", txtJumlahBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("nama_barang", txtNamaBarang.Text, DbType.String, ParameterDirection.Input);
            p.Add("satuan", txtSatuan.Text, DbType.String, ParameterDirection.Input);
            p.Add("expired_date", dateExpired.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            p.Add("harga_satuan", txtHargaSatuan.Text, DbType.String, ParameterDirection.Input);
            p.Add("status", DbType.Int16, direction: ParameterDirection.Output);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_barang", p);

            int status = p.Get<int>("status");
            if (status == 2)
            {
                MessageBox.Show("Username atau telepon sudah digunakan.");
                return;
            }
            else if (status == 1)
            {
                MessageBox.Show("Data berhasil diupdate.");
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan.");
            }

            LoadData();
            btnReset_Click(null, null);
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                MessageBox.Show("Please provide a valid Kode Barang.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            if (!(MessageBox.Show("Apakah anda yakin ingin melakukan ini?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)) return;

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("func", "delete", DbType.String, ParameterDirection.Input);
            p.Add("id_barang", hasilCari, DbType.String, ParameterDirection.Input);

            var res = await db.ExecuteAsyncSP(conn, "usp_create_update_delete_m_barang", p);

            if (res == null)
            {
                MessageBox.Show("Proses hapus data gagal");
                return;
            }

            MessageBox.Show("Data berhasil di hapus");
            LoadData();
        }

        private async void btnCari_Click(object sender, EventArgs e)
        {
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
        }

        private void FormGudang_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridViewBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex >= 0))
            {
                return;
            }

            isFillingData = true;
            DataGridViewRow row = dataGridViewBarang.Rows[e.RowIndex];
            txtKodeBarang.Text = row.Cells["kode_barang"].Value.ToString();
            txtNamaBarang.Text = row.Cells["nama_barang"].Value.ToString();
            txtJumlahBarang.Text = row.Cells["jumlah_barang"].Value.ToString();
            txtSatuan.Text = row.Cells["satuan"].Value.ToString();
            dateExpired.Value = Convert.ToDateTime(row.Cells["expired_date"].Value);
            txtHargaSatuan.Text = row.Cells["harga_satuan"].Value.ToString();
            txtCari.Text = row.Cells["nama_barang"].Value.ToString();
            hasilCari = row.Cells["id_barang"].Value.ToString();
            isFillingData = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
        }

        private async void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (isFillingData == true) return;

            if (string.IsNullOrWhiteSpace(txtCari.Text))
            {
                LoadData();
                return;
            }

            var db = new DBHelpers();
            var conn = GlobalConfig.GetConnection();
            var p = new DynamicParameters();

            p.Add("nama_barang", txtCari.Text + "%", DbType.String, ParameterDirection.Input);

            var res = await db.ToSingleModel<MBarang>(conn, "SELECT * FROM tbl_barang WHERE nama_barang LIKE @nama_barang", p);

            if (res == null)
            {
                return;
            }

            dataGridViewBarang.DataSource = new List<MBarang> { res };
            txtHargaSatuan.Text = res.harga_satuan.ToString();
            txtJumlahBarang.Text = res.jumlah_barang.ToString();
            txtKodeBarang.Text = res.kode_barang;
            txtNamaBarang.Text = res.nama_barang;
            txtSatuan.Text = res.satuan;
            dateExpired.Value = res.expired_date;
            hasilCari = res.id_barang.ToString();
        }
    }
}