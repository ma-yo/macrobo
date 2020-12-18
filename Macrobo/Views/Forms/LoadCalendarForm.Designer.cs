namespace Macrobo.Views.Forms
{
    partial class LoadCalendarForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CreateStaticCalendarButton = new Macrobo.Components.BaseButton();
            this.CalendarGrid = new Macrobo.Components.BaseDataGridView();
            this.COL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CALENDARTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_カレンダー名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_修正 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COL_削除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ImportButton = new Macrobo.Components.BaseButton();
            this.ExportButton = new Macrobo.Components.BaseButton();
            this.baseLabel1 = new Macrobo.Components.BaseLabel();
            this.CreateWebCalendarButton = new Macrobo.Components.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateStaticCalendarButton
            // 
            this.CreateStaticCalendarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateStaticCalendarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreateStaticCalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateStaticCalendarButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.CreateStaticCalendarButton.ForeColor = System.Drawing.Color.White;
            this.CreateStaticCalendarButton.Location = new System.Drawing.Point(129, 417);
            this.CreateStaticCalendarButton.Name = "CreateStaticCalendarButton";
            this.CreateStaticCalendarButton.Size = new System.Drawing.Size(151, 25);
            this.CreateStaticCalendarButton.TabIndex = 3;
            this.CreateStaticCalendarButton.Text = "固定カレンダー作成";
            this.CreateStaticCalendarButton.UseVisualStyleBackColor = false;
            this.CreateStaticCalendarButton.Click += new System.EventHandler(this.CreateCalendarButton_Click);
            // 
            // CalendarGrid
            // 
            this.CalendarGrid.AllowUserToAddRows = false;
            this.CalendarGrid.AllowUserToDeleteRows = false;
            this.CalendarGrid.AllowUserToResizeColumns = false;
            this.CalendarGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.CalendarGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CalendarGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CalendarGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CalendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalendarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_ID,
            this.COL_CALENDARTYPE,
            this.COL_カレンダー名,
            this.COL_修正,
            this.COL_削除});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CalendarGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.CalendarGrid.Location = new System.Drawing.Point(12, 12);
            this.CalendarGrid.Name = "CalendarGrid";
            this.CalendarGrid.RowHeadersVisible = false;
            this.CalendarGrid.RowTemplate.Height = 21;
            this.CalendarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CalendarGrid.Size = new System.Drawing.Size(629, 388);
            this.CalendarGrid.TabIndex = 4;
            this.CalendarGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CalendarGrid_CellContentClick);
            // 
            // COL_ID
            // 
            this.COL_ID.HeaderText = "ID";
            this.COL_ID.MinimumWidth = 60;
            this.COL_ID.Name = "COL_ID";
            this.COL_ID.ReadOnly = true;
            this.COL_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_ID.Width = 60;
            // 
            // COL_CALENDARTYPE
            // 
            this.COL_CALENDARTYPE.HeaderText = "カレンダータイプ";
            this.COL_CALENDARTYPE.MinimumWidth = 90;
            this.COL_CALENDARTYPE.Name = "COL_CALENDARTYPE";
            this.COL_CALENDARTYPE.ReadOnly = true;
            this.COL_CALENDARTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_CALENDARTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_CALENDARTYPE.Width = 90;
            // 
            // COL_カレンダー名
            // 
            this.COL_カレンダー名.HeaderText = "カレンダー名";
            this.COL_カレンダー名.MinimumWidth = 300;
            this.COL_カレンダー名.Name = "COL_カレンダー名";
            this.COL_カレンダー名.ReadOnly = true;
            this.COL_カレンダー名.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_カレンダー名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_カレンダー名.Width = 300;
            // 
            // COL_修正
            // 
            this.COL_修正.HeaderText = "修正";
            this.COL_修正.MinimumWidth = 80;
            this.COL_修正.Name = "COL_修正";
            this.COL_修正.ReadOnly = true;
            this.COL_修正.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_修正.Text = "修正";
            this.COL_修正.UseColumnTextForButtonValue = true;
            this.COL_修正.Width = 80;
            // 
            // COL_削除
            // 
            this.COL_削除.HeaderText = "削除";
            this.COL_削除.MinimumWidth = 80;
            this.COL_削除.Name = "COL_削除";
            this.COL_削除.ReadOnly = true;
            this.COL_削除.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_削除.Text = "削除";
            this.COL_削除.UseColumnTextForButtonValue = true;
            this.COL_削除.Width = 80;
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.ImportButton.ForeColor = System.Drawing.Color.White;
            this.ImportButton.Location = new System.Drawing.Point(443, 417);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(97, 25);
            this.ImportButton.TabIndex = 5;
            this.ImportButton.Text = "インポート";
            this.ImportButton.UseVisualStyleBackColor = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.ExportButton.ForeColor = System.Drawing.Color.White;
            this.ExportButton.Location = new System.Drawing.Point(546, 417);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(97, 25);
            this.ExportButton.TabIndex = 6;
            this.ExportButton.Text = "エクスポート";
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // baseLabel1
            // 
            this.baseLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseLabel1.BackColor = System.Drawing.Color.Silver;
            this.baseLabel1.Location = new System.Drawing.Point(12, 409);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(629, 1);
            this.baseLabel1.TabIndex = 14;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateWebCalendarButton
            // 
            this.CreateWebCalendarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateWebCalendarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreateWebCalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateWebCalendarButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.CreateWebCalendarButton.ForeColor = System.Drawing.Color.White;
            this.CreateWebCalendarButton.Location = new System.Drawing.Point(286, 417);
            this.CreateWebCalendarButton.Name = "CreateWebCalendarButton";
            this.CreateWebCalendarButton.Size = new System.Drawing.Size(151, 25);
            this.CreateWebCalendarButton.TabIndex = 15;
            this.CreateWebCalendarButton.Text = "外部カレンダー作成";
            this.CreateWebCalendarButton.UseVisualStyleBackColor = false;
            this.CreateWebCalendarButton.Click += new System.EventHandler(this.CreateWebCalendarButton_Click);
            // 
            // LoadCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 450);
            this.Controls.Add(this.CreateWebCalendarButton);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.CalendarGrid);
            this.Controls.Add(this.CreateStaticCalendarButton);
            this.MaximizeBox = false;
            this.Name = "LoadCalendarForm";
            this.Text = "Macrobo (マクロボ) - カレンダー作成・修正・削除";
            ((System.ComponentModel.ISupportInitialize)(this.CalendarGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.BaseButton CreateStaticCalendarButton;
        private Components.BaseDataGridView CalendarGrid;
        private Components.BaseButton ImportButton;
        private Components.BaseButton ExportButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CALENDARTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_カレンダー名;
        private System.Windows.Forms.DataGridViewButtonColumn COL_修正;
        private System.Windows.Forms.DataGridViewButtonColumn COL_削除;
        private Components.BaseLabel baseLabel1;
        private Components.BaseButton CreateWebCalendarButton;
    }
}