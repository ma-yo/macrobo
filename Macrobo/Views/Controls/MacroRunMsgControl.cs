using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Macrobo.Components;

namespace Macrobo.Views.Controls
{
    /// <summary>
    /// Author : M.Yoshida
    /// マクロ実行中のﾒｯｾｰｼﾞ表示
    /// マクロ実行中にNodeControlが表示されている場合、その中の検出画像がヒットしてしまうため、隠し用途として使う
    /// </summary>
    public partial class MacroRunMsgControl : BaseUserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MacroRunMsgControl()
        {
            InitializeComponent();
        }
    }
}
