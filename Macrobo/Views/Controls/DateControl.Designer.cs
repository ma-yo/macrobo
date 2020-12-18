namespace Macrobo.Views.Controls
{
    partial class DateControl
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
            this.OnOffButton = new Macrobo.Components.BaseButton();
            this.DayLbl = new Macrobo.Components.BaseLabel();
            this.SuspendLayout();
            // 
            // OnOffButton
            // 
            this.OnOffButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnOffButton.BackColor = System.Drawing.Color.White;
            this.OnOffButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OnOffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OnOffButton.ForeColor = System.Drawing.Color.Blue;
            this.OnOffButton.Location = new System.Drawing.Point(-1, 18);
            this.OnOffButton.Name = "OnOffButton";
            this.OnOffButton.Size = new System.Drawing.Size(95, 33);
            this.OnOffButton.TabIndex = 1;
            this.OnOffButton.Text = "◎";
            this.OnOffButton.UseVisualStyleBackColor = false;
            this.OnOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
            // 
            // DayLbl
            // 
            this.DayLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DayLbl.BackColor = System.Drawing.Color.White;
            this.DayLbl.Location = new System.Drawing.Point(-1, 0);
            this.DayLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DayLbl.Name = "DayLbl";
            this.DayLbl.Size = new System.Drawing.Size(95, 17);
            this.DayLbl.TabIndex = 0;
            this.DayLbl.Text = "0";
            this.DayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.OnOffButton);
            this.Controls.Add(this.DayLbl);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DateControl";
            this.Size = new System.Drawing.Size(93, 50);
            this.ResumeLayout(false);

        }

        #endregion

        public Components.BaseLabel DayLbl;
        public Components.BaseButton OnOffButton;
    }
}
