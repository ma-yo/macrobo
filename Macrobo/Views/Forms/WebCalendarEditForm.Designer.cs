namespace Macrobo.Views.Forms
{
    partial class WebCalendarEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.baseLabel1 = new Macrobo.Components.BaseLabel();
            this.DescriptionLbl2 = new Macrobo.Components.BaseLabel();
            this.TestButton = new Macrobo.Components.BaseButton();
            this.ParamGrid = new Macrobo.Components.BaseDataGridView();
            this.COL_PARAMNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PARAMVALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlParamTitleLbl = new Macrobo.Components.BaseLabel();
            this.FileTypePanel = new Macrobo.Components.BasePanel();
            this.TxtTypeRadio = new Macrobo.Components.BaseRadioButton();
            this.CsvTypeRadio = new Macrobo.Components.BaseRadioButton();
            this.FileTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.DescriptionLbl1 = new Macrobo.Components.BaseLabel();
            this.UrlTextBox = new Macrobo.Components.BaseTextBox();
            this.UrlTitleLbl = new Macrobo.Components.BaseLabel();
            this.SaveButton = new Macrobo.Components.BaseButton();
            this.CalendarIDLbl = new Macrobo.Components.BaseLabel();
            this.DescriptionTitleLbl = new Macrobo.Components.BaseLabel();
            this.DescriptionTextBox = new Macrobo.Components.BaseTextBox();
            this.CalendarIDTitleLbl = new Macrobo.Components.BaseLabel();
            this.EncodeContainer = new Macrobo.Components.BasePanel();
            this.EncodeTitleLbl = new Macrobo.Components.BaseLabel();
            this.EncodePanel = new Macrobo.Components.BasePanel();
            this.EncodeUTF16Radio = new Macrobo.Components.BaseRadioButton();
            this.EncodeUTF8Radio = new Macrobo.Components.BaseRadioButton();
            this.EncodeSJISRadio = new Macrobo.Components.BaseRadioButton();
            this.EncodeEUCRadio = new Macrobo.Components.BaseRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ParamGrid)).BeginInit();
            this.FileTypePanel.SuspendLayout();
            this.EncodeContainer.SuspendLayout();
            this.EncodePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseLabel1
            // 
            this.baseLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseLabel1.BackColor = System.Drawing.Color.Silver;
            this.baseLabel1.Location = new System.Drawing.Point(12, 434);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(740, 1);
            this.baseLabel1.TabIndex = 104;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionLbl2
            // 
            this.DescriptionLbl2.AutoSize = true;
            this.DescriptionLbl2.Location = new System.Drawing.Point(12, 136);
            this.DescriptionLbl2.Name = "DescriptionLbl2";
            this.DescriptionLbl2.Size = new System.Drawing.Size(407, 12);
            this.DescriptionLbl2.TabIndex = 103;
            this.DescriptionLbl2.Text = "※システムに保存されるデータは、平日でOFFの場合か、休日でONの場合となります。";
            this.DescriptionLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestButton
            // 
            this.TestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TestButton.ForeColor = System.Drawing.Color.White;
            this.TestButton.Location = new System.Drawing.Point(583, 440);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(88, 24);
            this.TestButton.TabIndex = 102;
            this.TestButton.Text = "出力チェック";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // ParamGrid
            // 
            this.ParamGrid.AllowUserToDeleteRows = false;
            this.ParamGrid.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.ParamGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ParamGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParamGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_PARAMNAME,
            this.COL_PARAMVALUE});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParamGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ParamGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ParamGrid.Location = new System.Drawing.Point(114, 153);
            this.ParamGrid.Name = "ParamGrid";
            this.ParamGrid.RowHeadersVisible = false;
            this.ParamGrid.RowTemplate.Height = 21;
            this.ParamGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ParamGrid.Size = new System.Drawing.Size(638, 273);
            this.ParamGrid.TabIndex = 101;
            // 
            // COL_PARAMNAME
            // 
            this.COL_PARAMNAME.HeaderText = "パラメーター名";
            this.COL_PARAMNAME.MinimumWidth = 200;
            this.COL_PARAMNAME.Name = "COL_PARAMNAME";
            this.COL_PARAMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_PARAMNAME.Width = 200;
            // 
            // COL_PARAMVALUE
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_PARAMVALUE.DefaultCellStyle = dataGridViewCellStyle2;
            this.COL_PARAMVALUE.HeaderText = "値";
            this.COL_PARAMVALUE.MinimumWidth = 420;
            this.COL_PARAMVALUE.Name = "COL_PARAMVALUE";
            this.COL_PARAMVALUE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_PARAMVALUE.Width = 420;
            // 
            // UrlParamTitleLbl
            // 
            this.UrlParamTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UrlParamTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.UrlParamTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UrlParamTitleLbl.ForeColor = System.Drawing.Color.White;
            this.UrlParamTitleLbl.Location = new System.Drawing.Point(12, 153);
            this.UrlParamTitleLbl.Name = "UrlParamTitleLbl";
            this.UrlParamTitleLbl.Size = new System.Drawing.Size(103, 273);
            this.UrlParamTitleLbl.TabIndex = 100;
            this.UrlParamTitleLbl.Text = "URLパラメーター";
            this.UrlParamTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileTypePanel
            // 
            this.FileTypePanel.BackColor = System.Drawing.Color.White;
            this.FileTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileTypePanel.Controls.Add(this.TxtTypeRadio);
            this.FileTypePanel.Controls.Add(this.CsvTypeRadio);
            this.FileTypePanel.Location = new System.Drawing.Point(114, 59);
            this.FileTypePanel.Name = "FileTypePanel";
            this.FileTypePanel.Size = new System.Drawing.Size(311, 22);
            this.FileTypePanel.TabIndex = 3;
            // 
            // TxtTypeRadio
            // 
            this.TxtTypeRadio.AutoSize = true;
            this.TxtTypeRadio.Location = new System.Drawing.Point(160, 2);
            this.TxtTypeRadio.Name = "TxtTypeRadio";
            this.TxtTypeRadio.Size = new System.Drawing.Size(131, 16);
            this.TxtTypeRadio.TabIndex = 5;
            this.TxtTypeRadio.TabStop = true;
            this.TxtTypeRadio.Text = "TXT形式(TAB区切り)";
            this.TxtTypeRadio.UseVisualStyleBackColor = true;
            // 
            // CsvTypeRadio
            // 
            this.CsvTypeRadio.AutoSize = true;
            this.CsvTypeRadio.Location = new System.Drawing.Point(17, 2);
            this.CsvTypeRadio.Name = "CsvTypeRadio";
            this.CsvTypeRadio.Size = new System.Drawing.Size(137, 16);
            this.CsvTypeRadio.TabIndex = 4;
            this.CsvTypeRadio.TabStop = true;
            this.CsvTypeRadio.Text = "CSV形式(カンマ区切り)";
            this.CsvTypeRadio.UseVisualStyleBackColor = true;
            // 
            // FileTypeTitleLbl
            // 
            this.FileTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.FileTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.FileTypeTitleLbl.Location = new System.Drawing.Point(12, 59);
            this.FileTypeTitleLbl.Name = "FileTypeTitleLbl";
            this.FileTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.FileTypeTitleLbl.TabIndex = 99;
            this.FileTypeTitleLbl.Text = "ファイルタイプ";
            this.FileTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionLbl1
            // 
            this.DescriptionLbl1.AutoSize = true;
            this.DescriptionLbl1.Location = new System.Drawing.Point(431, 65);
            this.DescriptionLbl1.Name = "DescriptionLbl1";
            this.DescriptionLbl1.Size = new System.Drawing.Size(242, 12);
            this.DescriptionLbl1.TabIndex = 98;
            this.DescriptionLbl1.Text = "※データフォーマットはマニュアルにてご確認ください。";
            this.DescriptionLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UrlTextBox.DefaultAlphaNumberOnly = false;
            this.UrlTextBox.DefaultClickSelectAll = false;
            this.UrlTextBox.DefaultNarrow = false;
            this.UrlTextBox.DefaultNumberOnly = false;
            this.UrlTextBox.DefaultToUpper = false;
            this.UrlTextBox.DefaultTrim = false;
            this.UrlTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.UrlTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.UrlTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.UrlTextBox.Location = new System.Drawing.Point(114, 109);
            this.UrlTextBox.MaxLength = 36656;
            this.UrlTextBox.MaxLengthBytes = 0;
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.UrlTextBox.Size = new System.Drawing.Size(638, 22);
            this.UrlTextBox.TabIndex = 9;
            this.UrlTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // UrlTitleLbl
            // 
            this.UrlTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.UrlTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UrlTitleLbl.ForeColor = System.Drawing.Color.White;
            this.UrlTitleLbl.Location = new System.Drawing.Point(12, 109);
            this.UrlTitleLbl.Name = "UrlTitleLbl";
            this.UrlTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.UrlTitleLbl.TabIndex = 96;
            this.UrlTitleLbl.Text = "取得先URL";
            this.UrlTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(677, 440);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 24);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CalendarIDLbl
            // 
            this.CalendarIDLbl.BackColor = System.Drawing.Color.White;
            this.CalendarIDLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalendarIDLbl.ForeColor = System.Drawing.Color.Black;
            this.CalendarIDLbl.Location = new System.Drawing.Point(114, 9);
            this.CalendarIDLbl.Name = "CalendarIDLbl";
            this.CalendarIDLbl.Size = new System.Drawing.Size(87, 22);
            this.CalendarIDLbl.TabIndex = 1;
            this.CalendarIDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionTitleLbl
            // 
            this.DescriptionTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.DescriptionTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTitleLbl.ForeColor = System.Drawing.Color.White;
            this.DescriptionTitleLbl.Location = new System.Drawing.Point(12, 32);
            this.DescriptionTitleLbl.Name = "DescriptionTitleLbl";
            this.DescriptionTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.DescriptionTitleLbl.TabIndex = 93;
            this.DescriptionTitleLbl.Text = "カレンダー名";
            this.DescriptionTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTextBox.DefaultAlphaNumberOnly = false;
            this.DescriptionTextBox.DefaultClickSelectAll = false;
            this.DescriptionTextBox.DefaultNarrow = false;
            this.DescriptionTextBox.DefaultNumberOnly = false;
            this.DescriptionTextBox.DefaultToUpper = false;
            this.DescriptionTextBox.DefaultTrim = false;
            this.DescriptionTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.DescriptionTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.DescriptionTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.DescriptionTextBox.Location = new System.Drawing.Point(113, 32);
            this.DescriptionTextBox.MaxLength = 256;
            this.DescriptionTextBox.MaxLengthBytes = 0;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.DescriptionTextBox.Size = new System.Drawing.Size(312, 22);
            this.DescriptionTextBox.TabIndex = 2;
            this.DescriptionTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // CalendarIDTitleLbl
            // 
            this.CalendarIDTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.CalendarIDTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalendarIDTitleLbl.ForeColor = System.Drawing.Color.White;
            this.CalendarIDTitleLbl.Location = new System.Drawing.Point(12, 9);
            this.CalendarIDTitleLbl.Name = "CalendarIDTitleLbl";
            this.CalendarIDTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.CalendarIDTitleLbl.TabIndex = 91;
            this.CalendarIDTitleLbl.Text = "カレンダーID";
            this.CalendarIDTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EncodeContainer
            // 
            this.EncodeContainer.BackColor = System.Drawing.Color.White;
            this.EncodeContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncodeContainer.Controls.Add(this.EncodeTitleLbl);
            this.EncodeContainer.Controls.Add(this.EncodePanel);
            this.EncodeContainer.Location = new System.Drawing.Point(12, 82);
            this.EncodeContainer.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.EncodeContainer.Name = "EncodeContainer";
            this.EncodeContainer.Size = new System.Drawing.Size(350, 22);
            this.EncodeContainer.TabIndex = 111;
            // 
            // EncodeTitleLbl
            // 
            this.EncodeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.EncodeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncodeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.EncodeTitleLbl.Location = new System.Drawing.Point(-1, -1);
            this.EncodeTitleLbl.Name = "EncodeTitleLbl";
            this.EncodeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.EncodeTitleLbl.TabIndex = 102;
            this.EncodeTitleLbl.Text = "文字コード";
            this.EncodeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EncodePanel
            // 
            this.EncodePanel.BackColor = System.Drawing.Color.White;
            this.EncodePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncodePanel.Controls.Add(this.EncodeUTF16Radio);
            this.EncodePanel.Controls.Add(this.EncodeUTF8Radio);
            this.EncodePanel.Controls.Add(this.EncodeSJISRadio);
            this.EncodePanel.Controls.Add(this.EncodeEUCRadio);
            this.EncodePanel.Location = new System.Drawing.Point(101, -1);
            this.EncodePanel.Margin = new System.Windows.Forms.Padding(2);
            this.EncodePanel.Name = "EncodePanel";
            this.EncodePanel.Size = new System.Drawing.Size(248, 22);
            this.EncodePanel.TabIndex = 101;
            // 
            // EncodeUTF16Radio
            // 
            this.EncodeUTF16Radio.AutoSize = true;
            this.EncodeUTF16Radio.Location = new System.Drawing.Point(182, 2);
            this.EncodeUTF16Radio.Margin = new System.Windows.Forms.Padding(2);
            this.EncodeUTF16Radio.Name = "EncodeUTF16Radio";
            this.EncodeUTF16Radio.Size = new System.Drawing.Size(63, 16);
            this.EncodeUTF16Radio.TabIndex = 28;
            this.EncodeUTF16Radio.TabStop = true;
            this.EncodeUTF16Radio.Text = "UTF-16";
            this.EncodeUTF16Radio.UseVisualStyleBackColor = true;
            // 
            // EncodeUTF8Radio
            // 
            this.EncodeUTF8Radio.AutoSize = true;
            this.EncodeUTF8Radio.Location = new System.Drawing.Point(121, 2);
            this.EncodeUTF8Radio.Margin = new System.Windows.Forms.Padding(2);
            this.EncodeUTF8Radio.Name = "EncodeUTF8Radio";
            this.EncodeUTF8Radio.Size = new System.Drawing.Size(57, 16);
            this.EncodeUTF8Radio.TabIndex = 27;
            this.EncodeUTF8Radio.TabStop = true;
            this.EncodeUTF8Radio.Text = "UTF-8";
            this.EncodeUTF8Radio.UseVisualStyleBackColor = true;
            // 
            // EncodeSJISRadio
            // 
            this.EncodeSJISRadio.AutoSize = true;
            this.EncodeSJISRadio.Location = new System.Drawing.Point(2, 2);
            this.EncodeSJISRadio.Margin = new System.Windows.Forms.Padding(2);
            this.EncodeSJISRadio.Name = "EncodeSJISRadio";
            this.EncodeSJISRadio.Size = new System.Drawing.Size(47, 16);
            this.EncodeSJISRadio.TabIndex = 25;
            this.EncodeSJISRadio.TabStop = true;
            this.EncodeSJISRadio.Text = "SJIS";
            this.EncodeSJISRadio.UseVisualStyleBackColor = true;
            // 
            // EncodeEUCRadio
            // 
            this.EncodeEUCRadio.AutoSize = true;
            this.EncodeEUCRadio.Location = new System.Drawing.Point(53, 2);
            this.EncodeEUCRadio.Margin = new System.Windows.Forms.Padding(2);
            this.EncodeEUCRadio.Name = "EncodeEUCRadio";
            this.EncodeEUCRadio.Size = new System.Drawing.Size(66, 16);
            this.EncodeEUCRadio.TabIndex = 26;
            this.EncodeEUCRadio.TabStop = true;
            this.EncodeEUCRadio.Text = "EUC-JP";
            this.EncodeEUCRadio.UseVisualStyleBackColor = true;
            // 
            // WebCalendarEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 469);
            this.Controls.Add(this.EncodeContainer);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.DescriptionLbl2);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.ParamGrid);
            this.Controls.Add(this.UrlParamTitleLbl);
            this.Controls.Add(this.FileTypePanel);
            this.Controls.Add(this.FileTypeTitleLbl);
            this.Controls.Add(this.DescriptionLbl1);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.UrlTitleLbl);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CalendarIDLbl);
            this.Controls.Add(this.DescriptionTitleLbl);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.CalendarIDTitleLbl);
            this.MaximizeBox = false;
            this.Name = "WebCalendarEditForm";
            this.Text = "Macrobo (マクロボ) - WEBカレンダー作成・修正";
            ((System.ComponentModel.ISupportInitialize)(this.ParamGrid)).EndInit();
            this.FileTypePanel.ResumeLayout(false);
            this.FileTypePanel.PerformLayout();
            this.EncodeContainer.ResumeLayout(false);
            this.EncodePanel.ResumeLayout(false);
            this.EncodePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.BaseButton SaveButton;
        public Components.BaseLabel CalendarIDLbl;
        public Components.BaseLabel DescriptionTitleLbl;
        public Components.BaseTextBox DescriptionTextBox;
        public Components.BaseLabel CalendarIDTitleLbl;
        public Components.BaseLabel UrlTitleLbl;
        public Components.BaseTextBox UrlTextBox;
        private Components.BaseLabel DescriptionLbl1;
        public Components.BaseLabel FileTypeTitleLbl;
        private Components.BasePanel FileTypePanel;
        private Components.BaseRadioButton CsvTypeRadio;
        private Components.BaseRadioButton TxtTypeRadio;
        public Components.BaseLabel UrlParamTitleLbl;
        private Components.BaseDataGridView ParamGrid;
        private Components.BaseButton TestButton;
        private Components.BaseLabel DescriptionLbl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PARAMNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PARAMVALUE;
        private Components.BaseLabel baseLabel1;
        private Components.BasePanel EncodeContainer;
        public Components.BaseLabel EncodeTitleLbl;
        public Components.BasePanel EncodePanel;
        public Components.BaseRadioButton EncodeUTF16Radio;
        public Components.BaseRadioButton EncodeUTF8Radio;
        public Components.BaseRadioButton EncodeSJISRadio;
        public Components.BaseRadioButton EncodeEUCRadio;
    }
}