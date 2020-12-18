namespace Macrobo.Views
{
    partial class NodeControl
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
            this.TitleLbl = new Macrobo.Components.BaseLabel();
            this.ProjTitleLbl = new Macrobo.Components.BaseLabel();
            this.ProjTextBox = new Macrobo.Components.BaseTextBox();
            this.ProcessTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.ProcessTypePanel = new Macrobo.Components.BasePanel();
            this.ExcelRadio = new Macrobo.Components.BaseRadioButton();
            this.DialogRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderRadio = new Macrobo.Components.BaseRadioButton();
            this.VariableRadio = new Macrobo.Components.BaseRadioButton();
            this.AppStartRadio = new Macrobo.Components.BaseRadioButton();
            this.WaitRadio = new Macrobo.Components.BaseRadioButton();
            this.MailSendRadio = new Macrobo.Components.BaseRadioButton();
            this.DetectRadio = new Macrobo.Components.BaseRadioButton();
            this.MouseInputRadio = new Macrobo.Components.BaseRadioButton();
            this.KeyboardInputRadio = new Macrobo.Components.BaseRadioButton();
            this.ContainerPanel = new Macrobo.Components.BasePanel();
            this.DescriptionTextBox = new Macrobo.Components.BaseTextBox();
            this.DescriptionTitleLbl = new Macrobo.Components.BaseLabel();
            this.ProcessTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLbl.BackColor = System.Drawing.Color.Teal;
            this.TitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleLbl.ForeColor = System.Drawing.Color.White;
            this.TitleLbl.Location = new System.Drawing.Point(-1, -1);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(754, 20);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "プロジェクト情報";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjTitleLbl
            // 
            this.ProjTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ProjTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ProjTitleLbl.Location = new System.Drawing.Point(3, 20);
            this.ProjTitleLbl.Name = "ProjTitleLbl";
            this.ProjTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.ProjTitleLbl.TabIndex = 1;
            this.ProjTitleLbl.Text = "プロジェクト名";
            this.ProjTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjTextBox
            // 
            this.ProjTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjTextBox.DefaultAlphaNumberOnly = false;
            this.ProjTextBox.DefaultClickSelectAll = false;
            this.ProjTextBox.DefaultNarrow = false;
            this.ProjTextBox.DefaultNumberOnly = false;
            this.ProjTextBox.DefaultToUpper = false;
            this.ProjTextBox.DefaultTrim = false;
            this.ProjTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ProjTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ProjTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ProjTextBox.Location = new System.Drawing.Point(81, 20);
            this.ProjTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProjTextBox.MaxLength = 128;
            this.ProjTextBox.MaxLengthBytes = 0;
            this.ProjTextBox.Name = "ProjTextBox";
            this.ProjTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ProjTextBox.Size = new System.Drawing.Size(364, 22);
            this.ProjTextBox.TabIndex = 0;
            this.ProjTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ProjTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProjTextBox_KeyUp);
            // 
            // ProcessTypeTitleLbl
            // 
            this.ProcessTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ProcessTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ProcessTypeTitleLbl.Location = new System.Drawing.Point(3, 43);
            this.ProcessTypeTitleLbl.Name = "ProcessTypeTitleLbl";
            this.ProcessTypeTitleLbl.Size = new System.Drawing.Size(79, 26);
            this.ProcessTypeTitleLbl.TabIndex = 4;
            this.ProcessTypeTitleLbl.Text = "処理タイプ";
            this.ProcessTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessTypePanel
            // 
            this.ProcessTypePanel.BackColor = System.Drawing.Color.White;
            this.ProcessTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessTypePanel.Controls.Add(this.ExcelRadio);
            this.ProcessTypePanel.Controls.Add(this.DialogRadio);
            this.ProcessTypePanel.Controls.Add(this.FileFolderRadio);
            this.ProcessTypePanel.Controls.Add(this.VariableRadio);
            this.ProcessTypePanel.Controls.Add(this.AppStartRadio);
            this.ProcessTypePanel.Controls.Add(this.WaitRadio);
            this.ProcessTypePanel.Controls.Add(this.MailSendRadio);
            this.ProcessTypePanel.Controls.Add(this.DetectRadio);
            this.ProcessTypePanel.Controls.Add(this.MouseInputRadio);
            this.ProcessTypePanel.Controls.Add(this.KeyboardInputRadio);
            this.ProcessTypePanel.Location = new System.Drawing.Point(81, 43);
            this.ProcessTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProcessTypePanel.Name = "ProcessTypePanel";
            this.ProcessTypePanel.Size = new System.Drawing.Size(666, 26);
            this.ProcessTypePanel.TabIndex = 1;
            // 
            // ExcelRadio
            // 
            this.ExcelRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.ExcelRadio.AutoCheck = false;
            this.ExcelRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ExcelRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ExcelRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ExcelRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ExcelRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.ExcelRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExcelRadio.Image = global::Macrobo.Properties.Resources.icons8_excel_15;
            this.ExcelRadio.Location = new System.Drawing.Point(603, 1);
            this.ExcelRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ExcelRadio.Name = "ExcelRadio";
            this.ExcelRadio.Size = new System.Drawing.Size(60, 22);
            this.ExcelRadio.TabIndex = 11;
            this.ExcelRadio.TabStop = true;
            this.ExcelRadio.Text = "Excel";
            this.ExcelRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExcelRadio.UseVisualStyleBackColor = false;
            this.ExcelRadio.CheckedChanged += new System.EventHandler(this.ExcelRadio_CheckedChanged);
            // 
            // DialogRadio
            // 
            this.DialogRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.DialogRadio.AutoCheck = false;
            this.DialogRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DialogRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DialogRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DialogRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.DialogRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.DialogRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DialogRadio.Image = global::Macrobo.Properties.Resources.icons8_chat_bubble_filled_15;
            this.DialogRadio.Location = new System.Drawing.Point(527, 1);
            this.DialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.DialogRadio.Name = "DialogRadio";
            this.DialogRadio.Size = new System.Drawing.Size(75, 22);
            this.DialogRadio.TabIndex = 10;
            this.DialogRadio.TabStop = true;
            this.DialogRadio.Text = "ダイアログ";
            this.DialogRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DialogRadio.UseVisualStyleBackColor = false;
            this.DialogRadio.CheckedChanged += new System.EventHandler(this.DialogRadio_CheckedChanged);
            // 
            // FileFolderRadio
            // 
            this.FileFolderRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.FileFolderRadio.AutoCheck = false;
            this.FileFolderRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileFolderRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.FileFolderRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FileFolderRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.FileFolderRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.FileFolderRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileFolderRadio.Image = global::Macrobo.Properties.Resources.icons8_doc_folder_filled_15;
            this.FileFolderRadio.Location = new System.Drawing.Point(420, 1);
            this.FileFolderRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderRadio.Name = "FileFolderRadio";
            this.FileFolderRadio.Size = new System.Drawing.Size(106, 22);
            this.FileFolderRadio.TabIndex = 9;
            this.FileFolderRadio.TabStop = true;
            this.FileFolderRadio.Text = "ファイル・フォルダ";
            this.FileFolderRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FileFolderRadio.UseVisualStyleBackColor = false;
            this.FileFolderRadio.CheckedChanged += new System.EventHandler(this.FileFolderRadio_CheckedChanged);
            // 
            // VariableRadio
            // 
            this.VariableRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.VariableRadio.AutoCheck = false;
            this.VariableRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.VariableRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.VariableRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VariableRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.VariableRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.VariableRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VariableRadio.Image = global::Macrobo.Properties.Resources.icons8_variable_filled_15;
            this.VariableRadio.Location = new System.Drawing.Point(364, 1);
            this.VariableRadio.Margin = new System.Windows.Forms.Padding(2);
            this.VariableRadio.Name = "VariableRadio";
            this.VariableRadio.Size = new System.Drawing.Size(55, 22);
            this.VariableRadio.TabIndex = 8;
            this.VariableRadio.TabStop = true;
            this.VariableRadio.Text = "変数";
            this.VariableRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.VariableRadio.UseVisualStyleBackColor = false;
            this.VariableRadio.CheckedChanged += new System.EventHandler(this.VariableRadio_CheckedChanged);
            // 
            // AppStartRadio
            // 
            this.AppStartRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.AppStartRadio.AutoCheck = false;
            this.AppStartRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AppStartRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AppStartRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.AppStartRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AppStartRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.AppStartRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppStartRadio.Image = global::Macrobo.Properties.Resources.icons8_windows;
            this.AppStartRadio.Location = new System.Drawing.Point(308, 1);
            this.AppStartRadio.Margin = new System.Windows.Forms.Padding(2);
            this.AppStartRadio.Name = "AppStartRadio";
            this.AppStartRadio.Size = new System.Drawing.Size(55, 22);
            this.AppStartRadio.TabIndex = 7;
            this.AppStartRadio.TabStop = true;
            this.AppStartRadio.Text = "アプリ";
            this.AppStartRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AppStartRadio.UseVisualStyleBackColor = false;
            this.AppStartRadio.CheckedChanged += new System.EventHandler(this.AppStartRadio_CheckedChanged);
            // 
            // WaitRadio
            // 
            this.WaitRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.WaitRadio.AutoCheck = false;
            this.WaitRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.WaitRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.WaitRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.WaitRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.WaitRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.WaitRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WaitRadio.Image = global::Macrobo.Properties.Resources.icons8_spinner_15;
            this.WaitRadio.Location = new System.Drawing.Point(194, 1);
            this.WaitRadio.Margin = new System.Windows.Forms.Padding(2);
            this.WaitRadio.Name = "WaitRadio";
            this.WaitRadio.Size = new System.Drawing.Size(54, 22);
            this.WaitRadio.TabIndex = 5;
            this.WaitRadio.TabStop = true;
            this.WaitRadio.Text = "待機";
            this.WaitRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.WaitRadio.UseVisualStyleBackColor = false;
            this.WaitRadio.CheckedChanged += new System.EventHandler(this.WaitRadio_CheckedChanged);
            // 
            // MailSendRadio
            // 
            this.MailSendRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.MailSendRadio.AutoCheck = false;
            this.MailSendRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MailSendRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.MailSendRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MailSendRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.MailSendRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.MailSendRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MailSendRadio.Image = global::Macrobo.Properties.Resources.icons8_email_15;
            this.MailSendRadio.Location = new System.Drawing.Point(249, 1);
            this.MailSendRadio.Margin = new System.Windows.Forms.Padding(2);
            this.MailSendRadio.Name = "MailSendRadio";
            this.MailSendRadio.Size = new System.Drawing.Size(58, 22);
            this.MailSendRadio.TabIndex = 6;
            this.MailSendRadio.TabStop = true;
            this.MailSendRadio.Text = "メール";
            this.MailSendRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MailSendRadio.UseVisualStyleBackColor = false;
            this.MailSendRadio.CheckedChanged += new System.EventHandler(this.MailSendRadio_CheckedChanged);
            // 
            // DetectRadio
            // 
            this.DetectRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.DetectRadio.AutoCheck = false;
            this.DetectRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DetectRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DetectRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DetectRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.DetectRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.DetectRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetectRadio.Image = global::Macrobo.Properties.Resources.icons8_search_15;
            this.DetectRadio.Location = new System.Drawing.Point(1, 1);
            this.DetectRadio.Margin = new System.Windows.Forms.Padding(2);
            this.DetectRadio.Name = "DetectRadio";
            this.DetectRadio.Size = new System.Drawing.Size(54, 22);
            this.DetectRadio.TabIndex = 2;
            this.DetectRadio.TabStop = true;
            this.DetectRadio.Text = "検出";
            this.DetectRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DetectRadio.UseVisualStyleBackColor = false;
            this.DetectRadio.CheckedChanged += new System.EventHandler(this.DetectButton_CheckedChanged);
            // 
            // MouseInputRadio
            // 
            this.MouseInputRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.MouseInputRadio.AutoCheck = false;
            this.MouseInputRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MouseInputRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.MouseInputRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MouseInputRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.MouseInputRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.MouseInputRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MouseInputRadio.Image = global::Macrobo.Properties.Resources.icons8_mouse_filled_15;
            this.MouseInputRadio.Location = new System.Drawing.Point(136, 1);
            this.MouseInputRadio.Margin = new System.Windows.Forms.Padding(2);
            this.MouseInputRadio.Name = "MouseInputRadio";
            this.MouseInputRadio.Size = new System.Drawing.Size(57, 22);
            this.MouseInputRadio.TabIndex = 4;
            this.MouseInputRadio.TabStop = true;
            this.MouseInputRadio.Text = "マウス";
            this.MouseInputRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MouseInputRadio.UseVisualStyleBackColor = false;
            this.MouseInputRadio.CheckedChanged += new System.EventHandler(this.ClickRadio_CheckedChanged);
            // 
            // KeyboardInputRadio
            // 
            this.KeyboardInputRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.KeyboardInputRadio.AutoCheck = false;
            this.KeyboardInputRadio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.KeyboardInputRadio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.KeyboardInputRadio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.KeyboardInputRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.KeyboardInputRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.KeyboardInputRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeyboardInputRadio.Image = global::Macrobo.Properties.Resources.icons8_keyboard_15;
            this.KeyboardInputRadio.Location = new System.Drawing.Point(56, 1);
            this.KeyboardInputRadio.Margin = new System.Windows.Forms.Padding(2);
            this.KeyboardInputRadio.Name = "KeyboardInputRadio";
            this.KeyboardInputRadio.Size = new System.Drawing.Size(79, 22);
            this.KeyboardInputRadio.TabIndex = 3;
            this.KeyboardInputRadio.TabStop = true;
            this.KeyboardInputRadio.Text = "キーボード";
            this.KeyboardInputRadio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.KeyboardInputRadio.UseVisualStyleBackColor = false;
            this.KeyboardInputRadio.CheckedChanged += new System.EventHandler(this.InputRadio_CheckedChanged);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContainerPanel.BackColor = System.Drawing.Color.White;
            this.ContainerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContainerPanel.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.ContainerPanel.Location = new System.Drawing.Point(3, 70);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(744, 460);
            this.ContainerPanel.TabIndex = 12;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.DescriptionTextBox.Location = new System.Drawing.Point(524, 20);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionTextBox.MaxLength = 128;
            this.DescriptionTextBox.MaxLengthBytes = 0;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.DescriptionTextBox.Size = new System.Drawing.Size(223, 22);
            this.DescriptionTextBox.TabIndex = 13;
            this.DescriptionTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.DescriptionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyUp);
            // 
            // DescriptionTitleLbl
            // 
            this.DescriptionTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.DescriptionTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTitleLbl.ForeColor = System.Drawing.Color.White;
            this.DescriptionTitleLbl.Location = new System.Drawing.Point(446, 20);
            this.DescriptionTitleLbl.Name = "DescriptionTitleLbl";
            this.DescriptionTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.DescriptionTitleLbl.TabIndex = 14;
            this.DescriptionTitleLbl.Text = "動作説明";
            this.DescriptionTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionTitleLbl);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.ProcessTypePanel);
            this.Controls.Add(this.ProcessTypeTitleLbl);
            this.Controls.Add(this.ProjTextBox);
            this.Controls.Add(this.ProjTitleLbl);
            this.Controls.Add(this.TitleLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NodeControl";
            this.Size = new System.Drawing.Size(752, 536);
            this.ProcessTypePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Components.BaseLabel TitleLbl;
        public Components.BaseLabel ProjTitleLbl;
        public Components.BaseTextBox ProjTextBox;
        public Components.BaseRadioButton KeyboardInputRadio;
        public Components.BaseRadioButton MouseInputRadio;
        public Components.BaseRadioButton DetectRadio;
        public Components.BaseLabel ProcessTypeTitleLbl;
        public Components.BasePanel ProcessTypePanel;
        public Components.BasePanel ContainerPanel;
        public Components.BaseRadioButton MailSendRadio;
        public Components.BaseRadioButton WaitRadio;
        public Components.BaseRadioButton AppStartRadio;
        public Components.BaseRadioButton VariableRadio;
        public Components.BaseRadioButton FileFolderRadio;
        public Components.BaseRadioButton DialogRadio;
        public Components.BaseRadioButton ExcelRadio;
        public Components.BaseTextBox DescriptionTextBox;
        public Components.BaseLabel DescriptionTitleLbl;
    }
}
