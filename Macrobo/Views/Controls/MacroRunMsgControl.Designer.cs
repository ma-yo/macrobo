namespace Macrobo.Views.Controls
{
    partial class MacroRunMsgControl
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
            this.MsgLbl = new Macrobo.Components.BaseLabel();
            this.SuspendLayout();
            // 
            // MsgLbl
            // 
            this.MsgLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MsgLbl.BackColor = System.Drawing.Color.White;
            this.MsgLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MsgLbl.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.MsgLbl.Location = new System.Drawing.Point(50, 229);
            this.MsgLbl.Name = "MsgLbl";
            this.MsgLbl.Size = new System.Drawing.Size(907, 52);
            this.MsgLbl.TabIndex = 0;
            this.MsgLbl.Text = "処理実行中...";
            this.MsgLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MacroRunMsgControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.MsgLbl);
            this.Name = "MacroRunMsgControl";
            this.Size = new System.Drawing.Size(1006, 511);
            this.ResumeLayout(false);

        }

        #endregion

        public Components.BaseLabel MsgLbl;
    }
}
