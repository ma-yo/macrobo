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
using Macrobo.Utils;
using Macrobo.Models.Enums;
using Macrobo.Models;
using System.Diagnostics;
using Macrobo.Views.Controls;
using Macrobo.Singleton;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// ノードコントロール
    /// </summary>
    public partial class NodeControl : BaseUserControl
    {
        /// <summary>
        /// ルートのプロジェクトモデルの参照を保持する
        /// </summary>
        public ProjectModel RootProjectModel { get; set; }
        /// <summary>
        /// プロジェクトモデルを保持
        /// </summary>
        public ProjectModel CurrentProjectModel { get; set; }
        /// <summary>
        /// 処理モデルを保持
        /// </summary>
        public ProcessModel ProcessModel { get; set; }
        /// <summary>
        /// プロセス名変更イベント
        /// </summary>
        /// <param name="ctrl"></param>
        public delegate void ProcessNameChangeEvent(NodeControl ctrl);
        /// <summary>
        /// プロセス名変更
        /// </summary>
        public ProcessNameChangeEvent OnProcessNameChange;
        /// <summary>
        /// ノードタイプ 0:ルートノード 1:子ノード
        /// </summary>
        private NodeType _nodeType = NodeType.None;
        public NodeType NodeType { get { return _nodeType;  } set { _nodeType = value; SetNodeType(); } }
        /// <summary>
        /// 処理実行タイプを保持 画像検索 キーボード入力 マウスインプット 待機 メール送信
        /// </summary>
        private ProcessType _processType = ProcessType.None;
        public ProcessType ProcessType { get { return _processType;  } set { _processType = value; SetProcessType(); } }
        /// <summary>
        /// プロセスタイプ変更ｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="type"></param>
        public delegate void ProcessTypeChangeEvent(ProcessType type);
        /// <summary>
        /// プロセスタイプ変更ｲﾍﾞﾝﾄ
        /// </summary>
        public ProcessTypeChangeEvent OnProcessTypeChange;
        /// <summary>
        /// ノードを保持する
        /// </summary>
        public TreeNode TreeNode { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public NodeControl()
        {
            try
            {
                InitializeComponent();
                DetectRadio.Click += ProcessTypeRadio_Click;
                KeyboardInputRadio.Click += ProcessTypeRadio_Click;
                MouseInputRadio.Click += ProcessTypeRadio_Click;
                WaitRadio.Click += ProcessTypeRadio_Click;
                MailSendRadio.Click += ProcessTypeRadio_Click;
                AppStartRadio.Click += ProcessTypeRadio_Click;
                VariableRadio.Click += ProcessTypeRadio_Click;
                FileFolderRadio.Click += ProcessTypeRadio_Click;
                DialogRadio.Click += ProcessTypeRadio_Click;
                ExcelRadio.Click += ProcessTypeRadio_Click;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードタイプをセットする
        /// </summary>
        private void SetNodeType()
        {
            try
            {
                switch (_nodeType)
                {
                    case NodeType.Root: //ルートノード
                        switch (CurrentProjectModel.ExecDataType)
                        {
                            case ExecDataType.PROJECT:
                                TitleLbl.Text = "プロジェクト情報";
                                ProjTitleLbl.Text = "プロジェクト名";
                                break;
                            case ExecDataType.MACRO:
                                TitleLbl.Text = "モジュール情報";
                                ProjTitleLbl.Text = "モジュール名";
                                break;
                        }
                        ProcessTypeTitleLbl.Visible = false;
                        ProcessTypePanel.Visible = false;
                        break;
                    case NodeType.Child: //チャイルドノード
                        switch (CurrentProjectModel.ExecDataType)
                        {
                            case ExecDataType.PROJECT:
                                TitleLbl.Text = "プロジェクトノード情報";
                                ProjTitleLbl.Text = "処理名";
                                break;
                            case ExecDataType.MACRO:
                                TitleLbl.Text = "マクロノード情報";
                                ProjTitleLbl.Text = "処理名";
                                break;
                        }
                        ProcessTypeTitleLbl.Visible = true;
                        ProcessTypePanel.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 処理タイプをセットする
        /// </summary>
        private void SetProcessType()
        {
            try
            {
                if (ContainerPanel.Controls.Count > 0 && ContainerPanel.Controls[0] is ProcessBaseControl)
                {
                    ProcessBaseControl ctrl = (ProcessBaseControl)ContainerPanel.Controls[0];

                    if (ctrl.ValidRadio.Checked)
                    {
                        ProcessModel.ValidType = ValidType.有効;
                    }
                    else
                    {
                        ProcessModel.ValidType = ValidType.無効;
                    }
                    ProcessModel.BeforeWaitMilliTime = (int)ctrl.BeforeWaitTimeUpDown.Value;
                    ProcessModel.AfterWaitMilliTime = (int)ctrl.AfterWaitTimeUpDown.Value;
                    ProcessModel.NextProcess = (ProcessModel)ctrl.CompButton.Tag;
                    ProcessModel.ErrorProcess = (ProcessModel)ctrl.ErrorButton.Tag;
                }
                ContainerPanel.ClearControls();
                switch (_processType)
                {
                    case ProcessType.検出:
                        {
                            DetectRadio.Checked = true;

                            AddProcessControl(new DetectControl());
                        }
                        break;
                    case ProcessType.キーボード入力:
                        {
                            KeyboardInputRadio.Checked = true;
                            AddProcessControl(new KeyboardInputControl());
                        }
                        break;
                    case ProcessType.マウス入力:
                        {
                            MouseInputRadio.Checked = true;
                            AddProcessControl(new MouseControl());
                        }
                        break;
                    case ProcessType.待機:
                        {
                            WaitRadio.Checked = true;
                            AddProcessControl(new WaitControl());
                        }
                        break;
                    case ProcessType.メール送信:
                        {
                            MailSendRadio.Checked = true;
                            AddProcessControl(new MailSendControl());
                        }
                        break;
                    case ProcessType.アプリ実行:
                        {
                            AppStartRadio.Checked = true;
                            AddProcessControl(new AppControl());
                        }
                        break;
                    case ProcessType.変数:
                        {
                            VariableRadio.Checked = true;
                            AddProcessControl(new VariableControl());
                        }
                        break;
                    case ProcessType.ファイルフォルダー処理:
                        {
                            FileFolderRadio.Checked = true;
                            AddProcessControl(new FileFolderControl());
                        }
                        break;
                    case ProcessType.ダイアログ:
                        {
                            DialogRadio.Checked = true;
                            AddProcessControl(new DialogControl());
                        }
                        break;
                    case ProcessType.Excel:
                        {
                            ExcelRadio.Checked = true;
                            AddProcessControl(new ExcelControl());
                        }
                        break;
                }
                OnProcessTypeChange?.Invoke(_processType);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロセスコントロールをコンテナにセットする
        /// </summary>
        /// <param name="ctrl"></param>
        private void AddProcessControl(ProcessBaseControl ctrl)
        {
            try
            {
                ctrl.Init(RootProjectModel, CurrentProjectModel, ProcessModel);
                ctrl.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                ctrl.Width = ContainerPanel.Width;
                ctrl.Height = ContainerPanel.Height;
                ctrl.Location = new Point(0, 0);
                ctrl.SetBaseValues(ProcessModel);
                ContainerPanel.Controls.Add(ctrl);

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ExcelRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ExcelRadio.Checked) return;
                ProcessType = ProcessType.Excel;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 画像検索Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!DetectRadio.Checked) return;
                ProcessType = ProcessType.検出;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キーボード入力Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!KeyboardInputRadio.Checked) return;
                ProcessType = ProcessType.キーボード入力;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスクリックRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!MouseInputRadio.Checked) return;
                ProcessType = ProcessType.マウス入力;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// メール送信Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailSendRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!MailSendRadio.Checked) return;
                ProcessType = ProcessType.メール送信;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 待機Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!WaitRadio.Checked) return;
                ProcessType = ProcessType.待機;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// アプリ開始Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppStartRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!AppStartRadio.Checked) return;
                ProcessType = ProcessType.アプリ実行;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!VariableRadio.Checked) return;
                ProcessType = ProcessType.変数;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダーRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileFolderRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!FileFolderRadio.Checked) return;
                ProcessType = ProcessType.ファイルフォルダー処理;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ダイアログRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DialogRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!DialogRadio.Checked) return;
                ProcessType = ProcessType.ダイアログ;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 処理モードを設定する
        /// </summary>
        /// <param name="rootProjectModel"></param>
        /// <param name="projectModel"></param>
        /// <param name="procModel"></param>
        internal void SetNodeMode(ProjectModel rootProjectModel, ProjectModel projectModel, ProcessModel procModel)
        {
            try
            {
                RootProjectModel = rootProjectModel;
                ProcessModel = procModel;
                CurrentProjectModel = projectModel;
                NodeType = NodeType.Child;
                ProjTextBox.Text = procModel.Name;
                ProjTextBox.Tag = procModel.Name;
                DescriptionTextBox.Text = procModel.Description;
                ProcessType = procModel.ProcessType;
                switch (ProcessType)
                {
                    case ProcessType.検出:
                        SetDetectControl(procModel);
                        break;
                    case ProcessType.キーボード入力:
                        SetKeyboardInputConrol(procModel);
                        break;
                    case ProcessType.マウス入力:
                        SetMouseClickControl(procModel);
                        break;
                    case ProcessType.待機:
                        SetWaitControl(procModel);
                        break;
                    case ProcessType.メール送信:
                        SetMailSendControl(procModel);
                        break;
                    case ProcessType.アプリ実行:
                        SetAppControl(procModel);
                        break;
                    case ProcessType.変数:
                        SetVariableControl(procModel);
                        break;
                    case ProcessType.ファイルフォルダー処理:
                        SetFileFolderControl(procModel);
                        break;
                    case ProcessType.ダイアログ:
                        SetDialogControl(procModel);
                        break;
                    case ProcessType.Excel:
                        SetExcelControl(procModel);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キーボード入力コントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetKeyboardInputConrol(ProcessModel procModel)
        {
            try
            {
                KeyboardInputControl ctrl = (KeyboardInputControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                switch (procModel.KeyboardInputType)
                {
                    case KeyboardInputType.KEYBOARD:
                        ctrl.KeyboardInputRadio.Checked = true;
                        break;
                    case KeyboardInputType.STRING:
                        ctrl.StringInputRadio.Checked = true;
                        if (!string.IsNullOrEmpty(procModel.VariableKey) && RootProjectModel.VariableList.ContainsKey(procModel.VariableKey))
                        {
                            ctrl.VariableButton.Tag = procModel.VariableKey;
                        }
                        break;
                }
                ctrl.StringInputTextBox.Text = procModel.KeyboardInput;
                if(procModel.KeyboardInputKeycodes != null)
                {
                    ctrl.StringInputTextBox.Tag = procModel.KeyboardInputKeycodes;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスクリックコントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetMouseClickControl(ProcessModel procModel)
        {
            try
            {
                MouseControl ctrl = (MouseControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                ctrl.ScrollSpeedUpDown.Value = procModel.ScrollSpeed;
                ctrl.ScrollAmountUpDown.Value = procModel.ScrollAmount;
                ctrl.ScrollCountUpDown.Value = procModel.ScrollCount;
                switch (procModel.MouseExecType)
                {
                    case MouseInputType.クリック:
                        ctrl.MouseClickRadio.Checked = true;
                        break;
                    case MouseInputType.移動:
                        ctrl.MouseMoveRadio.Checked = true;
                        break;
                    case MouseInputType.ドラッグドロップ:
                        ctrl.MouseDragDropRadio.Checked = true;
                        break;
                    case MouseInputType.ホイール操作:
                        ctrl.MouseWheelRadio.Checked = true;
                        break;
                }
                switch (procModel.MouseClickDetectType)
                {
                    case MouseInputDetectType.画像検出:
                        ctrl.ImageDetectRadio.Checked = true;
                        break;
                    case MouseInputDetectType.座標検出:
                        ctrl.PointInputRadio.Checked = true;
                        break;
                }
                for (int i = 0; i < procModel.CaptureImage.Count; i++)
                {
                    ctrl.ImageList[i] = procModel.CaptureImage[i];
                }
                if(ctrl.ImageList[0] != null)
                {
                    ctrl.CaptureImage.Image = ctrl.ImageList[0];
                }
                ctrl.StringInputTextBox.Text = procModel.KeyboardInput;
                if (!string.IsNullOrEmpty(procModel.KeyboardInput))
                {
                    ctrl.StringInputTextBox.Tag = procModel.KeyboardInputKeycodes;
                }
                switch (procModel.DetectAreaType)
                {
                    case DetectAreaType.SCREEN:
                        ctrl.DetectAreaScreenRadio.Checked = true;
                        break;
                    case DetectAreaType.CHOICE:
                        ctrl.DetectAreaChoiceRadio.Checked = true;
                        break;
                }
                ctrl.DetectAreaSXTextBox.Text = procModel.DetectAreaSX;
                ctrl.DetectAreaSYTextBox.Text = procModel.DetectAreaSY;
                ctrl.DetectAreaEXTextBox.Text = procModel.DetectAreaEX;
                ctrl.DetectAreaEYTextBox.Text = procModel.DetectAreaEY;

                ctrl.PointTypeButton.Tag = procModel.PointType;
                ctrl.TimeoutNumericUpDown.Value = procModel.Timeout;
                ctrl.ClickCountUpDown.Text = procModel.ClickCount;
                ctrl.OffsetXTextBox.Text = "" + procModel.OffsetXPoint;
                ctrl.OffsetYTextBox.Text = "" + procModel.OffsetYPoint;
                ctrl.ClickPosButton.Tag = procModel.ClickPosition;
                ctrl.ScrollButton.Tag = procModel.ScrollType;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 待機コントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetWaitControl(ProcessModel procModel)
        {
            try
            {
                WaitControl ctrl = (WaitControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                ctrl.TimeoutNumericUpDown.Value = procModel.Timeout;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 検出コントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        public void SetDetectControl(ProcessModel procModel)
        {
            try
            {
                DetectControl ctrl = (DetectControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                switch (procModel.DetectType)
                {
                    case DetectType.画像:
                        ctrl.ImageDetectRadio.Checked = true;
                        break;
                    case DetectType.ファイル:
                        ctrl.FileDetectRadio.Checked = true;
                        break;
                }
                switch (procModel.FileDetectType)
                {
                    case FileDetectType.完全一致:
                        ctrl.MatchRadio.Checked = true;
                        break;
                    case FileDetectType.前方一致:
                        ctrl.FMatchRadio.Checked = true;
                        break;
                    case FileDetectType.後方一致:
                        ctrl.BMatchRadio.Checked = true;
                        break;
                    case FileDetectType.部分一致:
                        ctrl.PMatchRadio.Checked = true;
                        break;
                }
                switch (procModel.DetectFileModeType)
                {
                    case DetectFileModeType.Exists:
                        ctrl.FileStateExistsRadio.Checked = true;
                        break;
                    case DetectFileModeType.Readable:
                        ctrl.FileStateReadableRadio.Checked = true;
                        break;
                    case DetectFileModeType.Writable:
                        ctrl.FileStateWritableRadio.Checked = true;
                        break;
                }
                switch (procModel.DetectAreaType)
                {
                    case DetectAreaType.SCREEN:
                        ctrl.DetectAreaScreenRadio.Checked = true;
                        break;
                    case DetectAreaType.CHOICE:
                        ctrl.DetectAreaChoiceRadio.Checked = true;
                        break;
                }
                ctrl.DetectAreaSXTextBox.Text = procModel.DetectAreaSX;
                ctrl.DetectAreaSYTextBox.Text = procModel.DetectAreaSY;
                ctrl.DetectAreaEXTextBox.Text = procModel.DetectAreaEX;
                ctrl.DetectAreaEYTextBox.Text = procModel.DetectAreaEY;

                ctrl.ScrollSpeedUpDown.Value = procModel.ScrollSpeed;
                ctrl.ScrollAmountUpDown.Value = procModel.ScrollAmount;
                for(int i = 0; i < procModel.CaptureImage.Count; i++)
                {
                    ctrl.ImageList[i] = procModel.CaptureImage[i];
                }
                if(ctrl.ImageList[0] != null)
                {
                    ctrl.CaptureImage.Image = ctrl.ImageList[0];
                }
                ctrl.FolderPathTextBox.Text = procModel.DetectFolderPath;
                ctrl.FileNameTextBox.Text = procModel.DetectFileName;
                ctrl.TimeoutNumericUpDown.Value = procModel.Timeout;
                ctrl.ScrollButton.Tag = procModel.ScrollType;

                if (!string.IsNullOrEmpty(procModel.VariableKey) && RootProjectModel.VariableList.ContainsKey(procModel.VariableKey))
                {
                    ctrl.VariableButton.Tag = procModel.VariableKey;
                }
                ctrl.MoveMouseButton.Tag = procModel.MoveMouseType;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダーコントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        public void SetFileFolderControl(ProcessModel procModel)
        {
            try
            {
                FileFolderControl ctrl = (FileFolderControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);

                switch (procModel.FileFolderActionType)
                {
                    case FileFolderActionType.ファイル:
                        ctrl.FileActionRadio.Checked = true;
                        break;
                    case FileFolderActionType.フォルダ:
                        ctrl.FolderActionRadio.Checked = true;
                        break;
                }
                switch (procModel.FileFolderExecType)
                {
                    case FileFolderExecType.Detect:
                        ctrl.FileFolderDetectRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        ctrl.TimeoutNumericUpDown.Value = procModel.Timeout;
                        break;
                    case FileFolderExecType.Create:
                        ctrl.FileFolderCreateRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        break;
                    case FileFolderExecType.Remove:
                        ctrl.FileFolderRemoveRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        break;
                    case FileFolderExecType.Move:
                        ctrl.FileFolderMoveRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        ctrl.FileFolderPath2TextBox.Text = procModel.FileFolderPath2;
                        break;
                    case FileFolderExecType.Copy:
                        ctrl.FileFolderCopyRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        ctrl.FileFolderPath2TextBox.Text = procModel.FileFolderPath2;
                        break;
                    case FileFolderExecType.SaveUdate:
                        ctrl.FileFolderSaveUdateRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        if (!string.IsNullOrEmpty(procModel.VariableKey) && RootProjectModel.VariableList.ContainsKey(procModel.VariableKey))
                        {
                            ctrl.VariableButton.Tag = procModel.VariableKey;
                        }
                        break;
                    case FileFolderExecType.Archive:
                        ctrl.FileFolderZipArchiveRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        ctrl.FileFolderPath2TextBox.Text = procModel.FileFolderPath2;
                        ctrl.ZipPasswordTextBox.Text = procModel.ArchiveFilePassword;
                        break;
                    case FileFolderExecType.UnArchive:
                        ctrl.FileFolderZipUnArchiveRadio.Checked = true;
                        ctrl.FileFolderPath1TextBox.Text = procModel.FileFolderPath1;
                        ctrl.FileFolderPath2TextBox.Text = procModel.FileFolderPath2;
                        ctrl.ZipPasswordTextBox.Text = procModel.ArchiveFilePassword;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Excelコントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetExcelControl(ProcessModel procModel)
        {
            try
            {
                ExcelControl ctrl = (ExcelControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);

                switch (procModel.ExcelSourceType)
                {
                    case ExcelSourceType.新規作成:
                        ctrl.ExcelSourceNewRadio.Checked = true;
                        break;
                    case ExcelSourceType.既存ファイル:
                        ctrl.ExcelSourceExistsRadio.Checked = true;
                        break;
                }
                ctrl.ExcelLoadFilePathTextBox.Text = procModel.FileFolderPath1;
                ctrl.ExcelSaveFilePathTextBox.Text = procModel.FileFolderPath2;
                ctrl.ExcelJobGrid.Rows.Clear();
                foreach (KeyValuePair<int, ExcelJobModel> pair in procModel.ExcelJobList)
                {
                    ctrl.ExcelJobGrid.Rows.Add();
                    ctrl.ExcelJobGrid.Rows[pair.Key].Cells[ctrl.COL_処理タイプ].Value = pair.Value.FileReadWriteType == FileReadWriteType.Read ? "読み込み" : "書き込み";
                    ctrl.ExcelJobGrid.Rows[pair.Key].Cells[ctrl.COL_シート名].Value = pair.Value.SheetName;
                    ctrl.ExcelJobGrid.Rows[pair.Key].Cells[ctrl.COL_セル名].Value = pair.Value.CellName;
                    ctrl.ExcelJobGrid.Rows[pair.Key].Cells[ctrl.COL_値].Value = pair.Value.Value;
                }
                if(ctrl.ExcelJobGrid.Rows.Count > 1)
                {
                    ctrl.ExcelJobGrid.Rows[ctrl.ExcelJobGrid.Rows.Count - 1].Cells[ctrl.COL_処理タイプ].Value = ctrl.ExcelJobGrid.Rows[ctrl.ExcelJobGrid.Rows.Count - 2].Cells[ctrl.COL_処理タイプ].Value;
                    ctrl.ExcelJobGrid.Rows[ctrl.ExcelJobGrid.Rows.Count - 1].Cells[ctrl.COL_シート名].Value = ctrl.ExcelJobGrid.Rows[ctrl.ExcelJobGrid.Rows.Count - 2].Cells[ctrl.COL_シート名].Value;
                }
                else
                {
                    ctrl.CreateFirstRow();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ダイアログコントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetDialogControl(ProcessModel procModel)
        {
            try
            {
                DialogControl ctrl = (DialogControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                ctrl.StringInputTextBox.Text = procModel.DialogText;
                switch (procModel.DialogType)
                {
                    case MessageBoxIcon.None:
                        ctrl.NormalDialogRadio.Checked = true;
                        break;
                    case MessageBoxIcon.Information:
                        ctrl.InfoDialogRadio.Checked = true;
                        break;
                    case MessageBoxIcon.Warning:
                        ctrl.AlertDialogRadio.Checked = true;
                        break;
                    case MessageBoxIcon.Error:
                        ctrl.ErrorDialogRadio.Checked = true;
                        break;
                }
                switch (procModel.DialogButtonType)
                {
                    case MessageBoxButtons.OK:
                        ctrl.OkDialogRadio.Checked = true;
                        break;
                    case MessageBoxButtons.YesNo:
                        ctrl.YesNoDialogRadio.Checked = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }


        /// <summary>
        /// メール送信コントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetMailSendControl(ProcessModel procModel)
        {
            try
            {
                MailSendControl ctrl = (MailSendControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                ctrl.SenderNameTextBox.Text = procModel.Mail_SenderName;
                ctrl.SenderAddressTextBox.Text = procModel.Mail_SenderAddress;
                ctrl.ReceiverNameTextBox.Text = procModel.Mail_ReceiverName;
                ctrl.ReceiverAddressTextBox.Text = procModel.Mail_ReceiverAddress;
                ctrl.MailTitleTextBox.Text = procModel.Mail_Title;
                ctrl.MailTextBox.Text = procModel.Mail_Text;
                ctrl.MailHostTextBox.Text = procModel.Mail_Host;
                ctrl.PortNoTextBox.Text = procModel.Mail_Port;
                ctrl.PasswordTextBox.Text = procModel.Mail_Password;
                ctrl.UserNameTextBox.Text = procModel.Mail_Username;
                ctrl.MailAttach1TextBox.Text = procModel.Mail_AttachList[0];
                ctrl.MailAttach2TextBox.Text = procModel.Mail_AttachList[1];
                ctrl.MailAttach3TextBox.Text = procModel.Mail_AttachList[2];
                ctrl.MailAttach4TextBox.Text = procModel.Mail_AttachList[3];
                ctrl.MailAttach5TextBox.Text = procModel.Mail_AttachList[4];
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// アプリコントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        private void SetAppControl(ProcessModel procModel)
        {
            try
            {
                AppControl ctrl = (AppControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                ctrl.TimeoutNumericUpDown.Value = procModel.Timeout;
                switch (procModel.AppStartType)
                {
                    case AppStartType.待機する:
                        ctrl.WaitRadio.Checked = true;
                        break;
                    case AppStartType.待機しない:
                        ctrl.NonWaitRadio.Checked = true;
                        break;
                }
                ctrl.ExecutePathTextBox.Text = procModel.AppExecutePath;
                ctrl.ExecuteArgsTextBox.Text = procModel.AppExecuteArgs;
                switch (procModel.AppWindowStyle)
                {
                    case ProcessWindowStyle.Normal:
                        ctrl.NormalStateRadio.Checked = true;
                        break;
                    case ProcessWindowStyle.Hidden:
                        ctrl.HiddenStateRadio.Checked = true;
                        break;
                    case ProcessWindowStyle.Maximized:
                        ctrl.MaxStateRadio.Checked = true;
                        break;
                    case ProcessWindowStyle.Minimized:
                        ctrl.MinStateRadio.Checked = true;
                        break;
                }
                ctrl.ExitCodeUpDown.Value = procModel.AppExitCode;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 変数コントロールに値を設定する
        /// </summary>
        /// <param name="procModel"></param>
        public void SetVariableControl(ProcessModel procModel)
        {
            try
            {
                VariableControl ctrl = (VariableControl)ContainerPanel.Controls[0];
                ctrl.SetBaseValues(procModel);
                switch (procModel.VariableExecType)
                {
                    case VariableExecType.キーボード入力:
                        ctrl.InputFromKeyboardRadio.Checked = true;
                        break;
                    case VariableExecType.ファイル入力:
                        ctrl.InputFromFileRadio.Checked = true;
                        break;
                    case VariableExecType.ファイル出力:
                        ctrl.OutputToFileRadio.Checked = true;
                        break;
                    case VariableExecType.クリップボード入力:
                        ctrl.InputFromClipBoardRadio.Checked = true;
                        break;
                    case VariableExecType.クリップボード出力:
                        ctrl.OutputToClipBoardRadio.Checked = true;
                        break;
                    case VariableExecType.変数比較:
                        ctrl.VariableCompareRadio.Checked = true;
                        break;
                    case VariableExecType.加算減算:
                        ctrl.CalcRadio.Checked = true;
                        break;
                    case VariableExecType.Excel入力:
                        ctrl.ExcelInputRadio.Checked = true;
                        break;
                    case VariableExecType.Excel出力:
                        ctrl.ExcelOutputRadio.Checked = true;
                        break;
                    case VariableExecType.WEBサービス入力:
                        ctrl.InputFromWebRadio.Checked = true;
                        break;
                }
                switch (procModel.FileOutputType)
                {
                    case FileOutputType.上書き:
                        ctrl.OverWriteRadio.Checked = true;
                        break;
                    case FileOutputType.追記:
                        ctrl.AppendRadio.Checked = true;
                        break;
                }
                switch (procModel.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        ctrl.VariableRadio.Checked = true;
                        break;
                    case VariableChoiceType.変数配列:
                        ctrl.ArrayVariableRadio.Checked = true;
                        break;
                }
                switch (procModel.VariableInputTargetType)
                {
                    case InputTargetType.変数:
                        ctrl.VariableTargetRadio.Checked = true;
                        break;
                    case InputTargetType.要素:
                        ctrl.ElementTargetRadio.Checked = true;
                        break;
                }
                switch (procModel.VariableCompareTargetType)
                {
                    case VariableCompareTargetType.変数:
                        ctrl.CompareTargetVariableRadio.Checked = true;
                        break;
                    case VariableCompareTargetType.入力:
                        ctrl.CompareTargetInputRadio.Checked = true;
                        break;
                }
                switch (procModel.ArraySeparateType)
                {
                    case ArraySeparateType.TEXT:
                        ctrl.TextSeparateRadio.Checked = true;
                        break;
                    case ArraySeparateType.CSV:
                        ctrl.CsvSeparateRadio.Checked = true;
                        break;
                }
                switch (procModel.EncodeType)
                {
                    case EncodeType.SHIFT_JIS:
                        ctrl.EncodeSJISRadio.Checked = true;
                        break;
                    case EncodeType.EUC_JP:
                        ctrl.EncodeEUCRadio.Checked = true;
                        break;
                    case EncodeType.UTF8:
                        ctrl.EncodeUTF8Radio.Checked = true;
                        break;
                    case EncodeType.UTF16:
                        ctrl.EncodeUTF16Radio.Checked = true;
                        break;
                }
                ctrl.ExcelSheetNameTextBox.Text = procModel.ExcelSheetName;
                ctrl.RowNoTextBox.Text = procModel.ArrayVariableRowIndex;
                ctrl.ColumnNoTextBox.Text = procModel.ArrayVariableColumnIndex;
                ctrl.CalcCountUpDown.Value = procModel.VariableCalcCount;
                ctrl.CalcButton.Tag = procModel.VariableCalcType;
                ctrl.FileInoutPathTextBox.Text = procModel.VariableInoutFilePath;
                ctrl.VariableValueInputTextBox.Text = procModel.VariableValueText;
                ctrl.ParamGrid.AllowUserToAddRows = false;
                ctrl.ParamGrid.Rows.Clear();
                foreach(var p in procModel.UrlParam)
                {
                    ctrl.ParamGrid.Rows.Add(p.Key, p.Value);
                }
                ctrl.ParamGrid.AllowUserToAddRows = true;

                if (!string.IsNullOrEmpty(procModel.VariableKey) && RootProjectModel.VariableList.ContainsKey(procModel.VariableKey))
                {
                    ctrl.Variable1Button.Tag = procModel.VariableKey;
                }
                if (!string.IsNullOrEmpty(procModel.VariableKey2) && RootProjectModel.VariableList.ContainsKey(procModel.VariableKey2))
                {
                    ctrl.Variable2Button.Tag = procModel.VariableKey2;
                }
                ctrl.ArrayVariableButton.Tag = procModel.ArrayVariableKey;
                ctrl.CompareTypeButton.Tag = procModel.CompareTypeType;
                ctrl.CompareOperatorButton.Tag = procModel.CompareOperatorType;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトモードを設定する
        /// </summary>
        /// <param name="projModel"></param>
        internal void SetProjectMode(ProjectModel projModel, ExecDataType execMode)
        {
            try
            {
                CurrentProjectModel = projModel;
                NodeType = NodeType.Root;
                ProjTextBox.Text = projModel.Name;
                ProjTextBox.Tag = projModel.Name;
                DescriptionTextBox.Text = projModel.Description;
                //プロジェクトControlをセットする
                ProjectControl ctrl = new ProjectControl();
                ctrl.Init(CurrentProjectModel);
                ctrl.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                ctrl.Width = ContainerPanel.Width;
                ctrl.Height = ContainerPanel.Height;
                ctrl.Location = new Point(0, 0);
                ContainerPanel.Controls.Add(ctrl);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 処理タイプラジオのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessTypeRadio_Click(object sender, EventArgs e)
        {
            try
            {
                if(!DetectRadio.Checked && !KeyboardInputRadio.Checked && !MouseInputRadio.Checked
                    && !WaitRadio.Checked && !MailSendRadio.Checked && !AppStartRadio.Checked
                    && !VariableRadio.Checked && !FileFolderRadio.Checked && !DialogRadio.Checked && !ExcelRadio.Checked)
                {
                    ((BaseRadioButton)sender).Checked = true;
                    return;
                }
                if (((BaseRadioButton)sender).Checked) return;
 
                if(SettingInfos.GetInstance().SettingDic[1] == "1")
                {
                    DialogResult result = this.ShowQuestionDialog("処理タイプ変更確認", "処理タイプを変更すると、以前の設定が消去されますが続行しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                DetectRadio.Checked = false;
                KeyboardInputRadio.Checked = false;
                MouseInputRadio.Checked = false;
                WaitRadio.Checked = false;
                MailSendRadio.Checked = false;
                AppStartRadio.Checked = false;
                VariableRadio.Checked = false;
                FileFolderRadio.Checked = false;
                DialogRadio.Checked = false;
                ExcelRadio.Checked = false;
                ((BaseRadioButton)sender).Checked = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクト名テキストのKeyUpイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (NodeType)
                {
                    case NodeType.Child:
                        ProcessModel.Name = ProjTextBox.Text;
                        break;
                    case NodeType.Root:
                        CurrentProjectModel.Name = ProjTextBox.Text;
                        break;
                }
                OnProcessNameChange?.Invoke(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 説明文のKeyUpイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriptionTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                switch (NodeType)
                {
                    case NodeType.Child:
                        ProcessModel.Description = DescriptionTextBox.Text;
                        break;
                    case NodeType.Root:
                        CurrentProjectModel.Description = DescriptionTextBox.Text;
                        break;
                }
                OnProcessNameChange?.Invoke(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
