namespace Macrobo.Views
{
    partial class WaitControl
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
            this.TimeoutNumericUpDown = new Macrobo.Components.BaseNumericUpDown();
            this.TimeoutTitleLbl = new Macrobo.Components.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).BeginInit();
            this.ValidTypePanel.SuspendLayout();
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
            this.ErrorButtonTitleLbl.Visible = false;
            // 
            // CompButtonTitleLbl
            // 
            this.CompButtonTitleLbl.TabIndex = 6;
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
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.TimeoutNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TimeoutNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(105, 53);
            this.TimeoutNumericUpDown.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.TimeoutNumericUpDown.TabIndex = 8;
            this.TimeoutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimeoutNumericUpDown.Value = new decimal(new int[] {
            1800000,
            0,
            0,
            0});
            // 
            // TimeoutTitleLbl
            // 
            this.TimeoutTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.TimeoutTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeoutTitleLbl.ForeColor = System.Drawing.Color.White;
            this.TimeoutTitleLbl.Location = new System.Drawing.Point(3, 53);
            this.TimeoutTitleLbl.Name = "TimeoutTitleLbl";
            this.TimeoutTitleLbl.Size = new System.Drawing.Size(103, 22);
            this.TimeoutTitleLbl.TabIndex = 9;
            this.TimeoutTitleLbl.Text = "待機ミリ秒";
            this.TimeoutTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WaitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimeoutTitleLbl);
            this.Controls.Add(this.TimeoutNumericUpDown);
            this.Name = "WaitControl";
            this.Size = new System.Drawing.Size(797, 494);
            this.Controls.SetChildIndex(this.ErrorButton, 0);
            this.Controls.SetChildIndex(this.ErrorButtonTitleLbl, 0);
            this.Controls.SetChildIndex(this.TimeoutNumericUpDown, 0);
            this.Controls.SetChildIndex(this.TimeoutTitleLbl, 0);
            this.Controls.SetChildIndex(this.ValidTypeTitleLbl, 0);
            this.Controls.SetChildIndex(this.ValidTypePanel, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeUpDown, 0);
            this.Controls.SetChildIndex(this.BeforeWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.AfterWaitTimeTitleLbl, 0);
            this.Controls.SetChildIndex(this.CompButton, 0);
            this.Controls.SetChildIndex(this.CompButtonTitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AfterWaitTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforeWaitTimeUpDown)).EndInit();
            this.ValidTypePanel.ResumeLayout(false);
            this.ValidTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Components.BaseNumericUpDown TimeoutNumericUpDown;
        public Components.BaseLabel TimeoutTitleLbl;
    }
}
