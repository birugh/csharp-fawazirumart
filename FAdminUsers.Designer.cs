namespace csharp_lksmart
{
    partial class FormAdminUser
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
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnKelolaLaporan = new System.Windows.Forms.Button();
            this.btnKelolaUser = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtTipeUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelepon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(753, 33);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(49, 13);
            this.labelTime.TabIndex = 22;
            this.labelTime.Text = "00:00:00";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(737, 9);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(65, 13);
            this.labelDate.TabIndex = 21;
            this.labelDate.Text = "0000/00/00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Admin";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(43, 351);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(93, 47);
            this.btnLog.TabIndex = 18;
            this.btnLog.Text = "Log Activity";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnKelolaLaporan
            // 
            this.btnKelolaLaporan.Location = new System.Drawing.Point(43, 274);
            this.btnKelolaLaporan.Name = "btnKelolaLaporan";
            this.btnKelolaLaporan.Size = new System.Drawing.Size(93, 47);
            this.btnKelolaLaporan.TabIndex = 17;
            this.btnKelolaLaporan.Text = "Kelola Laporan";
            this.btnKelolaLaporan.UseVisualStyleBackColor = true;
            this.btnKelolaLaporan.Click += new System.EventHandler(this.btnKelolaLaporan_Click);
            // 
            // btnKelolaUser
            // 
            this.btnKelolaUser.Location = new System.Drawing.Point(43, 199);
            this.btnKelolaUser.Name = "btnKelolaUser";
            this.btnKelolaUser.Size = new System.Drawing.Size(93, 47);
            this.btnKelolaUser.TabIndex = 16;
            this.btnKelolaUser.Text = "Kelola User";
            this.btnKelolaUser.UseVisualStyleBackColor = true;
            this.btnKelolaUser.Click += new System.EventHandler(this.btnKelolaUser_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(176, 320);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.Size = new System.Drawing.Size(619, 377);
            this.dataGridViewUsers.TabIndex = 15;
            this.dataGridViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kelola User";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(405, 233);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(93, 31);
            this.btnTambah.TabIndex = 19;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // txtTipeUser
            // 
            this.txtTipeUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTipeUser.Location = new System.Drawing.Point(176, 109);
            this.txtTipeUser.Name = "txtTipeUser";
            this.txtTipeUser.Size = new System.Drawing.Size(193, 20);
            this.txtTipeUser.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tipe User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(176, 148);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(193, 20);
            this.txtNama.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Telepon";
            // 
            // txtTelepon
            // 
            this.txtTelepon.Location = new System.Drawing.Point(176, 194);
            this.txtTelepon.Name = "txtTelepon";
            this.txtTelepon.Size = new System.Drawing.Size(193, 20);
            this.txtTelepon.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Alamat";
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(176, 233);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(193, 71);
            this.txtAlamat.TabIndex = 31;
            this.txtAlamat.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(402, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(405, 109);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(193, 20);
            this.txtUsername.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(402, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(405, 152);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(193, 20);
            this.txtPassword.TabIndex = 34;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(702, 165);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 24);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(702, 195);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(93, 26);
            this.btnHapus.TabIndex = 37;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(405, 194);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(193, 20);
            this.txtEmail.TabIndex = 38;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(702, 107);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(93, 20);
            this.txtSearch.TabIndex = 40;
            this.txtSearch.Text = "Search by Id";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearchId_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearchId_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(702, 134);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 24);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Cari";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(43, 426);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 47);
            this.btnLogout.TabIndex = 44;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(505, 233);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 31);
            this.btnReset.TabIndex = 45;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FormAdminUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 711);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTelepon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipeUser);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnKelolaLaporan);
            this.Controls.Add(this.btnKelolaUser);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.label1);
            this.Name = "FormAdminUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Kelola User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FKelolaUser_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnKelolaLaporan;
        private System.Windows.Forms.Button btnKelolaUser;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtTipeUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelepon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txtAlamat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReset;
    }
}