namespace Macrobo.Views.Forms
{
    partial class ExecLogForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ProjectGrid = new Macrobo.Components.BaseDataGridView();
            this.COL_選択 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecLogChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.baseLabel1 = new Macrobo.Components.BaseLabel();
            this.LogOutButton = new Macrobo.Components.BaseButton();
            this.FilterPanel = new Macrobo.Components.BasePanel();
            this.AllRadio = new Macrobo.Components.BaseRadioButton();
            this.EndRadio = new Macrobo.Components.BaseRadioButton();
            this.ErrorRadio = new Macrobo.Components.BaseRadioButton();
            this.FilterTitleLbl = new Macrobo.Components.BaseLabel();
            this.TaniPanel = new Macrobo.Components.BasePanel();
            this.DayTaniRadio = new Macrobo.Components.BaseRadioButton();
            this.MonthTaniRadio = new Macrobo.Components.BaseRadioButton();
            this.TaniTitleLbl = new Macrobo.Components.BaseLabel();
            this.LogDeleteButton = new Macrobo.Components.BaseButton();
            this.FileLogButton = new Macrobo.Components.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecLogChart)).BeginInit();
            this.FilterPanel.SuspendLayout();
            this.TaniPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectGrid
            // 
            this.ProjectGrid.AllowUserToAddRows = false;
            this.ProjectGrid.AllowUserToDeleteRows = false;
            this.ProjectGrid.AllowUserToResizeColumns = false;
            this.ProjectGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ProjectGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ProjectGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjectGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_選択,
            this.COL_名称});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProjectGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.ProjectGrid.Location = new System.Drawing.Point(12, 38);
            this.ProjectGrid.Name = "ProjectGrid";
            this.ProjectGrid.RowHeadersVisible = false;
            this.ProjectGrid.RowTemplate.Height = 21;
            this.ProjectGrid.Size = new System.Drawing.Size(344, 228);
            this.ProjectGrid.TabIndex = 0;
            this.ProjectGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProjectGrid_CellContentClick);
            this.ProjectGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProjectGrid_CellContentDoubleClick);
            this.ProjectGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.ProjectGrid_CurrentCellDirtyStateChanged);
            // 
            // COL_選択
            // 
            this.COL_選択.HeaderText = "";
            this.COL_選択.MinimumWidth = 25;
            this.COL_選択.Name = "COL_選択";
            this.COL_選択.Width = 25;
            // 
            // COL_名称
            // 
            this.COL_名称.HeaderText = "名称";
            this.COL_名称.MinimumWidth = 300;
            this.COL_名称.Name = "COL_名称";
            this.COL_名称.ReadOnly = true;
            this.COL_名称.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_名称.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_名称.Width = 300;
            // 
            // ExecLogChart
            // 
            this.ExecLogChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.Title = "Month";
            chartArea2.AxisY.Title = "Seconds";
            chartArea2.Name = "ChartArea1";
            this.ExecLogChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ExecLogChart.Legends.Add(legend2);
            this.ExecLogChart.Location = new System.Drawing.Point(362, 38);
            this.ExecLogChart.Name = "ExecLogChart";
            this.ExecLogChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.LegendText = "Total Seconds";
            series2.Name = "Series1";
            this.ExecLogChart.Series.Add(series2);
            this.ExecLogChart.Size = new System.Drawing.Size(634, 228);
            this.ExecLogChart.TabIndex = 1;
            this.ExecLogChart.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "月間稼働チャート";
            this.ExecLogChart.Titles.Add(title2);
            // 
            // baseLabel1
            // 
            this.baseLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseLabel1.BackColor = System.Drawing.Color.Silver;
            this.baseLabel1.Location = new System.Drawing.Point(8, 273);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(993, 1);
            this.baseLabel1.TabIndex = 106;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(909, 279);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(88, 24);
            this.LogOutButton.TabIndex = 105;
            this.LogOutButton.Text = "ログ出力";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // FilterPanel
            // 
            this.FilterPanel.BackColor = System.Drawing.Color.White;
            this.FilterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterPanel.Controls.Add(this.AllRadio);
            this.FilterPanel.Controls.Add(this.EndRadio);
            this.FilterPanel.Controls.Add(this.ErrorRadio);
            this.FilterPanel.Location = new System.Drawing.Point(114, 9);
            this.FilterPanel.Margin = new System.Windows.Forms.Padding(2);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(242, 22);
            this.FilterPanel.TabIndex = 107;
            // 
            // AllRadio
            // 
            this.AllRadio.AutoSize = true;
            this.AllRadio.Location = new System.Drawing.Point(174, 2);
            this.AllRadio.Margin = new System.Windows.Forms.Padding(2);
            this.AllRadio.Name = "AllRadio";
            this.AllRadio.Size = new System.Drawing.Size(52, 16);
            this.AllRadio.TabIndex = 11;
            this.AllRadio.TabStop = true;
            this.AllRadio.Text = "すべて";
            this.AllRadio.UseVisualStyleBackColor = true;
            // 
            // EndRadio
            // 
            this.EndRadio.AutoSize = true;
            this.EndRadio.Location = new System.Drawing.Point(15, 2);
            this.EndRadio.Margin = new System.Windows.Forms.Padding(2);
            this.EndRadio.Name = "EndRadio";
            this.EndRadio.Size = new System.Drawing.Size(71, 16);
            this.EndRadio.TabIndex = 9;
            this.EndRadio.TabStop = true;
            this.EndRadio.Text = "正常終了";
            this.EndRadio.UseVisualStyleBackColor = true;
            // 
            // ErrorRadio
            // 
            this.ErrorRadio.AutoSize = true;
            this.ErrorRadio.Location = new System.Drawing.Point(90, 2);
            this.ErrorRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ErrorRadio.Name = "ErrorRadio";
            this.ErrorRadio.Size = new System.Drawing.Size(80, 16);
            this.ErrorRadio.TabIndex = 10;
            this.ErrorRadio.TabStop = true;
            this.ErrorRadio.Text = "エラー・中断";
            this.ErrorRadio.UseVisualStyleBackColor = true;
            // 
            // FilterTitleLbl
            // 
            this.FilterTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.FilterTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterTitleLbl.ForeColor = System.Drawing.Color.White;
            this.FilterTitleLbl.Location = new System.Drawing.Point(12, 9);
            this.FilterTitleLbl.Name = "FilterTitleLbl";
            this.FilterTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.FilterTitleLbl.TabIndex = 108;
            this.FilterTitleLbl.Text = "抽出条件";
            this.FilterTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaniPanel
            // 
            this.TaniPanel.BackColor = System.Drawing.Color.White;
            this.TaniPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaniPanel.Controls.Add(this.DayTaniRadio);
            this.TaniPanel.Controls.Add(this.MonthTaniRadio);
            this.TaniPanel.Location = new System.Drawing.Point(464, 9);
            this.TaniPanel.Margin = new System.Windows.Forms.Padding(2);
            this.TaniPanel.Name = "TaniPanel";
            this.TaniPanel.Size = new System.Drawing.Size(143, 22);
            this.TaniPanel.TabIndex = 109;
            // 
            // DayTaniRadio
            // 
            this.DayTaniRadio.AutoSize = true;
            this.DayTaniRadio.Location = new System.Drawing.Point(5, 2);
            this.DayTaniRadio.Margin = new System.Windows.Forms.Padding(2);
            this.DayTaniRadio.Name = "DayTaniRadio";
            this.DayTaniRadio.Size = new System.Drawing.Size(59, 16);
            this.DayTaniRadio.TabIndex = 9;
            this.DayTaniRadio.TabStop = true;
            this.DayTaniRadio.Text = "日単位";
            this.DayTaniRadio.UseVisualStyleBackColor = true;
            // 
            // MonthTaniRadio
            // 
            this.MonthTaniRadio.AutoSize = true;
            this.MonthTaniRadio.Location = new System.Drawing.Point(72, 2);
            this.MonthTaniRadio.Margin = new System.Windows.Forms.Padding(2);
            this.MonthTaniRadio.Name = "MonthTaniRadio";
            this.MonthTaniRadio.Size = new System.Drawing.Size(59, 16);
            this.MonthTaniRadio.TabIndex = 10;
            this.MonthTaniRadio.TabStop = true;
            this.MonthTaniRadio.Text = "月単位";
            this.MonthTaniRadio.UseVisualStyleBackColor = true;
            // 
            // TaniTitleLbl
            // 
            this.TaniTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.TaniTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaniTitleLbl.ForeColor = System.Drawing.Color.White;
            this.TaniTitleLbl.Location = new System.Drawing.Point(362, 9);
            this.TaniTitleLbl.Name = "TaniTitleLbl";
            this.TaniTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.TaniTitleLbl.TabIndex = 110;
            this.TaniTitleLbl.Text = "抽出単位";
            this.TaniTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogDeleteButton
            // 
            this.LogDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LogDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogDeleteButton.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LogDeleteButton.ForeColor = System.Drawing.Color.White;
            this.LogDeleteButton.Location = new System.Drawing.Point(815, 279);
            this.LogDeleteButton.Name = "LogDeleteButton";
            this.LogDeleteButton.Size = new System.Drawing.Size(88, 24);
            this.LogDeleteButton.TabIndex = 111;
            this.LogDeleteButton.Text = "ログ削除";
            this.LogDeleteButton.UseVisualStyleBackColor = false;
            this.LogDeleteButton.Click += new System.EventHandler(this.LogDeleteButton_Click);
            // 
            // FileLogButton
            // 
            this.FileLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileLogButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FileLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileLogButton.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileLogButton.ForeColor = System.Drawing.Color.White;
            this.FileLogButton.Location = new System.Drawing.Point(721, 279);
            this.FileLogButton.Name = "FileLogButton";
            this.FileLogButton.Size = new System.Drawing.Size(88, 24);
            this.FileLogButton.TabIndex = 112;
            this.FileLogButton.Text = "ファイルログ";
            this.FileLogButton.UseVisualStyleBackColor = false;
            this.FileLogButton.Click += new System.EventHandler(this.FileLogButton_Click);
            // 
            // ExecLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 309);
            this.Controls.Add(this.FileLogButton);
            this.Controls.Add(this.LogDeleteButton);
            this.Controls.Add(this.TaniPanel);
            this.Controls.Add(this.TaniTitleLbl);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.FilterTitleLbl);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ExecLogChart);
            this.Controls.Add(this.ProjectGrid);
            this.Name = "ExecLogForm";
            this.Text = "Macrobo (マクロボ) - 実行ログ";
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExecLogChart)).EndInit();
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.TaniPanel.ResumeLayout(false);
            this.TaniPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.BaseDataGridView ProjectGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_選択;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_名称;
        private System.Windows.Forms.DataVisualization.Charting.Chart ExecLogChart;
        private Components.BaseLabel baseLabel1;
        private Components.BaseButton LogOutButton;
        public Components.BasePanel FilterPanel;
        public Components.BaseRadioButton AllRadio;
        public Components.BaseRadioButton EndRadio;
        public Components.BaseRadioButton ErrorRadio;
        public Components.BaseLabel FilterTitleLbl;
        public Components.BasePanel TaniPanel;
        public Components.BaseRadioButton DayTaniRadio;
        public Components.BaseRadioButton MonthTaniRadio;
        public Components.BaseLabel TaniTitleLbl;
        private Components.BaseButton LogDeleteButton;
        private Components.BaseButton FileLogButton;
    }
}