namespace Macrobo.Views
{
    partial class VersionInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInfoForm));
            this.OKButton = new Macrobo.Components.BaseButton();
            this.CopyrightLbl = new Macrobo.Components.BaseLabel();
            this.TitleLbl = new Macrobo.Components.BaseLabel();
            this.IconPictureBox = new Macrobo.Components.BasePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.OKButton.ForeColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(162, 63);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(86, 21);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CopyrightLbl
            // 
            this.CopyrightLbl.AutoSize = true;
            this.CopyrightLbl.BackColor = System.Drawing.SystemColors.Control;
            this.CopyrightLbl.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.CopyrightLbl.ForeColor = System.Drawing.Color.Black;
            this.CopyrightLbl.Location = new System.Drawing.Point(60, 35);
            this.CopyrightLbl.Name = "CopyrightLbl";
            this.CopyrightLbl.Size = new System.Drawing.Size(139, 12);
            this.CopyrightLbl.TabIndex = 2;
            this.CopyrightLbl.Text = "Copyright (C) 2019 ma-yo";
            this.CopyrightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLbl.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.TitleLbl.ForeColor = System.Drawing.Color.Black;
            this.TitleLbl.Location = new System.Drawing.Point(60, 19);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(142, 12);
            this.TitleLbl.TabIndex = 1;
            this.TitleLbl.Text = "Macrobo (RPAソリューション)";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("IconPictureBox.Image")));
            this.IconPictureBox.Location = new System.Drawing.Point(20, 19);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(26, 28);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconPictureBox.TabIndex = 0;
            this.IconPictureBox.TabStop = false;
            // 
            // VersionInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 96);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CopyrightLbl);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.IconPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionInfoForm";
            this.ShowIcon = false;
            this.Text = "Macrobo (マクロボ) - バージョン情報";
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.BasePictureBox IconPictureBox;
        private Components.BaseLabel TitleLbl;
        private Components.BaseLabel CopyrightLbl;
        private Components.BaseButton OKButton;
    }
}