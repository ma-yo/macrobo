namespace Macrobo.Views.Forms
{
    partial class ModuleSaveForm
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
            this.DescriptionTextBox = new Macrobo.Components.BaseTextBox();
            this.DescriptionTitleLbl = new Macrobo.Components.BaseLabel();
            this.ProjTextBox = new Macrobo.Components.BaseTextBox();
            this.ProjTitleLbl = new Macrobo.Components.BaseLabel();
            this.SaveButton = new Macrobo.Components.BaseButton();
            this.SuspendLayout();
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTextBox.DefaultAlphaNumberOnly = false;
            this.DescriptionTextBox.DefaultClickSelectAll = false;
            this.DescriptionTextBox.DefaultNarrow = false;
            this.DescriptionTextBox.DefaultNumberOnly = false;
            this.DescriptionTextBox.DefaultToUpper = false;
            this.DescriptionTextBox.DefaultTrim = false;
            this.DescriptionTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.DescriptionTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.DescriptionTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.DescriptionTextBox.Location = new System.Drawing.Point(90, 33);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionTextBox.MaxLength = 128;
            this.DescriptionTextBox.MaxLengthBytes = 0;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.DescriptionTextBox.Size = new System.Drawing.Size(309, 22);
            this.DescriptionTextBox.TabIndex = 17;
            this.DescriptionTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // DescriptionTitleLbl
            // 
            this.DescriptionTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.DescriptionTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTitleLbl.ForeColor = System.Drawing.Color.White;
            this.DescriptionTitleLbl.Location = new System.Drawing.Point(12, 33);
            this.DescriptionTitleLbl.Name = "DescriptionTitleLbl";
            this.DescriptionTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.DescriptionTitleLbl.TabIndex = 18;
            this.DescriptionTitleLbl.Text = "動作説明";
            this.DescriptionTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjTextBox
            // 
            this.ProjTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjTextBox.DefaultAlphaNumberOnly = false;
            this.ProjTextBox.DefaultClickSelectAll = false;
            this.ProjTextBox.DefaultNarrow = false;
            this.ProjTextBox.DefaultNumberOnly = false;
            this.ProjTextBox.DefaultToUpper = false;
            this.ProjTextBox.DefaultTrim = false;
            this.ProjTextBox.FocusBackColor = System.Drawing.Color.Empty;
            this.ProjTextBox.FocusForeColor = System.Drawing.Color.Empty;
            this.ProjTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ProjTextBox.Location = new System.Drawing.Point(90, 9);
            this.ProjTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProjTextBox.MaxLength = 128;
            this.ProjTextBox.MaxLengthBytes = 0;
            this.ProjTextBox.Name = "ProjTextBox";
            this.ProjTextBox.RenderingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ProjTextBox.Size = new System.Drawing.Size(309, 22);
            this.ProjTextBox.TabIndex = 15;
            this.ProjTextBox.TextRenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ProjTitleLbl
            // 
            this.ProjTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ProjTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ProjTitleLbl.Location = new System.Drawing.Point(12, 9);
            this.ProjTitleLbl.Name = "ProjTitleLbl";
            this.ProjTitleLbl.Size = new System.Drawing.Size(79, 22);
            this.ProjTitleLbl.TabIndex = 16;
            this.ProjTitleLbl.Text = "プロジェクト名";
            this.ProjTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(400, 8);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(55, 48);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "登録";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ModuleSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 67);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionTitleLbl);
            this.Controls.Add(this.ProjTextBox);
            this.Controls.Add(this.ProjTitleLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleSaveForm";
            this.Text = "Macrobo (マクロボ) - モジュール登録";
            this.Shown += new System.EventHandler(this.ModuleSaveForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Components.BaseTextBox DescriptionTextBox;
        public Components.BaseLabel DescriptionTitleLbl;
        public Components.BaseTextBox ProjTextBox;
        public Components.BaseLabel ProjTitleLbl;
        private Components.BaseButton SaveButton;
    }
}