namespace Macrobo.Views.Controls
{
    partial class DialogControl
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
            this.DialogTypePanel = new Macrobo.Components.BasePanel();
            this.ErrorDialogRadio = new Macrobo.Components.BaseRadioButton();
            this.AlertDialogRadio = new Macrobo.Components.BaseRadioButton();
            this.NormalDialogRadio = new Macrobo.Components.BaseRadioButton();
            this.InfoDialogRadio = new Macrobo.Components.BaseRadioButton();
            this.DialogTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.DialogButtonTypePanel = new Macrobo.Components.BasePanel();
            this.OkDialogRadio = new Macrobo.Components.BaseRadioButton();
            this.YesNoDialogRadio = new Macrobo.Components.BaseRadioButton();
            this.DialogButtonTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.StringInputTitleLbl = new Macrobo.Components.BaseLabel();
            this.StringInputTextBox = new Macrobo.Components.BaseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
            this.DialogTypePanel.SuspendLayout();
            this.DialogButtonTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AfterWaitTimeTitleLbl
            // 
            this.AfterWaitTimeTitleLbl.BackColor = System.Drawing.Color.Teal;
            // 
            // BeforeWaitTimeTitleLbl
            // 
            this.BeforeWaitTimeTitleLbl.BackColor = System.Drawing.Color.Teal;
            // 
            // ValidTypeTitleLbl
            // 
            this.ValidTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            // 
            // ErrorButtonTitleLbl
            // 
            this.ErrorButtonTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ErrorButtonTitleLbl.Text = "No移動先";
            // 
            // CompButtonTitleLbl
            // 
            this.CompButtonTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.CompButtonTitleLbl.Text = "OK/Yes移動先";
            // 
            // ErrorButton
            // 
            this.ErrorButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            // 
            // CompButton
            // 
            this.CompButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            // 
            // DialogTypePanel
            // 
            this.DialogTypePanel.BackColor = System.Drawing.Color.White;
            this.DialogTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialogTypePanel.Controls.Add(this.ErrorDialogRadio);
            this.DialogTypePanel.Controls.Add(this.AlertDialogRadio);
            this.DialogTypePanel.Controls.Add(this.NormalDialogRadio);
            this.DialogTypePanel.Controls.Add(this.InfoDialogRadio);
            this.DialogTypePanel.Location = new System.Drawing.Point(105, 53);
            this.DialogTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.DialogTypePanel.Name = "DialogTypePanel";
            this.DialogTypePanel.Size = new System.Drawing.Size(220, 22);
            this.DialogTypePanel.TabIndex = 7;
            // 
            // ErrorDialogRadio
            // 
            this.ErrorDialogRadio.AutoSize = true;
            this.ErrorDialogRadio.Location = new System.Drawing.Point(160, 2);
            this.ErrorDialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ErrorDialogRadio.Name = "ErrorDialogRadio";
            this.ErrorDialogRadio.Size = new System.Drawing.Size(50, 16);
            this.ErrorDialogRadio.TabIndex = 11;
            this.ErrorDialogRadio.TabStop = true;
            this.ErrorDialogRadio.Text = "エラー";
            this.ErrorDialogRadio.UseVisualStyleBackColor = true;
            // 
            // AlertDialogRadio
            // 
            this.AlertDialogRadio.AutoSize = true;
            this.AlertDialogRadio.Location = new System.Drawing.Point(109, 2);
            this.AlertDialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.AlertDialogRadio.Name = "AlertDialogRadio";
            this.AlertDialogRadio.Size = new System.Drawing.Size(47, 16);
            this.AlertDialogRadio.TabIndex = 10;
            this.AlertDialogRadio.TabStop = true;
            this.AlertDialogRadio.Text = "警告";
            this.AlertDialogRadio.UseVisualStyleBackColor = true;
            // 
            // NormalDialogRadio
            // 
            this.NormalDialogRadio.AutoSize = true;
            this.NormalDialogRadio.Location = new System.Drawing.Point(7, 2);
            this.NormalDialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.NormalDialogRadio.Name = "NormalDialogRadio";
            this.NormalDialogRadio.Size = new System.Drawing.Size(47, 16);
            this.NormalDialogRadio.TabIndex = 8;
            this.NormalDialogRadio.TabStop = true;
            this.NormalDialogRadio.Text = "通常";
            this.NormalDialogRadio.UseVisualStyleBackColor = true;
            // 
            // InfoDialogRadio
            // 
            this.InfoDialogRadio.AutoSize = true;
            this.InfoDialogRadio.Location = new System.Drawing.Point(58, 2);
            this.InfoDialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.InfoDialogRadio.Name = "InfoDialogRadio";
            this.InfoDialogRadio.Size = new System.Drawing.Size(47, 16);
            this.InfoDialogRadio.TabIndex = 9;
            this.InfoDialogRadio.TabStop = true;
            this.InfoDialogRadio.Text = "確認";
            this.InfoDialogRadio.UseVisualStyleBackColor = true;
            // 
            // DialogTypeTitleLbl
            // 
            this.DialogTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.DialogTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialogTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.DialogTypeTitleLbl.Location = new System.Drawing.Point(3, 53);
            this.DialogTypeTitleLbl.Name = "DialogTypeTitleLbl";
            this.DialogTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.DialogTypeTitleLbl.TabIndex = 67;
            this.DialogTypeTitleLbl.Text = "ダイアログタイプ";
            this.DialogTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DialogButtonTypePanel
            // 
            this.DialogButtonTypePanel.BackColor = System.Drawing.Color.White;
            this.DialogButtonTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialogButtonTypePanel.Controls.Add(this.OkDialogRadio);
            this.DialogButtonTypePanel.Controls.Add(this.YesNoDialogRadio);
            this.DialogButtonTypePanel.Location = new System.Drawing.Point(428, 53);
            this.DialogButtonTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.DialogButtonTypePanel.Name = "DialogButtonTypePanel";
            this.DialogButtonTypePanel.Size = new System.Drawing.Size(114, 22);
            this.DialogButtonTypePanel.TabIndex = 12;
            // 
            // OkDialogRadio
            // 
            this.OkDialogRadio.AutoSize = true;
            this.OkDialogRadio.Location = new System.Drawing.Point(7, 2);
            this.OkDialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.OkDialogRadio.Name = "OkDialogRadio";
            this.OkDialogRadio.Size = new System.Drawing.Size(38, 16);
            this.OkDialogRadio.TabIndex = 13;
            this.OkDialogRadio.TabStop = true;
            this.OkDialogRadio.Text = "OK";
            this.OkDialogRadio.UseVisualStyleBackColor = true;
            // 
            // YesNoDialogRadio
            // 
            this.YesNoDialogRadio.AutoSize = true;
            this.YesNoDialogRadio.Location = new System.Drawing.Point(49, 2);
            this.YesNoDialogRadio.Margin = new System.Windows.Forms.Padding(2);
            this.YesNoDialogRadio.Name = "YesNoDialogRadio";
            this.YesNoDialogRadio.Size = new System.Drawing.Size(56, 16);
            this.YesNoDialogRadio.TabIndex = 14;
            this.YesNoDialogRadio.TabStop = true;
            this.YesNoDialogRadio.Text = "YesNo";
            this.YesNoDialogRadio.UseVisualStyleBackColor = true;
            // 
            // DialogButtonTypeTitleLbl
            // 
            this.DialogButtonTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.DialogButtonTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialogButtonTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.DialogButtonTypeTitleLbl.Location = new System.Drawing.Point(326, 53);
            this.DialogButtonTypeTitleLbl.Name = "DialogButtonTypeTitleLbl";
            this.DialogButtonTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.DialogButtonTypeTitleLbl.TabIndex = 69;
            this.DialogButtonTypeTitleLbl.Text = "ボタンタイプ";
            this.DialogButtonTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StringInputTitleLbl
            // 
            this.StringInputTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.StringInputTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StringInputTitleLbl.ForeColor = System.Drawing.Color.White;
            this.StringInputTitleLbl.Location = new System.Drawing.Point(3, 76);
            this.StringInputTitleLbl.Name = "StringInputTitleLbl";
            this.StringInputTitleLbl.Size = new System.Drawing.Size(103, 260);
            this.StringInputTitleLbl.TabIndex = 71;
            this.StringInputTitleLbl.Text = "入力";
            this.StringInputTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StringInputTextBox
            // 
            this.StringInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StringInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StringInputTextBox.DefaultAlphaNumberOnly = false;
            this.StringInputTextBox.DefaultClickSelectAll = false;
            this.StringInputTextBox.DefaultNarrow = false;
            this.StringInputTextBox.DefaultNumberOnly = false;
            this.StringInputTextBox.DefaultToUpper = false;
            this.StringInputTextBox.DefaultTrim = false;
            this.StringInputTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.StringInputTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.StringInputTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.StringInputTextBox.Location = new System.Drawing.Point(105, 76);
            this.StringInputTextBox.MaxLengthBytes = 0;
            this.StringInputTextBox.Multiline = true;
            this.StringInputTextBox.Name = "StringInputTextBox";
            this.StringInputTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.StringInputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StringInputTextBox.Size = new System.Drawing.Size(687, 260);
            this.StringInputTextBox.TabIndex = 15;
            this.StringInputTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // DialogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StringInputTitleLbl);
            this.Controls.Add(this.StringInputTextBox);
            this.Controls.Add(this.DialogButtonTypePanel);
            this.Controls.Add(this.DialogButtonTypeTitleLbl);
            this.Controls.Add(this.DialogTypePanel);
            this.Controls.Add(this.DialogTypeTitleLbl);
            this.Name = "DialogControl";
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
            this.Controls.SetChildIndex(this.DialogTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.DialogTypePanel, 0);
            this.Controls.SetChildIndex(this.DialogButtonTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.DialogButtonTypePanel, 0);
            this.Controls.SetChildIndex(this.StringInputTextBox, 0);
            this.Controls.SetChildIndex(this.StringInputTitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            this.DialogTypePanel.ResumeLayout(false);
            this.DialogTypePanel.PerformLayout();
            this.DialogButtonTypePanel.ResumeLayout(false);
            this.DialogButtonTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Components.BasePanel DialogTypePanel;
        public Components.BaseRadioButton NormalDialogRadio;
        public Components.BaseRadioButton InfoDialogRadio;
        public Components.BaseLabel DialogTypeTitleLbl;
        public Components.BaseRadioButton ErrorDialogRadio;
        public Components.BaseRadioButton AlertDialogRadio;
        public Components.BasePanel DialogButtonTypePanel;
        public Components.BaseRadioButton OkDialogRadio;
        public Components.BaseRadioButton YesNoDialogRadio;
        public Components.BaseLabel DialogButtonTypeTitleLbl;
        public Components.BaseLabel StringInputTitleLbl;
        public Components.BaseTextBox StringInputTextBox;
    }
}
