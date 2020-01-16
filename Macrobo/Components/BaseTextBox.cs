using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Components
{    /// <summary>
     /// Author : M.Yoshida
     /// 基底テキストボックスコントロール
     /// </summary>
    public class BaseTextBox : TextBox
    {
        private const int WM_PASTE = 0x302;

        public Color FocusBackColor { get; set; }
        public Color FocusForeColor { get; set; }

        private Color SaveBackColor = Color.Empty;
        private Color SaveForeColor = Color.Empty;
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (SaveBackColor.IsEmpty)
                {
                    SaveBackColor = value;
                }
                base.BackColor = value;
            }
        }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (SaveForeColor.IsEmpty)
                {
                    SaveForeColor = value;
                }
                base.ForeColor = value;
            }
        }
        /// <summary>
        /// ToUpperCaseをLeave時に自動で行うか
        /// </summary>
        [Description("ToUpperCaseをLeave時に自動で行うか")]
        public bool DefaultToUpper { get; set; }

        [Description("Number入力チェックを行うか")]
        public bool DefaultNumberOnly { get; set; }

        [Description("ClickでのFocus時に文字列を選択状態にするか")]
        public bool DefaultClickSelectAll { get; set; }

        [Description("英数字のみ有効")]
        public bool DefaultAlphaNumberOnly { get; set; }

        [Description("Leave時にTrimを行うか")]
        public bool DefaultTrim { get; set; }
        [Description("バイト数最大値指定")]
        public int MaxLengthBytes { get; set; }

        [Description("全角を半角に置き換えるか")]
        public bool DefaultNarrow { get; set; }
        /// <summary>
        /// エンコード
        /// </summary>
        private Encoding sjis = Encoding.GetEncoding("Shift_JIS");

        private bool _mouseFirstClickFlg = false;

        public SmoothingMode RenderingMode { get; set; }
        public TextRenderingHint TextRenderingMode { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = RenderingMode;
            g.TextRenderingHint = TextRenderingMode;
            base.OnPaint(e);
        }

        public BaseTextBox()
            : base()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // BaseTextBox
            //
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BaseTextBox_MouseClick);
            this.Enter += new System.EventHandler(this.BaseTextBox_Enter);
            this.Leave += new System.EventHandler(this.BaseTextBox_Leave);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseTextBox_KeyPress);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseTextBox_Enter(object sender, EventArgs e)
        {
            if (!this.ReadOnly && this.Enabled && !this.FocusBackColor.IsEmpty)
            {
                if (this.SaveBackColor.IsEmpty)
                {
                    this.SaveBackColor = this.BackColor;
                }
                this.BackColor = FocusBackColor;
            }
            if (!this.ReadOnly && this.Enabled && !this.FocusForeColor.IsEmpty)
            {
                if (this.SaveForeColor.IsEmpty)
                {
                    this.SaveForeColor = this.ForeColor;
                }
                this.ForeColor = FocusForeColor;
            }
            this.SelectAll();
        }

        public void SetDefaultBackColor()
        {
            if (!this.ReadOnly && this.Enabled && !this.FocusBackColor.IsEmpty)
            {
                if (!this.SaveBackColor.IsEmpty)
                {
                    this.BackColor = this.SaveBackColor;
                }
            }
        }
        public void SetDefaultForeColor()
        {
            if (!this.ReadOnly && this.Enabled && !this.FocusForeColor.IsEmpty)
            {
                if (!this.SaveForeColor.IsEmpty)
                {
                    this.ForeColor = this.SaveForeColor;
                }
            }
        }
        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseTextBox_Leave(object sender, EventArgs e)
        {
            _mouseFirstClickFlg = false;
            if (!this.ReadOnly && this.Enabled && !this.FocusBackColor.IsEmpty)
            {
                if (!this.SaveBackColor.IsEmpty)
                {
                    this.BackColor = this.SaveBackColor;
                }
            }
            if (!this.ReadOnly && this.Enabled && !this.FocusForeColor.IsEmpty)
            {
                if (!this.SaveForeColor.IsEmpty)
                {
                    this.ForeColor = this.SaveForeColor;
                }
            }
            if (this.DefaultToUpper)
            {
                this.Text = this.Text.ToUpper();
            }
            if (this.DefaultTrim)
            {
                this.Text = this.Text.Trim();
            }
            if (this.DefaultNarrow)
            {
                this.Text = KanaEx.ToHankaku(this.Text);
                this.Text = KanaEx.ToHankakuKana(this.Text);
            }
        }

        /// <summary>
        /// KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MaxLengthBytes > 0)
            {
                if (sjis.GetByteCount(this.Text) > MaxLengthBytes)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (DefaultNumberOnly)
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                {
                    e.Handled = true;
                    return;
                }
            }
            if (DefaultAlphaNumberOnly)
            {
                if (Regex.IsMatch(e.KeyChar.ToString(), @"[^a-zA-z0-9-@_]") && e.KeyChar != '\b')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m"></param>
        [System.Security.Permissions.SecurityPermission(
            System.Security.Permissions.SecurityAction.LinkDemand,
            Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (DefaultNumberOnly)
            {
                if (m.Msg == WM_PASTE)
                {
                    IDataObject iData = Clipboard.GetDataObject();
                    //文字列がクリップボードにあるか
                    if (iData != null && iData.GetDataPresent(DataFormats.Text))
                    {
                        string clipStr = (string)iData.GetData(DataFormats.Text);
                        //クリップボードの文字列が数字か調べる
                        if (!System.Text.RegularExpressions.Regex.IsMatch(
                            clipStr,
                            @"^[0-9]+$"))
                            return;
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void BaseTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.Enabled && _mouseFirstClickFlg == false && DefaultClickSelectAll)
                {
                    this.Select(0, this.Text.Length);
                    this.SelectAll();
                }
                _mouseFirstClickFlg = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
