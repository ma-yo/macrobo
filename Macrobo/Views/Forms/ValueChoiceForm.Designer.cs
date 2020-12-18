namespace Macrobo.Views.Forms
{
    partial class ValueChoiceForm
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
            this.ValueChoiceGrid = new Macrobo.Components.BaseDataGridView();
            this.ValueTypeLbl = new Macrobo.Components.BaseLabel();
            this.ValueTypeTitleLbl = new Macrobo.Components.BaseLabel();
            this.COL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_NODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ValueChoiceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ValueChoiceGrid
            // 
            this.ValueChoiceGrid.AllowUserToAddRows = false;
            this.ValueChoiceGrid.AllowUserToDeleteRows = false;
            this.ValueChoiceGrid.AllowUserToResizeColumns = false;
            this.ValueChoiceGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.ValueChoiceGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ValueChoiceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ValueChoiceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ValueChoiceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValueChoiceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_NO,
            this.COL_NODE});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ValueChoiceGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValueChoiceGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ValueChoiceGrid.Location = new System.Drawing.Point(12, 42);
            this.ValueChoiceGrid.MultiSelect = false;
            this.ValueChoiceGrid.Name = "ValueChoiceGrid";
            this.ValueChoiceGrid.RowHeadersVisible = false;
            this.ValueChoiceGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ValueChoiceGrid.RowTemplate.Height = 21;
            this.ValueChoiceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ValueChoiceGrid.Size = new System.Drawing.Size(776, 406);
            this.ValueChoiceGrid.TabIndex = 54;
            this.ValueChoiceGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueChoiceGrid_CellContentDoubleClick);
            this.ValueChoiceGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueChoiceGrid_CellDoubleClick);
            this.ValueChoiceGrid.SizeChanged += new System.EventHandler(this.ValueChoiceGrid_SizeChanged);
            this.ValueChoiceGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValueChoiceGrid_KeyDown);
            // 
            // ValueTypeLbl
            // 
            this.ValueTypeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTypeLbl.BackColor = System.Drawing.Color.White;
            this.ValueTypeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValueTypeLbl.ForeColor = System.Drawing.Color.Black;
            this.ValueTypeLbl.Location = new System.Drawing.Point(136, 9);
            this.ValueTypeLbl.Name = "ValueTypeLbl";
            this.ValueTypeLbl.Size = new System.Drawing.Size(652, 22);
            this.ValueTypeLbl.TabIndex = 53;
            this.ValueTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ValueTypeTitleLbl
            // 
            this.ValueTypeTitleLbl.BackColor = System.Drawing.Color.Teal;
            this.ValueTypeTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValueTypeTitleLbl.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.ValueTypeTitleLbl.ForeColor = System.Drawing.Color.White;
            this.ValueTypeTitleLbl.Location = new System.Drawing.Point(12, 9);
            this.ValueTypeTitleLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ValueTypeTitleLbl.Name = "ValueTypeTitleLbl";
            this.ValueTypeTitleLbl.Size = new System.Drawing.Size(124, 22);
            this.ValueTypeTitleLbl.TabIndex = 3;
            this.ValueTypeTitleLbl.Text = "選択種別";
            this.ValueTypeTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // COL_NO
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COL_NO.DefaultCellStyle = dataGridViewCellStyle3;
            this.COL_NO.HeaderText = "NO";
            this.COL_NO.MinimumWidth = 80;
            this.COL_NO.Name = "COL_NO";
            this.COL_NO.ReadOnly = true;
            this.COL_NO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_NO.Width = 80;
            // 
            // COL_NODE
            // 
            this.COL_NODE.HeaderText = "ノード";
            this.COL_NODE.MinimumWidth = 400;
            this.COL_NODE.Name = "COL_NODE";
            this.COL_NODE.ReadOnly = true;
            this.COL_NODE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_NODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COL_NODE.Width = 400;
            // 
            // ValueChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.ValueChoiceGrid);
            this.Controls.Add(this.ValueTypeLbl);
            this.Controls.Add(this.ValueTypeTitleLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValueChoiceForm";
            this.Text = "Macrobo (マクロボ) - 選択";
            ((System.ComponentModel.ISupportInitialize)(this.ValueChoiceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Components.BaseLabel ValueTypeTitleLbl;
        public Components.BaseLabel ValueTypeLbl;
        private Components.BaseDataGridView ValueChoiceGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_NODE;
    }
}