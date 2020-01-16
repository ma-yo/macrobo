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
using Macrobo.Models;
using Macrobo.Views.Forms;

namespace Macrobo.Views.Controls
{
    /// <summary>
    /// Author : M.Yoshida
    /// ダイアログコントロール
    /// </summary>
    public partial class DialogControl : ProcessBaseControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DialogControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();
                NormalDialogRadio.Checked = true;
                OkDialogRadio.Checked = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ボタンイベントをセットする
        /// </summary>
        private void AddButtonEvent()
        {
            try
            {
                CompButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CompButton.Tag = ProcessModel.GetEndProcessModel();
                ErrorButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                ErrorButton.Tag = ProcessModel.GetErrorProcessModel();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
