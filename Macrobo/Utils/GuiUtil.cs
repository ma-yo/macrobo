using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Utils
{
    public sealed class GuiUtil
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int WM_SETREDRAW = 0x000B;
        /// <summary>
        /// IDを保持する
        /// </summary>
        private string _currentId;
        private Control _control;
        private static GuiUtil _instance = new GuiUtil();
        public static GuiUtil GetInstance()
        {
            return _instance;
        }
        /// <summary>
        /// IDを発行する
        /// </summary>
        /// <returns></returns>
        public string NewId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// コントロール(子コントロールも含む)の描画を停止します。
        /// </summary>
        /// <param name="control">対象コントロール</param>
        public void BeginUpdate(Control control, string id)
        {
            if (!string.IsNullOrEmpty(_currentId)) return;
            _currentId = id;
            _control = control;
            SendMessage(control.Handle, WM_SETREDRAW, 0, 0);
        }

        /// <summary>
        /// コントロール(子コントロールも含む)の描画を開始します。
        /// </summary>
        /// <param name="control">対象コントロール</param>
        public void EndUpdate(string id)
        {
            if (string.IsNullOrEmpty(_currentId)) return;
            if (_currentId != id) return;
            SendMessage(_control.Handle, WM_SETREDRAW, 1, 0);
            _control.Refresh();
            _currentId = "";
            _control = null;
        }
    }
}
