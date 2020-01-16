namespace Macrobo.Views.Controls
{
    partial class ExcelControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FileFolderTypePanel = new Macrobo.Components.BasePanel();
            this.ExcelSourceNewRadio = new Macrobo.Components.BaseRadioButton();
            this.ExcelSourceExistsRadio = new Macrobo.Components.BaseRadioButton();
            this.ExcelSourceTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.ExcelLoadFilePathTitleLbl = new Macrobo.Components.BaseLabel();
            this.ExcelLoadFilePathTextBox = new Macrobo.Components.BaseTextBox();
            this.FileOpenButton = new Macrobo.Components.BaseButton();
            this.ExcelSaveFilePathTextBox = new Macrobo.Components.BaseTextBox();
            this.SaveFileDialog = new Macrobo.Components.BaseButton();
            this.ExcelSaveFilePathTitleLbl = new Macrobo.Components.BaseLabel();
            this.ExcelJobGrid = new Macrobo.Components.BaseDataGridView();
            this.EXCELJOBGRID_COL_処理タイプ = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EXCELJOBGRID_COL_シート名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXCELJOBGRID_COL_セル名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXCELJOBGRID_COL_値 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
            this.FileFolderTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelJobGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AfterWaitTimeUpDown
            // 
            this.AfterWaitTimeUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AfterWaitTimeUpDown.TabIndex = 5;
            // 
            // BeforeWaitTimeUpDown
            // 
            this.BeforeWaitTimeUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BeforeWaitTimeUpDown.TabIndex = 4;
            // 
            // ValidTypePanel
            // 
            this.ValidTypePanel.TabIndex = 1;
            // 
            // ValidRadio
            // 
            this.ValidRadio.TabIndex = 2;
            // 
            // InValidRadio
            // 
            this.InValidRadio.TabIndex = 3;
            // 
            // ErrorButton
            // 
            this.ErrorButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ErrorButton.TabIndex = 7;
            // 
            // CompButton
            // 
            this.CompButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CompButton.TabIndex = 6;
            // 
            // FileFolderTypePanel
            // 
            this.FileFolderTypePanel.BackColor = System.Drawing.Color.White;
            this.FileFolderTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderTypePanel.Controls.Add(this.ExcelSourceNewRadio);
            this.FileFolderTypePanel.Controls.Add(this.ExcelSourceExistsRadio);
            this.FileFolderTypePanel.Location = new System.Drawing.Point(105, 53);
            this.FileFolderTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderTypePanel.Name = "FileFolderTypePanel";
            this.FileFolderTypePanel.Size = new System.Drawing.Size(180, 22);
            this.FileFolderTypePanel.TabIndex = 8;
            // 
            // ExcelSourceNewRadio
            // 
            this.ExcelSourceNewRadio.AutoSize = true;
            this.ExcelSourceNewRadio.Location = new System.Drawing.Point(6, 2);
            this.ExcelSourceNewRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ExcelSourceNewRadio.Name = "ExcelSourceNewRadio";
            this.ExcelSourceNewRadio.Size = new System.Drawing.Size(81, 16);
            this.ExcelSourceNewRadio.TabIndex = 9;
            this.ExcelSourceNewRadio.TabStop = true;
            this.ExcelSourceNewRadio.Text = "新規ファイル";
            this.ExcelSourceNewRadio.UseVisualStyleBackColor = true;
            // 
            // ExcelSourceExistsRadio
            // 
            this.ExcelSourceExistsRadio.AutoSize = true;
            this.ExcelSourceExistsRadio.Location = new System.Drawing.Point(91, 2);
            this.ExcelSourceExistsRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ExcelSourceExistsRadio.Name = "ExcelSourceExistsRadio";
            this.ExcelSourceExistsRadio.Size = new System.Drawing.Size(81, 16);
            this.ExcelSourceExistsRadio.TabIndex = 10;
            this.ExcelSourceExistsRadio.TabStop = true;
            this.ExcelSourceExistsRadio.Text = "既存ファイル";
            this.ExcelSourceExistsRadio.UseVisualStyleBackColor = true;
            // 
            // ExcelSourceTypeTitleLbl
            // 
            this.ExcelSourceTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ExcelSourceTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExcelSourceTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ExcelSourceTypeTitleLbl.Location = new System.Drawing.Point(3, 53);
            this.ExcelSourceTypeTitleLbl.Name = "ExcelSourceTypeTitleLbl";
            this.ExcelSourceTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ExcelSourceTypeTitleLbl.TabIndex = 67;
            this.ExcelSourceTypeTitleLbl.Text = "読込ソース";
            this.ExcelSourceTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcelLoadFilePathTitleLbl
            // 
            this.ExcelLoadFilePathTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ExcelLoadFilePathTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExcelLoadFilePathTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ExcelLoadFilePathTitleLbl.Location = new System.Drawing.Point(3, 76);
            this.ExcelLoadFilePathTitleLbl.Name = "ExcelLoadFilePathTitleLbl";
            this.ExcelLoadFilePathTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ExcelLoadFilePathTitleLbl.TabIndex = 68;
            this.ExcelLoadFilePathTitleLbl.Text = "読込ファイルパス";
            this.ExcelLoadFilePathTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcelLoadFilePathTextBox
            // 
            this.ExcelLoadFilePathTextBox.AllowDrop = true;
            this.ExcelLoadFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExcelLoadFilePathTextBox.DefaultAlphaNumberOnly = false;
            this.ExcelLoadFilePathTextBox.DefaultClickSelectAll = false;
            this.ExcelLoadFilePathTextBox.DefaultNarrow = false;
            this.ExcelLoadFilePathTextBox.DefaultNumberOnly = false;
            this.ExcelLoadFilePathTextBox.DefaultToUpper = false;
            this.ExcelLoadFilePathTextBox.DefaultTrim = false;
            this.ExcelLoadFilePathTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ExcelLoadFilePathTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ExcelLoadFilePathTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExcelLoadFilePathTextBox.Location = new System.Drawing.Point(105, 76);
            this.ExcelLoadFilePathTextBox.MaxLength = 1024;
            this.ExcelLoadFilePathTextBox.MaxLengthBytes = 0;
            this.ExcelLoadFilePathTextBox.Name = "ExcelLoadFilePathTextBox";
            this.ExcelLoadFilePathTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ExcelLoadFilePathTextBox.Size = new System.Drawing.Size(457, 22);
            this.ExcelLoadFilePathTextBox.TabIndex = 11;
            this.ExcelLoadFilePathTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ExcelLoadFilePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExcelLoadFilePathTextBox_DragDrop);
            this.ExcelLoadFilePathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExcelLoadFilePathTextBox_DragEnter);
            // 
            // FileOpenButton
            // 
            this.FileOpenButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileOpenButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.FileOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileOpenButton.ForeColor = System.Drawing.Color.Black;
            this.FileOpenButton.Location = new System.Drawing.Point(563, 76);
            this.FileOpenButton.Name = "FileOpenButton";
            this.FileOpenButton.Size = new System.Drawing.Size(42, 22);
            this.FileOpenButton.TabIndex = 12;
            this.FileOpenButton.Text = "参照";
            this.FileOpenButton.UseVisualStyleBackColor = false;
            this.FileOpenButton.Click += new System.EventHandler(this.FileOpenButton_Click);
            // 
            // ExcelSaveFilePathTextBox
            // 
            this.ExcelSaveFilePathTextBox.AllowDrop = true;
            this.ExcelSaveFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExcelSaveFilePathTextBox.DefaultAlphaNumberOnly = false;
            this.ExcelSaveFilePathTextBox.DefaultClickSelectAll = false;
            this.ExcelSaveFilePathTextBox.DefaultNarrow = false;
            this.ExcelSaveFilePathTextBox.DefaultNumberOnly = false;
            this.ExcelSaveFilePathTextBox.DefaultToUpper = false;
            this.ExcelSaveFilePathTextBox.DefaultTrim = false;
            this.ExcelSaveFilePathTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ExcelSaveFilePathTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ExcelSaveFilePathTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExcelSaveFilePathTextBox.Location = new System.Drawing.Point(105, 99);
            this.ExcelSaveFilePathTextBox.MaxLength = 1024;
            this.ExcelSaveFilePathTextBox.MaxLengthBytes = 0;
            this.ExcelSaveFilePathTextBox.Name = "ExcelSaveFilePathTextBox";
            this.ExcelSaveFilePathTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ExcelSaveFilePathTextBox.Size = new System.Drawing.Size(457, 22);
            this.ExcelSaveFilePathTextBox.TabIndex = 13;
            this.ExcelSaveFilePathTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ExcelSaveFilePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExcelSaveFilePathTextBox_DragDrop);
            this.ExcelSaveFilePathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExcelSaveFilePathTextBox_DragEnter);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SaveFileDialog.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.SaveFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveFileDialog.ForeColor = System.Drawing.Color.Black;
            this.SaveFileDialog.Location = new System.Drawing.Point(563, 99);
            this.SaveFileDialog.Name = "SaveFileDialog";
            this.SaveFileDialog.Size = new System.Drawing.Size(42, 22);
            this.SaveFileDialog.TabIndex = 14;
            this.SaveFileDialog.Text = "参照";
            this.SaveFileDialog.UseVisualStyleBackColor = false;
            this.SaveFileDialog.Click += new System.EventHandler(this.SaveFileDialog_Click);
            // 
            // ExcelSaveFilePathTitleLbl
            // 
            this.ExcelSaveFilePathTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ExcelSaveFilePathTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExcelSaveFilePathTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ExcelSaveFilePathTitleLbl.Location = new System.Drawing.Point(3, 99);
            this.ExcelSaveFilePathTitleLbl.Name = "ExcelSaveFilePathTitleLbl";
            this.ExcelSaveFilePathTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ExcelSaveFilePathTitleLbl.TabIndex = 75;
            this.ExcelSaveFilePathTitleLbl.Text = "出力ファイルパス";
            this.ExcelSaveFilePathTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcelJobGrid
            // 
            this.ExcelJobGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.ExcelJobGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ExcelJobGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcelJobGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExcelJobGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXCELJOBGRID_COL_処理タイプ,
            this.EXCELJOBGRID_COL_シート名,
            this.EXCELJOBGRID_COL_セル名,
            this.EXCELJOBGRID_COL_値});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExcelJobGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExcelJobGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ExcelJobGrid.Location = new System.Drawing.Point(3, 126);
            this.ExcelJobGrid.MultiSelect = false;
            this.ExcelJobGrid.Name = "ExcelJobGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelJobGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ExcelJobGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ExcelJobGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExcelJobGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ExcelJobGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ExcelJobGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ExcelJobGrid.RowTemplate.Height = 21;
            this.ExcelJobGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExcelJobGrid.Size = new System.Drawing.Size(770, 381);
            this.ExcelJobGrid.TabIndex = 15;
            this.ExcelJobGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelJobGrid_CellEndEdit);
            this.ExcelJobGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.ExcelJobGrid_CurrentCellDirtyStateChanged);
            // 
            // EXCELJOBGRID_COL_処理タイプ
            // 
            this.EXCELJOBGRID_COL_処理タイプ.HeaderText = "処理タイプ";
            this.EXCELJOBGRID_COL_処理タイプ.Items.AddRange(new object[] {
            "読み込み",
            "書き込み"});
            this.EXCELJOBGRID_COL_処理タイプ.Name = "EXCELJOBGRID_COL_処理タイプ";
            // 
            // EXCELJOBGRID_COL_シート名
            // 
            this.EXCELJOBGRID_COL_シート名.HeaderText = "シート名";
            this.EXCELJOBGRID_COL_シート名.MinimumWidth = 200;
            this.EXCELJOBGRID_COL_シート名.Name = "EXCELJOBGRID_COL_シート名";
            this.EXCELJOBGRID_COL_シート名.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EXCELJOBGRID_COL_シート名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EXCELJOBGRID_COL_シート名.Width = 200;
            // 
            // EXCELJOBGRID_COL_セル名
            // 
            this.EXCELJOBGRID_COL_セル名.HeaderText = "セル名";
            this.EXCELJOBGRID_COL_セル名.Name = "EXCELJOBGRID_COL_セル名";
            this.EXCELJOBGRID_COL_セル名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EXCELJOBGRID_COL_値
            // 
            this.EXCELJOBGRID_COL_値.HeaderText = "値";
            this.EXCELJOBGRID_COL_値.MinimumWidth = 310;
            this.EXCELJOBGRID_COL_値.Name = "EXCELJOBGRID_COL_値";
            this.EXCELJOBGRID_COL_値.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EXCELJOBGRID_COL_値.Width = 310;
            // 
            // ExcelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExcelJobGrid);
            this.Controls.Add(this.ExcelSaveFilePathTextBox);
            this.Controls.Add(this.SaveFileDialog);
            this.Controls.Add(this.ExcelSaveFilePathTitleLbl);
            this.Controls.Add(this.ExcelLoadFilePathTextBox);
            this.Controls.Add(this.FileOpenButton);
            this.Controls.Add(this.ExcelLoadFilePathTitleLbl);
            this.Controls.Add(this.FileFolderTypePanel);
            this.Controls.Add(this.ExcelSourceTypeTitleLbl);
            this.Name = "ExcelControl";
            this.Controls.SetChildIndex(this.ExcelSourceTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.FileFolderTypePanel, 0);
            this.Controls.SetChildIndex(this.ExcelLoadFilePathTitleLbl, 0);
            this.Controls.SetChildIndex(this.FileOpenButton, 0);
            this.Controls.SetChildIndex(this.ExcelLoadFilePathTextBox, 0);
            this.Controls.SetChildIndex(this.ExcelSaveFilePathTitleLbl, 0);
            this.Controls.SetChildIndex(this.SaveFileDialog, 0);
            this.Controls.SetChildIndex(this.ExcelSaveFilePathTextBox, 0);
            this.Controls.SetChildIndex(this.ValidTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.ValidTypePanel, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.CompButton, 0);
            this.Controls.SetChildIndex(this.ErrorButton, 0);
            this.Controls.SetChildIndex(this.CompButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.ErrorButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.ExcelJobGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            this.FileFolderTypePanel.ResumeLayout(false);
            this.FileFolderTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelJobGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Components.BasePanel FileFolderTypePanel;
        public Components.BaseRadioButton ExcelSourceNewRadio;
        public Components.BaseRadioButton ExcelSourceExistsRadio;
        public Components.BaseLabel ExcelSourceTypeTitleLbl;
        public Components.BaseLabel ExcelLoadFilePathTitleLbl;
        public Components.BaseTextBox ExcelLoadFilePathTextBox;
        public Components.BaseButton FileOpenButton;
        public Components.BaseTextBox ExcelSaveFilePathTextBox;
        public Components.BaseButton SaveFileDialog;
        public Components.BaseLabel ExcelSaveFilePathTitleLbl;
        public Components.BaseDataGridView ExcelJobGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn EXCELJOBGRID_COL_処理タイプ;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXCELJOBGRID_COL_シート名;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXCELJOBGRID_COL_セル名;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXCELJOBGRID_COL_値;
        private System.Windows.Forms.SaveFileDialog ExcelSaveFileDialog;
    }
}
