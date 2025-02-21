namespace csharp_lksmart
{
    partial class FAdminLaporan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnKelolaLaporan = new System.Windows.Forms.Button();
            this.btnKelolaUser = new System.Windows.Forms.Button();
            this.dataGridViewTransaksi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chartOmset = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransaksi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOmset)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(836, 32);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(49, 13);
            this.labelTime.TabIndex = 46;
            this.labelTime.Text = "00:00;00";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(820, 9);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(65, 13);
            this.labelDate.TabIndex = 45;
            this.labelDate.Text = "0000/00/00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Admin";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(57, 357);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(93, 47);
            this.btnLog.TabIndex = 42;
            this.btnLog.Text = "Log Activity";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnKelolaLaporan
            // 
            this.btnKelolaLaporan.Location = new System.Drawing.Point(57, 280);
            this.btnKelolaLaporan.Name = "btnKelolaLaporan";
            this.btnKelolaLaporan.Size = new System.Drawing.Size(93, 47);
            this.btnKelolaLaporan.TabIndex = 41;
            this.btnKelolaLaporan.Text = "Kelola Laporan";
            this.btnKelolaLaporan.UseVisualStyleBackColor = true;
            this.btnKelolaLaporan.Click += new System.EventHandler(this.btnKelolaLaporan_Click);
            // 
            // btnKelolaUser
            // 
            this.btnKelolaUser.Location = new System.Drawing.Point(57, 205);
            this.btnKelolaUser.Name = "btnKelolaUser";
            this.btnKelolaUser.Size = new System.Drawing.Size(93, 47);
            this.btnKelolaUser.TabIndex = 40;
            this.btnKelolaUser.Text = "Kelola User";
            this.btnKelolaUser.UseVisualStyleBackColor = true;
            this.btnKelolaUser.Click += new System.EventHandler(this.btnKelolaUser_Click);
            // 
            // dataGridViewTransaksi
            // 
            this.dataGridViewTransaksi.AllowUserToAddRows = false;
            this.dataGridViewTransaksi.AllowUserToDeleteRows = false;
            this.dataGridViewTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransaksi.Location = new System.Drawing.Point(217, 144);
            this.dataGridViewTransaksi.Name = "dataGridViewTransaksi";
            this.dataGridViewTransaksi.ReadOnly = true;
            this.dataGridViewTransaksi.Size = new System.Drawing.Size(649, 258);
            this.dataGridViewTransaksi.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Kelola Laporan";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(423, 102);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(93, 29);
            this.btnGenerate.TabIndex = 60;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chartOmset
            // 
            chartArea4.Name = "ChartArea1";
            this.chartOmset.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartOmset.Legends.Add(legend4);
            this.chartOmset.Location = new System.Drawing.Point(217, 425);
            this.chartOmset.Name = "chartOmset";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartOmset.Series.Add(series4);
            this.chartOmset.Size = new System.Drawing.Size(649, 276);
            this.chartOmset.TabIndex = 61;
            this.chartOmset.Text = "chart1";
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(217, 76);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 20);
            this.dateStart.TabIndex = 62;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(423, 76);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 63;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(530, 102);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(93, 29);
            this.btnFilter.TabIndex = 64;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(57, 439);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 47);
            this.btnLogout.TabIndex = 65;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 66;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FAdminLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 713);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.chartOmset);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnKelolaLaporan);
            this.Controls.Add(this.btnKelolaUser);
            this.Controls.Add(this.dataGridViewTransaksi);
            this.Controls.Add(this.label1);
            this.Name = "FAdminLaporan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Laporan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KelolaFormLaporan_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransaksi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOmset)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewTransaksi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOmset;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button1;
    }
}