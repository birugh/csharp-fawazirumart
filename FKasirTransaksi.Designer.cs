namespace csharp_lksmart
{
    partial class FormKasirTransaksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGridViewKeranjang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelepon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantitas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHargaSatuan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxPilihMenu = new System.Windows.Forms.ComboBox();
            this.labelKasir = new System.Windows.Forms.Label();
            this.txtUang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBayar = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.labelKembalian = new System.Windows.Forms.Label();
            this.cboxNamaPelanggan = new System.Windows.Forms.ComboBox();
            this.labelTotalKeseluruhan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeranjang)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Kasir";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(431, 245);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(93, 24);
            this.btnTambah.TabIndex = 19;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(51, 332);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 47);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGridViewKeranjang
            // 
            this.dataGridViewKeranjang.AllowUserToAddRows = false;
            this.dataGridViewKeranjang.AllowUserToDeleteRows = false;
            this.dataGridViewKeranjang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeranjang.Location = new System.Drawing.Point(201, 291);
            this.dataGridViewKeranjang.Name = "dataGridViewKeranjang";
            this.dataGridViewKeranjang.ReadOnly = true;
            this.dataGridViewKeranjang.Size = new System.Drawing.Size(619, 347);
            this.dataGridViewKeranjang.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Form Transaksi";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(530, 245);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 24);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Pilihan Menu";
            // 
            // txtTelepon
            // 
            this.txtTelepon.Location = new System.Drawing.Point(201, 220);
            this.txtTelepon.Name = "txtTelepon";
            this.txtTelepon.Size = new System.Drawing.Size(192, 20);
            this.txtTelepon.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Telepon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Nama Pelanggan";
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Enabled = false;
            this.txtTotalHarga.Location = new System.Drawing.Point(431, 219);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.Size = new System.Drawing.Size(192, 20);
            this.txtTotalHarga.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Total Harga";
            // 
            // txtQuantitas
            // 
            this.txtQuantitas.Location = new System.Drawing.Point(431, 168);
            this.txtQuantitas.Name = "txtQuantitas";
            this.txtQuantitas.Size = new System.Drawing.Size(192, 20);
            this.txtQuantitas.TabIndex = 33;
            this.txtQuantitas.TextChanged += new System.EventHandler(this.txtQuantitas_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Quantitas";
            // 
            // txtHargaSatuan
            // 
            this.txtHargaSatuan.Enabled = false;
            this.txtHargaSatuan.Location = new System.Drawing.Point(431, 109);
            this.txtHargaSatuan.Name = "txtHargaSatuan";
            this.txtHargaSatuan.Size = new System.Drawing.Size(192, 20);
            this.txtHargaSatuan.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Harga Satuan";
            // 
            // cboxPilihMenu
            // 
            this.cboxPilihMenu.FormattingEnabled = true;
            this.cboxPilihMenu.Location = new System.Drawing.Point(201, 108);
            this.cboxPilihMenu.Name = "cboxPilihMenu";
            this.cboxPilihMenu.Size = new System.Drawing.Size(192, 21);
            this.cboxPilihMenu.TabIndex = 36;
            this.cboxPilihMenu.SelectedIndexChanged += new System.EventHandler(this.cboxPilihMenu_SelectedIndexChanged);
            // 
            // labelKasir
            // 
            this.labelKasir.AutoSize = true;
            this.labelKasir.Location = new System.Drawing.Point(853, 9);
            this.labelKasir.Name = "labelKasir";
            this.labelKasir.Size = new System.Drawing.Size(39, 13);
            this.labelKasir.TabIndex = 37;
            this.labelKasir.Text = "Kasir ?";
            // 
            // txtUang
            // 
            this.txtUang.Location = new System.Drawing.Point(251, 650);
            this.txtUang.Name = "txtUang";
            this.txtUang.Size = new System.Drawing.Size(133, 20);
            this.txtUang.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 653);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Cash";
            // 
            // btnBayar
            // 
            this.btnBayar.Location = new System.Drawing.Point(291, 676);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.Size = new System.Drawing.Size(93, 24);
            this.btnBayar.TabIndex = 40;
            this.btnBayar.Text = "Bayar";
            this.btnBayar.UseVisualStyleBackColor = true;
            this.btnBayar.Click += new System.EventHandler(this.btnBayar_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(727, 644);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 24);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(291, 706);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(93, 24);
            this.btnSimpan.TabIndex = 42;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // labelKembalian
            // 
            this.labelKembalian.AutoSize = true;
            this.labelKembalian.Location = new System.Drawing.Point(390, 682);
            this.labelKembalian.Name = "labelKembalian";
            this.labelKembalian.Size = new System.Drawing.Size(98, 13);
            this.labelKembalian.TabIndex = 43;
            this.labelKembalian.Text = "Jumlah Kembalian: ";
            // 
            // cboxNamaPelanggan
            // 
            this.cboxNamaPelanggan.FormattingEnabled = true;
            this.cboxNamaPelanggan.Location = new System.Drawing.Point(201, 168);
            this.cboxNamaPelanggan.Name = "cboxNamaPelanggan";
            this.cboxNamaPelanggan.Size = new System.Drawing.Size(192, 21);
            this.cboxNamaPelanggan.TabIndex = 44;
            this.cboxNamaPelanggan.SelectedIndexChanged += new System.EventHandler(this.cboxNamaPelanggan_SelectedIndexChanged);
            // 
            // labelTotalKeseluruhan
            // 
            this.labelTotalKeseluruhan.AutoSize = true;
            this.labelTotalKeseluruhan.Location = new System.Drawing.Point(390, 653);
            this.labelTotalKeseluruhan.Name = "labelTotalKeseluruhan";
            this.labelTotalKeseluruhan.Size = new System.Drawing.Size(102, 13);
            this.labelTotalKeseluruhan.TabIndex = 45;
            this.labelTotalKeseluruhan.Text = "Total Keseluruhan 0";
            // 
            // FormKasirTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 771);
            this.Controls.Add(this.labelTotalKeseluruhan);
            this.Controls.Add(this.cboxNamaPelanggan);
            this.Controls.Add(this.labelKembalian);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnBayar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUang);
            this.Controls.Add(this.labelKasir);
            this.Controls.Add(this.cboxPilihMenu);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQuantitas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHargaSatuan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelepon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dataGridViewKeranjang);
            this.Controls.Add(this.label1);
            this.Name = "FormKasirTransaksi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Transaksi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTransaksi_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeranjang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dataGridViewKeranjang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelepon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantitas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHargaSatuan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboxPilihMenu;
        private System.Windows.Forms.Label labelKasir;
        private System.Windows.Forms.TextBox txtUang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBayar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label labelKembalian;
        private System.Windows.Forms.ComboBox cboxNamaPelanggan;
        private System.Windows.Forms.Label labelTotalKeseluruhan;
    }
}