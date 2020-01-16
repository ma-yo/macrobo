namespace Macrobo.Views
{
    partial class ProcessBaseControl
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
            this.AfterWaitTimeTitleLbl = new Macrobo.Components.BaseLabel();
            this.BeforeWaitTimeTitleLbl = new Macrobo.Components.BaseLabel();
            this.AfterWaitTimeUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.BeforeWaitTimeUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.ValidTypePanel = new Macrobo.Components.BasePanel();
            this.ValidRadio = new Macrobo.Components.BaseRadioButton();
            this.InValidRadio = new Macrobo.Components.BaseRadioButton();
            this.ValidTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.ErrorButtonTitleLbl = new Macrobo.Components.BaseLabel();
            this.CompButtonTitleLbl = new Macrobo.Components.BaseLabel();
            this.ErrorButton = new Macrobo.Components.BaseButton();
            this.CompButton = new Macrobo.Components.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AfterWaitTimeTitleLbl
            // 
            this.AfterWaitTimeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.AfterWaitTimeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AfterWaitTimeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.AfterWaitTimeTitleLbl.Location = new System.Drawing.Point(402, 3);
            this.AfterWaitTimeTitleLbl.Name = "AfterWaitTimeTitleLbl";
            this.AfterWaitTimeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.AfterWaitTimeTitleLbl.TabIndex = 47;
            this.AfterWaitTimeTitleLbl.Text = "実行後待機ミリ秒";
            this.AfterWaitTimeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BeforeWaitTimeTitleLbl
            // 
            this.BeforeWaitTimeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.BeforeWaitTimeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BeforeWaitTimeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.BeforeWaitTimeTitleLbl.Location = new System.Drawing.Point(216, 3);
            this.BeforeWaitTimeTitleLbl.Name = "BeforeWaitTimeTitleLbl";
            this.BeforeWaitTimeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.BeforeWaitTimeTitleLbl.TabIndex = 45;
            this.BeforeWaitTimeTitleLbl.Text = "実行前待機ミリ秒";
            this.BeforeWaitTimeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AfterWaitTimeUpDown
            // 
            this.AfterWaitTimeUpDown.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.AfterWaitTimeUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AfterWaitTimeUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.AfterWaitTimeUpDown.Location = new System.Drawing.Point(504, 3);
            this.AfterWaitTimeUpDown.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.AfterWaitTimeUpDown.Name = "AfterWaitTimeUpDown";
            this.AfterWaitTimeUpDown.Size = new System.Drawing.Size(83, 22);
            this.AfterWaitTimeUpDown.TabIndex = 4;
            this.AfterWaitTimeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BeforeWaitTimeUpDown
            // 
            this.BeforeWaitTimeUpDown.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.BeforeWaitTimeUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BeforeWaitTimeUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.BeforeWaitTimeUpDown.Location = new System.Drawing.Point(318, 3);
            this.BeforeWaitTimeUpDown.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.BeforeWaitTimeUpDown.Name = "BeforeWaitTimeUpDown";
            this.BeforeWaitTimeUpDown.Size = new System.Drawing.Size(83, 22);
            this.BeforeWaitTimeUpDown.TabIndex = 3;
            this.BeforeWaitTimeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ValidTypePanel
            // 
            this.ValidTypePanel.BackColor = System.Drawing.Color.White;
            this.ValidTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValidTypePanel.Controls.Add(this.ValidRadio);
            this.ValidTypePanel.Controls.Add(this.InValidRadio);
            this.ValidTypePanel.Location = new System.Drawing.Point(105, 3);
            this.ValidTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ValidTypePanel.Name = "ValidTypePanel";
            this.ValidTypePanel.Size = new System.Drawing.Size(110, 22);
            this.ValidTypePanel.TabIndex = 0;
            // 
            // ValidRadio
            // 
            this.ValidRadio.AutoSize = true;
            this.ValidRadio.Location = new System.Drawing.Point(7, 2);
            this.ValidRadio.Margin = new System.Windows.Forms.Padding(2);
            this.ValidRadio.Name = "ValidRadio";
            this.ValidRadio.Size = new System.Drawing.Size(47, 16);
            this.ValidRadio.TabIndex = 1;
            this.ValidRadio.TabStop = true;
            this.ValidRadio.Text = "有効";
            this.ValidRadio.UseVisualStyleBackColor = true;
            // 
            // InValidRadio
            // 
            this.InValidRadio.AutoSize = true;
            this.InValidRadio.Location = new System.Drawing.Point(58, 2);
            this.InValidRadio.Margin = new System.Windows.Forms.Padding(2);
            this.InValidRadio.Name = "InValidRadio";
            this.InValidRadio.Size = new System.Drawing.Size(47, 16);
            this.InValidRadio.TabIndex = 2;
            this.InValidRadio.TabStop = true;
            this.InValidRadio.Text = "無効";
            this.InValidRadio.UseVisualStyleBackColor = true;
            // 
            // ValidTypeTitleLbl
            // 
            this.ValidTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ValidTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValidTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ValidTypeTitleLbl.Location = new System.Drawing.Point(3, 3);
            this.ValidTypeTitleLbl.Name = "ValidTypeTitleLbl";
            this.ValidTypeTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ValidTypeTitleLbl.TabIndex = 44;
            this.ValidTypeTitleLbl.Text = "有効区分";
            this.ValidTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorButtonTitleLbl
            // 
            this.ErrorButtonTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ErrorButtonTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorButtonTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ErrorButtonTitleLbl.Location = new System.Drawing.Point(402, 26);
            this.ErrorButtonTitleLbl.Name = "ErrorButtonTitleLbl";
            this.ErrorButtonTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.ErrorButtonTitleLbl.TabIndex = 65;
            this.ErrorButtonTitleLbl.Text = "処理エラー移動先";
            this.ErrorButtonTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompButtonTitleLbl
            // 
            this.CompButtonTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.CompButtonTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompButtonTitleLbl.ForeColor = System.Drawing.Color.White;
            this.CompButtonTitleLbl.Location = new System.Drawing.Point(3, 26);
            this.CompButtonTitleLbl.Name = "CompButtonTitleLbl";
            this.CompButtonTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.CompButtonTitleLbl.TabIndex = 64;
            this.CompButtonTitleLbl.Text = "処理成功移動先";
            this.CompButtonTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorButton
            // 
            this.ErrorButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ErrorButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ErrorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ErrorButton.Font = new System.Drawing.Font("MS UI Gothic", 9.5F);
            this.ErrorButton.ForeColor = System.Drawing.Color.Black;
            this.ErrorButton.Location = new System.Drawing.Point(504, 26);
            this.ErrorButton.Name = "ErrorButton";
            this.ErrorButton.Size = new System.Drawing.Size(296, 22);
            this.ErrorButton.TabIndex = 6;
            this.ErrorButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ErrorButton.UseVisualStyleBackColor = false;
            this.ErrorButton.Click += new System.EventHandler(this.ErrorButton_Click);
            // 
            // CompButton
            // 
            this.CompButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CompButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CompButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompButton.Font = new System.Drawing.Font("MS UI Gothic", 9.5F);
            this.CompButton.ForeColor = System.Drawing.Color.Black;
            this.CompButton.Location = new System.Drawing.Point(105, 26);
            this.CompButton.Name = "CompButton";
            this.CompButton.Size = new System.Drawing.Size(296, 22);
            this.CompButton.TabIndex = 5;
            this.CompButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CompButton.UseVisualStyleBackColor = false;
            this.CompButton.Click += new System.EventHandler(this.CompButton_Click);
            // 
            // ProcessBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ErrorButtonTitleLbl);
            this.Controls.Add(this.CompButtonTitleLbl);
            this.Controls.Add(this.ErrorButton);
            this.Controls.Add(this.CompButton);
            this.Controls.Add(this.AfterWaitTimeTitleLbl);
            this.Controls.Add(this.BeforeWaitTimeTitleLbl);
            this.Controls.Add(this.AfterWaitTimeUpDown);
            this.Controls.Add(this.BeforeWaitTimeUpDown);
            this.Controls.Add(this.ValidTypePanel);
            this.Controls.Add(this.ValidTypeTitleLbl);
            this.Name = "ProcessBaseControl";
            this.Size = new System.Drawing.Size(797, 512);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Components.BaseLabel AfterWaitTimeTitleLbl;
        public Components.BaseLabel BeforeWaitTimeTitleLbl;
        public Components.BaseNumericUpDown AfterWaitTimeUpDown;
        public Components.BaseNumericUpDown BeforeWaitTimeUpDown;
        public Components.BasePanel ValidTypePanel;
        public Components.BaseRadioButton ValidRadio;
        public Components.BaseRadioButton InValidRadio;
        public Components.BaseLabel ValidTypeTitleLbl;
        public Components.BaseLabel ErrorButtonTitleLbl;
        public Components.BaseLabel CompButtonTitleLbl;
        public Components.BaseButton ErrorButton;
        public Components.BaseButton CompButton;
    }
}
