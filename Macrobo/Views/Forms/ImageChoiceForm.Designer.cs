namespace Macrobo.Views.Forms
{
    partial class ImageChoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CaptureChoicePanel = new Macrobo.Components.BaseFlowLayoutPanel();
            this.SuspendLayout();
            // 
            // CaptureChoicePanel
            // 
            this.CaptureChoicePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CaptureChoicePanel.AutoScroll = true;
            this.CaptureChoicePanel.BackColor = System.Drawing.Color.DimGray;
            this.CaptureChoicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CaptureChoicePanel.Location = new System.Drawing.Point(12, 12);
            this.CaptureChoicePanel.Name = "CaptureChoicePanel";
            this.CaptureChoicePanel.Size = new System.Drawing.Size(776, 426);
            this.CaptureChoicePanel.TabIndex = 0;
            // 
            // ImageChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CaptureChoicePanel);
            this.Name = "ImageChoiceForm";
            this.Text = "Macrobo (マクロボ) - イメージ選択";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Components.BaseFlowLayoutPanel CaptureChoicePanel;
    }
}