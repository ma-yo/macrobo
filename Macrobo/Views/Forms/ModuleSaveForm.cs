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
using Macrobo.Utils;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// モジュール保存画面
    /// </summary>
    public partial class ModuleSaveForm : BaseForm
    {
        public bool Saved { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ModuleSaveForm()
        {
            InitializeComponent();
            ProjTextBox.KeyDown += ProjTextBox_KeyDown;
            DescriptionTextBox.KeyDown += DescriptionTextBox_KeyDown;
        }
        /// <summary>
        /// 説明文TextBoxのKeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaveButton.Focus();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ProjTextBoxのKeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    DescriptionTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleSaveForm_Shown(object sender, EventArgs e)
        {
            try
            {
                ProjTextBox.Focus();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 保存ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ProjTextBox.Text.Trim()))
                {
                    this.ShowErrorDialog("モジュール名未入力", "モジュール名は入力必須項目です。");
                    return;
                }
                Saved = true;
                Close();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
