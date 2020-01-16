using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Components
{
    /// <summary>
    /// Author : M.Yoshida
    /// 基本ラベル
    /// </summary>
    public class BaseLabel : Label
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseLabel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseLabel
            // 
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoSize = false;
            this.ResumeLayout(false);

        }
    }
}
