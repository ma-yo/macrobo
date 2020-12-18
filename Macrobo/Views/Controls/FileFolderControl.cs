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
using Microsoft.WindowsAPICodePack.Dialogs;
using Macrobo.Views.Forms;

namespace Macrobo.Views.Controls
{
    /// <summary>
    /// Author : M.Yoshida
    /// ファイルフォルダーコントロール
    /// </summary>
    public partial class FileFolderControl : ProcessBaseControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FileFolderControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();
                FileActionRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FolderActionRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderDetectRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderCreateRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderRemoveRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderMoveRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderCopyRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderSaveUdateRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderZipArchiveRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileFolderZipUnArchiveRadio.CheckedChanged += ActionRadio_CheckedChanged;
                FileActionRadio.Checked = true;
                FileFolderDetectRadio.Checked = true;
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
                VariableButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                VariableButton.Tag = StringValue.VARIABLE_VAR0;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダ実行処理の選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (!radio.Checked) return;
                FileFolderPath1TitleLbl.Visible = false;
                FileFolderPath1TextBox.Visible = false;
                FileFolderOpen1Button.Visible = false;
                FileFolderPath2TitleLbl.Visible = false;
                FileFolderPath2TextBox.Visible = false;
                FileFolderOpen2Button.Visible = false;
                VariableTitleLbl.Visible = false;
                VariableButton.Visible = false;
                TimeoutTitleLbl.Visible = false;
                TimeoutNumericUpDown.Visible = false;
                ZipPasswordTextBox.Visible = false;
                ZipPasswordTitleLbl.Visible = false;
                if (FileActionRadio.Checked)
                {
                    if (FileFolderDetectRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "検出ファイル";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;
                    }
                    if (FileFolderCreateRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "作成ファイル";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                    }
                    if (FileFolderRemoveRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "削除ファイル";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                    }
                    if (FileFolderMoveRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "移動元ファイルパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "移動先ファイルパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                    if (FileFolderCopyRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "コピー元ファイルパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "コピー先ファイルパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                    if (FileFolderSaveUdateRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "更新日ファイル";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        VariableTitleLbl.Visible = true;
                        VariableButton.Visible = true;
                    }
                    if (FileFolderZipArchiveRadio.Checked)
                    {
                        ZipPasswordTextBox.Visible = true;
                        ZipPasswordTitleLbl.Visible = true;
                        FileFolderPath1TitleLbl.Text = "圧縮元ファイルパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "圧縮先ファイルパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                    if (FileFolderZipUnArchiveRadio.Checked)
                    {
                        ZipPasswordTextBox.Visible = true;
                        ZipPasswordTitleLbl.Visible = true;
                        FileFolderPath1TitleLbl.Text = "解凍元ファイルパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "解凍先ファイルパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                }
                if (FolderActionRadio.Checked)
                {
                    if (FileFolderDetectRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "検出フォルダ";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;
                    }
                    if (FileFolderCreateRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "作成フォルダ";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                    }
                    if (FileFolderRemoveRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "削除フォルダ";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                    }
                    if (FileFolderMoveRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "移動元フォルダパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "移動先フォルダパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                    if (FileFolderCopyRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "コピー元フォルダパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "コピー先フォルダパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                    if (FileFolderSaveUdateRadio.Checked)
                    {
                        FileFolderPath1TitleLbl.Text = "更新日フォルダ";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        VariableTitleLbl.Visible = true;
                        VariableButton.Visible = true;
                    }
                    if (FileFolderZipArchiveRadio.Checked)
                    {
                        ZipPasswordTextBox.Visible = true;
                        ZipPasswordTitleLbl.Visible = true;
                        FileFolderPath1TitleLbl.Text = "圧縮元フォルダパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "圧縮先フォルダパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                    if (FileFolderZipUnArchiveRadio.Checked)
                    {
                        ZipPasswordTextBox.Visible = true;
                        ZipPasswordTitleLbl.Visible = true;
                        FileFolderPath1TitleLbl.Text = "解凍元フォルダパス";
                        FileFolderPath1TitleLbl.Visible = true;
                        FileFolderPath1TextBox.Visible = true;
                        FileFolderOpen1Button.Visible = true;
                        FileFolderPath2TitleLbl.Text = "解凍先フォルダパス";
                        FileFolderPath2TitleLbl.Visible = true;
                        FileFolderPath2TextBox.Visible = true;
                        FileFolderOpen2Button.Visible = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル又は、フォルダを選択します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderOpen1Button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileOrFolderDialog(0);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル又はフォルダ選択ダイアログをオープンする
        /// </summary>
        /// <param name="index"></param>
        private void OpenFileOrFolderDialog(int index)
        {
            try
            {
                string selectType = "ファイル";
                if (FolderActionRadio.Checked)
                {
                    selectType = "フォルダ";
                }
                var dialog = new CommonOpenFileDialog(selectType + "の選択");
                // フォルダ選択モード
                if (FolderActionRadio.Checked)
                {
                    dialog.IsFolderPicker = true;
                }
                dialog.Multiselect = false;
                if (dialog.ShowDialog(ParentForm.Handle) == CommonFileDialogResult.Ok)
                {
                    switch (index)
                    {
                        case 0:
                            FileFolderPath1TextBox.Text = dialog.FileName;
                            break;
                        case 1:
                            FileFolderPath2TextBox.Text = dialog.FileName;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ファイル又は、フォルダを選択します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderOpen2Button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileOrFolderDialog(1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 変数を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<string> keyList = new List<string>();
                keyList.Add(StringValue.VARIABLE_未設定);
                foreach (var variable in CurrentProjectModel.VariableList)
                {
                    keyList.Add(variable.Key);
                }
                string title = VariableTitleLbl.Text;
                form.Init(title, keyList, (string)VariableButton.Tag);
                form.ShowDialog(this);
                VariableButton.Tag = form.GetSelected<string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダパステキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderPath1TextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    FileFolderPath1TextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダパステキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderPath1TextBox_DragEnter(object sender, DragEventArgs e)
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
        /// <summary>
        /// ファイルフォルダパステキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderPath2TextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    FileFolderPath2TextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダパステキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderPath2TextBox_DragEnter(object sender, DragEventArgs e)
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
