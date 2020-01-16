using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Components
{    /// <summary>
     /// Author : M.Yoshida
     /// 基底データグリッドビュー
     /// </summary>
    public class BaseDataGridView : DataGridView
    {
        /// <summary>
        /// 垂直スクロールバー
        /// </summary>
        public ScrollBar VScrollBar { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseDataGridView()
        {
            VScrollBar = this.VerticalScrollBar;
        }
    }
}
