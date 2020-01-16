namespace Macrobo.Views
{
    partial class KeyboardInputControl
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
            this.InputTypePanel = new Macrobo.Components.BasePanel();
            this.KeyboardInputRadio = new Macrobo.Components.BaseRadioButton();
            this.StringInputRadio = new Macrobo.Components.BaseRadioButton();
            this.InputTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.StringInputTitleLbl = new Macrobo.Components.BaseLabel();
            this.StringInputTextBox = new Macrobo.Components.BaseTextBox();
            this.AlertLbl = new Macrobo.Components.BaseLabel();
            this.VariableTitleLbl = new Macrobo.Components.BaseLabel();
            this.VariableButton = new Macrobo.Components.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
            this.InputTypePanel.SuspendLayout();
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
            this.ErrorButtonTitleLbl.Visible = false;
            // 
            // CompButtonTitleLbl
            // 
            this.CompButtonTitleLbl.TabIndex = 8;
            // 
            // ErrorButton
            // 
            this.ErrorButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ErrorButton.TabIndex = 7;
            this.ErrorButton.Visible = false;
            // 
            // CompButton
            // 
            this.CompButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CompButton.TabIndex = 6;
            // 
            // InputTypePanel
            // 
            this.InputTypePanel.BackColor = System.Drawing.Color.White;
            this.InputTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputTypePanel.Controls.Add(this.KeyboardInputRadio);
            this.InputTypePanel.Controls.Add(this.StringInputRadio);
            this.InputTypePanel.Location = new System.Drawing.Point(105, 53);
            this.InputTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.InputTypePanel.Name = "InputTypePanel";
            this.InputTypePanel.Size = new System.Drawing.Size(173, 22);
            this.InputTypePanel.TabIndex = 8;
            // 
            // KeyboardInputRadio
            // 
            this.KeyboardInputRadio.AutoSize = true;
            this.KeyboardInputRadio.Location = new System.Drawing.Point(10, 2);
            this.KeyboardInputRadio.Margin = new System.Windows.Forms.Padding(2);
            this.KeyboardInputRadio.Name = "KeyboardInputRadio";
            this.KeyboardInputRadio.Size = new System.Drawing.Size(69, 16);
            this.KeyboardInputRadio.TabIndex = 9;
            this.KeyboardInputRadio.TabStop = true;
            this.KeyboardInputRadio.Text = "キータイプ";
            this.KeyboardInputRadio.UseVisualStyleBackColor = true;
            this.KeyboardInputRadio.CheckedChanged += new System.EventHandler(this.KeyboardInputRadio_CheckedChanged);
            // 
            // StringInputRadio
            // 
            this.StringInputRadio.AutoSize = true;
            this.StringInputRadio.Location = new System.Drawing.Point(81, 2);
            this.StringInputRadio.Margin = new System.Windows.Forms.Padding(2);
            this.StringInputRadio.Name = "StringInputRadio";
            this.StringInputRadio.Size = new System.Drawing.Size(83, 16);
            this.StringInputRadio.TabIndex = 10;
            this.StringInputRadio.TabStop = true;
            this.StringInputRadio.Text = "文字列入力";
            this.StringInputRadio.UseVisualStyleBackColor = true;
            this.StringInputRadio.CheckedChanged += new System.EventHandler(this.StringInputRadio_CheckedChanged);
            // 
            // InputTypeTitleLbl
            // 
            this.InputTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.InputTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.InputTypeTitleLbl.Location = new System.Drawing.Point(3, 53);
            this.InputTypeTitleLbl.Name = "InputTypeTitleLbl";
            this.InputTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.InputTypeTitleLbl.TabIndex = 10;
            this.InputTypeTitleLbl.Text = "入力タイプ";
            this.InputTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StringInputTitleLbl
            // 
            this.StringInputTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.StringInputTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StringInputTitleLbl.ForeColor = System.Drawing.Color.White;
            this.StringInputTitleLbl.Location = new System.Drawing.Point(3, 76);
            this.StringInputTitleLbl.Name = "StringInputTitleLbl";
            this.StringInputTitleLbl.Size = new System.Drawing.Size(103, 260);
            this.StringInputTitleLbl.TabIndex = 15;
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
            this.StringInputTextBox.TabIndex = 11;
            this.StringInputTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.StringInputTextBox.WordWrap = false;
            // 
            // AlertLbl
            // 
            this.AlertLbl.BackColor = System.Drawing.SystemColors.Control;
            this.AlertLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertLbl.ForeColor = System.Drawing.Color.Black;
            this.AlertLbl.Location = new System.Drawing.Point(3, 341);
            this.AlertLbl.Name = "AlertLbl";
            this.AlertLbl.Size = new System.Drawing.Size(275, 15);
            this.AlertLbl.TabIndex = 16;
            this.AlertLbl.Text = "※入力にフォーカスさせてから、キータイプを行ってください。";
            this.AlertLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VariableTitleLbl
            // 
            this.VariableTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.VariableTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VariableTitleLbl.ForeColor = System.Drawing.Color.White;
            this.VariableTitleLbl.Location = new System.Drawing.Point(3, 341);
            this.VariableTitleLbl.Name = "VariableTitleLbl";
            this.VariableTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.VariableTitleLbl.TabIndex = 66;
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
            this.VariableButton.Location = new System.Drawing.Point(105, 341);
            this.VariableButton.Name = "VariableButton";
            this.VariableButton.Size = new System.Drawing.Size(220, 22);
            this.VariableButton.TabIndex = 12;
            this.VariableButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VariableButton.UseVisualStyleBackColor = false;
            this.VariableButton.Click += new System.EventHandler(this.VariableButton_Click);
            // 
            // KeyboardInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VariableTitleLbl);
            this.Controls.Add(this.VariableButton);
            this.Controls.Add(this.AlertLbl);
            this.Controls.Add(this.StringInputTitleLbl);
            this.Controls.Add(this.StringInputTextBox);
            this.Controls.Add(this.InputTypePanel);
            this.Controls.Add(this.InputTypeTitleLbl);
            this.Name = "KeyboardInputControl";
            this.Size = new System.Drawing.Size(797, 494);
            this.Controls.SetChildIndex(this.ErrorButton, 0);
            this.Controls.SetChildIndex(this.ErrorButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.InputTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.InputTypePanel, 0);
            this.Controls.SetChildIndex(this.StringInputTextBox, 0);
            this.Controls.SetChildIndex(this.StringInputTitleLbl, 0);
            this.Controls.SetChildIndex(this.AlertLbl, 0);
            this.Controls.SetChildIndex(this.CompButton, 0);
            this.Controls.SetChildIndex(this.ValidTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.ValidTypePanel, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.VariableButton, 0);
            this.Controls.SetChildIndex(this.CompButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.VariableTitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            this.InputTypePanel.ResumeLayout(false);
            this.InputTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Components.BasePanel InputTypePanel;
        public Components.BaseRadioButton KeyboardInputRadio;
        public Components.BaseRadioButton StringInputRadio;
        public Components.BaseLabel InputTypeTitleLbl;
        public Components.BaseLabel StringInputTitleLbl;
        public Components.BaseTextBox StringInputTextBox;
        private Components.BaseLabel AlertLbl;
        public Components.BaseLabel VariableTitleLbl;
        public Components.BaseButton VariableButton;
    }
}
