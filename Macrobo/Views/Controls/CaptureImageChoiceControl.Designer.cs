namespace Macrobo.Views.Controls
{
    partial class CaptureImageChoiceControl
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
            this.ImageBox = new Macrobo.Components.BasePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(3, 3);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(144, 144);
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            this.ImageBox.Click += new System.EventHandler(this.ImageBox_Click);
            this.ImageBox.DoubleClick += new System.EventHandler(this.ImageBox_DoubleClick);
            // 
            // CaptureImageChoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.ImageBox);
            this.Name = "CaptureImageChoiceControl";
            this.Click += new System.EventHandler(this.CaptureImageChoiceControl_Click);
            this.DoubleClick += new System.EventHandler(this.CaptureImageChoiceControl_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Components.BasePictureBox ImageBox;
    }
}
