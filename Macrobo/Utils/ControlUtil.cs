using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Utils
{

    /// <summary>
    /// コントロール系ユーティリティー
    /// Author : M.Yoshida
    /// </summary>
    public static class ControlUtil
    {
        /// <summary>
        /// コンテナ内のコントロールをハンドルを残さずにクリアする。
        /// </summary>
        /// <param name="c"></param>
        public static void ClearControls(this Control c)
        {
            try
            {
                if (c.Controls.Count == 0) return;
                for (int i = 0; i < c.Controls.Count; i++)
                {
                    Control c2 = c.Controls[i];
                    c.Controls.RemoveAt(i);
                    c2.Dispose();
                    i--;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// コンテナ内のコントロールをハンドルを残さずにクリアする。
        /// </summary>
        /// <param name="c"></param>
        public static void ClearControlsNotDispose(this Control c)
        {
            try
            {
                if (c.Controls.Count == 0) return;
                for (int i = 0; i < c.Controls.Count; i++)
                {
                    c.Controls.RemoveAt(i);
                    i--;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// コンテナ内のコントロールをハンドルを残さずにクリアする。
        /// </summary>
        /// <param name="c"></param>
        public static void ClearControl(this Control c, int index)
        {
            try
            {
                if (c.Controls.Count <= index) return;
                Control c2 = c.Controls[index];
                c.Controls.RemoveAt(index);
                c2.Dispose();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// コンテナ内のコントロールをハンドルを残さずにクリアする。
        /// </summary>
        /// <param name="c"></param>
        public static void ClearControl(this Control c, Control ctrl)
        {
            try
            {
                if (c.Controls.Count == 0) return;
                for (int i = 0; i < c.Controls.Count; i++)
                {
                    Control c2 = c.Controls[i];
                    if (c2.Equals(ctrl))
                    {
                        c.Controls.RemoveAt(i);
                        c2.Dispose();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
