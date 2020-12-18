namespace Macrobo.Views.Forms
{
    partial class ProcessChoiceForm
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
            this.ProcessChoiceList = new Macrobo.Components.BaseListBox();
            this.SuspendLayout();
            // 
            // ProcessChoiceList
            // 
            this.ProcessChoiceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessChoiceList.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ProcessChoiceList.FormattingEnabled = true;
            this.ProcessChoiceList.ItemHeight = 15;
            this.ProcessChoiceList.Location = new System.Drawing.Point(12, 12);
            this.ProcessChoiceList.Name = "ProcessChoiceList";
            this.ProcessChoiceList.Size = new System.Drawing.Size(371, 424);
            this.ProcessChoiceList.TabIndex = 0;
            this.ProcessChoiceList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ProcessChoiceList_MouseDoubleClick);
            // 
            // ProcessChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.ProcessChoiceList);
            this.Name = "ProcessChoiceForm";
            this.Text = "Macrobo (マクロボ) - 移動先選択";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.BaseListBox ProcessChoiceList;
    }
}