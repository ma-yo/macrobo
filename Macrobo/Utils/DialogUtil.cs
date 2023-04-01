using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// ダイアログユーティリティ
    /// </summary>
    public static class DialogUtil
    {
        public static DialogResult ShowErrorDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowErrorDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Error, defaultButton);
        }
        public static DialogResult ShowInfoDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowInfoDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Information, defaultButton);
        }
        public static DialogResult ShowWarningDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowWarningDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Warning, defaultButton);
        }

        public static DialogResult ShowQuestionDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowQuestionDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Question, defaultButton);
        }

        public static DialogResult ShowDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.None, defaultButton);
        }

        public static DialogResult ShowDangerDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowDangerDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Asterisk, defaultButton);
        }

        public static DialogResult ShowStopDialog(this Control c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowStopDialog(this Control c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Stop, defaultButton);
        }

















        public static DialogResult ShowErrorDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowErrorDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Error, defaultButton);
        }
        public static DialogResult ShowInfoDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowInfoDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Information, defaultButton);
        }
        public static DialogResult ShowWarningDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowWarningDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Warning, defaultButton);
        }

        public static DialogResult ShowQuestionDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowQuestionDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Question, defaultButton);
        }

        public static DialogResult ShowDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.None, defaultButton);
        }

        public static DialogResult ShowDangerDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowDangerDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Asterisk, defaultButton);
        }

        public static DialogResult ShowStopDialog(this UserControl c, string title, string message)
        {
            return MessageBox.Show(c, message, title, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult ShowStopDialog(this UserControl c, string title, string message, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(c, message, title, button, MessageBoxIcon.Stop, defaultButton);
        }
    }
}
