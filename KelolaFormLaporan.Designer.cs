namespace csharp_lksmart
{
    partial class KelolaFormLaporan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnKelolaLaporan = new System.Windows.Forms.Button();
            this.btnKelolaUser = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(819, 44);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(23, 13);
            this.labelTime.TabIndex = 46;
            this.labelTime.Text = "jam";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(712, 21);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(130, 13);
            this.labelDate.TabIndex = 45;
            this.labelDate.Text = "hari, tanggal, bulan, tahun";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Admin";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(45, 381);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(93, 47);
            this.btnLog.TabIndex = 42;
            this.btnLog.Text = "Log Activity";
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // btnKelolaLaporan
            // 
            this.btnKelolaLaporan.Location = new System.Drawing.Point(45, 304);
            this.btnKelolaLaporan.Name = "btnKelolaLaporan";
            this.btnKelolaLaporan.Size = new System.Drawing.Size(93, 47);
            this.btnKelolaLaporan.TabIndex = 41;
            this.btnKelolaLaporan.Text = "Kelola Laporan";
            this.btnKelolaLaporan.UseVisualStyleBackColor = true;
            // 
            // btnKelolaUser
            // 
            this.btnKelolaUser.Location = new System.Drawing.Point(45, 229);
            this.btnKelolaUser.Name = "btnKelolaUser";
            this.btnKelolaUser.Size = new System.Drawing.Size(93, 47);
            this.btnKelolaUser.TabIndex = 40;
            this.btnKelolaUser.Text = "Kelola User";
            this.btnKelolaUser.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(217, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(566, 277);
            this.dataGridView1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Kelola User";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(774, 395);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(93, 47);
            this.btnGenerate.TabIndex = 60;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(217, 425);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(530, 276);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(278, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 62;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(484, 70);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 63;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(690, 59);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(93, 47);
            this.btnFilter.TabIndex = 64;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // KelolaFormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 713);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnKelolaLaporan);
            this.Controls.Add(this.btnKelolaUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "KelolaFormLaporan";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnFilter;
    }
}