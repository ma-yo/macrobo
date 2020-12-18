using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Components
{
    /// <summary>
    /// Author : M.Yoshida
    /// 基本ボタン
    /// </summary>
    public class BaseButton : Button
    {
        /// <summary>
        /// タグ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tag"></param>
        public delegate void TagChangeEvent(BaseButton sender, object tag);
        /// <summary>
        /// タグ変更イベントハンドラー
        /// </summary>
        public TagChangeEvent OnTagChanged;
        /// <summary>
        /// タグオブジェクトを格納
        /// </summary>
        private object _tag;
        /// <summary>
        /// Tagオブジェクトのゲッターセッター
        /// </summary>
        public new object Tag { get { return _tag;  } set { _tag = value; OnTagChanged?.Invoke(this, _tag); } }
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseButton()
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
            this.BackColor = Color.FromArgb(255, 64, 64, 64);
            this.ForeColor = Color.White;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.FromArgb(255, 64, 64, 64);
            this.ResumeLayout(false);
        }
    }
}
