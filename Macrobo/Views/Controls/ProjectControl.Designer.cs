namespace Macrobo.Views
{
    partial class ProjectControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MouseSpeedTitleLbl = new Macrobo.Components.BaseLabel();
            this.MouseSpeedUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.VariableTitleLbl = new Macrobo.Components.BaseLabel();
            this.VariableGrid = new Macrobo.Components.BaseDataGridView();
            this.VARIABLE_GRID_COL_変数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VARIABLE_GRID_COL_値 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VARIABLE_GRID_COL_説明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VariableContextMenuStrip = new Macrobo.Components.BaseContextMenuStrip();
            this.上へ移動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下へ移動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrayVariableTitleLbl = new Macrobo.Components.BaseLabel();
            this.ArrayVariableGrid = new Macrobo.Components.BaseDataGridView();
            this.ARRAY_VARIABLE_GRID_COL_変数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARRAY_VARIABLE_GRID_COL_列数 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ARRAY_VARIABLE_GRID_COL_説明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrayVariableContextMenuStrip = new Macrobo.Components.BaseContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.LogViewTitleLbl = new Macrobo.Components.BaseLabel();
            this.LogViewPanel = new Macrobo.Components.BasePanel();
            this.LogViewRadio = new Macrobo.Components.BaseRadioButton();
            this.LogNotViewRadio = new Macrobo.Components.BaseRadioButton();
            this.CalendarComboTitleLbl = new Macrobo.Components.BaseLabel();
            this.CalendarComboBox = new Macrobo.Components.BaseComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MouseSpeedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariableGrid)).BeginInit();
            this.VariableContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayVariableGrid)).BeginInit();
            this.ArrayVariableContextMenuStrip.SuspendLayout();
            this.LogViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MouseSpeedTitleLbl
            // 
            this.MouseSpeedTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.MouseSpeedTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MouseSpeedTitleLbl.ForeColor = System.Drawing.Color.White;
            this.MouseSpeedTitleLbl.Location = new System.Drawing.Point(446, 3);
            this.MouseSpeedTitleLbl.Name = "MouseSpeedTitleLbl";
            this.MouseSpeedTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.MouseSpeedTitleLbl.TabIndex = 13;
            this.MouseSpeedTitleLbl.Text = "マウススピード";
            this.MouseSpeedTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MouseSpeedUpDown
            // 
            this.MouseSpeedUpDown.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.MouseSpeedUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MouseSpeedUpDown.Location = new System.Drawing.Point(524, 3);
            this.MouseSpeedUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MouseSpeedUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MouseSpeedUpDown.Name = "MouseSpeedUpDown";
            this.MouseSpeedUpDown.Size = new System.Drawing.Size(152, 22);
            this.MouseSpeedUpDown.TabIndex = 12;
            this.MouseSpeedUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MouseSpeedUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // VariableTitleLbl
            // 
            this.VariableTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.VariableTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VariableTitleLbl.ForeColor = System.Drawing.Color.White;
            this.VariableTitleLbl.Location = new System.Drawing.Point(3, 3);
            this.VariableTitleLbl.Name = "VariableTitleLbl";
            this.VariableTitleLbl.Size = new System.Drawing.Size(442, 21);
            this.VariableTitleLbl.TabIndex = 14;
            this.VariableTitleLbl.Text = "変数";
            this.VariableTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VariableGrid
            // 
            this.VariableGrid.AllowUserToAddRows = false;
            this.VariableGrid.AllowUserToDeleteRows = false;
            this.VariableGrid.AllowUserToResizeColumns = false;
            this.VariableGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VariableGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.VariableGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VariableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VariableGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VARIABLE_GRID_COL_変数,
            this.VARIABLE_GRID_COL_値,
            this.VARIABLE_GRID_COL_説明});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VariableGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.VariableGrid.Location = new System.Drawing.Point(3, 23);
            this.VariableGrid.MultiSelect = false;
            this.VariableGrid.Name = "VariableGrid";
            this.VariableGrid.RowHeadersVisible = false;
            this.VariableGrid.RowTemplate.Height = 21;
            this.VariableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VariableGrid.Size = new System.Drawing.Size(442, 231);
            this.VariableGrid.TabIndex = 15;
            this.VariableGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VariableGrid_KeyDown);
            this.VariableGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VariableGrid_MouseClick);
            // 
            // VARIABLE_GRID_COL_変数
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VARIABLE_GRID_COL_変数.DefaultCellStyle = dataGridViewCellStyle2;
            this.VARIABLE_GRID_COL_変数.HeaderText = "変数名";
            this.VARIABLE_GRID_COL_変数.MinimumWidth = 100;
            this.VARIABLE_GRID_COL_変数.Name = "VARIABLE_GRID_COL_変数";
            this.VARIABLE_GRID_COL_変数.ReadOnly = true;
            this.VARIABLE_GRID_COL_変数.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VARIABLE_GRID_COL_変数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VARIABLE_GRID_COL_値
            // 
            this.VARIABLE_GRID_COL_値.HeaderText = "値";
            this.VARIABLE_GRID_COL_値.MinimumWidth = 150;
            this.VARIABLE_GRID_COL_値.Name = "VARIABLE_GRID_COL_値";
            this.VARIABLE_GRID_COL_値.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VARIABLE_GRID_COL_値.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VARIABLE_GRID_COL_値.Width = 150;
            // 
            // VARIABLE_GRID_COL_説明
            // 
            this.VARIABLE_GRID_COL_説明.HeaderText = "説明";
            this.VARIABLE_GRID_COL_説明.MinimumWidth = 173;
            this.VARIABLE_GRID_COL_説明.Name = "VARIABLE_GRID_COL_説明";
            this.VARIABLE_GRID_COL_説明.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VARIABLE_GRID_COL_説明.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VARIABLE_GRID_COL_説明.Width = 173;
            // 
            // VariableContextMenuStrip
            // 
            this.VariableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上へ移動ToolStripMenuItem,
            this.下へ移動ToolStripMenuItem});
            this.VariableContextMenuStrip.Name = "TreeNodeContextMenuStrip";
            this.VariableContextMenuStrip.Size = new System.Drawing.Size(135, 48);
            // 
            // 上へ移動ToolStripMenuItem
            // 
            this.上へ移動ToolStripMenuItem.Image = global::Macrobo.Properties.Resources.baseline_add_circle_black_18dp;
            this.上へ移動ToolStripMenuItem.Name = "上へ移動ToolStripMenuItem";
            this.上へ移動ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.上へ移動ToolStripMenuItem.Text = "追加 Insert";
            this.上へ移動ToolStripMenuItem.Click += new System.EventHandler(this.追加ToolStripMenuItem_Click);
            // 
            // 下へ移動ToolStripMenuItem
            // 
            this.下へ移動ToolStripMenuItem.Image = global::Macrobo.Properties.Resources.baseline_remove_circle_red_18dp;
            this.下へ移動ToolStripMenuItem.Name = "下へ移動ToolStripMenuItem";
            this.下へ移動ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.下へ移動ToolStripMenuItem.Text = "削除 Delete";
            this.下へ移動ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // ArrayVariableTitleLbl
            // 
            this.ArrayVariableTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ArrayVariableTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ArrayVariableTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrayVariableTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ArrayVariableTitleLbl.Location = new System.Drawing.Point(3, 255);
            this.ArrayVariableTitleLbl.Name = "ArrayVariableTitleLbl";
            this.ArrayVariableTitleLbl.Size = new System.Drawing.Size(442, 21);
            this.ArrayVariableTitleLbl.TabIndex = 16;
            this.ArrayVariableTitleLbl.Text = "変数配列";
            this.ArrayVariableTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArrayVariableGrid
            // 
            this.ArrayVariableGrid.AllowUserToAddRows = false;
            this.ArrayVariableGrid.AllowUserToDeleteRows = false;
            this.ArrayVariableGrid.AllowUserToResizeColumns = false;
            this.ArrayVariableGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ArrayVariableGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ArrayVariableGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ArrayVariableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArrayVariableGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ARRAY_VARIABLE_GRID_COL_変数,
            this.ARRAY_VARIABLE_GRID_COL_列数,
            this.ARRAY_VARIABLE_GRID_COL_説明});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ArrayVariableGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.ArrayVariableGrid.Location = new System.Drawing.Point(3, 275);
            this.ArrayVariableGrid.MultiSelect = false;
            this.ArrayVariableGrid.Name = "ArrayVariableGrid";
            this.ArrayVariableGrid.RowHeadersVisible = false;
            this.ArrayVariableGrid.RowTemplate.Height = 21;
            this.ArrayVariableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ArrayVariableGrid.Size = new System.Drawing.Size(442, 232);
            this.ArrayVariableGrid.TabIndex = 17;
            this.ArrayVariableGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArrayVariableGrid_KeyDown);
            this.ArrayVariableGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ArrayVariableGrid_MouseClick);
            // 
            // ARRAY_VARIABLE_GRID_COL_変数
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ARRAY_VARIABLE_GRID_COL_変数.DefaultCellStyle = dataGridViewCellStyle5;
            this.ARRAY_VARIABLE_GRID_COL_変数.HeaderText = "変数名";
            this.ARRAY_VARIABLE_GRID_COL_変数.MinimumWidth = 100;
            this.ARRAY_VARIABLE_GRID_COL_変数.Name = "ARRAY_VARIABLE_GRID_COL_変数";
            this.ARRAY_VARIABLE_GRID_COL_変数.ReadOnly = true;
            this.ARRAY_VARIABLE_GRID_COL_変数.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ARRAY_VARIABLE_GRID_COL_変数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ARRAY_VARIABLE_GRID_COL_列数
            // 
            this.ARRAY_VARIABLE_GRID_COL_列数.HeaderText = "列数";
            this.ARRAY_VARIABLE_GRID_COL_列数.MinimumWidth = 70;
            this.ARRAY_VARIABLE_GRID_COL_列数.Name = "ARRAY_VARIABLE_GRID_COL_列数";
            this.ARRAY_VARIABLE_GRID_COL_列数.Width = 70;
            // 
            // ARRAY_VARIABLE_GRID_COL_説明
            // 
            this.ARRAY_VARIABLE_GRID_COL_説明.HeaderText = "説明";
            this.ARRAY_VARIABLE_GRID_COL_説明.MinimumWidth = 253;
            this.ARRAY_VARIABLE_GRID_COL_説明.Name = "ARRAY_VARIABLE_GRID_COL_説明";
            this.ARRAY_VARIABLE_GRID_COL_説明.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ARRAY_VARIABLE_GRID_COL_説明.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ARRAY_VARIABLE_GRID_COL_説明.Width = 253;
            // 
            // ArrayVariableContextMenuStrip
            // 
            this.ArrayVariableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.ArrayVariableContextMenuStrip.Name = "TreeNodeContextMenuStrip";
            this.ArrayVariableContextMenuStrip.Size = new System.Drawing.Size(135, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Macrobo.Properties.Resources.baseline_add_circle_black_18dp;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem1.Text = "追加 Insert";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.追加ArrayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Macrobo.Properties.Resources.baseline_remove_circle_red_18dp;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem2.Text = "削除 Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.削除ArrayToolStripMenuItem_Click);
            // 
            // LogViewTitleLbl
            // 
            this.LogViewTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.LogViewTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogViewTitleLbl.ForeColor = System.Drawing.Color.White;
            this.LogViewTitleLbl.Location = new System.Drawing.Point(446, 26);
            this.LogViewTitleLbl.Name = "LogViewTitleLbl";
            this.LogViewTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.LogViewTitleLbl.TabIndex = 20;
            this.LogViewTitleLbl.Text = "ログ表示";
            this.LogViewTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogViewPanel
            // 
            this.LogViewPanel.BackColor = System.Drawing.Color.White;
            this.LogViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogViewPanel.Controls.Add(this.LogViewRadio);
            this.LogViewPanel.Controls.Add(this.LogNotViewRadio);
            this.LogViewPanel.Location = new System.Drawing.Point(524, 26);
            this.LogViewPanel.Margin = new System.Windows.Forms.Padding(2);
            this.LogViewPanel.Name = "LogViewPanel";
            this.LogViewPanel.Size = new System.Drawing.Size(152, 22);
            this.LogViewPanel.TabIndex = 21;
            // 
            // LogViewRadio
            // 
            this.LogViewRadio.AutoSize = true;
            this.LogViewRadio.Location = new System.Drawing.Point(2, 2);
            this.LogViewRadio.Margin = new System.Windows.Forms.Padding(2);
            this.LogViewRadio.Name = "LogViewRadio";
            this.LogViewRadio.Size = new System.Drawing.Size(66, 16);
            this.LogViewRadio.TabIndex = 19;
            this.LogViewRadio.TabStop = true;
            this.LogViewRadio.Text = "表示する";
            this.LogViewRadio.UseVisualStyleBackColor = true;
            // 
            // LogNotViewRadio
            // 
            this.LogNotViewRadio.AutoSize = true;
            this.LogNotViewRadio.Location = new System.Drawing.Point(72, 2);
            this.LogNotViewRadio.Margin = new System.Windows.Forms.Padding(2);
            this.LogNotViewRadio.Name = "LogNotViewRadio";
            this.LogNotViewRadio.Size = new System.Drawing.Size(76, 16);
            this.LogNotViewRadio.TabIndex = 20;
            this.LogNotViewRadio.TabStop = true;
            this.LogNotViewRadio.Text = "表示しない";
            this.LogNotViewRadio.UseVisualStyleBackColor = true;
            // 
            // CalendarComboTitleLbl
            // 
            this.CalendarComboTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.CalendarComboTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalendarComboTitleLbl.ForeColor = System.Drawing.Color.White;
            this.CalendarComboTitleLbl.Location = new System.Drawing.Point(446, 49);
            this.CalendarComboTitleLbl.Name = "CalendarComboTitleLbl";
            this.CalendarComboTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.CalendarComboTitleLbl.TabIndex = 22;
            this.CalendarComboTitleLbl.Text = "実行カレンダー";
            this.CalendarComboTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalendarComboBox
            // 
            this.CalendarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CalendarComboBox.Font = new System.Drawing.Font("MS UI Gothic", 10.5F);
            this.CalendarComboBox.FormattingEnabled = true;
            this.CalendarComboBox.Location = new System.Drawing.Point(524, 49);
            this.CalendarComboBox.Name = "CalendarComboBox";
            this.CalendarComboBox.Size = new System.Drawing.Size(220, 22);
            this.CalendarComboBox.TabIndex = 48;
            // 
            // ProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarComboBox);
            this.Controls.Add(this.CalendarComboTitleLbl);
            this.Controls.Add(this.LogViewPanel);
            this.Controls.Add(this.LogViewTitleLbl);
            this.Controls.Add(this.ArrayVariableTitleLbl);
            this.Controls.Add(this.ArrayVariableGrid);
            this.Controls.Add(this.VariableTitleLbl);
            this.Controls.Add(this.MouseSpeedTitleLbl);
            this.Controls.Add(this.MouseSpeedUpDown);
            this.Controls.Add(this.VariableGrid);
            this.Name = "ProjectControl";
            this.Size = new System.Drawing.Size(797, 512);
            ((System.ComponentModel.ISupportInitialize)(this.MouseSpeedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariableGrid)).EndInit();
            this.VariableContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArrayVariableGrid)).EndInit();
            this.ArrayVariableContextMenuStrip.ResumeLayout(false);
            this.LogViewPanel.ResumeLayout(false);
            this.LogViewPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Components.BaseLabel MouseSpeedTitleLbl;
        public Components.BaseNumericUpDown MouseSpeedUpDown;
        public Components.BaseLabel VariableTitleLbl;
        private Components.BaseContextMenuStrip VariableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 上へ移動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下へ移動ToolStripMenuItem;
        public Components.BaseDataGridView VariableGrid;
        public Components.BaseLabel ArrayVariableTitleLbl;
        public Components.BaseDataGridView ArrayVariableGrid;
        private Components.BaseContextMenuStrip ArrayVariableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public Components.BaseLabel LogViewTitleLbl;
        public Components.BasePanel LogViewPanel;
        public Components.BaseRadioButton LogViewRadio;
        public Components.BaseRadioButton LogNotViewRadio;
        private System.Windows.Forms.DataGridViewTextBoxColumn VARIABLE_GRID_COL_変数;
        private System.Windows.Forms.DataGridViewTextBoxColumn VARIABLE_GRID_COL_値;
        private System.Windows.Forms.DataGridViewTextBoxColumn VARIABLE_GRID_COL_説明;
        public Components.BaseLabel CalendarComboTitleLbl;
        public Components.BaseComboBox CalendarComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARRAY_VARIABLE_GRID_COL_変数;
        private System.Windows.Forms.DataGridViewComboBoxColumn ARRAY_VARIABLE_GRID_COL_列数;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARRAY_VARIABLE_GRID_COL_説明;
    }
}
