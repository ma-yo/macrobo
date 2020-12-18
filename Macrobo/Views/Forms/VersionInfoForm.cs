using Macrobo.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// バージョン情報を表示
    /// </summary>
    public partial class VersionInfoForm : BaseForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VersionInfoForm()
        {
            InitializeComponent();
            TitleLbl.Text = "Macrobo Version " + Application.ProductVersion;
            CopyrightLbl.Text = "Copyright (C) 2019 - " + DateTime.Now.ToString("yyyy") + " ma-yo";
        }
        /// <summary>
        /// OKButtonのClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
