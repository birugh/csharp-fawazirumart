namespace csharp_lksmart
{
    partial class FormAdminLogActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminLogActivity));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.dateEnd = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.dateStart = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.labelTime = new Bunifu.UI.WinForms.BunifuLabel();
            this.labelDate = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnReset = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dataGridViewLogActivity = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.cboxSearch = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnKelolaPelanggan = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnLogout = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnLogActivity = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnKelolaUser = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuLabel8 = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKelolaLaporan = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogActivity)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEnd
            // 
            this.dateEnd.BackColor = System.Drawing.Color.Transparent;
            this.dateEnd.BorderRadius = 2;
            this.dateEnd.Color = System.Drawing.Color.Silver;
            this.dateEnd.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dateEnd.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dateEnd.DisabledColor = System.Drawing.Color.Gray;
            this.dateEnd.DisplayWeekNumbers = false;
            this.dateEnd.DPHeight = 0;
            this.dateEnd.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateEnd.FillDatePicker = false;
            this.dateEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateEnd.ForeColor = System.Drawing.Color.Black;
            this.dateEnd.Icon = ((System.Drawing.Image)(resources.GetObject("dateEnd.Icon")));
            this.dateEnd.IconColor = System.Drawing.Color.Gray;
            this.dateEnd.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dateEnd.LeftTextMargin = 5;
            this.dateEnd.Location = new System.Drawing.Point(515, 142);
            this.dateEnd.MinimumSize = new System.Drawing.Size(4, 32);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(195, 32);
            this.dateEnd.TabIndex = 37;
            this.dateEnd.Value = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // dateStart
            // 
            this.dateStart.BackColor = System.Drawing.Color.Transparent;
            this.dateStart.BorderRadius = 4;
            this.dateStart.Color = System.Drawing.Color.Silver;
            this.dateStart.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dateStart.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dateStart.DisabledColor = System.Drawing.Color.Gray;
            this.dateStart.DisplayWeekNumbers = false;
            this.dateStart.DPHeight = 0;
            this.dateStart.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateStart.FillDatePicker = false;
            this.dateStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateStart.ForeColor = System.Drawing.Color.Black;
            this.dateStart.Icon = ((System.Drawing.Image)(resources.GetObject("dateStart.Icon")));
            this.dateStart.IconColor = System.Drawing.Color.Gray;
            this.dateStart.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dateStart.LeftTextMargin = 5;
            this.dateStart.Location = new System.Drawing.Point(314, 142);
            this.dateStart.MinimumSize = new System.Drawing.Size(4, 32);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(195, 32);
            this.dateStart.TabIndex = 38;
            this.dateStart.Value = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // labelTime
            // 
            this.labelTime.AllowParentOverrides = false;
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoEllipsis = false;
            this.labelTime.CursorType = null;
            this.labelTime.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.labelTime.Location = new System.Drawing.Point(918, 33);
            this.labelTime.Name = "labelTime";
            this.labelTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTime.Size = new System.Drawing.Size(54, 22);
            this.labelTime.TabIndex = 35;
            this.labelTime.Text = "00:00:00";
            this.labelTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTime.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // labelDate
            // 
            this.labelDate.AllowParentOverrides = false;
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoEllipsis = false;
            this.labelDate.CursorType = null;
            this.labelDate.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.labelDate.Location = new System.Drawing.Point(896, 13);
            this.labelDate.Name = "labelDate";
            this.labelDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelDate.Size = new System.Drawing.Size(76, 22);
            this.labelDate.TabIndex = 36;
            this.labelDate.Text = "0000/00/00";
            this.labelDate.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDate.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnReset
            // 
            this.btnReset.AllowAnimations = true;
            this.btnReset.AllowMouseEffects = true;
            this.btnReset.AllowToggling = false;
            this.btnReset.AnimationSpeed = 200;
            this.btnReset.AutoGenerateColors = false;
            this.btnReset.AutoRoundBorders = false;
            this.btnReset.AutoSizeLeftIcon = true;
            this.btnReset.AutoSizeRightIcon = true;
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackColor1 = System.Drawing.Color.Crimson;
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.ButtonText = "Reset";
            this.btnReset.ButtonTextMarginLeft = 0;
            this.btnReset.ColorContrastOnClick = 45;
            this.btnReset.ColorContrastOnHover = 45;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnReset.CustomizableEdges = borderEdges1;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReset.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReset.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReset.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Idle;
            this.btnReset.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnReset.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnReset.IconMarginLeft = 11;
            this.btnReset.IconPadding = 10;
            this.btnReset.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnReset.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnReset.IconSize = 25;
            this.btnReset.IdleBorderColor = System.Drawing.Color.Crimson;
            this.btnReset.IdleBorderRadius = 8;
            this.btnReset.IdleBorderThickness = 1;
            this.btnReset.IdleFillColor = System.Drawing.Color.Crimson;
            this.btnReset.IdleIconLeftImage = null;
            this.btnReset.IdleIconRightImage = null;
            this.btnReset.IndicateFocus = false;
            this.btnReset.Location = new System.Drawing.Point(870, 142);
            this.btnReset.Name = "btnReset";
            this.btnReset.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReset.OnDisabledState.BorderRadius = 8;
            this.btnReset.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.OnDisabledState.BorderThickness = 1;
            this.btnReset.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReset.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReset.OnDisabledState.IconLeftImage = null;
            this.btnReset.OnDisabledState.IconRightImage = null;
            this.btnReset.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(80)))), ((int)(((byte)(106)))));
            this.btnReset.onHoverState.BorderRadius = 8;
            this.btnReset.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.onHoverState.BorderThickness = 1;
            this.btnReset.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(80)))), ((int)(((byte)(106)))));
            this.btnReset.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnReset.onHoverState.IconLeftImage = null;
            this.btnReset.onHoverState.IconRightImage = null;
            this.btnReset.OnIdleState.BorderColor = System.Drawing.Color.Crimson;
            this.btnReset.OnIdleState.BorderRadius = 8;
            this.btnReset.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.OnIdleState.BorderThickness = 1;
            this.btnReset.OnIdleState.FillColor = System.Drawing.Color.Crimson;
            this.btnReset.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnReset.OnIdleState.IconLeftImage = null;
            this.btnReset.OnIdleState.IconRightImage = null;
            this.btnReset.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(15)))), ((int)(((byte)(46)))));
            this.btnReset.OnPressedState.BorderRadius = 8;
            this.btnReset.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.OnPressedState.BorderThickness = 1;
            this.btnReset.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(15)))), ((int)(((byte)(46)))));
            this.btnReset.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnReset.OnPressedState.IconLeftImage = null;
            this.btnReset.OnPressedState.IconRightImage = null;
            this.btnReset.Size = new System.Drawing.Size(102, 32);
            this.btnReset.TabIndex = 34;
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReset.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnReset.TextMarginLeft = 0;
            this.btnReset.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnReset.UseDefaultRadiusAndThickness = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGridViewLogActivity
            // 
            this.dataGridViewLogActivity.AllowCustomTheming = false;
            this.dataGridViewLogActivity.AllowUserToAddRows = false;
            this.dataGridViewLogActivity.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewLogActivity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLogActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLogActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewLogActivity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewLogActivity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLogActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLogActivity.ColumnHeadersHeight = 40;
            this.dataGridViewLogActivity.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dataGridViewLogActivity.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewLogActivity.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewLogActivity.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataGridViewLogActivity.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLogActivity.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dataGridViewLogActivity.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGridViewLogActivity.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridViewLogActivity.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewLogActivity.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewLogActivity.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dataGridViewLogActivity.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewLogActivity.CurrentTheme.Name = null;
            this.dataGridViewLogActivity.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewLogActivity.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewLogActivity.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewLogActivity.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dataGridViewLogActivity.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLogActivity.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLogActivity.EnableHeadersVisualStyles = false;
            this.dataGridViewLogActivity.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dataGridViewLogActivity.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridViewLogActivity.HeaderBgColor = System.Drawing.Color.Empty;
            this.dataGridViewLogActivity.HeaderForeColor = System.Drawing.Color.White;
            this.dataGridViewLogActivity.Location = new System.Drawing.Point(314, 191);
            this.dataGridViewLogActivity.Name = "dataGridViewLogActivity";
            this.dataGridViewLogActivity.ReadOnly = true;
            this.dataGridViewLogActivity.RowHeadersVisible = false;
            this.dataGridViewLogActivity.RowTemplate.Height = 40;
            this.dataGridViewLogActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLogActivity.Size = new System.Drawing.Size(658, 358);
            this.dataGridViewLogActivity.TabIndex = 32;
            this.dataGridViewLogActivity.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(316, 33);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(218, 56);
            this.bunifuLabel2.TabIndex = 28;
            this.bunifuLabel2.Text = "LOG ACTIVITY";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(314, 12);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(127, 23);
            this.bunifuLabel1.TabIndex = 29;
            this.bunifuLabel1.Text = "Pages / Dashboard";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AllowParentOverrides = false;
            this.bunifuLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.CursorType = null;
            this.bunifuLabel7.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.bunifuLabel7.Location = new System.Drawing.Point(515, 114);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(59, 23);
            this.bunifuLabel7.TabIndex = 30;
            this.bunifuLabel7.Text = "Date End";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.bunifuLabel3.Location = new System.Drawing.Point(314, 113);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(66, 23);
            this.bunifuLabel3.TabIndex = 31;
            this.bunifuLabel3.Text = "Date Start";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cboxSearch
            // 
            this.cboxSearch.BackColor = System.Drawing.Color.Transparent;
            this.cboxSearch.BackgroundColor = System.Drawing.Color.White;
            this.cboxSearch.BorderColor = System.Drawing.Color.Silver;
            this.cboxSearch.BorderRadius = 4;
            this.cboxSearch.Color = System.Drawing.Color.Silver;
            this.cboxSearch.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cboxSearch.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboxSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboxSearch.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboxSearch.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cboxSearch.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cboxSearch.DisplayMember = "0";
            this.cboxSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxSearch.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cboxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSearch.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboxSearch.FillDropDown = true;
            this.cboxSearch.FillIndicator = false;
            this.cboxSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboxSearch.ForeColor = System.Drawing.Color.Black;
            this.cboxSearch.FormattingEnabled = true;
            this.cboxSearch.Icon = null;
            this.cboxSearch.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboxSearch.IndicatorColor = System.Drawing.Color.Gray;
            this.cboxSearch.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboxSearch.ItemBackColor = System.Drawing.Color.White;
            this.cboxSearch.ItemBorderColor = System.Drawing.Color.White;
            this.cboxSearch.ItemForeColor = System.Drawing.Color.Black;
            this.cboxSearch.ItemHeight = 26;
            this.cboxSearch.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cboxSearch.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cboxSearch.Items.AddRange(new object[] {
            "Default",
            "Login",
            "Logout",
            "Insert",
            "Update",
            "Delete",
            "Soft Delete"});
            this.cboxSearch.ItemTopMargin = 3;
            this.cboxSearch.Location = new System.Drawing.Point(716, 142);
            this.cboxSearch.Name = "cboxSearch";
            this.cboxSearch.Size = new System.Drawing.Size(148, 32);
            this.cboxSearch.TabIndex = 53;
            this.cboxSearch.Tag = "0";
            this.cboxSearch.Text = null;
            this.cboxSearch.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboxSearch.TextLeftMargin = 5;
            this.cboxSearch.ValueMember = "0";
            this.cboxSearch.SelectedIndexChanged += new System.EventHandler(this.cboxSearch_SelectedIndexChanged);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(316, 85);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(656, 18);
            this.bunifuSeparator1.TabIndex = 99;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AllowParentOverrides = false;
            this.bunifuLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.CursorType = null;
            this.bunifuLabel4.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(43)))), ((int)(((byte)(77)))));
            this.bunifuLabel4.Location = new System.Drawing.Point(716, 114);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(33, 23);
            this.bunifuLabel4.TabIndex = 30;
            this.bunifuLabel4.Text = "Filter";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(240)))));
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 3;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.btnKelolaPelanggan);
            this.bunifuPanel2.Controls.Add(this.btnLogout);
            this.bunifuPanel2.Controls.Add(this.btnLogActivity);
            this.bunifuPanel2.Controls.Add(this.btnKelolaLaporan);
            this.bunifuPanel2.Controls.Add(this.btnKelolaUser);
            this.bunifuPanel2.Controls.Add(this.bunifuLabel8);
            this.bunifuPanel2.Controls.Add(this.pictureBox1);
            this.bunifuPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(300, 561);
            this.bunifuPanel2.TabIndex = 100;
            // 
            // btnKelolaPelanggan
            // 
            this.btnKelolaPelanggan.AllowAnimations = true;
            this.btnKelolaPelanggan.AllowMouseEffects = true;
            this.btnKelolaPelanggan.AllowToggling = false;
            this.btnKelolaPelanggan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKelolaPelanggan.AnimationSpeed = 200;
            this.btnKelolaPelanggan.AutoGenerateColors = false;
            this.btnKelolaPelanggan.AutoRoundBorders = false;
            this.btnKelolaPelanggan.AutoSizeLeftIcon = true;
            this.btnKelolaPelanggan.AutoSizeRightIcon = true;
            this.btnKelolaPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.btnKelolaPelanggan.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaPelanggan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKelolaPelanggan.BackgroundImage")));
            this.btnKelolaPelanggan.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaPelanggan.ButtonText = "Kelola Pelanggan";
            this.btnKelolaPelanggan.ButtonTextMarginLeft = 0;
            this.btnKelolaPelanggan.ColorContrastOnClick = 45;
            this.btnKelolaPelanggan.ColorContrastOnHover = 45;
            this.btnKelolaPelanggan.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnKelolaPelanggan.CustomizableEdges = borderEdges2;
            this.btnKelolaPelanggan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnKelolaPelanggan.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKelolaPelanggan.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnKelolaPelanggan.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnKelolaPelanggan.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Idle;
            this.btnKelolaPelanggan.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnKelolaPelanggan.ForeColor = System.Drawing.Color.White;
            this.btnKelolaPelanggan.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKelolaPelanggan.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnKelolaPelanggan.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnKelolaPelanggan.IconMarginLeft = 11;
            this.btnKelolaPelanggan.IconPadding = 10;
            this.btnKelolaPelanggan.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKelolaPelanggan.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnKelolaPelanggan.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnKelolaPelanggan.IconSize = 25;
            this.btnKelolaPelanggan.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaPelanggan.IdleBorderRadius = 6;
            this.btnKelolaPelanggan.IdleBorderThickness = 1;
            this.btnKelolaPelanggan.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaPelanggan.IdleIconLeftImage = null;
            this.btnKelolaPelanggan.IdleIconRightImage = null;
            this.btnKelolaPelanggan.IndicateFocus = false;
            this.btnKelolaPelanggan.Location = new System.Drawing.Point(62, 312);
            this.btnKelolaPelanggan.Name = "btnKelolaPelanggan";
            this.btnKelolaPelanggan.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKelolaPelanggan.OnDisabledState.BorderRadius = 6;
            this.btnKelolaPelanggan.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaPelanggan.OnDisabledState.BorderThickness = 1;
            this.btnKelolaPelanggan.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnKelolaPelanggan.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnKelolaPelanggan.OnDisabledState.IconLeftImage = null;
            this.btnKelolaPelanggan.OnDisabledState.IconRightImage = null;
            this.btnKelolaPelanggan.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnKelolaPelanggan.onHoverState.BorderRadius = 6;
            this.btnKelolaPelanggan.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaPelanggan.onHoverState.BorderThickness = 1;
            this.btnKelolaPelanggan.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnKelolaPelanggan.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaPelanggan.onHoverState.IconLeftImage = null;
            this.btnKelolaPelanggan.onHoverState.IconRightImage = null;
            this.btnKelolaPelanggan.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaPelanggan.OnIdleState.BorderRadius = 6;
            this.btnKelolaPelanggan.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaPelanggan.OnIdleState.BorderThickness = 1;
            this.btnKelolaPelanggan.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaPelanggan.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaPelanggan.OnIdleState.IconLeftImage = null;
            this.btnKelolaPelanggan.OnIdleState.IconRightImage = null;
            this.btnKelolaPelanggan.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(175)))), ((int)(((byte)(222)))));
            this.btnKelolaPelanggan.OnPressedState.BorderRadius = 6;
            this.btnKelolaPelanggan.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaPelanggan.OnPressedState.BorderThickness = 1;
            this.btnKelolaPelanggan.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(175)))), ((int)(((byte)(222)))));
            this.btnKelolaPelanggan.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaPelanggan.OnPressedState.IconLeftImage = null;
            this.btnKelolaPelanggan.OnPressedState.IconRightImage = null;
            this.btnKelolaPelanggan.Size = new System.Drawing.Size(176, 39);
            this.btnKelolaPelanggan.TabIndex = 38;
            this.btnKelolaPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnKelolaPelanggan.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKelolaPelanggan.TextMarginLeft = 0;
            this.btnKelolaPelanggan.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnKelolaPelanggan.UseDefaultRadiusAndThickness = true;
            this.btnKelolaPelanggan.Click += new System.EventHandler(this.btnKelolaPelanggan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AllowAnimations = true;
            this.btnLogout.AllowMouseEffects = true;
            this.btnLogout.AllowToggling = false;
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.AnimationSpeed = 200;
            this.btnLogout.AutoGenerateColors = false;
            this.btnLogout.AutoRoundBorders = false;
            this.btnLogout.AutoSizeLeftIcon = true;
            this.btnLogout.AutoSizeRightIcon = true;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackColor1 = System.Drawing.Color.Crimson;
            this.btnLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.BackgroundImage")));
            this.btnLogout.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogout.ButtonText = "Logout";
            this.btnLogout.ButtonTextMarginLeft = 0;
            this.btnLogout.ColorContrastOnClick = 45;
            this.btnLogout.ColorContrastOnHover = 45;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnLogout.CustomizableEdges = borderEdges3;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogout.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogout.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogout.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Idle;
            this.btnLogout.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogout.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogout.IconMarginLeft = 11;
            this.btnLogout.IconPadding = 10;
            this.btnLogout.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogout.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogout.IconSize = 25;
            this.btnLogout.IdleBorderColor = System.Drawing.Color.Crimson;
            this.btnLogout.IdleBorderRadius = 6;
            this.btnLogout.IdleBorderThickness = 1;
            this.btnLogout.IdleFillColor = System.Drawing.Color.Crimson;
            this.btnLogout.IdleIconLeftImage = null;
            this.btnLogout.IdleIconRightImage = null;
            this.btnLogout.IndicateFocus = false;
            this.btnLogout.Location = new System.Drawing.Point(62, 463);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogout.OnDisabledState.BorderRadius = 6;
            this.btnLogout.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogout.OnDisabledState.BorderThickness = 1;
            this.btnLogout.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogout.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogout.OnDisabledState.IconLeftImage = null;
            this.btnLogout.OnDisabledState.IconRightImage = null;
            this.btnLogout.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(80)))), ((int)(((byte)(106)))));
            this.btnLogout.onHoverState.BorderRadius = 6;
            this.btnLogout.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogout.onHoverState.BorderThickness = 1;
            this.btnLogout.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(80)))), ((int)(((byte)(106)))));
            this.btnLogout.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogout.onHoverState.IconLeftImage = null;
            this.btnLogout.onHoverState.IconRightImage = null;
            this.btnLogout.OnIdleState.BorderColor = System.Drawing.Color.Crimson;
            this.btnLogout.OnIdleState.BorderRadius = 6;
            this.btnLogout.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogout.OnIdleState.BorderThickness = 1;
            this.btnLogout.OnIdleState.FillColor = System.Drawing.Color.Crimson;
            this.btnLogout.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnLogout.OnIdleState.IconLeftImage = null;
            this.btnLogout.OnIdleState.IconRightImage = null;
            this.btnLogout.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(15)))), ((int)(((byte)(46)))));
            this.btnLogout.OnPressedState.BorderRadius = 6;
            this.btnLogout.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogout.OnPressedState.BorderThickness = 1;
            this.btnLogout.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(15)))), ((int)(((byte)(46)))));
            this.btnLogout.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnLogout.OnPressedState.IconLeftImage = null;
            this.btnLogout.OnPressedState.IconRightImage = null;
            this.btnLogout.Size = new System.Drawing.Size(176, 39);
            this.btnLogout.TabIndex = 37;
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogout.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogout.TextMarginLeft = 0;
            this.btnLogout.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogout.UseDefaultRadiusAndThickness = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogActivity
            // 
            this.btnLogActivity.AllowAnimations = true;
            this.btnLogActivity.AllowMouseEffects = true;
            this.btnLogActivity.AllowToggling = false;
            this.btnLogActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogActivity.AnimationSpeed = 200;
            this.btnLogActivity.AutoGenerateColors = false;
            this.btnLogActivity.AutoRoundBorders = false;
            this.btnLogActivity.AutoSizeLeftIcon = true;
            this.btnLogActivity.AutoSizeRightIcon = true;
            this.btnLogActivity.BackColor = System.Drawing.Color.Transparent;
            this.btnLogActivity.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnLogActivity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogActivity.BackgroundImage")));
            this.btnLogActivity.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogActivity.ButtonText = "Log Activity";
            this.btnLogActivity.ButtonTextMarginLeft = 0;
            this.btnLogActivity.ColorContrastOnClick = 45;
            this.btnLogActivity.ColorContrastOnHover = 45;
            this.btnLogActivity.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnLogActivity.CustomizableEdges = borderEdges4;
            this.btnLogActivity.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogActivity.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogActivity.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogActivity.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogActivity.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Idle;
            this.btnLogActivity.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogActivity.ForeColor = System.Drawing.Color.White;
            this.btnLogActivity.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogActivity.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogActivity.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogActivity.IconMarginLeft = 11;
            this.btnLogActivity.IconPadding = 10;
            this.btnLogActivity.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogActivity.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogActivity.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogActivity.IconSize = 25;
            this.btnLogActivity.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnLogActivity.IdleBorderRadius = 6;
            this.btnLogActivity.IdleBorderThickness = 1;
            this.btnLogActivity.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnLogActivity.IdleIconLeftImage = null;
            this.btnLogActivity.IdleIconRightImage = null;
            this.btnLogActivity.IndicateFocus = false;
            this.btnLogActivity.Location = new System.Drawing.Point(62, 402);
            this.btnLogActivity.Name = "btnLogActivity";
            this.btnLogActivity.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogActivity.OnDisabledState.BorderRadius = 6;
            this.btnLogActivity.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogActivity.OnDisabledState.BorderThickness = 1;
            this.btnLogActivity.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogActivity.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogActivity.OnDisabledState.IconLeftImage = null;
            this.btnLogActivity.OnDisabledState.IconRightImage = null;
            this.btnLogActivity.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(163)))), ((int)(((byte)(204)))));
            this.btnLogActivity.onHoverState.BorderRadius = 6;
            this.btnLogActivity.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogActivity.onHoverState.BorderThickness = 1;
            this.btnLogActivity.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(163)))), ((int)(((byte)(204)))));
            this.btnLogActivity.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogActivity.onHoverState.IconLeftImage = null;
            this.btnLogActivity.onHoverState.IconRightImage = null;
            this.btnLogActivity.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnLogActivity.OnIdleState.BorderRadius = 6;
            this.btnLogActivity.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogActivity.OnIdleState.BorderThickness = 1;
            this.btnLogActivity.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnLogActivity.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnLogActivity.OnIdleState.IconLeftImage = null;
            this.btnLogActivity.OnIdleState.IconRightImage = null;
            this.btnLogActivity.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(122)))), ((int)(((byte)(153)))));
            this.btnLogActivity.OnPressedState.BorderRadius = 6;
            this.btnLogActivity.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogActivity.OnPressedState.BorderThickness = 1;
            this.btnLogActivity.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(122)))), ((int)(((byte)(153)))));
            this.btnLogActivity.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnLogActivity.OnPressedState.IconLeftImage = null;
            this.btnLogActivity.OnPressedState.IconRightImage = null;
            this.btnLogActivity.Size = new System.Drawing.Size(176, 39);
            this.btnLogActivity.TabIndex = 35;
            this.btnLogActivity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogActivity.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogActivity.TextMarginLeft = 0;
            this.btnLogActivity.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogActivity.UseDefaultRadiusAndThickness = true;
            this.btnLogActivity.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnKelolaUser
            // 
            this.btnKelolaUser.AllowAnimations = true;
            this.btnKelolaUser.AllowMouseEffects = true;
            this.btnKelolaUser.AllowToggling = false;
            this.btnKelolaUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKelolaUser.AnimationSpeed = 200;
            this.btnKelolaUser.AutoGenerateColors = false;
            this.btnKelolaUser.AutoRoundBorders = false;
            this.btnKelolaUser.AutoSizeLeftIcon = true;
            this.btnKelolaUser.AutoSizeRightIcon = true;
            this.btnKelolaUser.BackColor = System.Drawing.Color.Transparent;
            this.btnKelolaUser.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKelolaUser.BackgroundImage")));
            this.btnKelolaUser.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaUser.ButtonText = "Kelola User";
            this.btnKelolaUser.ButtonTextMarginLeft = 0;
            this.btnKelolaUser.ColorContrastOnClick = 45;
            this.btnKelolaUser.ColorContrastOnHover = 45;
            this.btnKelolaUser.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.btnKelolaUser.CustomizableEdges = borderEdges6;
            this.btnKelolaUser.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnKelolaUser.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKelolaUser.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnKelolaUser.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnKelolaUser.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Idle;
            this.btnKelolaUser.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnKelolaUser.ForeColor = System.Drawing.Color.White;
            this.btnKelolaUser.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKelolaUser.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnKelolaUser.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnKelolaUser.IconMarginLeft = 11;
            this.btnKelolaUser.IconPadding = 10;
            this.btnKelolaUser.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKelolaUser.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnKelolaUser.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnKelolaUser.IconSize = 25;
            this.btnKelolaUser.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaUser.IdleBorderRadius = 6;
            this.btnKelolaUser.IdleBorderThickness = 1;
            this.btnKelolaUser.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaUser.IdleIconLeftImage = null;
            this.btnKelolaUser.IdleIconRightImage = null;
            this.btnKelolaUser.IndicateFocus = false;
            this.btnKelolaUser.Location = new System.Drawing.Point(62, 267);
            this.btnKelolaUser.Name = "btnKelolaUser";
            this.btnKelolaUser.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKelolaUser.OnDisabledState.BorderRadius = 6;
            this.btnKelolaUser.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaUser.OnDisabledState.BorderThickness = 1;
            this.btnKelolaUser.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnKelolaUser.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnKelolaUser.OnDisabledState.IconLeftImage = null;
            this.btnKelolaUser.OnDisabledState.IconRightImage = null;
            this.btnKelolaUser.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnKelolaUser.onHoverState.BorderRadius = 6;
            this.btnKelolaUser.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaUser.onHoverState.BorderThickness = 1;
            this.btnKelolaUser.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnKelolaUser.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaUser.onHoverState.IconLeftImage = null;
            this.btnKelolaUser.onHoverState.IconRightImage = null;
            this.btnKelolaUser.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaUser.OnIdleState.BorderRadius = 6;
            this.btnKelolaUser.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaUser.OnIdleState.BorderThickness = 1;
            this.btnKelolaUser.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaUser.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaUser.OnIdleState.IconLeftImage = null;
            this.btnKelolaUser.OnIdleState.IconRightImage = null;
            this.btnKelolaUser.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(175)))), ((int)(((byte)(222)))));
            this.btnKelolaUser.OnPressedState.BorderRadius = 6;
            this.btnKelolaUser.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaUser.OnPressedState.BorderThickness = 1;
            this.btnKelolaUser.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(175)))), ((int)(((byte)(222)))));
            this.btnKelolaUser.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaUser.OnPressedState.IconLeftImage = null;
            this.btnKelolaUser.OnPressedState.IconRightImage = null;
            this.btnKelolaUser.Size = new System.Drawing.Size(176, 39);
            this.btnKelolaUser.TabIndex = 33;
            this.btnKelolaUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnKelolaUser.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKelolaUser.TextMarginLeft = 0;
            this.btnKelolaUser.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnKelolaUser.UseDefaultRadiusAndThickness = true;
            this.btnKelolaUser.Click += new System.EventHandler(this.btnKelolaUser_Click);
            // 
            // bunifuLabel8
            // 
            this.bunifuLabel8.AllowParentOverrides = false;
            this.bunifuLabel8.AutoEllipsis = false;
            this.bunifuLabel8.CursorType = null;
            this.bunifuLabel8.Font = new System.Drawing.Font("Poppins SemiBold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel8.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel8.Location = new System.Drawing.Point(91, 193);
            this.bunifuLabel8.Name = "bunifuLabel8";
            this.bunifuLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel8.Size = new System.Drawing.Size(119, 62);
            this.bunifuLabel8.TabIndex = 34;
            this.bunifuLabel8.Text = "Admin";
            this.bunifuLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel8.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::csharp_lksmart.Properties.Resources.icon_administrator;
            this.pictureBox1.Location = new System.Drawing.Point(74, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnKelolaLaporan
            // 
            this.btnKelolaLaporan.AllowAnimations = true;
            this.btnKelolaLaporan.AllowMouseEffects = true;
            this.btnKelolaLaporan.AllowToggling = false;
            this.btnKelolaLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKelolaLaporan.AnimationSpeed = 200;
            this.btnKelolaLaporan.AutoGenerateColors = false;
            this.btnKelolaLaporan.AutoRoundBorders = false;
            this.btnKelolaLaporan.AutoSizeLeftIcon = true;
            this.btnKelolaLaporan.AutoSizeRightIcon = true;
            this.btnKelolaLaporan.BackColor = System.Drawing.Color.Transparent;
            this.btnKelolaLaporan.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaLaporan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKelolaLaporan.BackgroundImage")));
            this.btnKelolaLaporan.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaLaporan.ButtonText = "Kelola Laporan";
            this.btnKelolaLaporan.ButtonTextMarginLeft = 0;
            this.btnKelolaLaporan.ColorContrastOnClick = 45;
            this.btnKelolaLaporan.ColorContrastOnHover = 45;
            this.btnKelolaLaporan.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.btnKelolaLaporan.CustomizableEdges = borderEdges5;
            this.btnKelolaLaporan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnKelolaLaporan.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKelolaLaporan.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnKelolaLaporan.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnKelolaLaporan.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Idle;
            this.btnKelolaLaporan.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.btnKelolaLaporan.ForeColor = System.Drawing.Color.White;
            this.btnKelolaLaporan.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKelolaLaporan.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnKelolaLaporan.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnKelolaLaporan.IconMarginLeft = 11;
            this.btnKelolaLaporan.IconPadding = 10;
            this.btnKelolaLaporan.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKelolaLaporan.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnKelolaLaporan.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnKelolaLaporan.IconSize = 25;
            this.btnKelolaLaporan.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaLaporan.IdleBorderRadius = 6;
            this.btnKelolaLaporan.IdleBorderThickness = 1;
            this.btnKelolaLaporan.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaLaporan.IdleIconLeftImage = null;
            this.btnKelolaLaporan.IdleIconRightImage = null;
            this.btnKelolaLaporan.IndicateFocus = false;
            this.btnKelolaLaporan.Location = new System.Drawing.Point(62, 357);
            this.btnKelolaLaporan.Name = "btnKelolaLaporan";
            this.btnKelolaLaporan.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKelolaLaporan.OnDisabledState.BorderRadius = 6;
            this.btnKelolaLaporan.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaLaporan.OnDisabledState.BorderThickness = 1;
            this.btnKelolaLaporan.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnKelolaLaporan.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnKelolaLaporan.OnDisabledState.IconLeftImage = null;
            this.btnKelolaLaporan.OnDisabledState.IconRightImage = null;
            this.btnKelolaLaporan.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnKelolaLaporan.onHoverState.BorderRadius = 6;
            this.btnKelolaLaporan.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaLaporan.onHoverState.BorderThickness = 1;
            this.btnKelolaLaporan.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnKelolaLaporan.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaLaporan.onHoverState.IconLeftImage = null;
            this.btnKelolaLaporan.onHoverState.IconRightImage = null;
            this.btnKelolaLaporan.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaLaporan.OnIdleState.BorderRadius = 6;
            this.btnKelolaLaporan.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaLaporan.OnIdleState.BorderThickness = 1;
            this.btnKelolaLaporan.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(212)))));
            this.btnKelolaLaporan.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaLaporan.OnIdleState.IconLeftImage = null;
            this.btnKelolaLaporan.OnIdleState.IconRightImage = null;
            this.btnKelolaLaporan.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(175)))), ((int)(((byte)(222)))));
            this.btnKelolaLaporan.OnPressedState.BorderRadius = 6;
            this.btnKelolaLaporan.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnKelolaLaporan.OnPressedState.BorderThickness = 1;
            this.btnKelolaLaporan.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(175)))), ((int)(((byte)(222)))));
            this.btnKelolaLaporan.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnKelolaLaporan.OnPressedState.IconLeftImage = null;
            this.btnKelolaLaporan.OnPressedState.IconRightImage = null;
            this.btnKelolaLaporan.Size = new System.Drawing.Size(176, 39);
            this.btnKelolaLaporan.TabIndex = 36;
            this.btnKelolaLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnKelolaLaporan.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnKelolaLaporan.TextMarginLeft = 0;
            this.btnKelolaLaporan.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnKelolaLaporan.UseDefaultRadiusAndThickness = true;
            this.btnKelolaLaporan.Click += new System.EventHandler(this.btnKelolaLaporan_Click);
            // 
            // FormAdminLogActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.cboxSearch);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dataGridViewLogActivity);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.bunifuLabel4);
            this.Controls.Add(this.bunifuLabel7);
            this.Controls.Add(this.bunifuLabel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdminLogActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Log Activity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminLogActivity_FormClosing);
            this.Load += new System.EventHandler(this.FormAdminLogActivity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogActivity)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuDatePicker dateEnd;
        private Bunifu.UI.WinForms.BunifuDatePicker dateStart;
        private Bunifu.UI.WinForms.BunifuLabel labelTime;
        private Bunifu.UI.WinForms.BunifuLabel labelDate;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnReset;
        private Bunifu.UI.WinForms.BunifuDataGridView dataGridViewLogActivity;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuDropdown cboxSearch;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnKelolaPelanggan;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogout;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogActivity;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnKelolaUser;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnKelolaLaporan;
    }
}