using Macrobo.Components;

namespace Macrobo
{
    partial class MainMenu
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.EditProjectButton = new Macrobo.Components.BaseButton();
            this.ExecuteProjectButton = new Macrobo.Components.BaseButton();
            this.NewProjectButton = new Macrobo.Components.BaseButton();
            this.NewMacroButton = new Macrobo.Components.BaseButton();
            this.EditMacroButton = new Macrobo.Components.BaseButton();
            this.ExportProjectButton = new Macrobo.Components.BaseButton();
            this.ImportProjectButton = new Macrobo.Components.BaseButton();
            this.ExecuteMacroButton = new Macrobo.Components.BaseButton();
            this.ImportMacroButton = new Macrobo.Components.BaseButton();
            this.ExportMacroButton = new Macrobo.Components.BaseButton();
            this.SeparateLabel = new Macrobo.Components.BaseLabel();
            this.CalendarButton = new Macrobo.Components.BaseButton();
            this.basePictureBox1 = new Macrobo.Components.BasePictureBox();
            this.basePictureBox2 = new Macrobo.Components.BasePictureBox();
            this.baseLabel1 = new Macrobo.Components.BaseLabel();
            this.basePictureBox3 = new Macrobo.Components.BasePictureBox();
            this.SettingButton = new Macrobo.Components.BaseButton();
            this.DatabaseExportButton = new Macrobo.Components.BaseButton();
            this.DatabaseImportButton = new Macrobo.Components.BaseButton();
            this.LogViewerButton = new Macrobo.Components.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.basePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // EditProjectButton
            // 
            this.EditProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProjectButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.EditProjectButton.ForeColor = System.Drawing.Color.White;
            this.EditProjectButton.Location = new System.Drawing.Point(240, 12);
            this.EditProjectButton.Name = "EditProjectButton";
            this.EditProjectButton.Size = new System.Drawing.Size(166, 28);
            this.EditProjectButton.TabIndex = 1;
            this.EditProjectButton.Text = "プロジェクト修正";
            this.EditProjectButton.UseVisualStyleBackColor = false;
            this.EditProjectButton.Click += new System.EventHandler(this.EditProjectButton_Click);
            // 
            // ExecuteProjectButton
            // 
            this.ExecuteProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExecuteProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteProjectButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExecuteProjectButton.ForeColor = System.Drawing.Color.White;
            this.ExecuteProjectButton.Location = new System.Drawing.Point(412, 12);
            this.ExecuteProjectButton.Name = "ExecuteProjectButton";
            this.ExecuteProjectButton.Size = new System.Drawing.Size(166, 28);
            this.ExecuteProjectButton.TabIndex = 2;
            this.ExecuteProjectButton.Text = "プロジェクト実行";
            this.ExecuteProjectButton.UseVisualStyleBackColor = false;
            this.ExecuteProjectButton.Click += new System.EventHandler(this.ExecuteProjectButton_Click);
            // 
            // NewProjectButton
            // 
            this.NewProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewProjectButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.NewProjectButton.ForeColor = System.Drawing.Color.White;
            this.NewProjectButton.Location = new System.Drawing.Point(68, 12);
            this.NewProjectButton.Name = "NewProjectButton";
            this.NewProjectButton.Size = new System.Drawing.Size(166, 28);
            this.NewProjectButton.TabIndex = 0;
            this.NewProjectButton.Text = "新規プロジェクト作成";
            this.NewProjectButton.UseVisualStyleBackColor = false;
            this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
            // 
            // NewMacroButton
            // 
            this.NewMacroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewMacroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewMacroButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.NewMacroButton.ForeColor = System.Drawing.Color.White;
            this.NewMacroButton.Location = new System.Drawing.Point(68, 81);
            this.NewMacroButton.Name = "NewMacroButton";
            this.NewMacroButton.Size = new System.Drawing.Size(166, 28);
            this.NewMacroButton.TabIndex = 6;
            this.NewMacroButton.Text = "新規モジュール作成";
            this.NewMacroButton.UseVisualStyleBackColor = false;
            this.NewMacroButton.Click += new System.EventHandler(this.NewModuleButton_Click);
            // 
            // EditMacroButton
            // 
            this.EditMacroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditMacroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditMacroButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.EditMacroButton.ForeColor = System.Drawing.Color.White;
            this.EditMacroButton.Location = new System.Drawing.Point(240, 81);
            this.EditMacroButton.Name = "EditMacroButton";
            this.EditMacroButton.Size = new System.Drawing.Size(166, 28);
            this.EditMacroButton.TabIndex = 7;
            this.EditMacroButton.Text = "モジュール修正";
            this.EditMacroButton.UseVisualStyleBackColor = false;
            this.EditMacroButton.Click += new System.EventHandler(this.EditModuleButton_Click);
            // 
            // ExportProjectButton
            // 
            this.ExportProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExportProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportProjectButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExportProjectButton.ForeColor = System.Drawing.Color.White;
            this.ExportProjectButton.Location = new System.Drawing.Point(68, 46);
            this.ExportProjectButton.Name = "ExportProjectButton";
            this.ExportProjectButton.Size = new System.Drawing.Size(166, 28);
            this.ExportProjectButton.TabIndex = 3;
            this.ExportProjectButton.Text = "プロジェクトエクスポート";
            this.ExportProjectButton.UseVisualStyleBackColor = false;
            this.ExportProjectButton.Click += new System.EventHandler(this.ExportProjectButton_Click);
            // 
            // ImportProjectButton
            // 
            this.ImportProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ImportProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportProjectButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ImportProjectButton.ForeColor = System.Drawing.Color.White;
            this.ImportProjectButton.Location = new System.Drawing.Point(240, 46);
            this.ImportProjectButton.Name = "ImportProjectButton";
            this.ImportProjectButton.Size = new System.Drawing.Size(166, 28);
            this.ImportProjectButton.TabIndex = 4;
            this.ImportProjectButton.Text = "プロジェクトインポート";
            this.ImportProjectButton.UseVisualStyleBackColor = false;
            this.ImportProjectButton.Click += new System.EventHandler(this.ImportProject_Click);
            // 
            // ExecuteMacroButton
            // 
            this.ExecuteMacroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExecuteMacroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteMacroButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExecuteMacroButton.ForeColor = System.Drawing.Color.White;
            this.ExecuteMacroButton.Location = new System.Drawing.Point(412, 81);
            this.ExecuteMacroButton.Name = "ExecuteMacroButton";
            this.ExecuteMacroButton.Size = new System.Drawing.Size(166, 28);
            this.ExecuteMacroButton.TabIndex = 8;
            this.ExecuteMacroButton.Text = "モジュール実行";
            this.ExecuteMacroButton.UseVisualStyleBackColor = false;
            this.ExecuteMacroButton.Click += new System.EventHandler(this.ExecuteModuleButton_Click);
            // 
            // ImportMacroButton
            // 
            this.ImportMacroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ImportMacroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportMacroButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ImportMacroButton.ForeColor = System.Drawing.Color.White;
            this.ImportMacroButton.Location = new System.Drawing.Point(240, 115);
            this.ImportMacroButton.Name = "ImportMacroButton";
            this.ImportMacroButton.Size = new System.Drawing.Size(166, 28);
            this.ImportMacroButton.TabIndex = 10;
            this.ImportMacroButton.Text = "モジュールインポート";
            this.ImportMacroButton.UseVisualStyleBackColor = false;
            this.ImportMacroButton.Click += new System.EventHandler(this.ImportMacroButton_Click);
            // 
            // ExportMacroButton
            // 
            this.ExportMacroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExportMacroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportMacroButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ExportMacroButton.ForeColor = System.Drawing.Color.White;
            this.ExportMacroButton.Location = new System.Drawing.Point(68, 115);
            this.ExportMacroButton.Name = "ExportMacroButton";
            this.ExportMacroButton.Size = new System.Drawing.Size(166, 28);
            this.ExportMacroButton.TabIndex = 9;
            this.ExportMacroButton.Text = "モジュールエクスポート";
            this.ExportMacroButton.UseVisualStyleBackColor = false;
            this.ExportMacroButton.Click += new System.EventHandler(this.ExportMacroButton_Click);
            // 
            // SeparateLabel
            // 
            this.SeparateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeparateLabel.BackColor = System.Drawing.Color.Silver;
            this.SeparateLabel.Location = new System.Drawing.Point(13, 77);
            this.SeparateLabel.Name = "SeparateLabel";
            this.SeparateLabel.Size = new System.Drawing.Size(568, 1);
            this.SeparateLabel.TabIndex = 10;
            this.SeparateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalendarButton
            // 
            this.CalendarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalendarButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.CalendarButton.ForeColor = System.Drawing.Color.White;
            this.CalendarButton.Location = new System.Drawing.Point(68, 150);
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.Size = new System.Drawing.Size(166, 28);
            this.CalendarButton.TabIndex = 5;
            this.CalendarButton.Text = "カレンダー管理";
            this.CalendarButton.UseVisualStyleBackColor = false;
            this.CalendarButton.Click += new System.EventHandler(this.CalendarButton_Click);
            // 
            // basePictureBox1
            // 
            this.basePictureBox1.Image = global::Macrobo.Properties.Resources.icons8_training_filled_50;
            this.basePictureBox1.Location = new System.Drawing.Point(12, 12);
            this.basePictureBox1.Name = "basePictureBox1";
            this.basePictureBox1.Size = new System.Drawing.Size(50, 50);
            this.basePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.basePictureBox1.TabIndex = 11;
            this.basePictureBox1.TabStop = false;
            // 
            // basePictureBox2
            // 
            this.basePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("basePictureBox2.Image")));
            this.basePictureBox2.Location = new System.Drawing.Point(12, 81);
            this.basePictureBox2.Name = "basePictureBox2";
            this.basePictureBox2.Size = new System.Drawing.Size(50, 50);
            this.basePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.basePictureBox2.TabIndex = 12;
            this.basePictureBox2.TabStop = false;
            // 
            // baseLabel1
            // 
            this.baseLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseLabel1.BackColor = System.Drawing.Color.Silver;
            this.baseLabel1.Location = new System.Drawing.Point(13, 146);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(568, 1);
            this.baseLabel1.TabIndex = 13;
            this.baseLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // basePictureBox3
            // 
            this.basePictureBox3.Image = global::Macrobo.Properties.Resources.icons8_wrench_filled_50;
            this.basePictureBox3.Location = new System.Drawing.Point(12, 150);
            this.basePictureBox3.Name = "basePictureBox3";
            this.basePictureBox3.Size = new System.Drawing.Size(50, 50);
            this.basePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.basePictureBox3.TabIndex = 14;
            this.basePictureBox3.TabStop = false;
            // 
            // SettingButton
            // 
            this.SettingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.SettingButton.ForeColor = System.Drawing.Color.White;
            this.SettingButton.Location = new System.Drawing.Point(240, 150);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(166, 28);
            this.SettingButton.TabIndex = 15;
            this.SettingButton.Text = "共通設定";
            this.SettingButton.UseVisualStyleBackColor = false;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // DatabaseExportButton
            // 
            this.DatabaseExportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DatabaseExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DatabaseExportButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.DatabaseExportButton.ForeColor = System.Drawing.Color.White;
            this.DatabaseExportButton.Location = new System.Drawing.Point(68, 184);
            this.DatabaseExportButton.Name = "DatabaseExportButton";
            this.DatabaseExportButton.Size = new System.Drawing.Size(166, 28);
            this.DatabaseExportButton.TabIndex = 16;
            this.DatabaseExportButton.Text = "データベースエクスポート";
            this.DatabaseExportButton.UseVisualStyleBackColor = false;
            this.DatabaseExportButton.Click += new System.EventHandler(this.DatabaseExportButton_Click);
            // 
            // DatabaseImportButton
            // 
            this.DatabaseImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DatabaseImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DatabaseImportButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.DatabaseImportButton.ForeColor = System.Drawing.Color.White;
            this.DatabaseImportButton.Location = new System.Drawing.Point(240, 184);
            this.DatabaseImportButton.Name = "DatabaseImportButton";
            this.DatabaseImportButton.Size = new System.Drawing.Size(166, 28);
            this.DatabaseImportButton.TabIndex = 17;
            this.DatabaseImportButton.Text = "データベースインポート";
            this.DatabaseImportButton.UseVisualStyleBackColor = false;
            this.DatabaseImportButton.Click += new System.EventHandler(this.DatabaseImportButton_Click);
            // 
            // LogViewerButton
            // 
            this.LogViewerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogViewerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogViewerButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.LogViewerButton.ForeColor = System.Drawing.Color.White;
            this.LogViewerButton.Location = new System.Drawing.Point(412, 150);
            this.LogViewerButton.Name = "LogViewerButton";
            this.LogViewerButton.Size = new System.Drawing.Size(166, 28);
            this.LogViewerButton.TabIndex = 18;
            this.LogViewerButton.Text = "実行ログ";
            this.LogViewerButton.UseVisualStyleBackColor = false;
            this.LogViewerButton.Click += new System.EventHandler(this.LogViewerButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(594, 224);
            this.Controls.Add(this.LogViewerButton);
            this.Controls.Add(this.DatabaseImportButton);
            this.Controls.Add(this.DatabaseExportButton);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.basePictureBox3);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.basePictureBox2);
            this.Controls.Add(this.basePictureBox1);
            this.Controls.Add(this.CalendarButton);
            this.Controls.Add(this.SeparateLabel);
            this.Controls.Add(this.ImportMacroButton);
            this.Controls.Add(this.ExportMacroButton);
            this.Controls.Add(this.ExecuteMacroButton);
            this.Controls.Add(this.ImportProjectButton);
            this.Controls.Add(this.ExportProjectButton);
            this.Controls.Add(this.EditMacroButton);
            this.Controls.Add(this.NewMacroButton);
            this.Controls.Add(this.EditProjectButton);
            this.Controls.Add(this.ExecuteProjectButton);
            this.Controls.Add(this.NewProjectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Macrobo (マクロボ) - メインメニュー";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Shown += new System.EventHandler(this.MainMenu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.basePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseButton NewProjectButton;
        private BaseButton ExecuteProjectButton;
        private BaseButton EditProjectButton;
        private BaseButton NewMacroButton;
        private BaseButton EditMacroButton;
        private BaseButton ExportProjectButton;
        private BaseButton ImportProjectButton;
        private BaseButton ExecuteMacroButton;
        private BaseButton ImportMacroButton;
        private BaseButton ExportMacroButton;
        private BaseLabel SeparateLabel;
        private BaseButton CalendarButton;
        private BasePictureBox basePictureBox1;
        private BasePictureBox basePictureBox2;
        private BaseLabel baseLabel1;
        private BasePictureBox basePictureBox3;
        private BaseButton SettingButton;
        private BaseButton DatabaseExportButton;
        private BaseButton DatabaseImportButton;
        private BaseButton LogViewerButton;
    }
}

