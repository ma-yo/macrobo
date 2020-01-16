namespace Macrobo.Views
{
    partial class LoadProjectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProjectGrid = new Macrobo.Components.BaseDataGridView();
            this.COL_プロジェクト名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_読込 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COL_削除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COL_出力 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COL_実行 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COL_ショートカット = new System.Windows.Forms.DataGridViewButtonColumn();
            this.COL_CDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectGrid
            // 
            this.ProjectGrid.AllowUserToAddRows = false;
            this.ProjectGrid.AllowUserToDeleteRows = false;
            this.ProjectGrid.AllowUserToResizeColumns = false;
            this.ProjectGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.ProjectGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProjectGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProjectGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ProjectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProjectGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_プロジェクト名,
            this.COL_読込,
            this.COL_削除,
            this.COL_出力,
            this.COL_実行,
            this.COL_ショートカット,
            this.COL_CDATE});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProjectGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.ProjectGrid.Location = new System.Drawing.Point(12, 12);
            this.ProjectGrid.Name = "ProjectGrid";
            this.ProjectGrid.RowHeadersVisible = false;
            this.ProjectGrid.RowTemplate.Height = 21;
            this.ProjectGrid.Size = new System.Drawing.Size(473, 393);
            this.ProjectGrid.TabIndex = 0;
            this.ProjectGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProjectGrid_CellContentClick);
            // 
            // COL_プロジェクト名
            // 
            this.COL_プロジェクト名.HeaderText = "プロジェクト名";
            this.COL_プロジェクト名.MinimumWidth = 350;
            this.COL_プロジェクト名.Name = "COL_プロジェクト名";
            this.COL_プロジェクト名.ReadOnly = true;
            this.COL_プロジェクト名.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_プロジェクト名.Width = 350;
            // 
            // COL_読込
            // 
            this.COL_読込.HeaderText = "読込";
            this.COL_読込.MinimumWidth = 60;
            this.COL_読込.Name = "COL_読込";
            this.COL_読込.ReadOnly = true;
            this.COL_読込.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_読込.Text = "読込";
            this.COL_読込.UseColumnTextForButtonValue = true;
            this.COL_読込.Visible = false;
            this.COL_読込.Width = 60;
            // 
            // COL_削除
            // 
            this.COL_削除.HeaderText = "削除";
            this.COL_削除.MinimumWidth = 60;
            this.COL_削除.Name = "COL_削除";
            this.COL_削除.ReadOnly = true;
            this.COL_削除.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_削除.Text = "削除";
            this.COL_削除.UseColumnTextForButtonValue = true;
            this.COL_削除.Visible = false;
            this.COL_削除.Width = 60;
            // 
            // COL_出力
            // 
            this.COL_出力.HeaderText = "エクスポート";
            this.COL_出力.MinimumWidth = 80;
            this.COL_出力.Name = "COL_出力";
            this.COL_出力.ReadOnly = true;
            this.COL_出力.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_出力.UseColumnTextForButtonValue = true;
            this.COL_出力.Visible = false;
            this.COL_出力.Width = 80;
            // 
            // COL_実行
            // 
            this.COL_実行.HeaderText = "実行";
            this.COL_実行.MinimumWidth = 80;
            this.COL_実行.Name = "COL_実行";
            this.COL_実行.ReadOnly = true;
            this.COL_実行.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_実行.UseColumnTextForButtonValue = true;
            this.COL_実行.Visible = false;
            this.COL_実行.Width = 80;
            // 
            // COL_ショートカット
            // 
            this.COL_ショートカット.HeaderText = "ショートカット";
            this.COL_ショートカット.MinimumWidth = 80;
            this.COL_ショートカット.Name = "COL_ショートカット";
            this.COL_ショートカット.ReadOnly = true;
            this.COL_ショートカット.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_ショートカット.UseColumnTextForButtonValue = true;
            this.COL_ショートカット.Visible = false;
            this.COL_ショートカット.Width = 80;
            // 
            // COL_CDATE
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COL_CDATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.COL_CDATE.HeaderText = "登録・更新日";
            this.COL_CDATE.MinimumWidth = 120;
            this.COL_CDATE.Name = "COL_CDATE";
            this.COL_CDATE.ReadOnly = true;
            this.COL_CDATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_CDATE.Visible = false;
            this.COL_CDATE.Width = 120;
            // 
            // LoadProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 415);
            this.Controls.Add(this.ProjectGrid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadProjectForm";
            this.Text = "Macrobo (マクロボ) - プロジェクト読込・削除";
            this.Shown += new System.EventHandler(this.LoadProjectForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.BaseDataGridView ProjectGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_プロジェクト名;
        private System.Windows.Forms.DataGridViewButtonColumn COL_読込;
        private System.Windows.Forms.DataGridViewButtonColumn COL_削除;
        private System.Windows.Forms.DataGridViewButtonColumn COL_出力;
        private System.Windows.Forms.DataGridViewButtonColumn COL_実行;
        private System.Windows.Forms.DataGridViewButtonColumn COL_ショートカット;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CDATE;
    }
}