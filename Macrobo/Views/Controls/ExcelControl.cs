using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Macrobo.Models;
using Macrobo.Components;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Macrobo.Views.Controls
{
    /// <summary>
    /// Author : M.Yoshida
    /// Excelコントロール
    /// </summary>
    public partial class ExcelControl : ProcessBaseControl
    {
        private bool ExcelJobGridRowsAddingFlag = false;
        public int COL_処理タイプ = 0;
        public int COL_シート名 = 0;
        public int COL_セル名 = 0;
        public int COL_値 = 0;
        /// <summary>
        /// Constructor
        /// </summary>
        public ExcelControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();

                COL_処理タイプ = EXCELJOBGRID_COL_処理タイプ.Index;
                COL_シート名 = EXCELJOBGRID_COL_シート名.Index;
                COL_セル名 = EXCELJOBGRID_COL_セル名.Index;
                COL_値 = EXCELJOBGRID_COL_値.Index;
                ExcelSourceNewRadio.CheckedChanged += ExcelSourceRadio_CheckedChanged;
                ExcelSourceExistsRadio.CheckedChanged += ExcelSourceRadio_CheckedChanged;

                ExcelSourceNewRadio.Checked = true;

                CreateFirstRow();

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 1行目が無い場合は作成する
        /// </summary>
        public void CreateFirstRow()
        {
            try
            {
                if(ExcelJobGrid.Rows.Count == 0)
                {
                    ExcelJobGrid.Rows.Add();
                    ExcelJobGrid.Rows[0].Cells[COL_処理タイプ].Value = "読み込み";
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 読込ソースの変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelSourceRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (!radio.Checked) return;

                ExcelLoadFilePathTitleLbl.Visible = false;
                ExcelLoadFilePathTextBox.Visible = false;
                FileOpenButton.Visible = false;
                if (radio.Equals(ExcelSourceExistsRadio))
                {
                    ExcelLoadFilePathTitleLbl.Visible = true;
                    ExcelLoadFilePathTextBox.Visible = true;
                    FileOpenButton.Visible = true;
                }
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
                ErrorButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CompButton.Tag = ProcessModel.GetEndProcessModel();
                ErrorButton.Tag = ProcessModel.GetErrorProcessModel();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// エクセルセルステート変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelJobGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                ExcelJobGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// Excelﾌｧｲﾙパスを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog("Excelファイルの選択");
                // フォルダ選択モード
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                dialog.Filters.Add(new CommonFileDialogFilter("Excel ブック", "*.xls;*.xlsx"));
                if (dialog.ShowDialog(ParentForm.Handle) == CommonFileDialogResult.Ok)
                {
                    ExcelLoadFilePathTextBox.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        private void SaveFileDialog_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelSaveFileDialog.FileName = "newfile.xlsx";
                ExcelSaveFileDialog.Filter = "Excelブック(*.xls;*.xlsx)|*.xls;*.xlsx";
                ExcelSaveFileDialog.Title = "Excelファイルの保存先を選択してください。";
                ExcelSaveFileDialog.OverwritePrompt = false;
                ExcelSaveFileDialog.CheckFileExists = false;
                if(ExcelSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelSaveFilePathTextBox.Text = ExcelSaveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 読込元ファイル入力のDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelLoadFilePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if(files != null)
                {
                    ExcelLoadFilePathTextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 読込元ファイル入力のDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelLoadFilePathTextBox_DragEnter(object sender, DragEventArgs e)
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
        /// Excel書き出しテキストのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelSaveFilePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    ExcelSaveFilePathTextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Excel書き出しテキストのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelSaveFilePathTextBox_DragEnter(object sender, DragEventArgs e)
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
        /// Cellの編集終了後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelJobGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ExcelJobGridRowsAddingFlag) return;
                if (e.RowIndex < 0) return;
                if (e.RowIndex == ExcelJobGrid.Rows.Count - 1)
                {
                    foreach (DataGridViewColumn column in ExcelJobGrid.Columns)
                    {
                        if (column.Index == COL_処理タイプ) continue;
                        if (!string.IsNullOrEmpty("" + ExcelJobGrid.Rows[e.RowIndex].Cells[column.Index].Value))
                        {
                            ExcelJobGridRowsAddingFlag = true;
                            int newRow = ExcelJobGrid.Rows.Add();
                            ExcelJobGrid.Rows[newRow].Cells[COL_処理タイプ].Value = ExcelJobGrid.Rows[newRow - 1].Cells[COL_処理タイプ].Value;
                            ExcelJobGrid.Rows[newRow].Cells[COL_シート名].Value = ExcelJobGrid.Rows[newRow - 1].Cells[COL_シート名].Value;
                            ExcelJobGridRowsAddingFlag = false;
                            return;
                        }
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
