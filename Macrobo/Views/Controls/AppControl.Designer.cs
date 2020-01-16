namespace Macrobo.Views
{
    partial class AppControl
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
            this.AppStartTypePanel = new Macrobo.Components.BasePanel();
            this.WaitRadio = new Macrobo.Components.BaseRadioButton();
            this.NonWaitRadio = new Macrobo.Components.BaseRadioButton();
            this.AppStartTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.ExecutePathTitleLbl = new Macrobo.Components.BaseLabel();
            this.FileOpenButton = new Macrobo.Components.BaseButton();
            this.ExecuteArgsTitleLbl = new Macrobo.Components.BaseLabel();
            this.ExecuteArgsTextBox = new Macrobo.Components.BaseTextBox();
            this.AppWindowStatePanel = new Macrobo.Components.BasePanel();
            this.MinStateRadio = new Macrobo.Components.BaseRadioButton();
            this.MaxStateRadio = new Macrobo.Components.BaseRadioButton();
            this.NormalStateRadio = new Macrobo.Components.BaseRadioButton();
            this.HiddenStateRadio = new Macrobo.Components.BaseRadioButton();
            this.AppWindowStateTitleLbl = new Macrobo.Components.BaseLabel();
            this.TimeoutTitleLbl = new Macrobo.Components.BaseLabel();
            this.TimeoutNumericUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.ExitCodeTitleLbl = new Macrobo.Components.BaseLabel();
            this.ExitCodeUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.ExecPathOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExecutePathTextBox = new Macrobo.Components.BaseTextBox();
            this.AlertLbl = new Macrobo.Components.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
            this.AppStartTypePanel.SuspendLayout();
            this.AppWindowStatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitCodeUpDown)).BeginInit();
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
            this.ErrorButtonTitleLbl.TabIndex = 62;
            // 
            // CompButtonTitleLbl
            // 
            this.CompButtonTitleLbl.TabIndex = 56;
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
            // AppStartTypePanel
            // 
            this.AppStartTypePanel.BackColor = System.Drawing.Color.White;
            this.AppStartTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppStartTypePanel.Controls.Add(this.WaitRadio);
            this.AppStartTypePanel.Controls.Add(this.NonWaitRadio);
            this.AppStartTypePanel.Location = new System.Drawing.Point(105, 53);
            this.AppStartTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.AppStartTypePanel.Name = "AppStartTypePanel";
            this.AppStartTypePanel.Size = new System.Drawing.Size(161, 22);
            this.AppStartTypePanel.TabIndex = 8;
            // 
            // WaitRadio
            // 
            this.WaitRadio.AutoSize = true;
            this.WaitRadio.Location = new System.Drawing.Point(10, 2);
            this.WaitRadio.Margin = new System.Windows.Forms.Padding(2);
            this.WaitRadio.Name = "WaitRadio";
            this.WaitRadio.Size = new System.Drawing.Size(66, 16);
            this.WaitRadio.TabIndex = 9;
            this.WaitRadio.TabStop = true;
            this.WaitRadio.Text = "待機する";
            this.WaitRadio.UseVisualStyleBackColor = true;
            // 
            // NonWaitRadio
            // 
            this.NonWaitRadio.AutoSize = true;
            this.NonWaitRadio.Location = new System.Drawing.Point(79, 2);
            this.NonWaitRadio.Margin = new System.Windows.Forms.Padding(2);
            this.NonWaitRadio.Name = "NonWaitRadio";
            this.NonWaitRadio.Size = new System.Drawing.Size(76, 16);
            this.NonWaitRadio.TabIndex = 10;
            this.NonWaitRadio.TabStop = true;
            this.NonWaitRadio.Text = "待機しない";
            this.NonWaitRadio.UseVisualStyleBackColor = true;
            // 
            // AppStartTypeTitleLbl
            // 
            this.AppStartTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.AppStartTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppStartTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.AppStartTypeTitleLbl.Location = new System.Drawing.Point(3, 53);
            this.AppStartTypeTitleLbl.Name = "AppStartTypeTitleLbl";
            this.AppStartTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.AppStartTypeTitleLbl.TabIndex = 50;
            this.AppStartTypeTitleLbl.Text = "プロセスの終了";
            this.AppStartTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExecutePathTitleLbl
            // 
            this.ExecutePathTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ExecutePathTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecutePathTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ExecutePathTitleLbl.Location = new System.Drawing.Point(3, 76);
            this.ExecutePathTitleLbl.Name = "ExecutePathTitleLbl";
            this.ExecutePathTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ExecutePathTitleLbl.TabIndex = 51;
            this.ExecutePathTitleLbl.Text = "実行パス";
            this.ExecutePathTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileOpenButton
            // 
            this.FileOpenButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileOpenButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.FileOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileOpenButton.ForeColor = System.Drawing.Color.Black;
            this.FileOpenButton.Location = new System.Drawing.Point(562, 76);
            this.FileOpenButton.Name = "FileOpenButton";
            this.FileOpenButton.Size = new System.Drawing.Size(41, 22);
            this.FileOpenButton.TabIndex = 17;
            this.FileOpenButton.Text = "参照";
            this.FileOpenButton.UseVisualStyleBackColor = false;
            this.FileOpenButton.Click += new System.EventHandler(this.FileOpenButton_Click);
            // 
            // ExecuteArgsTitleLbl
            // 
            this.ExecuteArgsTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ExecuteArgsTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecuteArgsTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ExecuteArgsTitleLbl.Location = new System.Drawing.Point(3, 99);
            this.ExecuteArgsTitleLbl.Name = "ExecuteArgsTitleLbl";
            this.ExecuteArgsTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ExecuteArgsTitleLbl.TabIndex = 54;
            this.ExecuteArgsTitleLbl.Text = "起動引数";
            this.ExecuteArgsTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExecuteArgsTextBox
            // 
            this.ExecuteArgsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecuteArgsTextBox.DefaultAlphaNumberOnly = false;
            this.ExecuteArgsTextBox.DefaultClickSelectAll = false;
            this.ExecuteArgsTextBox.DefaultNarrow = false;
            this.ExecuteArgsTextBox.DefaultNumberOnly = false;
            this.ExecuteArgsTextBox.DefaultToUpper = false;
            this.ExecuteArgsTextBox.DefaultTrim = false;
            this.ExecuteArgsTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ExecuteArgsTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ExecuteArgsTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExecuteArgsTextBox.Location = new System.Drawing.Point(105, 99);
            this.ExecuteArgsTextBox.MaxLength = 1024;
            this.ExecuteArgsTextBox.MaxLengthBytes = 0;
            this.ExecuteArgsTextBox.Name = "ExecuteArgsTextBox";
            this.ExecuteArgsTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ExecuteArgsTextBox.Size = new System.Drawing.Size(456, 22);
            this.ExecuteArgsTextBox.TabIndex = 18;
            this.ExecuteArgsTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // AppWindowStatePanel
            // 
            this.AppWindowStatePanel.BackColor = System.Drawing.Color.White;
            this.AppWindowStatePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppWindowStatePanel.Controls.Add(this.MinStateRadio);
            this.AppWindowStatePanel.Controls.Add(this.MaxStateRadio);
            this.AppWindowStatePanel.Controls.Add(this.NormalStateRadio);
            this.AppWindowStatePanel.Controls.Add(this.HiddenStateRadio);
            this.AppWindowStatePanel.Location = new System.Drawing.Point(369, 53);
            this.AppWindowStatePanel.Margin = new System.Windows.Forms.Padding(2);
            this.AppWindowStatePanel.Name = "AppWindowStatePanel";
            this.AppWindowStatePanel.Size = new System.Drawing.Size(234, 22);
            this.AppWindowStatePanel.TabIndex = 11;
            // 
            // MinStateRadio
            // 
            this.MinStateRadio.AutoSize = true;
            this.MinStateRadio.Location = new System.Drawing.Point(173, 2);
            this.MinStateRadio.Margin = new System.Windows.Forms.Padding(2);
            this.MinStateRadio.Name = "MinStateRadio";
            this.MinStateRadio.Size = new System.Drawing.Size(59, 16);
            this.MinStateRadio.TabIndex = 15;
            this.MinStateRadio.TabStop = true;
            this.MinStateRadio.Text = "最小化";
            this.MinStateRadio.UseVisualStyleBackColor = true;
            // 
            // MaxStateRadio
            // 
            this.MaxStateRadio.AutoSize = true;
            this.MaxStateRadio.Location = new System.Drawing.Point(112, 2);
            this.MaxStateRadio.Margin = new System.Windows.Forms.Padding(2);
            this.MaxStateRadio.Name = "MaxStateRadio";
            this.MaxStateRadio.Size = new System.Drawing.Size(59, 16);
            this.MaxStateRadio.TabIndex = 14;
            this.MaxStateRadio.TabStop = true;
            this.MaxStateRadio.Text = "最大化";
            this.MaxStateRadio.UseVisualStyleBackColor = true;
            // 
            // NormalStateRadio
            // 
            this.NormalStateRadio.AutoSize = true;
            this.NormalStateRadio.Location = new System.Drawing.Point(3, 2);
            this.NormalStateRadio.Margin = new System.Windows.Forms.Padding(2);
            this.NormalStateRadio.Name = "NormalStateRadio";
            this.NormalStateRadio.Size = new System.Drawing.Size(47, 16);
            this.NormalStateRadio.TabIndex = 12;
            this.NormalStateRadio.TabStop = true;
            this.NormalStateRadio.Text = "通常";
            this.NormalStateRadio.UseVisualStyleBackColor = true;
            // 
            // HiddenStateRadio
            // 
            this.HiddenStateRadio.AutoSize = true;
            this.HiddenStateRadio.Location = new System.Drawing.Point(51, 2);
            this.HiddenStateRadio.Margin = new System.Windows.Forms.Padding(2);
            this.HiddenStateRadio.Name = "HiddenStateRadio";
            this.HiddenStateRadio.Size = new System.Drawing.Size(59, 16);
            this.HiddenStateRadio.TabIndex = 13;
            this.HiddenStateRadio.TabStop = true;
            this.HiddenStateRadio.Text = "非表示";
            this.HiddenStateRadio.UseVisualStyleBackColor = true;
            // 
            // AppWindowStateTitleLbl
            // 
            this.AppWindowStateTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.AppWindowStateTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppWindowStateTitleLbl.ForeColor = System.Drawing.Color.White;
            this.AppWindowStateTitleLbl.Location = new System.Drawing.Point(267, 53);
            this.AppWindowStateTitleLbl.Name = "AppWindowStateTitleLbl";
            this.AppWindowStateTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.AppWindowStateTitleLbl.TabIndex = 59;
            this.AppWindowStateTitleLbl.Text = "起動画面";
            this.AppWindowStateTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeoutTitleLbl
            // 
            this.TimeoutTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.TimeoutTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeoutTitleLbl.ForeColor = System.Drawing.Color.White;
            this.TimeoutTitleLbl.Location = new System.Drawing.Point(3, 122);
            this.TimeoutTitleLbl.Name = "TimeoutTitleLbl";
            this.TimeoutTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.TimeoutTitleLbl.TabIndex = 61;
            this.TimeoutTitleLbl.Text = "待機ミリ秒数";
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
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.TimeoutNumericUpDown.TabIndex = 19;
            this.TimeoutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExitCodeTitleLbl
            // 
            this.ExitCodeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ExitCodeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExitCodeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ExitCodeTitleLbl.Location = new System.Drawing.Point(266, 122);
            this.ExitCodeTitleLbl.Name = "ExitCodeTitleLbl";
            this.ExitCodeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ExitCodeTitleLbl.TabIndex = 65;
            this.ExitCodeTitleLbl.Text = "正常終了時コード";
            this.ExitCodeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitCodeUpDown
            // 
            this.ExitCodeUpDown.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExitCodeUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ExitCodeUpDown.Location = new System.Drawing.Point(368, 122);
            this.ExitCodeUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.ExitCodeUpDown.Minimum = new decimal(new int[] {
            65536,
            0,
            0,
            -2147483648});
            this.ExitCodeUpDown.Name = "ExitCodeUpDown";
            this.ExitCodeUpDown.Size = new System.Drawing.Size(159, 22);
            this.ExitCodeUpDown.TabIndex = 20;
            this.ExitCodeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExecutePathTextBox
            // 
            this.ExecutePathTextBox.AllowDrop = true;
            this.ExecutePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecutePathTextBox.DefaultAlphaNumberOnly = false;
            this.ExecutePathTextBox.DefaultClickSelectAll = false;
            this.ExecutePathTextBox.DefaultNarrow = false;
            this.ExecutePathTextBox.DefaultNumberOnly = false;
            this.ExecutePathTextBox.DefaultToUpper = false;
            this.ExecutePathTextBox.DefaultTrim = false;
            this.ExecutePathTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ExecutePathTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ExecutePathTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExecutePathTextBox.Location = new System.Drawing.Point(105, 76);
            this.ExecutePathTextBox.MaxLength = 1024;
            this.ExecutePathTextBox.MaxLengthBytes = 0;
            this.ExecutePathTextBox.Name = "ExecutePathTextBox";
            this.ExecutePathTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ExecutePathTextBox.Size = new System.Drawing.Size(456, 22);
            this.ExecutePathTextBox.TabIndex = 66;
            this.ExecutePathTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ExecutePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExecutePathTextBox_DragDrop);
            this.ExecutePathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExecutePathTextBox_DragEnter);
            // 
            // AlertLbl
            // 
            this.AlertLbl.BackColor = System.Drawing.Color.White;
            this.AlertLbl.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.AlertLbl.ForeColor = System.Drawing.Color.Black;
            this.AlertLbl.Location = new System.Drawing.Point(3, 147);
            this.AlertLbl.Name = "AlertLbl";
            this.AlertLbl.Size = new System.Drawing.Size(275, 16);
            this.AlertLbl.TabIndex = 79;
            this.AlertLbl.Text = "※待機ミリ秒0の場合、プロセス終了まで待機します。";
            this.AlertLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AlertLbl);
            this.Controls.Add(this.ExecutePathTextBox);
            this.Controls.Add(this.AppStartTypeTitleLbl);
            this.Controls.Add(this.AppWindowStateTitleLbl);
            this.Controls.Add(this.ExitCodeTitleLbl);
            this.Controls.Add(this.TimeoutTitleLbl);
            this.Controls.Add(this.ExecuteArgsTitleLbl);
            this.Controls.Add(this.ExecutePathTitleLbl);
            this.Controls.Add(this.ExitCodeUpDown);
            this.Controls.Add(this.TimeoutNumericUpDown);
            this.Controls.Add(this.AppWindowStatePanel);
            this.Controls.Add(this.ExecuteArgsTextBox);
            this.Controls.Add(this.FileOpenButton);
            this.Controls.Add(this.AppStartTypePanel);
            this.Name = "AppControl";
            this.Controls.SetChildIndex(this.AppStartTypePanel, 0);
            this.Controls.SetChildIndex(this.FileOpenButton, 0);
            this.Controls.SetChildIndex(this.ExecuteArgsTextBox, 0);
            this.Controls.SetChildIndex(this.AppWindowStatePanel, 0);
            this.Controls.SetChildIndex(this.TimeoutNumericUpDown, 0);
            this.Controls.SetChildIndex(this.ExitCodeUpDown, 0);
            this.Controls.SetChildIndex(this.ExecutePathTitleLbl, 0);
            this.Controls.SetChildIndex(this.ExecuteArgsTitleLbl, 0);
            this.Controls.SetChildIndex(this.TimeoutTitleLbl, 0);
            this.Controls.SetChildIndex(this.ExitCodeTitleLbl, 0);
            this.Controls.SetChildIndex(this.AppWindowStateTitleLbl, 0);
            this.Controls.SetChildIndex(this.AppStartTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.ValidTypePanel, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.ValidTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.CompButton, 0);
            this.Controls.SetChildIndex(this.ErrorButton, 0);
            this.Controls.SetChildIndex(this.CompButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.ErrorButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.ExecutePathTextBox, 0);
            this.Controls.SetChildIndex(this.AlertLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            this.AppStartTypePanel.ResumeLayout(false);
            this.AppStartTypePanel.PerformLayout();
            this.AppWindowStatePanel.ResumeLayout(false);
            this.AppWindowStatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitCodeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Components.BasePanel AppStartTypePanel;
        public Components.BaseRadioButton WaitRadio;
        public Components.BaseRadioButton NonWaitRadio;
        public Components.BaseLabel AppStartTypeTitleLbl;
        public Components.BaseLabel ExecutePathTitleLbl;
        public Components.BaseButton FileOpenButton;
        public Components.BaseLabel ExecuteArgsTitleLbl;
        public Components.BaseTextBox ExecuteArgsTextBox;
        public Components.BasePanel AppWindowStatePanel;
        public Components.BaseRadioButton NormalStateRadio;
        public Components.BaseRadioButton HiddenStateRadio;
        public Components.BaseLabel AppWindowStateTitleLbl;
        public Components.BaseRadioButton MinStateRadio;
        public Components.BaseRadioButton MaxStateRadio;
        public Components.BaseLabel TimeoutTitleLbl;
        public Components.BaseNumericUpDown TimeoutNumericUpDown;
        public Components.BaseLabel ExitCodeTitleLbl;
        public Components.BaseNumericUpDown ExitCodeUpDown;
        private System.Windows.Forms.OpenFileDialog ExecPathOpenFileDialog;
        public Components.BaseTextBox ExecutePathTextBox;
        private Components.BaseLabel AlertLbl;
    }
}
