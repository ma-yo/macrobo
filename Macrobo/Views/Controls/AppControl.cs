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

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// 外部プロセス実行コントロール
    /// </summary>
    public partial class AppControl : ProcessBaseControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AppControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();
                WaitRadio.Checked = true;
                NormalStateRadio.Checked = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ボタンイベントを作成する
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

                WaitRadio.CheckedChanged += WaitRadio_CheckedChanged;
                NonWaitRadio.CheckedChanged += WaitRadio_CheckedChanged;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 待機Radioのチェック後変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (!radio.Checked) return;
                ExitCodeTitleLbl.Visible = radio.Equals(WaitRadio);
                ExitCodeUpDown.Visible = radio.Equals(WaitRadio);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="rootProjectModel"></param>
        /// <param name="projModel"></param>
        /// <param name="procModel"></param>
        public override void Init(ProjectModel rootProjectModel, ProjectModel projModel, ProcessModel procModel)
        {
            try
            {
                this.RootProjectModel = rootProjectModel;
                this.CurrentProjectModel = projModel;
                this.ProcessModel = procModel;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルオープンを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExecPathOpenFileDialog.Multiselect = false;
                DialogResult result = ExecPathOpenFileDialog.ShowDialog();
                if (result != DialogResult.OK) return;
                ExecutePathTextBox.Text = ExecPathOpenFileDialog.FileName;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行パステキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    ExecutePathTextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行パステキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecutePathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
