namespace Macrobo.Views.Controls
{
    partial class FileFolderControl
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
            this.FileFolderExecTypePanel = new Macrobo.Components.BasePanel();
            this.FileFolderZipUnArchiveRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderZipArchiveRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderCopyRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderSaveUdateRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderMoveRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderRemoveRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderDetectRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderCreateRadio = new Macrobo.Components.BaseRadioButton();
            this.FileFolderExecTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.FileFolderActionTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.FileFolderTypePanel = new Macrobo.Components.BasePanel();
            this.FileActionRadio = new Macrobo.Components.BaseRadioButton();
            this.FolderActionRadio = new Macrobo.Components.BaseRadioButton();
            this.VariableTitleLbl = new Macrobo.Components.BaseLabel();
            this.VariableButton = new Macrobo.Components.BaseButton();
            this.TimeoutTitleLbl = new Macrobo.Components.BaseLabel();
            this.TimeoutNumericUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.FileFolderPath1TitleLbl = new Macrobo.Components.BaseLabel();
            this.FileFolderPath1TextBox = new Macrobo.Components.BaseTextBox();
            this.FileFolderOpen1Button = new Macrobo.Components.BaseButton();
            this.FileFolderPath2TitleLbl = new Macrobo.Components.BaseLabel();
            this.FileFolderOpen2Button = new Macrobo.Components.BaseButton();
            this.FileFolderPath2TextBox = new Macrobo.Components.BaseTextBox();
            this.ZipPasswordTitleLbl = new Macrobo.Components.BaseLabel();
            this.ZipPasswordTextBox = new Macrobo.Components.BaseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
            this.FileFolderExecTypePanel.SuspendLayout();
            this.FileFolderTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AfterWaitTimeUpDown
            // 
            this.AfterWaitTimeUpDown.TabIndex = 5;
            // 
            // BeforeWaitTimeUpDown
            // 
            this.BeforeWaitTimeUpDown.TabIndex = 4;
            // 
            // ValidTypePanel
            // 
            this.ValidTypePanel.TabIndex = 1;
            // 
            // ErrorButtonTitleLbl
            // 
            this.ErrorButtonTitleLbl.TabIndex = 74;
            // 
            // CompButtonTitleLbl
            // 
            this.CompButtonTitleLbl.TabIndex = 73;
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
            // FileFolderExecTypePanel
            // 
            this.FileFolderExecTypePanel.BackColor = System.Drawing.Color.White;
            this.FileFolderExecTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderZipUnArchiveRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderZipArchiveRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderCopyRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderSaveUdateRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderMoveRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderRemoveRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderDetectRadio);
            this.FileFolderExecTypePanel.Controls.Add(this.FileFolderCreateRadio);
            this.FileFolderExecTypePanel.Location = new System.Drawing.Point(105, 76);
            this.FileFolderExecTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderExecTypePanel.Name = "FileFolderExecTypePanel";
            this.FileFolderExecTypePanel.Size = new System.Drawing.Size(521, 22);
            this.FileFolderExecTypePanel.TabIndex = 11;
            // 
            // FileFolderZipUnArchiveRadio
            // 
            this.FileFolderZipUnArchiveRadio.AutoSize = true;
            this.FileFolderZipUnArchiveRadio.Location = new System.Drawing.Point(455, 2);
            this.FileFolderZipUnArchiveRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderZipUnArchiveRadio.Name = "FileFolderZipUnArchiveRadio";
            this.FileFolderZipUnArchiveRadio.Size = new System.Drawing.Size(63, 16);
            this.FileFolderZipUnArchiveRadio.TabIndex = 19;
            this.FileFolderZipUnArchiveRadio.TabStop = true;
            this.FileFolderZipUnArchiveRadio.Text = "Zip解凍";
            this.FileFolderZipUnArchiveRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderZipArchiveRadio
            // 
            this.FileFolderZipArchiveRadio.AutoSize = true;
            this.FileFolderZipArchiveRadio.Location = new System.Drawing.Point(388, 2);
            this.FileFolderZipArchiveRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderZipArchiveRadio.Name = "FileFolderZipArchiveRadio";
            this.FileFolderZipArchiveRadio.Size = new System.Drawing.Size(63, 16);
            this.FileFolderZipArchiveRadio.TabIndex = 18;
            this.FileFolderZipArchiveRadio.TabStop = true;
            this.FileFolderZipArchiveRadio.Text = "Zip圧縮";
            this.FileFolderZipArchiveRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderCopyRadio
            // 
            this.FileFolderCopyRadio.AutoSize = true;
            this.FileFolderCopyRadio.Location = new System.Drawing.Point(213, 2);
            this.FileFolderCopyRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderCopyRadio.Name = "FileFolderCopyRadio";
            this.FileFolderCopyRadio.Size = new System.Drawing.Size(50, 16);
            this.FileFolderCopyRadio.TabIndex = 17;
            this.FileFolderCopyRadio.TabStop = true;
            this.FileFolderCopyRadio.Text = "コピー";
            this.FileFolderCopyRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderSaveUdateRadio
            // 
            this.FileFolderSaveUdateRadio.AutoSize = true;
            this.FileFolderSaveUdateRadio.Location = new System.Drawing.Point(267, 2);
            this.FileFolderSaveUdateRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderSaveUdateRadio.Name = "FileFolderSaveUdateRadio";
            this.FileFolderSaveUdateRadio.Size = new System.Drawing.Size(117, 16);
            this.FileFolderSaveUdateRadio.TabIndex = 16;
            this.FileFolderSaveUdateRadio.TabStop = true;
            this.FileFolderSaveUdateRadio.Text = "最終更新日の保存";
            this.FileFolderSaveUdateRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderMoveRadio
            // 
            this.FileFolderMoveRadio.AutoSize = true;
            this.FileFolderMoveRadio.Location = new System.Drawing.Point(162, 2);
            this.FileFolderMoveRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderMoveRadio.Name = "FileFolderMoveRadio";
            this.FileFolderMoveRadio.Size = new System.Drawing.Size(47, 16);
            this.FileFolderMoveRadio.TabIndex = 15;
            this.FileFolderMoveRadio.TabStop = true;
            this.FileFolderMoveRadio.Text = "移動";
            this.FileFolderMoveRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderRemoveRadio
            // 
            this.FileFolderRemoveRadio.AutoSize = true;
            this.FileFolderRemoveRadio.Location = new System.Drawing.Point(111, 2);
            this.FileFolderRemoveRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderRemoveRadio.Name = "FileFolderRemoveRadio";
            this.FileFolderRemoveRadio.Size = new System.Drawing.Size(47, 16);
            this.FileFolderRemoveRadio.TabIndex = 14;
            this.FileFolderRemoveRadio.TabStop = true;
            this.FileFolderRemoveRadio.Text = "削除";
            this.FileFolderRemoveRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderDetectRadio
            // 
            this.FileFolderDetectRadio.AutoSize = true;
            this.FileFolderDetectRadio.Location = new System.Drawing.Point(9, 2);
            this.FileFolderDetectRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderDetectRadio.Name = "FileFolderDetectRadio";
            this.FileFolderDetectRadio.Size = new System.Drawing.Size(47, 16);
            this.FileFolderDetectRadio.TabIndex = 12;
            this.FileFolderDetectRadio.TabStop = true;
            this.FileFolderDetectRadio.Text = "検出";
            this.FileFolderDetectRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderCreateRadio
            // 
            this.FileFolderCreateRadio.AutoSize = true;
            this.FileFolderCreateRadio.Location = new System.Drawing.Point(60, 2);
            this.FileFolderCreateRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderCreateRadio.Name = "FileFolderCreateRadio";
            this.FileFolderCreateRadio.Size = new System.Drawing.Size(47, 16);
            this.FileFolderCreateRadio.TabIndex = 13;
            this.FileFolderCreateRadio.TabStop = true;
            this.FileFolderCreateRadio.Text = "作成";
            this.FileFolderCreateRadio.UseVisualStyleBackColor = true;
            // 
            // FileFolderExecTypeTitleLbl
            // 
            this.FileFolderExecTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.FileFolderExecTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderExecTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.FileFolderExecTypeTitleLbl.Location = new System.Drawing.Point(3, 76);
            this.FileFolderExecTypeTitleLbl.Name = "FileFolderExecTypeTitleLbl";
            this.FileFolderExecTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.FileFolderExecTypeTitleLbl.TabIndex = 50;
            this.FileFolderExecTypeTitleLbl.Text = "実行タイプ";
            this.FileFolderExecTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileFolderActionTypeTitleLbl
            // 
            this.FileFolderActionTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.FileFolderActionTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderActionTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.FileFolderActionTypeTitleLbl.Location = new System.Drawing.Point(3, 53);
            this.FileFolderActionTypeTitleLbl.Name = "FileFolderActionTypeTitleLbl";
            this.FileFolderActionTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.FileFolderActionTypeTitleLbl.TabIndex = 51;
            this.FileFolderActionTypeTitleLbl.Text = "操作タイプ";
            this.FileFolderActionTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileFolderTypePanel
            // 
            this.FileFolderTypePanel.BackColor = System.Drawing.Color.White;
            this.FileFolderTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderTypePanel.Controls.Add(this.FileActionRadio);
            this.FileFolderTypePanel.Controls.Add(this.FolderActionRadio);
            this.FileFolderTypePanel.Location = new System.Drawing.Point(105, 53);
            this.FileFolderTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.FileFolderTypePanel.Name = "FileFolderTypePanel";
            this.FileFolderTypePanel.Size = new System.Drawing.Size(145, 22);
            this.FileFolderTypePanel.TabIndex = 8;
            // 
            // FileActionRadio
            // 
            this.FileActionRadio.AutoSize = true;
            this.FileActionRadio.Location = new System.Drawing.Point(7, 2);
            this.FileActionRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FileActionRadio.Name = "FileActionRadio";
            this.FileActionRadio.Size = new System.Drawing.Size(57, 16);
            this.FileActionRadio.TabIndex = 9;
            this.FileActionRadio.TabStop = true;
            this.FileActionRadio.Text = "ファイル";
            this.FileActionRadio.UseVisualStyleBackColor = true;
            // 
            // FolderActionRadio
            // 
            this.FolderActionRadio.AutoSize = true;
            this.FolderActionRadio.Location = new System.Drawing.Point(68, 2);
            this.FolderActionRadio.Margin = new System.Windows.Forms.Padding(2);
            this.FolderActionRadio.Name = "FolderActionRadio";
            this.FolderActionRadio.Size = new System.Drawing.Size(68, 16);
            this.FolderActionRadio.TabIndex = 10;
            this.FolderActionRadio.TabStop = true;
            this.FolderActionRadio.Text = "フォルダー";
            this.FolderActionRadio.UseVisualStyleBackColor = true;
            // 
            // VariableTitleLbl
            // 
            this.VariableTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.VariableTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VariableTitleLbl.ForeColor = System.Drawing.Color.White;
            this.VariableTitleLbl.Location = new System.Drawing.Point(3, 122);
            this.VariableTitleLbl.Name = "VariableTitleLbl";
            this.VariableTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.VariableTitleLbl.TabIndex = 77;
            this.VariableTitleLbl.Text = "変数に格納";
            this.VariableTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VariableButton
            // 
            this.VariableButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.VariableButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.VariableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VariableButton.Font = new System.Drawing.Font("MS UI Gothic", 9.5F);
            this.VariableButton.ForeColor = System.Drawing.Color.Black;
            this.VariableButton.Location = new System.Drawing.Point(106, 122);
            this.VariableButton.Name = "VariableButton";
            this.VariableButton.Size = new System.Drawing.Size(219, 22);
            this.VariableButton.TabIndex = 21;
            this.VariableButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VariableButton.UseVisualStyleBackColor = false;
            this.VariableButton.Click += new System.EventHandler(this.VariableButton_Click);
            // 
            // TimeoutTitleLbl
            // 
            this.TimeoutTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.TimeoutTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeoutTitleLbl.ForeColor = System.Drawing.Color.White;
            this.TimeoutTitleLbl.Location = new System.Drawing.Point(3, 122);
            this.TimeoutTitleLbl.Name = "TimeoutTitleLbl";
            this.TimeoutTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.TimeoutTitleLbl.TabIndex = 76;
            this.TimeoutTitleLbl.Text = "タイムアウトミリ秒";
            this.TimeoutTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.TimeoutNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TimeoutNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(105, 122);
            this.TimeoutNumericUpDown.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(220, 22);
            this.TimeoutNumericUpDown.TabIndex = 25;
            this.TimeoutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimeoutNumericUpDown.Value = new decimal(new int[] {
            1800000,
            0,
            0,
            0});
            // 
            // FileFolderPath1TitleLbl
            // 
            this.FileFolderPath1TitleLbl.BackColor = System.Drawing.Color.Teal;
            this.FileFolderPath1TitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderPath1TitleLbl.ForeColor = System.Drawing.Color.White;
            this.FileFolderPath1TitleLbl.Location = new System.Drawing.Point(3, 99);
            this.FileFolderPath1TitleLbl.Name = "FileFolderPath1TitleLbl";
            this.FileFolderPath1TitleLbl.Size = new System.Drawing.Size(103, 22);
            this.FileFolderPath1TitleLbl.TabIndex = 81;
            this.FileFolderPath1TitleLbl.Text = "ファイル指定";
            this.FileFolderPath1TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileFolderPath1TextBox
            // 
            this.FileFolderPath1TextBox.AllowDrop = true;
            this.FileFolderPath1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderPath1TextBox.DefaultAlphaNumberOnly = false;
            this.FileFolderPath1TextBox.DefaultClickSelectAll = false;
            this.FileFolderPath1TextBox.DefaultNarrow = false;
            this.FileFolderPath1TextBox.DefaultNumberOnly = false;
            this.FileFolderPath1TextBox.DefaultToUpper = false;
            this.FileFolderPath1TextBox.DefaultTrim = false;
            this.FileFolderPath1TextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.FileFolderPath1TextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.FileFolderPath1TextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.FileFolderPath1TextBox.Location = new System.Drawing.Point(104, 99);
            this.FileFolderPath1TextBox.MaxLength = 1024;
            this.FileFolderPath1TextBox.MaxLengthBytes = 0;
            this.FileFolderPath1TextBox.Name = "FileFolderPath1TextBox";
            this.FileFolderPath1TextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.FileFolderPath1TextBox.Size = new System.Drawing.Size(467, 22);
            this.FileFolderPath1TextBox.TabIndex = 20;
            this.FileFolderPath1TextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.FileFolderPath1TextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileFolderPath1TextBox_DragDrop);
            this.FileFolderPath1TextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileFolderPath1TextBox_DragEnter);
            // 
            // FileFolderOpen1Button
            // 
            this.FileFolderOpen1Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileFolderOpen1Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.FileFolderOpen1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileFolderOpen1Button.ForeColor = System.Drawing.Color.Black;
            this.FileFolderOpen1Button.Location = new System.Drawing.Point(572, 99);
            this.FileFolderOpen1Button.Name = "FileFolderOpen1Button";
            this.FileFolderOpen1Button.Size = new System.Drawing.Size(42, 22);
            this.FileFolderOpen1Button.TabIndex = 21;
            this.FileFolderOpen1Button.Text = "参照";
            this.FileFolderOpen1Button.UseVisualStyleBackColor = false;
            this.FileFolderOpen1Button.Click += new System.EventHandler(this.FileFolderOpen1Button_Click);
            // 
            // FileFolderPath2TitleLbl
            // 
            this.FileFolderPath2TitleLbl.BackColor = System.Drawing.Color.Teal;
            this.FileFolderPath2TitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderPath2TitleLbl.ForeColor = System.Drawing.Color.White;
            this.FileFolderPath2TitleLbl.Location = new System.Drawing.Point(3, 122);
            this.FileFolderPath2TitleLbl.Name = "FileFolderPath2TitleLbl";
            this.FileFolderPath2TitleLbl.Size = new System.Drawing.Size(103, 22);
            this.FileFolderPath2TitleLbl.TabIndex = 84;
            this.FileFolderPath2TitleLbl.Text = "ファイル指定";
            this.FileFolderPath2TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileFolderOpen2Button
            // 
            this.FileFolderOpen2Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileFolderOpen2Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.FileFolderOpen2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileFolderOpen2Button.ForeColor = System.Drawing.Color.Black;
            this.FileFolderOpen2Button.Location = new System.Drawing.Point(572, 122);
            this.FileFolderOpen2Button.Name = "FileFolderOpen2Button";
            this.FileFolderOpen2Button.Size = new System.Drawing.Size(42, 22);
            this.FileFolderOpen2Button.TabIndex = 23;
            this.FileFolderOpen2Button.Text = "参照";
            this.FileFolderOpen2Button.UseVisualStyleBackColor = false;
            this.FileFolderOpen2Button.Click += new System.EventHandler(this.FileFolderOpen2Button_Click);
            // 
            // FileFolderPath2TextBox
            // 
            this.FileFolderPath2TextBox.AllowDrop = true;
            this.FileFolderPath2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileFolderPath2TextBox.DefaultAlphaNumberOnly = false;
            this.FileFolderPath2TextBox.DefaultClickSelectAll = false;
            this.FileFolderPath2TextBox.DefaultNarrow = false;
            this.FileFolderPath2TextBox.DefaultNumberOnly = false;
            this.FileFolderPath2TextBox.DefaultToUpper = false;
            this.FileFolderPath2TextBox.DefaultTrim = false;
            this.FileFolderPath2TextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.FileFolderPath2TextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.FileFolderPath2TextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.FileFolderPath2TextBox.Location = new System.Drawing.Point(104, 122);
            this.FileFolderPath2TextBox.MaxLength = 1024;
            this.FileFolderPath2TextBox.MaxLengthBytes = 0;
            this.FileFolderPath2TextBox.Name = "FileFolderPath2TextBox";
            this.FileFolderPath2TextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.FileFolderPath2TextBox.Size = new System.Drawing.Size(467, 22);
            this.FileFolderPath2TextBox.TabIndex = 22;
            this.FileFolderPath2TextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.FileFolderPath2TextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileFolderPath2TextBox_DragDrop);
            this.FileFolderPath2TextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileFolderPath2TextBox_DragEnter);
            // 
            // ZipPasswordTitleLbl
            // 
            this.ZipPasswordTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ZipPasswordTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZipPasswordTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ZipPasswordTitleLbl.Location = new System.Drawing.Point(3, 145);
            this.ZipPasswordTitleLbl.Name = "ZipPasswordTitleLbl";
            this.ZipPasswordTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ZipPasswordTitleLbl.TabIndex = 86;
            this.ZipPasswordTitleLbl.Text = "パスワード指定";
            this.ZipPasswordTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZipPasswordTextBox
            // 
            this.ZipPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZipPasswordTextBox.DefaultAlphaNumberOnly = false;
            this.ZipPasswordTextBox.DefaultClickSelectAll = false;
            this.ZipPasswordTextBox.DefaultNarrow = false;
            this.ZipPasswordTextBox.DefaultNumberOnly = false;
            this.ZipPasswordTextBox.DefaultToUpper = false;
            this.ZipPasswordTextBox.DefaultTrim = false;
            this.ZipPasswordTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ZipPasswordTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ZipPasswordTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ZipPasswordTextBox.Location = new System.Drawing.Point(104, 145);
            this.ZipPasswordTextBox.MaxLength = 1024;
            this.ZipPasswordTextBox.MaxLengthBytes = 0;
            this.ZipPasswordTextBox.Name = "ZipPasswordTextBox";
            this.ZipPasswordTextBox.PasswordChar = '*';
            this.ZipPasswordTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ZipPasswordTextBox.Size = new System.Drawing.Size(467, 22);
            this.ZipPasswordTextBox.TabIndex = 24;
            this.ZipPasswordTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // FileFolderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimeoutTitleLbl);
            this.Controls.Add(this.TimeoutNumericUpDown);
            this.Controls.Add(this.ZipPasswordTitleLbl);
            this.Controls.Add(this.ZipPasswordTextBox);
            this.Controls.Add(this.FileFolderPath2TitleLbl);
            this.Controls.Add(this.FileFolderOpen2Button);
            this.Controls.Add(this.FileFolderPath2TextBox);
            this.Controls.Add(this.FileFolderPath1TitleLbl);
            this.Controls.Add(this.FileFolderOpen1Button);
            this.Controls.Add(this.FileFolderPath1TextBox);
            this.Controls.Add(this.VariableTitleLbl);
            this.Controls.Add(this.VariableButton);
            this.Controls.Add(this.FileFolderTypePanel);
            this.Controls.Add(this.FileFolderActionTypeTitleLbl);
            this.Controls.Add(this.FileFolderExecTypePanel);
            this.Controls.Add(this.FileFolderExecTypeTitleLbl);
            this.Name = "FileFolderControl";
            this.Size = new System.Drawing.Size(796, 492);
            this.Controls.SetChildIndex(this.ValidTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.ValidTypePanel, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.FileFolderExecTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.FileFolderExecTypePanel, 0);
            this.Controls.SetChildIndex(this.FileFolderActionTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.FileFolderTypePanel, 0);
            this.Controls.SetChildIndex(this.CompButton, 0);
            this.Controls.SetChildIndex(this.ErrorButton, 0);
            this.Controls.SetChildIndex(this.VariableButton, 0);
            this.Controls.SetChildIndex(this.CompButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.ErrorButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.VariableTitleLbl, 0);
            this.Controls.SetChildIndex(this.FileFolderPath1TextBox, 0);
            this.Controls.SetChildIndex(this.FileFolderOpen1Button, 0);
            this.Controls.SetChildIndex(this.FileFolderPath1TitleLbl, 0);
            this.Controls.SetChildIndex(this.FileFolderPath2TextBox, 0);
            this.Controls.SetChildIndex(this.FileFolderOpen2Button, 0);
            this.Controls.SetChildIndex(this.FileFolderPath2TitleLbl, 0);
            this.Controls.SetChildIndex(this.ZipPasswordTextBox, 0);
            this.Controls.SetChildIndex(this.ZipPasswordTitleLbl, 0);
            this.Controls.SetChildIndex(this.TimeoutNumericUpDown, 0);
            this.Controls.SetChildIndex(this.TimeoutTitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            this.FileFolderExecTypePanel.ResumeLayout(false);
            this.FileFolderExecTypePanel.PerformLayout();
            this.FileFolderTypePanel.ResumeLayout(false);
            this.FileFolderTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Components.BasePanel FileFolderExecTypePanel;
        public Components.BaseRadioButton FileFolderDetectRadio;
        public Components.BaseRadioButton FileFolderCreateRadio;
        public Components.BaseLabel FileFolderExecTypeTitleLbl;
        public Components.BaseRadioButton FileFolderMoveRadio;
        public Components.BaseRadioButton FileFolderRemoveRadio;
        public Components.BaseLabel FileFolderActionTypeTitleLbl;
        public Components.BasePanel FileFolderTypePanel;
        public Components.BaseRadioButton FileActionRadio;
        public Components.BaseRadioButton FolderActionRadio;
        public Components.BaseRadioButton FileFolderSaveUdateRadio;
        public Components.BaseLabel VariableTitleLbl;
        public Components.BaseButton VariableButton;
        public Components.BaseLabel TimeoutTitleLbl;
        public Components.BaseNumericUpDown TimeoutNumericUpDown;
        public Components.BaseLabel FileFolderPath1TitleLbl;
        public Components.BaseTextBox FileFolderPath1TextBox;
        public Components.BaseButton FileFolderOpen1Button;
        public Components.BaseLabel FileFolderPath2TitleLbl;
        public Components.BaseButton FileFolderOpen2Button;
        public Components.BaseTextBox FileFolderPath2TextBox;
        public Components.BaseRadioButton FileFolderCopyRadio;
        public Components.BaseRadioButton FileFolderZipUnArchiveRadio;
        public Components.BaseRadioButton FileFolderZipArchiveRadio;
        public Components.BaseLabel ZipPasswordTitleLbl;
        public Components.BaseTextBox ZipPasswordTextBox;
    }
}
