using Macrobo.Utils.Gui;
using Newtonsoft.Json;
using Macrobo.Components;
using Macrobo.Logics;
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using Macrobo.Views.Controls;
using System.Net;
using System.IO;
using Macrobo.Views.Forms;
using Macrobo.Singleton;
using System.Threading.Tasks;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// 自動実行処理作成フォーム
    /// </summary>
    public partial class ProcessEditForm : BaseForm
    {
        /// <summary>
        /// 起動モード
        /// </summary>
        private ProcessEditFormViewMode ViewMode { get; set; }
        /// <summary>
        /// プロジェクトデータ
        /// </summary>
        private ProjectModel ProjectModel { get; set; }
        /// <summary>
        /// 現在のツリーノードを保持
        /// </summary>
        private TreeNode CurrentNode { get; set; }
        /// <summary>
        /// Shiftキーのダウンフラグ
        /// </summary>
        private bool ShiftKeyDown { get; set; }
        /// <summary>
        /// Controlキーのダウンフラグ
        /// </summary>
        private bool ControlKeyDown { get; set; }
        /// <summary>
        /// Cキーのダウンフラグ
        /// </summary>
        private bool CKeyDown { get; set; }
        /// <summary>
        /// Xキーのダウンフラグ
        /// </summary>
        private bool XKeyDown { get; set; }
        /// <summary>
        /// Sキーのダウンフラグ
        /// </summary>
        private bool SKeyDown { get; set; }
        /// <summary>
        /// Enterキーのダウンフラグ
        /// </summary>
        private bool EnterKeyDown { get; set; }
        /// <summary>
        /// マクロ実行クラス
        /// </summary>
        private MacroExecutor _macroExecutor;
        /// <summary>
        /// マクロ実行スレッド
        /// </summary>
        private Thread _execThread;
        /// <summary>
        /// 再生停止依頼中フラグ
        /// </summary>
        private volatile bool _cancellingFlag = false;
        /// <summary>
        /// 再生中ﾌﾗｸﾞ
        /// </summary>
        private volatile bool _isPlaying = false;
        /// <summary>
        /// キーボード入力イベント処理中フラグ
        /// </summary>
        private volatile bool _keyEventFlag = false;
        /// <summary>
        /// KeyboardHookイベント
        /// </summary>
        private KeyboardHook KeyboardHook;

        /// <summary>
        /// ALT+F4キーを無効にする
        /// </summary>
        private bool _altF4Pressed;
        /// <summary>
        /// ノード又はモジュールのコピーを保持
        /// </summary>
        private object NodeModuleCopyObject { get; set; }
        /// <summary>
        /// 複数のノード又はモジュールのコピーを保持
        /// </summary>
        private List<object> CheckedNodeModuleCopyObject { get; set; }
        /// <summary>
        /// AfterCheck実行フラグ
        /// </summary>
        private bool _onAfterCheckFlag;
        /// <summary>
        /// ノード又はモジュールの削除中ﾌﾗｸﾞ
        /// </summary>
        private bool _nodeModuleRemovingFlag;
        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessEditForm()
        {
            try
            {
                InitializeComponent();
                //キーボードフックイベントを登録
                CreateKeyboardHook();
                //ノードツリー描画イベントを登録
                AddNodeTreeEvent();
                //イメージリストを作成する
                AddNodeTreeImageList();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードツリーへのイメージリストを作成する
        /// </summary>
        private void AddNodeTreeImageList()
        {
            try
            {
                ImageList imgList = new ImageList();
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_project_filled_25);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_module_filled_25);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_search_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_keyboard_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_mouse_filled_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_spinner_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_email_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_windows);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_variable_filled_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_doc_folder_filled_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_chat_bubble_filled_15);
                imgList.Images.Add(global::Macrobo.Properties.Resources.icons8_excel_15);
                ProjectNode.ImageList = imgList;

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードイベントを追加する
        /// </summary>
        private void AddNodeTreeEvent()
        {
            try
            {
                ProjectNode.DrawMode = TreeViewDrawMode.OwnerDrawText;
                ProjectNode.DrawNode += delegate (object o, DrawTreeNodeEventArgs args)
                {
                    List<TreeNode> nodeList = new List<TreeNode>();
                    CreateOneDimensionNodeListAll(ProjectNode.Nodes, nodeList);
                    int no = 0;
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        if (nodeList[i].Equals(args.Node))
                        {
                            no = i + 1;
                            break;
                        }
                    }
                    bool ownerDraw = ((args.State & TreeNodeStates.Selected) == 0);
                    if (args.Node.Bounds.Width == 0 || args.Node.Bounds.Height == 0) return;

                    //選択行をハイライト表示させる
                    Color backColor = !ownerDraw ? Color.FromArgb(255, 0, 64, 64) : Color.FromArgb(255, 255, 255, 255);
                    Color foreColor = !ownerDraw ? Color.White : Color.Black;
                    if (backColor == Color.Empty) backColor = ((TreeView)o).BackColor;
                    if (foreColor == Color.Empty) foreColor = ((TreeView)o).ForeColor;

                    string addNo = "[" + string.Format("{0:000}", no) + "]";
                    Size addNoSize = TextRenderer.MeasureText(addNo, args.Node.NodeFont ?? ((BaseTreeView)o).Font);

                    using (Brush b = new SolidBrush(Color.White))
                    {
                        args.Graphics.FillRectangle(b, new Rectangle(args.Node.Bounds.X, args.Node.Bounds.Y - 1, ProjectNode.Width, args.Node.Bounds.Height + 1));
                    }
                    using (Brush b = new SolidBrush(backColor))
                    {
                        args.Graphics.FillRectangle(b, new Rectangle(args.Node.Bounds.X, args.Node.Bounds.Y, args.Node.Bounds.Width + addNoSize.Width, args.Node.Bounds.Height - 1));
                    }
                    using (Brush b = new SolidBrush(foreColor))
                    {
                        args.Graphics.DrawString(
                            addNo + args.Node.Text,
                            args.Node.NodeFont ?? ((BaseTreeView)o).Font,
                            b,
                            args.Bounds.X, args.Bounds.Y + 2);
                    }
                };
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キーボードフックイベントを作成する
        /// </summary>
        private void CreateKeyboardHook()
        {
            try
            {
                if (KeyboardHook != null)
                {
                    KeyboardHook.Dispose();
                }
                KeyboardHook = new KeyboardHook();
                KeyboardHook.KeyboardHooked += KeyboardHook_KeyboardHooked;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init(ProcessEditFormViewMode viewMode, ProjectModel model)
        {
            try
            {
                ProjectModel = model;
                ViewMode = viewMode;
                switch (ViewMode)
                {
                    case ProcessEditFormViewMode.新規プロジェクト:
                        this.Text = "Macrobo - 新規プロジェクト作成";
                        break;
                    case ProcessEditFormViewMode.プロジェクト修正:
                        this.Text = "Macrobo - プロジェクト修正";
                        break;
                    case ProcessEditFormViewMode.新規モジュール:
                        this.Text = "Macrobo - 新規モジュール作成";
                        ModuleDropDownButton.Visible = false;
                        TopToolTipSeparator4.Visible = false;
                        break;
                    case ProcessEditFormViewMode.モジュール修正:
                        this.Text = "Macrobo - 新規モジュール修正";
                        ModuleDropDownButton.Visible = false;
                        TopToolTipSeparator4.Visible = false;
                        break;
                }
                TreeNode node = ProjectModel.CreateTreeNode();
                ProjectNode.Nodes.Add(node);
                ProjectNode.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ツリーの選択後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string guiId = GuiUtil.GetInstance().NewId();
                GuiUtil.GetInstance().BeginUpdate(MainHorizontalSplitContainer, guiId);
                SetNodeView();
                CurrentNode = e.Node;
                GuiUtil.GetInstance().EndUpdate(guiId);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ツリーの選択前イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                //ノード・モジュールの削除実行中の場合は、イベントをキャンセルする
                if (_nodeModuleRemovingFlag)
                {
                    return;
                }
                if (!SaveNodeView())
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードを保存する
        /// </summary>
        /// <returns></returns>
        private bool SaveNodeView()
        {
            try
            {
                if (MainHorizontalSplitContainer.Panel2.Controls.Count == 0) return true;
                NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                switch (ctrl.NodeType)
                {
                    case  NodeType.Root:
                        if (!SaveRootNodeView())
                        {
                            return false;
                        }
                        break;
                    case NodeType.Child:
                        if (!SaveChildNodeView())
                        {
                            return false;
                        }
                        break;
                }
                //保存時に、プロセスが存在しない場合は、終了するをセットする
                List<ProcessModel> modelList = ProjectModel.GetOneDimensionProcessModelList();
                foreach (var model in modelList)
                {
                    if (model.NextProcess == null || model.NextProcess.Name != StringValue.END_PROCESS && !modelList.Exists(a => a.Equals(model.NextProcess)))
                    {
                        model.NextProcess = ProcessModel.GetEndProcessModel();
                    }
                    if (model.ErrorProcess == null || model.ErrorProcess.Name != StringValue.END_PROCESS_ERROR && !modelList.Exists(a => a.Equals(model.ErrorProcess)))
                    {
                        model.ErrorProcess = ProcessModel.GetErrorProcessModel();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクト情報を保存する
        /// </summary>
        /// <returns></returns>
        private bool SaveRootNodeView()
        {
            try
            {
                NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                ProjectModel projModel = ctrl.CurrentProjectModel;
                ProjectControl proCtrl = (ProjectControl)ctrl.ContainerPanel.Controls[0];
                //入力コントロールより値をモデルにセットする
                projModel.MouseSpeed = (int)proCtrl.MouseSpeedUpDown.Value;
                projModel.ViewLogType = (proCtrl.LogViewRadio.Checked) ? ViewLogType.表示する : ViewLogType.表示しない;
                projModel.ExecCalendarId = ((CalendarModel)proCtrl.CalendarComboBox.SelectedItem).CalendarId;
                projModel.VariableList.Clear();
                projModel.ArrayVariableList.Clear();
                proCtrl.VariableGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                proCtrl.ArrayVariableGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in proCtrl.VariableGrid.Rows)
                {
                    projModel.VariableList.Add("" + row.Cells[proCtrl.COL_変数].Value, new VariableModel( "" + row.Cells[proCtrl.COL_値].Value, "" + row.Cells[proCtrl.COL_説明].Value ));
                }
                foreach (DataGridViewRow row in proCtrl.ArrayVariableGrid.Rows)
                {
                    ArrayVariableModel model = new ArrayVariableModel();
                    model.Description = "" + row.Cells[proCtrl.COL_配列説明].Value;
                    projModel.ArrayVariableList.Add("" + row.Cells[proCtrl.COL_変数配列].Value, model);
                }
                if (string.IsNullOrEmpty(ctrl.ProjTextBox.Text.Trim()))
                {
                    ctrl.ProjTextBox.Text = (string)ctrl.ProjTextBox.Tag;
                    string nameStr = "プロジェクト";
                    switch (projModel.ExecDataType)
                    {
                        case ExecDataType.MACRO:
                            nameStr = "モジュール";
                            break;
                    }
                    ProjectNode.SelectedNode.Text = ctrl.ProjTextBox.Text;
                    this.ShowErrorDialog(nameStr + "名エラー", nameStr + "名は入力必須項目です。");
                    return false;
                }
                if (CurrentNode == null) return false;
                CurrentNode.Text = ctrl.ProjTextBox.Text;
                projModel.Name = ctrl.ProjTextBox.Text;
                projModel.Description = ctrl.DescriptionTextBox.Text;
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノード情報を保存する
        /// </summary>
        /// <returns></returns>
        private bool SaveChildNodeView()
        {
            try
            {
                NodeControl nodtCtrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                ProcessModel procModel = nodtCtrl.ProcessModel;
                if (string.IsNullOrEmpty(nodtCtrl.ProjTextBox.Text.Trim()))
                {
                    nodtCtrl.ProjTextBox.Text = (string)nodtCtrl.ProjTextBox.Tag;
                    ProjectNode.SelectedNode.Text = nodtCtrl.ProjTextBox.Text;
                    this.ShowErrorDialog("処理名エラー", "処理名は入力必須項目です。");
                    return false;
                }
                if (nodtCtrl.ProjTextBox.Text.Trim() == StringValue.END_PROCESS)
                {
                    nodtCtrl.ProjTextBox.Text = (string)nodtCtrl.ProjTextBox.Tag;
                    ProjectNode.SelectedNode.Text = nodtCtrl.ProjTextBox.Text;
                    this.ShowErrorDialog("処理名エラー", "処理名[" + StringValue.END_PROCESS + "]はシステムで予約されています。\r\n別名を設定してください。");
                    return false;
                }

                if (nodtCtrl.ProjTextBox.Text.Trim() == StringValue.END_PROCESS_ERROR)
                {
                    nodtCtrl.ProjTextBox.Text = (string)nodtCtrl.ProjTextBox.Tag;
                    ProjectNode.SelectedNode.Text = nodtCtrl.ProjTextBox.Text;
                    this.ShowErrorDialog("処理名エラー", "処理名[" + StringValue.END_PROCESS_ERROR + "]はシステムで予約されています。\r\n別名を設定してください。");
                    return false;
                }

                if (CurrentNode == null) return false;

                CurrentNode.Text = nodtCtrl.ProjTextBox.Text;
                procModel.Name = nodtCtrl.ProjTextBox.Text;
                procModel.Description = nodtCtrl.DescriptionTextBox.Text;
                procModel.ProcessType = nodtCtrl.ProcessType;
                
                switch (procModel.ProcessType)
                {
                    case ProcessType.検出:
                        SetDetectControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.キーボード入力:
                        SetKeyboardControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.マウス入力:
                        SetMouseControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.待機:
                        SetWaitControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.メール送信:
                        SetMailSendControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.アプリ実行:
                        SetAppControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.変数:
                        SetVariableControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.ファイルフォルダー処理:
                        SetFileFolderControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.ダイアログ:
                        SetDialogControlModel(procModel, nodtCtrl);
                        break;
                    case ProcessType.Excel:
                        SetExcelControlModel(procModel, nodtCtrl);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ExcelコントロールのモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetExcelControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                ExcelControl ctrl = (ExcelControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);

                if (ctrl.ExcelSourceNewRadio.Checked)
                {
                    procModel.ExcelSourceType = ExcelSourceType.新規作成;
                }
                else
                {
                    procModel.ExcelSourceType = ExcelSourceType.既存ファイル;
                }
                procModel.FileFolderPath1 = ctrl.ExcelLoadFilePathTextBox.Text.Trim();
                procModel.FileFolderPath2 = ctrl.ExcelSaveFilePathTextBox.Text.Trim();

                List<ExcelJobModel> modelList = new List<ExcelJobModel>();
                foreach(DataGridViewRow row in ctrl.ExcelJobGrid.Rows)
                {
                    string execType = "" + row.Cells[ctrl.COL_処理タイプ].Value;
                    string sheetName = ("" + row.Cells[ctrl.COL_シート名].Value).Trim(); ;
                    string cellName = ("" + row.Cells[ctrl.COL_セル名].Value).Trim(); ;
                    string value = ("" + row.Cells[ctrl.COL_値].Value).Trim(); ;
                    if(string.IsNullOrEmpty(sheetName) || string.IsNullOrEmpty(cellName) || string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    modelList.Add(new ExcelJobModel(execType=="読み込み" ? FileReadWriteType.Read: FileReadWriteType.Write, sheetName, cellName, value));
                }

                procModel.ExcelJobList.Clear();
                for(int i = 0; i < modelList.Count; i++)
                {
                    procModel.ExcelJobList.Add(i, modelList[i]);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ダイアログコントロールのモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetDialogControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                DialogControl ctrl = (DialogControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                if (ctrl.NormalDialogRadio.Checked)
                {
                    procModel.DialogType = MessageBoxIcon.None;
                }
                if (ctrl.InfoDialogRadio.Checked)
                {
                    procModel.DialogType = MessageBoxIcon.Information;
                }
                if (ctrl.AlertDialogRadio.Checked)
                {
                    procModel.DialogType = MessageBoxIcon.Exclamation;
                }
                if (ctrl.ErrorDialogRadio.Checked)
                {
                    procModel.DialogType = MessageBoxIcon.Error;
                }
                if (ctrl.OkDialogRadio.Checked)
                {
                    procModel.DialogButtonType = MessageBoxButtons.OK;
                }
                if (ctrl.YesNoDialogRadio.Checked)
                {
                    procModel.DialogButtonType = MessageBoxButtons.YesNo;
                }
                procModel.DialogText = ctrl.StringInputTextBox.Text.Trim();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルフォルダーコントロールのモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetFileFolderControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                FileFolderControl ctrl = (FileFolderControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                if (ctrl.FileActionRadio.Checked)
                {
                    procModel.FileFolderActionType = FileFolderActionType.ファイル;
                }
                if (ctrl.FolderActionRadio.Checked)
                {
                    procModel.FileFolderActionType = FileFolderActionType.フォルダ;
                }
                if (ctrl.FileFolderDetectRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.Detect;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                    procModel.Timeout = (int)ctrl.TimeoutNumericUpDown.Value;
                }
                if (ctrl.FileFolderCreateRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.Create;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                }
                if (ctrl.FileFolderRemoveRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.Remove;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                }
                if (ctrl.FileFolderMoveRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.Move;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                    procModel.FileFolderPath2 = ctrl.FileFolderPath2TextBox.Text.Trim();
                }
                if (ctrl.FileFolderCopyRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.Copy;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                    procModel.FileFolderPath2 = ctrl.FileFolderPath2TextBox.Text.Trim();
                }
                if (ctrl.FileFolderSaveUdateRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.SaveUdate;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                    procModel.VariableKey = (string)ctrl.VariableButton.Tag;
                }
                if (ctrl.FileFolderZipArchiveRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.Archive;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                    procModel.FileFolderPath2 = ctrl.FileFolderPath2TextBox.Text.Trim();
                    procModel.ArchiveFilePassword = ctrl.ZipPasswordTextBox.Text;
                }
                if (ctrl.FileFolderZipUnArchiveRadio.Checked)
                {
                    procModel.FileFolderExecType = FileFolderExecType.UnArchive;
                    procModel.FileFolderPath1 = ctrl.FileFolderPath1TextBox.Text.Trim();
                    procModel.FileFolderPath2 = ctrl.FileFolderPath2TextBox.Text.Trim();
                    procModel.ArchiveFilePassword = ctrl.ZipPasswordTextBox.Text;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数コントロールのモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetVariableControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                VariableControl ctrl = (VariableControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                if (ctrl.InputFromKeyboardRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.キーボード入力;
                }
                if (ctrl.InputFromFileRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.ファイル入力;
                }
                if (ctrl.OutputToFileRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.ファイル出力;
                }
                if (ctrl.InputFromClipBoardRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.クリップボード入力;
                }
                if (ctrl.OutputToClipBoardRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.クリップボード出力;
                }
                if (ctrl.VariableCompareRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.変数比較;
                }
                if (ctrl.CalcRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.加算減算;
                }
                if (ctrl.ExcelInputRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.Excel入力;
                }
                if (ctrl.ExcelOutputRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.Excel出力;
                }
                if (ctrl.InputFromWebRadio.Checked)
                {
                    procModel.VariableExecType = VariableExecType.WEBサービス入力;
                }
                if (ctrl.OverWriteRadio.Checked)
                {
                    procModel.FileOutputType = FileOutputType.上書き;
                }else{
                    procModel.FileOutputType = FileOutputType.追記;
                }
                if (ctrl.VariableRadio.Checked)
                {
                    procModel.VariableChoiceType = VariableChoiceType.単一変数;
                }
                else
                {
                    procModel.VariableChoiceType = VariableChoiceType.変数配列;
                }
                if (ctrl.VariableTargetRadio.Checked)
                {
                    procModel.VariableInputTargetType = InputTargetType.変数;
                }
                else
                {
                    procModel.VariableInputTargetType = InputTargetType.要素;
                }
                if (ctrl.CompareTargetVariableRadio.Checked)
                {
                    procModel.VariableCompareTargetType = VariableCompareTargetType.変数;
                }
                else
                {
                    procModel.VariableCompareTargetType = VariableCompareTargetType.入力;
                }
                if (ctrl.TextSeparateRadio.Checked)
                {
                    procModel.ArraySeparateType = ArraySeparateType.TEXT;
                }
                else
                {
                    procModel.ArraySeparateType = ArraySeparateType.CSV;
                }
                if (ctrl.EncodeSJISRadio.Checked)
                {
                    procModel.EncodeType = EncodeType.SHIFT_JIS;
                }
                else if (ctrl.EncodeEUCRadio.Checked)
                {
                    procModel.EncodeType = EncodeType.EUC_JP;
                }
                else if (ctrl.EncodeUTF8Radio.Checked)
                {
                    procModel.EncodeType = EncodeType.UTF8;
                }
                else if (ctrl.EncodeUTF16Radio.Checked)
                {
                    procModel.EncodeType = EncodeType.UTF16;
                }
                procModel.UrlParam.Clear();
                foreach (DataGridViewRow row in ctrl.ParamGrid.Rows)
                {
                    string key = "" + row.Cells[0].Value;
                    string value = "" + row.Cells[1].Value;
                    if(!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    {
                        procModel.UrlParam.Add(key, value);
                    }
                }
                procModel.ExcelSheetName = ctrl.ExcelSheetNameTextBox.Text.Trim();
                procModel.ArrayVariableColumnIndex = ctrl.ColumnNoTextBox.Text.Trim();
                procModel.ArrayVariableRowIndex = ctrl.RowNoTextBox.Text.Trim();
                procModel.VariableCalcType = (VariableCalcType)ctrl.CalcButton.Tag;
                procModel.VariableCalcCount = (int)ctrl.CalcCountUpDown.Value;
                procModel.VariableInoutFilePath = ctrl.FileInoutPathTextBox.Text;
                procModel.VariableValueText = ctrl.VariableValueInputTextBox.Text;
                procModel.VariableKey = (string)ctrl.Variable1Button.Tag;
                procModel.VariableKey2 = (string)ctrl.Variable2Button.Tag;
                procModel.ArrayVariableKey = (string)ctrl.ArrayVariableButton.Tag;
                procModel.CompareTypeType = (CompareTypeType)ctrl.CompareTypeButton.Tag;
                procModel.CompareOperatorType = (CompareOperatorType)ctrl.CompareOperatorButton.Tag;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// AppControlモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetAppControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                AppControl ctrl = (AppControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                procModel.Timeout = (int)ctrl.TimeoutNumericUpDown.Value;
                procModel.AppExitCode = (int)ctrl.ExitCodeUpDown.Value;
                procModel.AppStartType = ctrl.WaitRadio.Checked ? AppStartType.待機する : AppStartType.待機しない;
                procModel.AppExecutePath = ctrl.ExecutePathTextBox.Text;
                procModel.AppExecuteArgs = ctrl.ExecuteArgsTextBox.Text.Trim();

                if (ctrl.NormalStateRadio.Checked)
                {
                    procModel.AppWindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                }
                if (ctrl.HiddenStateRadio.Checked)
                {
                    procModel.AppWindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                }
                if (ctrl.MaxStateRadio.Checked)
                {
                    procModel.AppWindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                }
                if (ctrl.MinStateRadio.Checked)
                {
                    procModel.AppWindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// メール送信コントロールモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetMailSendControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                MailSendControl ctrl = (MailSendControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                procModel.Mail_Host = ctrl.MailHostTextBox.Text;
                procModel.Mail_SenderName = ctrl.SenderNameTextBox.Text;
                procModel.Mail_SenderAddress = ctrl.SenderAddressTextBox.Text;
                procModel.Mail_ReceiverName = ctrl.ReceiverNameTextBox.Text;
                procModel.Mail_ReceiverAddress = ctrl.ReceiverAddressTextBox.Text;
                procModel.Mail_Title = ctrl.MailTitleTextBox.Text;
                procModel.Mail_Text = ctrl.MailTextBox.Text;
                procModel.Mail_Port = ctrl.PortNoTextBox.Text;
                procModel.Mail_Password = ctrl.PasswordTextBox.Text;
                procModel.Mail_Username = ctrl.UserNameTextBox.Text;
                procModel.Mail_AttachList[0] = ctrl.MailAttach1TextBox.Text;
                procModel.Mail_AttachList[1] = ctrl.MailAttach2TextBox.Text;
                procModel.Mail_AttachList[2] = ctrl.MailAttach3TextBox.Text;
                procModel.Mail_AttachList[3] = ctrl.MailAttach4TextBox.Text;
                procModel.Mail_AttachList[4] = ctrl.MailAttach5TextBox.Text;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// WaitControlモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetWaitControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                WaitControl ctrl = (WaitControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                procModel.Timeout = (int)ctrl.TimeoutNumericUpDown.Value;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// マウスコントロールモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetMouseControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                MouseControl ctrl = (MouseControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                procModel.ScrollSpeed = (int)ctrl.ScrollSpeedUpDown.Value;
                procModel.ScrollAmount = (int)ctrl.ScrollAmountUpDown.Value;
                if (ctrl.MouseClickRadio.Checked)
                {
                    procModel.MouseExecType = MouseInputType.クリック;
                }
                if (ctrl.MouseMoveRadio.Checked)
                {
                    procModel.MouseExecType = MouseInputType.移動;
                }
                if (ctrl.MouseDragDropRadio.Checked)
                {
                    procModel.MouseExecType = MouseInputType.ドラッグドロップ;
                }
                if (ctrl.MouseWheelRadio.Checked)
                {
                    procModel.MouseExecType = MouseInputType.ホイール操作;
                }
                procModel.MouseClickDetectType = ctrl.ImageDetectRadio.Checked ? MouseInputDetectType.画像検出 : MouseInputDetectType.座標検出;
                procModel.Timeout = (int)ctrl.TimeoutNumericUpDown.Value;
                procModel.ScrollCount = (int)ctrl.ScrollCountUpDown.Value;
                switch (procModel.MouseExecType)
                {
                    case MouseInputType.クリック:
                        switch (procModel.MouseClickDetectType)
                        {
                            case MouseInputDetectType.画像検出:
                                for (int i = 0; i < ctrl.ImageList.Count; i++)
                                {
                                    procModel.CaptureImage[i] = null;
                                    if (ctrl.ImageList[i] != null)
                                    {
                                        procModel.CaptureImage[i] = ctrl.ImageList[i];
                                    }
                                }
                                break;
                        }
                        break;
                    case MouseInputType.移動:
                        switch (procModel.MouseClickDetectType)
                        {
                            case MouseInputDetectType.画像検出:
                                for (int i = 0; i < ctrl.ImageList.Count; i++)
                                {
                                    procModel.CaptureImage[i] = null;
                                    if (ctrl.ImageList[i] != null)
                                    {
                                        procModel.CaptureImage[i] = ctrl.ImageList[i];
                                    }
                                }
                                break;
                        }
                        break;
                    case MouseInputType.ドラッグドロップ:
                        switch (procModel.MouseClickDetectType)
                        {
                            case MouseInputDetectType.画像検出:
                                procModel.CaptureImage[0] = ctrl.ImageList[0];
                                procModel.CaptureImage[1] = ctrl.ImageList[1];
                                break;
                            case MouseInputDetectType.座標検出:
                                procModel.CaptureImage[0] = ctrl.ImageList[0];
                                break;
                        }
                        break;
                }

                procModel.KeyboardInput = ctrl.StringInputTextBox.Text;
                procModel.KeyboardInputKeycodes = null;
                if (!string.IsNullOrEmpty(procModel.KeyboardInput))
                {
                    procModel.KeyboardInputKeycodes = (List<Keys>)ctrl.StringInputTextBox.Tag;
                }

                if (ctrl.DetectAreaScreenRadio.Checked)
                {
                    procModel.DetectAreaType = DetectAreaType.SCREEN;
                }
                else
                {
                    procModel.DetectAreaType = DetectAreaType.CHOICE;
                }
                procModel.DetectAreaSX = ctrl.DetectAreaSXTextBox.Text;
                procModel.DetectAreaSY = ctrl.DetectAreaSYTextBox.Text;
                procModel.DetectAreaEX = ctrl.DetectAreaEXTextBox.Text;
                procModel.DetectAreaEY = ctrl.DetectAreaEYTextBox.Text;

                procModel.PointType = (PointType)ctrl.PointTypeButton.Tag;
                procModel.ClickCount = ctrl.ClickCountUpDown.Value;
                procModel.ClickPosition = (MouseClickPosition)ctrl.ClickPosButton.Tag;
                int.TryParse(ctrl.OffsetXTextBox.Text, out int pointX);
                procModel.OffsetXPoint = pointX;
                int.TryParse(ctrl.OffsetYTextBox.Text, out int pointY);
                procModel.OffsetYPoint = pointY;
                procModel.ScrollType = (ScrollType)ctrl.ScrollButton.Tag;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キーボードコントロールのモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetKeyboardControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                KeyboardInputControl ctrl = (KeyboardInputControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                procModel.KeyboardInputType = ctrl.KeyboardInputRadio.Checked ? KeyboardInputType.KEYBOARD : KeyboardInputType.STRING;
                procModel.KeyboardInput = ctrl.StringInputTextBox.Text;
                if (ctrl.StringInputTextBox.Tag != null)
                {
                    procModel.KeyboardInputKeycodes = (List<Keys>)ctrl.StringInputTextBox.Tag;
                }
                switch (procModel.KeyboardInputType)
                {
                    case KeyboardInputType.KEYBOARD:
                        procModel.VariableKey = "";
                        procModel.VariableValueText = "";
                        break;
                    case KeyboardInputType.STRING:
                        procModel.VariableKey = "";
                        if ((string)ctrl.VariableButton.Tag != StringValue.VARIABLE_未設定)
                        {
                            procModel.VariableKey = (string)ctrl.VariableButton.Tag;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 検出コントロールのモデルをProcessModelへセットする
        /// </summary>
        /// <param name="procModel"></param>
        /// <param name="nodtCtrl"></param>
        private void SetDetectControlModel(ProcessModel procModel, NodeControl nodtCtrl)
        {
            try
            {
                DetectControl ctrl = (DetectControl)nodtCtrl.ContainerPanel.Controls[0];
                ctrl.GetBaseValues(procModel);
                if (ctrl.ImageDetectRadio.Checked)
                {
                    procModel.DetectType = DetectType.画像;
                }
                if (ctrl.FileDetectRadio.Checked)
                {
                    procModel.DetectType = DetectType.ファイル;
                }
                procModel.DetectFolderPath = "";
                procModel.DetectFileName = "";
                switch (procModel.DetectType)
                {
                    case DetectType.画像:
                        for(int i = 0; i < ctrl.ImageList.Count; i++)
                        {
                            procModel.CaptureImage[i] = null;
                            if (ctrl.ImageList[i] != null)
                            {
                                procModel.CaptureImage[i] = ctrl.ImageList[i];
                            }
                        }
                        break;
                    case DetectType.ファイル:
                        procModel.DetectFolderPath = ctrl.FolderPathTextBox.Text.Trim();
                        procModel.DetectFileName = ctrl.FileNameTextBox.Text.Trim();
                        break;
                }
                if (ctrl.MatchRadio.Checked)
                {
                    procModel.FileDetectType = FileDetectType.完全一致;
                }
                if (ctrl.FMatchRadio.Checked)
                {
                    procModel.FileDetectType = FileDetectType.前方一致;
                }
                if (ctrl.BMatchRadio.Checked)
                {
                    procModel.FileDetectType = FileDetectType.後方一致;
                }
                if (ctrl.PMatchRadio.Checked)
                {
                    procModel.FileDetectType = FileDetectType.部分一致;
                }
                if (ctrl.FileStateExistsRadio.Checked)
                {
                    procModel.DetectFileModeType = DetectFileModeType.Exists;
                }
                if (ctrl.FileStateReadableRadio.Checked)
                {
                    procModel.DetectFileModeType = DetectFileModeType.Readable;
                }
                if (ctrl.FileStateWritableRadio.Checked)
                {
                    procModel.DetectFileModeType = DetectFileModeType.Writable;
                }
                procModel.VariableKey = (string)ctrl.VariableButton.Tag;
                procModel.ScrollSpeed = (int)ctrl.ScrollSpeedUpDown.Value;
                procModel.ScrollAmount = (int)ctrl.ScrollAmountUpDown.Value;
                procModel.Timeout = (int)ctrl.TimeoutNumericUpDown.Value;

                procModel.ScrollType = (ScrollType)ctrl.ScrollButton.Tag;
                procModel.MoveMouseType = (MoveMouseType)ctrl.MoveMouseButton.Tag;

                if (ctrl.DetectAreaScreenRadio.Checked)
                {
                    procModel.DetectAreaType = DetectAreaType.SCREEN;
                }
                else
                {
                    procModel.DetectAreaType = DetectAreaType.CHOICE;
                }
                procModel.DetectAreaSX = ctrl.DetectAreaSXTextBox.Text;
                procModel.DetectAreaSY = ctrl.DetectAreaSYTextBox.Text;
                procModel.DetectAreaEX = ctrl.DetectAreaEXTextBox.Text;
                procModel.DetectAreaEY = ctrl.DetectAreaEYTextBox.Text;

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ルートノード選択時イベント
        /// </summary>
        private void SetNodeView()
        {
            try
            {
                AddVariableButton.Enabled = false;
                RemoveVariableButton.Enabled = false;
                AddArrayVariableButton.Enabled = false;
                RemoveArrayVariableButton.Enabled = false;
                AddNodeButton.Enabled = false;
                RemoveNodeButton.Enabled = false;
                AddModuleButton.Enabled = false;
                RemoveModuleButton.Enabled = false;
                switch (this.ProjectModel.ExecDataType)
                {
                    case ExecDataType.MACRO:
                        AddModuleButton.Visible = false;
                        RemoveModuleButton.Visible = false;
                        TopToolTipSeparator4.Visible = false;
                        break;
                }
                MainHorizontalSplitContainer.Panel2.ClearControls();
                NodeControl ctrl = new NodeControl();
                ctrl.OnProcessTypeChange = OnProcessTypeChange;
                ctrl.OnProcessNameChange = OnProcessNameChange;
                ctrl.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                ctrl.Width = MainHorizontalSplitContainer.Panel2.Width;
                ctrl.Height = MainHorizontalSplitContainer.Panel2.Height;
                ctrl.Location = new Point(0, 0);

                //ルートノード
                if (ProjectNode.SelectedNode.Tag is ProjectModel && ProjectNode.SelectedNode.Parent == null)
                {
                    ctrl.SetProjectMode((ProjectModel)ProjectNode.SelectedNode.Tag, ExecDataType.PROJECT);
                    AddVariableButton.Enabled = true;
                    RemoveVariableButton.Enabled = true;
                    AddArrayVariableButton.Enabled = true;
                    RemoveArrayVariableButton.Enabled = true;
                    AddNodeButton.Enabled = true;
                    AddModuleButton.Enabled = true;
                }
                else
                {
                    //モジュールルートノード
                    if (ProjectNode.SelectedNode.Tag is ProjectModel)
                    {
                        ctrl.SetProjectMode((ProjectModel)ProjectNode.SelectedNode.Tag, ExecDataType.MACRO);
                        RemoveModuleButton.Enabled = true;
                    }
                    else
                    {
                        ProjectModel parentModel = (ProjectModel)ProjectNode.SelectedNode.Parent.Tag;
                        ctrl.SetNodeMode(ProjectModel, parentModel, (ProcessModel)ProjectNode.SelectedNode.Tag);
                        if (ctrl.ProcessModel.ProcessType == ProcessType.None)
                        {
                            ctrl.DetectRadio.Checked = true;
                        }
                        RemoveNodeButton.Enabled = true;
                    }

                    AddNodeButton.Enabled = true;
                    if(ProjectNode.SelectedNode.Parent.Tag.Equals(ProjectModel))
                    {
                        AddModuleButton.Enabled = true;
                    }
                }
                ctrl.TreeNode = ProjectNode.SelectedNode;
                MainHorizontalSplitContainer.Panel2.Controls.Add(ctrl);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロセスタイプの変更イベント
        /// </summary>
        /// <param name="type"></param>
        private void OnProcessTypeChange(ProcessType type)
        {
            try
            {
                ProjectNode.SelectedNode.ImageIndex = ProjectModel.GetImageIndex(type);
                ProjectNode.SelectedNode.SelectedImageIndex = ProjectNode.SelectedNode.ImageIndex;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロセス名変更イベント
        /// </summary>
        /// <param name="ctrl"></param>
        private void OnProcessNameChange(NodeControl ctrl)
        {
            try
            {
                ProjectNode.SelectedNode.Text = ctrl.ProjTextBox.Text;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キー入力をクリアする
        /// </summary>
        private void ClearKeyInput()
        {
            try
            {
                ShiftKeyDown = false;
                ControlKeyDown = false;
                CKeyDown = false;
                XKeyDown = false;
                SKeyDown = false;
                EnterKeyDown = false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
    }
        /// <summary>
        /// WindowsのKeyboard入力を取得する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardHook_KeyboardHooked(object sender, Macrobo.Utils.Gui.KeyboardHookedEventArgs e)
        {
            try
            {
                bool childControlResult = false;
                //ProcessControlへキーボードフックイベントを流す
                if(MainHorizontalSplitContainer.Panel2.Controls.Count > 0)
                {
                    NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                    if(ctrl.ContainerPanel.Controls.Count > 0 && ctrl.ContainerPanel.Controls[0] is ProcessBaseControl)
                    {
                        ((ProcessBaseControl)ctrl.ContainerPanel.Controls[0]).OnKeyboardHook?.Invoke(sender, e, out childControlResult);
                    }
                }
                if (childControlResult) return;
                SetKeyInputFlag(e);
                //KeyboardHookイベント実行中フラグがTrueの場合、処理しない
                if (_cancellingFlag || _keyEventFlag)
                {
                    ClearKeyInput();
                    return;
                }
                _keyEventFlag = true;
                if (ActionCapture())
                {
                    ClearKeyInput();
                    _keyEventFlag = false;
                    return;
                }
                if (ActionPlayStop())
                {
                    ClearKeyInput();
                    _keyEventFlag = false;
                    return;
                }
                if (ActionSave())
                {
                    ClearKeyInput();
                    _keyEventFlag = false;
                    return;
                }
                if (ActionPlay())
                {
                    ClearKeyInput();
                    _keyEventFlag = false;
                    return;
                }
                _keyEventFlag = false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 保存を行う
        /// </summary>
        private bool ActionSave()
        {
            try
            {
                if (ControlKeyDown && SKeyDown && !ShiftKeyDown)
                {
                    if (IsPlaying()) return true;
                    if (!this.ContainsFocus) return true;
                    ExecuteSave(ProjectModel, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 再生を実行する
        /// </summary>
        /// <returns></returns>
        private bool ActionPlay()
        {
            try
            {
                //Control+Enterにて実行する
                if(ControlKeyDown && EnterKeyDown)
                {
                    if (IsPlaying()) return true;
                    PlayMacro(false, MacroExecMode.ALL);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マクロ実行中の場合停止させる(強制終了)
        /// </summary>
        private bool ActionPlayStop()
        {
            try
            {
                if (ShiftKeyDown && ControlKeyDown && SKeyDown)
                {
                    if (IsPlaying())
                    {
                        _macroExecutor._stopFlag = true;
                        while(_execThread.IsAlive)
                        {
                            _cancellingFlag = true;
                            Thread.Sleep(100);
                            Application.DoEvents();
                        }
                        _cancellingFlag = false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キーイベントからキャプチャを行う
        /// </summary>
        private bool ActionCapture()
        {
            try
            {
                if ((ShiftKeyDown && ControlKeyDown && CKeyDown) || (ShiftKeyDown && ControlKeyDown && XKeyDown))
                {
                    if (IsPlaying()) return true;
                    NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                    switch (ctrl.NodeType)
                    {
                        case NodeType.Child:
                            switch (ctrl.ProcessType)
                            {
                                case ProcessType.検出: //画像検索
                                    if (CKeyDown)
                                    {
                                        DetectControl imageSearchCtrl = (DetectControl)ctrl.ContainerPanel.Controls[0];
                                        imageSearchCtrl.ExecuteCapture();
                                    }
                                    break;
                                case ProcessType.キーボード入力: //キーボード入力
                                    break;
                                case ProcessType.マウス入力: //マウスクリック
                                    if (CKeyDown)
                                    {
                                        MouseControl clickCtrl = (MouseControl)ctrl.ContainerPanel.Controls[0];
                                        clickCtrl.ExecuteCapture(0);
                                    }
                                    if (XKeyDown)
                                    {
                                        MouseControl clickCtrl = (MouseControl)ctrl.ContainerPanel.Controls[0];
                                        clickCtrl.ExecuteCapture(1);
                                    }
                                    break;

                            }
                            break;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// マクロ実行中判定
        /// </summary>
        /// <returns></returns>
        private bool IsPlaying()
        {
            try
            {
                return _isPlaying;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キーダウン/アップフラグをセットする
        /// </summary>
        /// <param name="e"></param>
        private void SetKeyInputFlag(KeyboardHookedEventArgs e)
        {
            try
            {
                if (e.KeyCode.ToString() == "LShiftKey" || e.KeyCode.ToString() == "RShiftKey")
                {
                    ShiftKeyDown = e.UpDown == KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "LControlKey" || e.KeyCode.ToString() == "RControlKey")
                {
                    ControlKeyDown = e.UpDown == KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "C")
                {
                    CKeyDown = e.UpDown == KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "S")
                {
                    SKeyDown = e.UpDown == KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "X")
                {
                    XKeyDown = e.UpDown == KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "Return")
                {
                    EnterKeyDown = e.UpDown == KeyboardUpDown.Down;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 再生ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                PlayMacro(true, MacroExecMode.ALL);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マクロを再生する
        /// </summary>
        /// <param name="dialogShow"></param>
        /// <param name="macroExecMode"></param>
        private void PlayMacro(bool dialogShow, MacroExecMode macroExecMode)
        {
            try
            {
                //現在選択中のノード開始位置として利用するため、退避しておく。
                TreeNode selNode = ProjectNode.SelectedNode;
                //検出画像が表示されていると誤動作するのでルートを選択させておく
                ProjectNode.SelectedNode = ProjectNode.Nodes[0];
                if (!CheckProject()) return;

                if (dialogShow)
                {
                    DialogResult result = this.ShowInfoDialog("マクロの実行確認", "作成したマクロを実行しますか？\r\n[Ctrl + Shift + S] キーにて停止可能です。", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                }
                //カウントダウン
                ExecuteCountDownAnimation(macroExecMode);
                //マクロ実行
                ExecutePlay(ProjectModel, true, macroExecMode, selNode);
                
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カウントダウンアニメーションを実行する
        /// </summary>
        /// <param name="macroExecMode"></param>
        private void ExecuteCountDownAnimation(MacroExecMode macroExecMode)
        {
            try
            {
                switch (macroExecMode)
                {
                    case MacroExecMode.SINGLE:
                    case MacroExecMode.BELOWSELECTION:
                        {
                            if (SettingInfos.GetInstance().SettingDic[4] == "1")
                            {
                                MainHorizontalSplitContainer.Panel2.Controls[0].Visible = false;
                                MacroRunMsgControl msgCtrl = AddMacroRunMsgControl();
                                //フォーカス等を移したい場合があるので、3秒待つ
                                msgCtrl.MsgLbl.Text = "3";
                                Application.DoEvents();
                                Thread.Sleep(1000);
                                msgCtrl.MsgLbl.Text = "2";
                                Application.DoEvents();
                                Thread.Sleep(1000);
                                msgCtrl.MsgLbl.Text = "1";
                                Application.DoEvents();
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// マクロを実行する。
        /// </summary>
        /// <param name="projectModel"></param>
        /// <param name="showEndDialog"></param>
        /// <param name="macroExecMode"></param>
        /// <param name="selectedNode"></param>
        private void ExecutePlay(ProjectModel projectModel, bool showEndDialog, MacroExecMode macroExecMode, TreeNode selectedNode)
        {
            try
            {
                LogGrid.Rows.Clear();
                SaveButton.Enabled = false;
                PlayButton.Enabled = false;
                NodeDropDownButton.Enabled = false;
                VariableDropDownButton.Enabled = false;
                HelpDropDownButton.Enabled = false;
                StopButton.Enabled = true;

                MainHorizontalSplitContainer.Panel2.Controls[0].Visible = false;

                MacroRunMsgControl msgCtrl = null;
                if (MainHorizontalSplitContainer.Panel2.Controls.Count == 1)
                {
                    msgCtrl = AddMacroRunMsgControl();
                }
                else
                {
                    msgCtrl = (MacroRunMsgControl)MainHorizontalSplitContainer.Panel2.Controls[1];
                }

                MainHorizontalSplitContainer.Panel1.Enabled = false;
                _isPlaying = true;
                _execThread = new Thread(new ThreadStart(() => {
                    _macroExecutor = new MacroExecutor(projectModel, MacroStartType.EDITORSTART);
                    _macroExecutor.MacroExecMode = macroExecMode;
                    switch (macroExecMode)
                    {
                        case MacroExecMode.BELOWSELECTION:
                        case MacroExecMode.SINGLE:
                            {
                                if (selectedNode.Tag is ProjectModel && selectedNode.Parent == null)
                                {
                                    selectedNode = selectedNode.Nodes[0];
                                }

                                if (selectedNode.Tag is ProjectModel && selectedNode.Parent != null)
                                {
                                    ProjectModel projModel = (ProjectModel)selectedNode.Tag.DeepCopy();
                                    _macroExecutor.MacroStartProcessId = projModel.ProjectId;
                                }
                                else
                                {
                                    ProcessModel procModel = (ProcessModel)selectedNode.Tag.DeepCopy();
                                    _macroExecutor.MacroStartProcessId = procModel.ProcessId;
                                }
                            }
                            break;
                    }
                    _macroExecutor.OnLogEvent = SetMacroLog;
                    _macroExecutor.OnBeforeProcessStart = BeforeProcessStart;
                    _macroExecutor.Run(false);
                    Invoke(new MethodInvoker(() => {
                        if (_macroExecutor._stopFlag)
                        {
                            this.ShowWarningDialog("マクロの実行停止", "マクロ処理を停止しました。", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            if (showEndDialog)
                            {
                                this.ShowDialog("マクロの実行完了", "マクロ処理が完了しました。", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            }
                        }

                        SaveButton.Enabled = true;
                        PlayButton.Enabled = true;
                        NodeDropDownButton.Enabled = true;
                        VariableDropDownButton.Enabled = true;
                        HelpDropDownButton.Enabled = true;
                        StopButton.Enabled = false;
                        MainHorizontalSplitContainer.Panel1.Enabled = true;
                        msgCtrl = (MacroRunMsgControl)MainHorizontalSplitContainer.Panel2.Controls[1];
                        MainHorizontalSplitContainer.Panel2.Controls.RemoveAt(1);
                        msgCtrl.Dispose();
                        MainHorizontalSplitContainer.Panel2.Controls[0].Visible = true;
                        _isPlaying = false;
                    }));
                    _macroExecutor = null;
                }));
                _execThread.Start();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マクロ実行メッセージコントロールを追加する
        /// </summary>
        private MacroRunMsgControl AddMacroRunMsgControl()
        {
            try
            {
                MacroRunMsgControl msgCtrl = new MacroRunMsgControl();
                MainHorizontalSplitContainer.Panel2.Controls.Add(msgCtrl);
                msgCtrl.Location = new Point(0, 0);
                msgCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                msgCtrl.Width = MainHorizontalSplitContainer.Panel2.Width;
                msgCtrl.Height = MainHorizontalSplitContainer.Panel2.Height;
                return msgCtrl;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロセス実行前イベント
        /// </summary>
        /// <param name="processModel"></param>
        private void BeforeProcessStart(ProcessModel processModel)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => {
                        MacroRunMsgControl ctrl = (MacroRunMsgControl)MainHorizontalSplitContainer.Panel2.Controls[1];
                        ctrl.MsgLbl.Text = processModel.Name;
                    }));
                }
                else
                {
                    MacroRunMsgControl ctrl = (MacroRunMsgControl)MainHorizontalSplitContainer.Panel2.Controls[1];
                    ctrl.MsgLbl.Text = processModel.Name;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// マクロログをﾃｷｽﾄﾎﾞｯｸｽに記述する
        /// </summary>
        /// <param name="msg"></param>
        private void SetMacroLog(LogType logType , string msg, ProjectModel projectModel)
        {
            try
            {
                if (projectModel.ViewLogType == ViewLogType.表示しない) return;
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => {
                        LogGrid.Rows.Insert(0, DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss] ") + msg);
                        switch (logType)
                        {
                            case LogType.SUCCESS:
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.LimeGreen;
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.LimeGreen;
                                break;
                            case LogType.INFO:
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.Black;
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.Black;
                                break;
                            case LogType.WARN:
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.OrangeRed;
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.OrangeRed;
                                break;
                            case LogType.ERROR:
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.Red;
                                LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.Red;
                                break;
                        }
                        if(LogGrid.Rows.Count > 10000)
                        {
                            LogGrid.Rows.RemoveAt(10000);
                        }
                    }));
                }
                else
                {
                    LogGrid.Rows.Insert(0, DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss] ") + msg);
                    switch (logType)
                    {
                        case LogType.SUCCESS:
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.LimeGreen;
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.LimeGreen;
                            break;
                        case LogType.INFO:
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.Black;
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.Black;
                            break;
                        case LogType.WARN:
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.OrangeRed;
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.OrangeRed;
                            break;
                        case LogType.ERROR:
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.ForeColor = Color.Red;
                            LogGrid.Rows[0].Cells[COL_LOG.Index].Style.SelectionForeColor = Color.Red;
                            break;
                    }
                    if (LogGrid.Rows.Count > 10000)
                    {
                        LogGrid.Rows.RemoveAt(10000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクトをここでチェックする
        /// </summary>
        /// <returns></returns>
        private bool CheckProject()
        {
            try
            {
                if (!SaveNodeView())
                {
                    return false;
                }

                //ここで処理がすべて正常に登録されているかのチェックを行う
                List<string> errorList = ProjectModel.CheckMacroInput();
                if(errorList.Count > 0)
                {
                    string msg = "";
                    foreach(var m in errorList)
                    {
                        if (string.IsNullOrEmpty(msg))
                        {
                            msg = m;
                        }
                        else
                        {
                            msg += "\r\n" + m;
                        }
                    }
                    this.ShowErrorDialog(StringValue.PROCESS_NAME + "登録エラー", msg);
                    return false;
                }
                return true;
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
                ExecuteSave(ProjectModel, true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 保存処理を行う
        /// </summary>
        private void ExecuteSave(ProjectModel saveModel, bool showDialog)
        {
            try
            {
                if (!SaveNodeView())
                {
                    if (showDialog)
                    {
                        this.ShowErrorDialog("処理不正", "不正な処理が存在するため、保存できません。");
                    }
                    return;
                }
                string name = "";
                switch (saveModel.ExecDataType)
                {
                    case ExecDataType.PROJECT:
                        name = "プロジェクト";
                        break;
                    case ExecDataType.MACRO:
                        name = "モジュール";
                        break;
                }
                if (showDialog)
                {
                    DialogResult result = this.ShowInfoDialog("保存確認", name + "を保存しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                }

                SaveProject(saveModel);
                if (showDialog)
                {
                    this.ShowDialog("保存成功", name + "を保存しました。");
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトを保存する
        /// </summary>
        /// <param name="model"></param>
        public static void SaveProject(ProjectModel model)
        {
            try
            {
                System.IO.File.Copy(Program.USERPROFILE_PATH + @"\db.sqlite", Program.USERPROFILE_PATH + @"\backup_db.sqlite", true);
                //画像ファイルをバイト配列に変換する
                foreach (var proc in model.ProcessModelList)
                {
                    proc.BitmapToByteArray(false);
                    proc.NextProcessId = proc.NextProcess?.ProcessId;
                    proc.ErrorProcessId = proc.ErrorProcess?.ProcessId;
                }
                foreach (var macro in model.MacroModelList)
                {
                    //変数のリストを2次元配列に変換する
                    foreach(var ary in macro.ArrayVariableList)
                    {
                        ary.Value.ListToArray();
                    }
                    foreach (var proc in macro.ProcessModelList)
                    {
                        proc.BitmapToByteArray(false);
                        proc.NextProcessId = proc.NextProcess?.ProcessId;
                        proc.ErrorProcessId = proc.ErrorProcess?.ProcessId;
                    }
                }
                foreach(var ary in model.ArrayVariableList)
                {
                    ary.Value.ListToArray();
                }
                DbUtil.GetInstance().Create_Project_Module_Info(model);

                System.IO.File.Delete(Program.USERPROFILE_PATH + @"\backup_db.sqlite");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ツリーノードを上へ移動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 上へ移動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetTreeNodeMove(0);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ツリーノードを移動する 0:Up 1:Down
        /// </summary>
        /// <param name="upDown"></param>
        private void SetTreeNodeMove(int upDown)
        {
            try
            {
                TreeNode node = ProjectNode.SelectedNode;
                bool nextProcessSetFlag = SettingInfos.GetInstance().SettingDic[2] == "1";
                string id = "";
                if (node.Tag is ProjectModel)
                {
                    id = ((ProjectModel)node.Tag).ProjectId;
                }
                else
                {
                    id = ((ProcessModel)node.Tag).ProcessId;
                }
                ProjectModel projModel = (ProjectModel)node.Parent.Tag;
                for (int i = 0; i < projModel.NodeIdList.Count; i++)
                {
                    if (id == projModel.NodeIdList[i])
                    {
                        int add = 0;
                        switch (upDown)
                        {
                            case 0:
                                if (i == 0) return;
                                add = -1;
                                break;
                            case 1:
                                if (i == projModel.NodeIdList.Count - 1) return;
                                add = 1;
                                break;
                        }
                        projModel.NodeIdList.RemoveAt(i);
                        projModel.NodeIdList.Insert(i + add, id);

                        switch (projModel.ExecDataType)
                        {
                            case ExecDataType.PROJECT:
                                ProjectNode.Nodes[0].Nodes.RemoveAt(i);
                                ProjectNode.Nodes[0].Nodes.Insert(i + add, node);
                                ProjectNode.SelectedNode = node;
                                break;
                            case ExecDataType.MACRO:
                                int idx = node.Index;
                                TreeNode parent = node.Parent;
                                parent.Nodes.RemoveAt(idx);
                                parent.Nodes.Insert(idx + add, node);
                                ProjectNode.SelectedNode = node;
                                break;
                        }
                        if (nextProcessSetFlag)
                        {
                            //移動したノードがモジュールルートノードで、子がいない場合は終了
                            if (node.Tag is ProjectModel && ((ProjectModel)node.Tag).NodeIdList.Count == 0)
                            {
                                return;
                            }
                            //モジュール内の移動の場合
                            if (node.Tag is ProcessModel && node.Parent.Parent != null)
                            {
                                List<TreeNode> nodeList = new List<TreeNode>();
                                CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                                for (int a = 0; a < nodeList.Count; a++)
                                {
                                    if (nodeList[a].Equals(node))
                                    {
                                        ProcessModel movedModel = (ProcessModel)node.Tag;
                                        switch (upDown)
                                        {
                                            case 0://下から上へ
                                                {
                                                    ProcessModel afterModel = (ProcessModel)nodeList[a + 1].Tag;
                                                    if (a - 1 >= 0)
                                                    {
                                                        ProcessModel beforeModel = (ProcessModel)nodeList[a - 1].Tag;
                                                        beforeModel.NextProcess = movedModel;
                                                    }
                                                    afterModel.NextProcess = movedModel.NextProcess;
                                                    movedModel.NextProcess = afterModel;
                                                }
                                                break;
                                            case 1://上から下へ
                                                {
                                                    ProcessModel beforeModel = (ProcessModel)nodeList[a - 1].Tag;
                                                    if (a - 2 >= 0)
                                                    {
                                                        ProcessModel beforeBeforeModel = (ProcessModel)nodeList[a - 2].Tag;
                                                        beforeBeforeModel.NextProcess = beforeModel;
                                                    }
                                                    movedModel.NextProcess = beforeModel.NextProcess;
                                                    beforeModel.NextProcess = movedModel;
                                                }
                                                break;
                                        }
                                        ProcessBaseControl ctrl = (ProcessBaseControl)((NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0]).ContainerPanel.Controls[0];
                                        ctrl.CompButton.Tag = movedModel.NextProcess;
                                    }
                                }
                            }
                            else
                            {
                                //ノードでの移動の場合
                                TreeNode node1 = null; ;
                                TreeNode node2 = null;
                                switch (upDown)
                                {
                                    case 0://下から上へ
                                        node1 = node;
                                        node2 = ProjectNode.Nodes[0].Nodes[i + add + 1];
                                        //入れ替えたノードがモジュールで子がいない場合は、移動無し扱い
                                        if (node2.Tag is ProjectModel && ((ProjectModel)node2.Tag).NodeIdList.Count == 0)
                                        {
                                            return;
                                        }
                                        break;
                                    case 1://上から下へ
                                        node1 = ProjectNode.Nodes[0].Nodes[i + add - 1];
                                        node2 = node;
                                        //入れ替えたノードがモジュールで子がいない場合は、移動無し扱い
                                        if (node1.Tag is ProjectModel && ((ProjectModel)node1.Tag).NodeIdList.Count == 0)
                                        {
                                            return;
                                        }
                                        break;
                                }

                                List<TreeNode> nodeList = new List<TreeNode>();
                                CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                                //node1を処理
                                for (int x = 0; x < 2; x++)
                                {
                                    TreeNode workNode = null;
                                    switch (x)
                                    {
                                        case 0:
                                            workNode = node1;
                                            break;
                                        case 1:
                                            workNode = node2;
                                            break;
                                    }
                                    if (workNode.Tag is ProcessModel)
                                    {
                                        for (int a = 0; a < nodeList.Count; a++)
                                        {
                                            if (nodeList[a].Equals(workNode))
                                            {
                                                ProcessModel movedModel = (ProcessModel)workNode.Tag;
                                                //1つ前のNextProcessをセットしなおす
                                                if (a - 1 >= 0)
                                                {
                                                    ((ProcessModel)nodeList[a - 1].Tag).NextProcess = movedModel;
                                                }
                                                //自信のNextProcessを1つ先にセットしなおす
                                                if (a + 1 <= nodeList.Count - 1)
                                                {
                                                    movedModel.NextProcess = (ProcessModel)nodeList[a + 1].Tag;
                                                }
                                                else
                                                {
                                                    movedModel.NextProcess = ProcessModel.GetEndProcessModel();
                                                }
                                                if (workNode.Equals(node))
                                                {
                                                    ProcessBaseControl ctrl = (ProcessBaseControl)((NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0]).ContainerPanel.Controls[0];
                                                    ctrl.CompButton.Tag = movedModel.NextProcess;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ProjectModel pjModel = (ProjectModel)workNode.Tag;
                                        ProcessModel moduleFirstModel = pjModel.ProcessModelList.First(a => a.ProcessId == pjModel.NodeIdList[0]);
                                        ProcessModel moduleLastModel = pjModel.ProcessModelList.First(a => a.ProcessId == pjModel.NodeIdList[pjModel.NodeIdList.Count - 1]);
                                        for (int a = 0; a < nodeList.Count; a++)
                                        {
                                            if (nodeList[a].Tag.Equals(moduleFirstModel))
                                            {
                                                if (a - 1 >= 0)
                                                {
                                                    ((ProcessModel)nodeList[a - 1].Tag).NextProcess = moduleFirstModel;
                                                }
                                            }
                                            if (nodeList[a].Tag.Equals(moduleLastModel))
                                            {
                                                if (a + 1 <= nodeList.Count - 1)
                                                {
                                                    moduleLastModel.NextProcess = (ProcessModel)nodeList[a + 1].Tag;
                                                }
                                                else
                                                {
                                                    moduleLastModel.NextProcess = ProcessModel.GetEndProcessModel();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
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
        /// ツリーノードを下へ移動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 下へ移動ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetTreeNodeMove(1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// MacroTreeのマウスクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectNode_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                TreeNode node = ProjectNode.GetNodeAt(e.X, e.Y);
                if (node == null)
                {
                    return;
                }
                
                bool selected = false;
                TreeViewHitTestInfo hitTest = ProjectNode.HitTest(e.Location);
                //ラベル・イメージ以外をクリックされた場合は、ノードを選択状態にする
                if (hitTest.Location != TreeViewHitTestLocations.Label
                    && hitTest.Location != TreeViewHitTestLocations.Image)
                {
                    selected = true;
                    ProjectNode.SelectedNode = node;
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (!selected)
                    {
                        ProjectNode.SelectedNode = node;
                    }
                    node = ProjectNode.SelectedNode;
                    AllNodesOpenStripMenuItem.Enabled = (node.Tag is ProjectModel && node.Parent == null);
                    NodeOpenStripMenuItem.Enabled = node.Nodes.Count > 0;
                    NodeCloseStripMenuItem.Enabled = node.Nodes.Count > 0;

                    ModuleCreateStripMenuItem.Enabled = !(node.Tag is ProjectModel && node.Parent == null);
                    NodeCopyStripMenuItem.Enabled = !(node.Tag is ProjectModel && node.Parent == null);
                    NodeExecStripMenuItem.Enabled = !(node.Tag is ProjectModel && node.Parent == null);
                    MoveUpStripMenuItem.Enabled = !(node.Tag is ProjectModel && node.Parent == null);
                    MoveDownStripMenuItem.Enabled = !(node.Tag is ProjectModel && node.Parent == null);
                    RemoveNodeStripMenuItem.Enabled = !(node.Tag is ProjectModel && node.Parent == null);

                    if (node.Parent != null && node.Parent.Tag is ProjectModel)
                    {
                        ProjectModel projModel = (ProjectModel)node.Parent.Tag;
                        AddModuleStripMenuItem.Enabled = (projModel.ExecDataType != ExecDataType.MACRO);
                    }
                    TreeNodeContextMenuStrip.Show(Cursor.Position, ToolStripDropDownDirection.BelowRight);
                }


            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 停止ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPlaying())
                {
                    _macroExecutor._stopFlag = true;
                    while (_execThread.IsAlive)
                    {
                        _cancellingFlag = true;
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }
                    _isPlaying = false;
                    _cancellingFlag = false;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// バージョン情報を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                new VersionInfoForm().ShowDialog(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数を追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrRemoveVariable(0);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveVariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrRemoveVariable(1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddArrayVariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrRemoveArrayVariable(0);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveArrayVariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrRemoveArrayVariable(1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数の追加削除を行う
        /// </summary>
        /// <param name="idx"></param>
        private void AddOrRemoveVariable(int idx)
        {
            try
            {
                NodeControl nodeCtrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                ProjectControl ctrl = (ProjectControl)nodeCtrl.ContainerPanel.Controls[0];
                switch (idx)
                {
                    case 0:
                        ctrl.ExecuteVariableInsert();
                        break;
                    case 1:
                        ctrl.ExecuteVariableDelete();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列の追加削除を行う
        /// </summary>
        /// <param name="idx"></param>
        private void AddOrRemoveArrayVariable(int idx)
        {
            try
            {
                NodeControl nodeCtrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                ProjectControl ctrl = (ProjectControl)nodeCtrl.ContainerPanel.Controls[0];
                switch (idx)
                {
                    case 0:
                        ctrl.ExecuteArrayVariableInsert();
                        break;
                    case 1:
                        ctrl.ExecuteArrayVariableDelete();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードの追加イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ctrl"></param>
        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessModel newModel = new ProcessModel();
                newModel.Name = StringValue.PROCESS_NAME;
                AddNode(newModel, true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードを追加する
        /// </summary>
        /// <param name="newModel"></param>
        /// <param name="showDialog"></param>
        private void AddNode(ProcessModel newModel, bool showDialog)
        {
            try
            {
                //ノード追加時に選択しているノードの成功時遷移先を追加したノードにするかの設定
                //ルートノードを選択している場合は、次のノードにするかの設定
                bool nextProcessSetFlag = SettingInfos.GetInstance().SettingDic[2] == "1";
                TreeNode node = new TreeNode(newModel.Name);
                node.Tag = newModel;
                node.ImageIndex = ProjectModel.GetImageIndex(newModel.ProcessType);
                node.SelectedImageIndex = node.ImageIndex;

                List<TreeNode> nodeList = new List<TreeNode>();

                ProjectModel projModel = null;
                int patternIdx = -1;
                //選択ノードがルートノードの場合
                if (ProjectNode.SelectedNode.Parent == null)
                {
                    patternIdx = 0;
                    projModel = (ProjectModel)ProjectNode.SelectedNode.Tag;
                }
                //選択ノードが子ノードの場合
                if (ProjectNode.SelectedNode.Parent != null && ProjectNode.SelectedNode.Parent.Parent == null && ProjectNode.SelectedNode.Tag is ProcessModel)
                {
                    patternIdx = 1;
                    projModel = (ProjectModel)ProjectNode.SelectedNode.Parent.Tag;
                }
                //選択ノードがモジュールの場合
                if (ProjectNode.SelectedNode.Parent != null && ProjectNode.SelectedNode.Parent.Parent == null && ProjectNode.SelectedNode.Tag is ProjectModel)
                {
                    patternIdx = 2;
                    //モジュール上での追加は、ルートノードか、モジュールに追加かを判定後にProjectModelを決定する
                }
                //選択ノードがモジュールの子ノードの場合
                if (ProjectNode.SelectedNode.Parent != null && ProjectNode.SelectedNode.Parent.Parent != null && ProjectNode.SelectedNode.Tag is ProcessModel)
                {
                    patternIdx = 3;
                    projModel = (ProjectModel)ProjectNode.SelectedNode.Parent.Tag;
                }
                //このIDの後ろに入れる
                string id = "";
                switch (patternIdx)
                {
                    case 0: //選択ノードがルートノードの場合
                        {
                            //ルートノード直下へnewNodeを追加する
                            //idは最初なので、なし
                            ProjectNode.Nodes[0].Nodes.Insert(0, node);
                            if (nextProcessSetFlag)
                            {
                                CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                                for (int i = 0; i < nodeList.Count; i++)
                                {
                                    if (nodeList[i].Equals(node))
                                    {
                                        if (nodeList.Count - 1 > i)
                                        {
                                            newModel.NextProcess = (ProcessModel)nodeList[i + 1].Tag;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 1: //選択ノードが子ノードの場合
                        {
                            //ルートノード直下へnewNodeを追加する
                            int addIdx = ProjectNode.SelectedNode.Index + 1;
                            ProjectNode.Nodes[0].Nodes.Insert(addIdx, node);
                            ProcessModel model = (ProcessModel)ProjectNode.SelectedNode.Tag;
                            id = model.ProcessId;
                            if (nextProcessSetFlag)
                            {
                                model.NextProcess = newModel;
                                ProcessBaseControl ctrl = (ProcessBaseControl)((NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0]).ContainerPanel.Controls[0];
                                ctrl.CompButton.Tag = newModel;
                                CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                                for (int i = 0; i < nodeList.Count; i++)
                                {
                                    if (nodeList[i].Equals(node))
                                    {
                                        if (nodeList.Count - 1 > i)
                                        {
                                            newModel.NextProcess = (ProcessModel)nodeList[i + 1].Tag;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 2: //選択ノードがモジュールの場合
                        {
                            DialogResult result = DialogResult.Yes;
                            if (showDialog)
                            {
                                result = this.ShowInfoDialog("ノード追加先を指定してください。", "ルートノードへ追加しますか？\r\nはい = ルートノード\r\nいいえ = モジュールノード", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button1);
                                if (result == DialogResult.Cancel) return;
                            }
                            if (result == DialogResult.Yes)
                            {
                                projModel = (ProjectModel)ProjectNode.Nodes[0].Tag;
                                int addIdx = ProjectNode.SelectedNode.Index + 1;
                                ProjectNode.SelectedNode.Parent.Nodes.Insert(addIdx, node);
                            }
                            else
                            {
                                projModel = (ProjectModel)ProjectNode.SelectedNode.Tag;
                                ProjectNode.SelectedNode.Nodes.Insert(0, node);
                            }
                            id = ((ProjectModel)ProjectNode.SelectedNode.Tag).ProjectId;
                            if (nextProcessSetFlag)
                            {
                                CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                                for (int i = 0; i < nodeList.Count; i++)
                                {
                                    if (nodeList[i].Equals(node))
                                    {
                                        if (nodeList.Count - 1 > i)
                                        {
                                            newModel.NextProcess = (ProcessModel)nodeList[i + 1].Tag;
                                            break;
                                        }
                                    }
                                }
                                for (int i = 0; i < nodeList.Count; i++)
                                {
                                    if (nodeList[i].Equals(node))
                                    {
                                        if (i - 1 >= 0)
                                        {
                                            ProcessModel procModel = (ProcessModel)nodeList[i - 1].Tag;
                                            procModel.NextProcess = newModel;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 3: //選択ノードがモジュールの子ノードの場合
                        {
                            int addIdx = ProjectNode.SelectedNode.Index + 1;
                            ProjectNode.SelectedNode.Parent.Nodes.Insert(addIdx, node);
                            ProcessModel model = (ProcessModel)ProjectNode.SelectedNode.Tag;
                            id = model.ProcessId;
                            if (nextProcessSetFlag)
                            {
                                model.NextProcess = newModel;
                                ProcessBaseControl ctrl = (ProcessBaseControl)((NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0]).ContainerPanel.Controls[0];
                                ctrl.CompButton.Tag = newModel;
                                CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                                for (int i = 0; i < nodeList.Count; i++)
                                {
                                    if (nodeList[i].Equals(node))
                                    {
                                        if (nodeList.Count - 1 > i)
                                        {
                                            newModel.NextProcess = (ProcessModel)nodeList[i + 1].Tag;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                projModel.ProcessModelList.Add(newModel);
                projModel.SetNodeId(newModel.ProcessId, id);

                bool moveNewNode = SettingInfos.GetInstance().SettingDic[5] == "1";
                if (moveNewNode)
                {
                    ProjectNode.SelectedNode = node;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードの1次元配列を取得する
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="nodeList"></param>
        private void CreateOneDimensionNodeList(TreeNodeCollection nodes, List<TreeNode> nodeList)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag is ProcessModel)
                    {
                        nodeList.Add(node);
                    }
                    CreateOneDimensionNodeList(node.Nodes, nodeList);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードの1次元配列を取得する
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="nodeList"></param>
        private void CreateOneDimensionNodeListAll(TreeNodeCollection nodes, List<TreeNode> nodeList)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    nodeList.Add(node);
                    CreateOneDimensionNodeListAll(node.Nodes, nodeList);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードの削除イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveNode(true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードを削除する
        /// </summary>
        /// <param name="showDialog"></param>
        private void RemoveNode(bool showDialog)
        {
            try
            {
                if (showDialog)
                {
                    DialogResult result = this.ShowInfoDialog("処理削除", "処理を削除しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                }

                ProcessModel procModel = (ProcessModel)ProjectNode.SelectedNode.Tag;
                ProjectModel projModel = (ProjectModel)ProjectNode.SelectedNode.Parent.Tag;

                //ノード追加時に選択しているノードの成功時遷移先を追加したノードにするかの設定
                //ルートノードを選択している場合は、次のノードにするかの設定
                bool nextProcessSetFlag = SettingInfos.GetInstance().SettingDic[2] == "1";
                if (nextProcessSetFlag)
                {
                    List<TreeNode> nodeList = new List<TreeNode>();
                    CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        ProcessModel nodeModel = (ProcessModel)nodeList[i].Tag;
                        if (nodeModel.Equals(procModel))
                        {
                            if (i - 1 >= 0 && i + 1 <= nodeList.Count - 1)
                            {
                                ProcessModel beforeProc = (ProcessModel)nodeList[i - 1].Tag;
                                ProcessModel afterProc = (ProcessModel)nodeList[i + 1].Tag;
                                beforeProc.NextProcess = afterProc;
                            }
                        }
                    }
                }

                projModel.RemoveModel(projModel.ProcessModelList, procModel);
                NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                ctrl.TreeNode.Remove();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// モジュール追加ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProjectForm form = new LoadProjectForm();
                form.Init(LoadProjectMode. モジュール読込);
                form.ShowDialog(this);
                if (form.LoadResult != DialogResult.OK) return;
                ProjectModel newModel = form.ProjectModel;
                AddModule(newModel);
                
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュールを追加します。
        /// </summary>
        /// <param name="newModel"></param>
        private void AddModule(ProjectModel newModel)
        {
            try
            {
                //IDを更新する
                newModel.RenewId();
                TreeNode node = new TreeNode(newModel.Name);
                node.Tag = newModel;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                ProjectModel.MacroModelList.Add(newModel);
                string id = "";
                if (ProjectNode.SelectedNode.Tag is ProcessModel)
                {
                    id = ((ProcessModel)ProjectNode.SelectedNode.Tag).ProcessId;
                }
                else
                {
                    id = ((ProjectModel)ProjectNode.SelectedNode.Tag).ProjectId;
                }
                if (ProjectNode.SelectedNode.Parent == null)
                {
                    ProjectNode.SelectedNode.Nodes.Insert(0, node);
                }
                else
                {
                    ProjectNode.SelectedNode.Parent.Nodes.Insert(ProjectNode.SelectedNode.Index + 1, node);
                }
                ProjectModel.SetNodeId(newModel.ProjectId, id);

                foreach (var macroId in newModel.NodeIdList)
                {
                    ProcessModel procModel = newModel.ProcessModelList.First(a => a.ProcessId == macroId);
                    TreeNode procNode = new TreeNode(procModel.Name);
                    procNode.ImageIndex = ProjectModel.GetImageIndex(procModel.ProcessType);
                    procNode.SelectedImageIndex = procNode.ImageIndex;
                    procNode.Tag = procModel;
                    node.Nodes.Add(procNode);
                }

                bool nextProcessSetFlag = SettingInfos.GetInstance().SettingDic[2] == "1";
                if (nextProcessSetFlag)
                {
                    ProcessModel macroBeforeModel = newModel.ProcessModelList.FirstOrDefault(a => a.ProcessId == newModel.NodeIdList[0]);
                    ProcessModel macroAfterModel = newModel.ProcessModelList.FirstOrDefault(a => a.ProcessId == newModel.NodeIdList[newModel.NodeIdList.Count - 1]);
                    if (macroBeforeModel != null && macroAfterModel != null)
                    {
                        List<TreeNode> nodeList = new List<TreeNode>();
                        CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                        ProcessModel beforeProc = null;
                        ProcessModel afterProc = null;
                        for (int i = 0; i < nodeList.Count; i++)
                        {
                            ProcessModel nodeModel = (ProcessModel)nodeList[i].Tag;
                            if (nodeModel.Equals(macroBeforeModel))
                            {
                                if (i - 1 >= 0)
                                {
                                    beforeProc = (ProcessModel)nodeList[i - 1].Tag;
                                    beforeProc.NextProcess = macroBeforeModel;
                                }
                            }
                            if (nodeModel.Equals(macroAfterModel))
                            {
                                if (i + 1 <= nodeList.Count - 1)
                                {
                                    afterProc = (ProcessModel)nodeList[i + 1].Tag;
                                    macroAfterModel.NextProcess = afterProc;
                                }
                            }
                        }
                        if (ProjectNode.SelectedNode.Tag is ProcessModel)
                        {
                            ProcessBaseControl ctrl = (ProcessBaseControl)((NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0]).ContainerPanel.Controls[0];
                            ctrl.CompButton.Tag = macroBeforeModel;
                        }

                    }
                }
                bool newNodeMoveFlag = SettingInfos.GetInstance().SettingDic[5] == "1";
                if (newNodeMoveFlag)
                {
                    ProjectNode.SelectedNode = node;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// モジュールを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveModule(true);
                
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュールの削除を実行する
        /// </summary>
        /// <param name="showDialog"></param>
        private void RemoveModule(bool showDialog)
        {
            try
            {
                if (showDialog)
                {
                    DialogResult result = this.ShowInfoDialog("モジュール削除", "モジュールを削除しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                }

                ProjectModel macroModel = (ProjectModel)ProjectNode.SelectedNode.Tag;
                ProjectModel projModel = (ProjectModel)ProjectNode.SelectedNode.Parent.Tag;

                //ノード追加時に選択しているノードの成功時遷移先を追加したノードにするかの設定
                //ルートノードを選択している場合は、次のノードにするかの設定
                bool nextProcessSetFlag = SettingInfos.GetInstance().SettingDic[2] == "1";
                if (nextProcessSetFlag)
                {
                    ProcessModel macroBeforeModel = macroModel.ProcessModelList.FirstOrDefault(a => a.ProcessId == macroModel.NodeIdList[0]);
                    ProcessModel macroAfterModel = macroModel.ProcessModelList.FirstOrDefault(a => a.ProcessId == macroModel.NodeIdList[macroModel.NodeIdList.Count - 1]);
                    if (macroBeforeModel != null && macroAfterModel != null)
                    {
                        List<TreeNode> nodeList = new List<TreeNode>();
                        CreateOneDimensionNodeList(ProjectNode.Nodes, nodeList);
                        ProcessModel beforeProc = null;
                        ProcessModel afterProc = null;
                        for (int i = 0; i < nodeList.Count; i++)
                        {
                            ProcessModel nodeModel = (ProcessModel)nodeList[i].Tag;
                            if (nodeModel.Equals(macroBeforeModel))
                            {
                                if (i - 1 >= 0)
                                {
                                    beforeProc = (ProcessModel)nodeList[i - 1].Tag;
                                }
                            }
                            if (nodeModel.Equals(macroAfterModel))
                            {
                                if (i + 1 <= nodeList.Count - 1)
                                {
                                    afterProc = (ProcessModel)nodeList[i + 1].Tag;
                                }
                            }
                        }
                        if (beforeProc != null && afterProc != null)
                        {
                            beforeProc.NextProcess = afterProc;
                        }
                    }
                }

                projModel.RemoveMacroModel(projModel.MacroModelList, macroModel);
                NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                ctrl.TreeNode.Remove();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// フォーム終了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //マクロ実行中は終了させない
                if (IsPlaying() || _altF4Pressed)
                {
                    _altF4Pressed = false;
                    e.Cancel = true;
                    return;
                }
                if (KeyboardHook != null)
                {
                    KeyboardHook.KeyboardHooked -= KeyboardHook_KeyboardHooked;
                    KeyboardHook.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ロググリッドのリサイズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogGrid_Resize(object sender, EventArgs e)
        {
            try
            {
                LogGrid.Columns[COL_LOG.Index].Width = LogGrid.Width - LogGrid.VScrollBar.Width;
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
        private void ProcessEditForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Owner.Hide();
                LogGrid_Resize(LogGrid, new EventArgs());
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ボーダーを消去する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ProcessEditFormのキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {            
                //ALT F4を無効にするための措置
                if (e.Alt && e.KeyCode == Keys.F4)
                    _altF4Pressed = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveNodeStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _nodeModuleRemovingFlag = true;
                TreeNode node = ProjectNode.SelectedNode;
                if (node.Tag is ProjectModel)
                {
                    RemoveModuleButton_Click(RemoveModuleButton, new EventArgs());
                }
                else
                {
                    RemoveNodeButton_Click(RemoveNodeButton, new EventArgs());
                }
                _nodeModuleRemovingFlag = false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNodeStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNodeButton_Click(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ﾏﾆｭｱﾙを起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileUtil.ViewFile(@"Resources\" + StringValue.MANUAL_SITE);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
     

        /// <summary>
        /// デスクトップパスボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesktopPathButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("$Desktop");
                this.ShowDialog("定数入力", "デスクトップパス定数をクリップボードにコピーしました。\r\n貼り付けてお使いください。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ドキュメントパスボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentPathButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("$Document");
                this.ShowDialog("定数入力", "ドキュメントフォルダパス定数をクリップボードにコピーしました。\r\n貼り付けてお使いください。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行ログボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecLogButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("$PrintLog");
                this.ShowDialog("定数入力", "実行ログ定数をクリップボードにコピーしました。\r\n貼り付けてお使いください。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// TABボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("{TAB}");
                this.ShowDialog("定数入力", "TAB定数をクリップボードにコピーしました。\r\n貼り付けてお使いください。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ユーザーフォルダパスボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFolderPathButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("$UserProfile");
                this.ShowDialog("定数入力", "ユーザーフォルダパス定数をクリップボードにコピーしました。\r\n貼り付けてお使いください。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 日付関数文字列を作成する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimeFuncButton_Click(object sender, EventArgs e)
        {

            try
            {
                CreateDateTimeFuncForm form = new CreateDateTimeFuncForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュール作成画面を起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                KeyboardHook.Dispose();
                MainMenu.ShowModuleCreateForm(this);
                CreateKeyboardHook();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// モジュールの修正を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                KeyboardHook.Dispose();
                MainMenu.ShowEditProject(this, 1, MacroStartType.EDITORSTART);
                CreateKeyboardHook();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
 
        /// <summary>
        /// モジュール追加ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModuleStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                AddModuleButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノード又はモジュールを単体実行する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeExecStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PlayMacro(false, MacroExecMode.SINGLE);

                return;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択以下を実行する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnderSelNodeExecStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                PlayMacro(false, MacroExecMode.BELOWSELECTION);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択されているノードを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeOpenStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectNode.SelectedNode.Expand();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択されているノードを閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeCloseStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectNode.SelectedNode.Collapse();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 全ノードを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllNodesOpenStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectNode.SelectedNode.ExpandAll();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ControlのDeactivateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessEditForm_Deactivate(object sender, EventArgs e)
        {
            try
            {
                NodeControl ctrl = (NodeControl)MainHorizontalSplitContainer.Panel2.Controls[0];
                if(ctrl.ContainerPanel.Controls[0] is ProcessBaseControl)
                {
                    ProcessBaseControl procCtrl = (ProcessBaseControl)ctrl.ContainerPanel.Controls[0];
                    procCtrl.OnDeactivate?.Invoke();
                }


            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 現在のノード又はモジュールをコピーします。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeCopyStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetNodeModuleCopyObject(); 
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードモジュールコピーオブジェクトにセットする
        /// </summary>
        private void SetNodeModuleCopyObject()
        {
            try
            {
                NodeModuleCopyObject = ProjectNode.SelectedNode.Tag;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 現在選択されているノードの下にコピーしておいたモジュールを貼り付けます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodePasteStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                ExecuteNodeModulePaste();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノード又はモジュールを貼り付ける
        /// </summary>
        private void ExecuteNodeModulePaste()
        {
            try
            {
                if (NodeModuleCopyObject == null) return;
                if (NodeModuleCopyObject is ProcessModel)
                {
                    ProcessModel procModel = (ProcessModel)NodeModuleCopyObject.DeepCopy();
                    procModel.Name = "(ｺﾋﾟｰ) " + procModel.Name;
                    procModel.ProcessId = ProjectModel.NewId();
                    AddNode(procModel, true);
                }
                else
                {
                    if (ProjectNode.SelectedNode.Level == 2)
                    {
                        this.ShowInfoDialog("モジュール追加不可", "モジュール内にモジュールを追加する事は出来ません。");
                        return;
                    }
                    ProjectModel projModel = (ProjectModel)NodeModuleCopyObject.DeepCopy();
                    projModel.Name = "(ｺﾋﾟｰ) " + projModel.Name;
                    AddModule(projModel);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ProjectNodeのKeyDownｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectNode_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if(e.Control)
                {
                    if (!e.Alt)
                    {
                        if (e.KeyCode == Keys.C)
                        {
                            if (ProjectNode.SelectedNode != ProjectNode.Nodes[0])
                            {
                                SetNodeModuleCopyObject();
                            }
                        }
                        if (e.KeyCode == Keys.V)
                        {
                            ExecuteNodeModulePaste();
                        }
                    }
                    else
                    {
                        if (e.KeyCode == Keys.C)
                        {
                            CheckedNodesCopyStripMenuItem_Click(null, new EventArgs());
                        }
                        if (e.KeyCode == Keys.V)
                        {
                            CheckedNodesPasteStripMenuItem_Click(null, new EventArgs());
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュール登録を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleCreateStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (!SaveNodeView())
                {
                    this.ShowErrorDialog("処理不正", "不正な処理が存在するため、登録できません。");
                    return;
                }

                ModuleSaveForm form = new ModuleSaveForm();
                ProjectModel projModel = null;
                if (ProjectNode.SelectedNode.Tag is ProcessModel)
                {
                    projModel = new ProjectModel();
                    ProcessModel model = (ProcessModel)ProjectNode.SelectedNode.Tag.DeepCopy();
                    model.ProcessId = ProjectModel.NewId();
                    model.NextProcess = ProcessModel.GetEndProcessModel();
                    model.ErrorProcess = ProcessModel.GetErrorProcessModel();
                    projModel.ProcessModelList.Add(model);
                    projModel.SetNodeId(model.ProcessId, "");
                    projModel.ExecDataType = ExecDataType.MACRO;
                    form.ProjTextBox.Text = model.Name;
                    form.ProjTextBox.Tag = model.Name;
                    form.DescriptionTextBox.Text = model.Description;
                }
                else
                {
                    projModel = (ProjectModel)ProjectNode.SelectedNode.Tag.DeepCopy();
                    projModel.ProjectId = ProjectModel.NewId();
                    projModel.RenewId();
                    form.ProjTextBox.Text = projModel.Name;
                    form.ProjTextBox.Tag = projModel.Name;
                    form.DescriptionTextBox.Text = projModel.Description;
                }

                
                form.ShowDialog(this);
                if (!form.Saved) return;

                projModel.Name = form.ProjTextBox.Text.Trim();
                projModel.Description = form.DescriptionTextBox.Text.Trim();
                ExecuteSave(projModel, false);
                this.ShowDialog("保存成功", "モジュールを保存しました。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードのチェック状態を解除する
        /// </summary>
        /// <param name="nodes"></param>
        private void ClearProjectNodeChecked(TreeNodeCollection nodes)
        {
            try
            {
                foreach(TreeNode node in nodes)
                {
                    node.Checked = false;
                    ClearProjectNodeChecked(node.Nodes);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択されているモジュール又はノードをモジュール登録する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedModuleCreateStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<ProcessModel> procList = new List<ProcessModel>();
                GetCheckedProcessList(ProjectNode.Nodes, procList);
                if(procList.Count == 0)
                {
                    this.ShowInfoDialog("ノード未検出", "選択されているノードは存在しません。");
                    return;
                }

                if (!SaveNodeView())
                {
                    this.ShowErrorDialog("処理不正", "不正な処理が存在するため、登録できません。");
                    return;
                }



                ModuleSaveForm form = new ModuleSaveForm();
                ProjectModel projModel = new ProjectModel();
                string id = "";
                foreach(var proc in procList)
                {
                    projModel.ProcessModelList.Add(proc.DeepCopy());
                    projModel.SetNodeId(proc.ProcessId,id);
                    id = proc.ProcessId;
                }
                projModel.ExecDataType = ExecDataType.MACRO;
                projModel.RenewId();
                form.ShowDialog(this);
                if (!form.Saved) return;

                projModel.Name = form.ProjTextBox.Text.Trim();
                projModel.Description = form.DescriptionTextBox.Text.Trim();
                ExecuteSave(projModel, false);
                this.ShowDialog("保存成功", "モジュールを保存しました。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// チェックされているノードを取得します。
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="procList"></param>
        private void GetCheckedProcessList(TreeNodeCollection nodes, List<ProcessModel> procList)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked && node.Tag != null && node.Tag is ProcessModel)
                    {
                        procList.Add((ProcessModel)node.Tag);
                    }
                    GetCheckedProcessList(node.Nodes, procList);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// チェックされているノードを取得します。
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="checkedNodes"></param>
        private void GetCheckedNodeListAll(TreeNodeCollection nodes, List<TreeNode> checkedNodes, int level)
        {
            try
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked && node.Parent != null && node.Level == level)
                    {
                        checkedNodes.Add(node);
                    }
                    GetCheckedNodeListAll(node.Nodes, checkedNodes, level);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ProjectNodeのAfterCheckイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectNode_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (_onAfterCheckFlag)
                {
                    return;
                }
                _onAfterCheckFlag = true;
                SetProjectNodeChecked(e.Node.Nodes, e.Node.Checked);
                _onAfterCheckFlag = false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトノードのチェックイベント
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="check"></param>
        private void SetProjectNodeChecked(TreeNodeCollection nodes, bool check)
        {
            try
            {
                foreach(TreeNode node in nodes)
                {
                    node.Checked = check;
                    SetProjectNodeChecked(node.Nodes, check);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択チェックしているノードをコピーする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedNodesCopyStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CheckedNodeModuleCopyObject = new List<object>();
                List<TreeNode> checkedNodeList1 = new List<TreeNode>();
                List<TreeNode> checkedNodeList2 = new List<TreeNode>();
                GetCheckedNodeListAll(ProjectNode.Nodes, checkedNodeList1, 1);
                GetCheckedNodeListAll(ProjectNode.Nodes, checkedNodeList2, 2);

                //Level1又はLevel2のどちらかのみコピーする
                if(checkedNodeList1.Count > 0)
                {
                    foreach (var c in checkedNodeList1)
                    {
                        CheckedNodeModuleCopyObject.Add(c.Tag);
                    }
                }else if(checkedNodeList1.Count == 0 && checkedNodeList2.Count > 0)
                {
                    foreach (var c in checkedNodeList2)
                    {
                        CheckedNodeModuleCopyObject.Add(c.Tag);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードを貼り付ける
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedNodesPasteStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckedNodeModuleCopyObject == null || CheckedNodeModuleCopyObject.Count == 0) return;
                TreeNode selNode = ProjectNode.SelectedNode;
                //モジュール内にモジュールを追加するのはNG
                if (selNode.Level == 2)
                {
                    foreach(var obj in CheckedNodeModuleCopyObject)
                    {
                        if(obj is ProjectModel)
                        {
                            this.ShowErrorDialog("モジュール追加不可", "モジュール内に更にモジュールを追加する事は出来ません。");
                            return;
                        }
                    }
                }
                for(int i = CheckedNodeModuleCopyObject.Count - 1 ; i >= 0; i--)
                {
                    var obj = CheckedNodeModuleCopyObject[i];
                    if (obj is ProcessModel)
                    {
                        ProcessModel copyProcModel = (ProcessModel)obj.DeepCopy();
                        copyProcModel.ProcessId = ProjectModel.NewId();
                        AddNode(copyProcModel, false);
                    }
                    else
                    {
                        ProjectModel copyProjectModel = (ProjectModel)obj.DeepCopy();
                        copyProjectModel.RenewId();
                        AddModule(copyProjectModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 選択チェックされているノードを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RemoveCheckedNodesStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<TreeNode> checkedList = new List<TreeNode>();
                GetCheckedNodeListAll(ProjectNode.Nodes[0].Nodes, checkedList);
                if(checkedList.Count == 0)
                {
                    return;
                }
                DialogResult result = this.ShowInfoDialog("選択ノード・モジュールの削除確認", "選択されているノード又はモジュールを削除しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No) return;

                //Cursor.Current = Cursors.WaitCursor;
                StripStatusLabel.Text = "ノード・モジュールを削除中...";
                StripStatusLabel.Visible = true;
                StripStatusProgressBar.Visible = true;
                StripStatusProgressBar.Value = 0;
                StripStatusProgressBar.Maximum = checkedList.Count;
                Application.DoEvents();
                await Task.Run(()=> {
                    this.Invoke(new MethodInvoker(()=> {

                        string guiId = GuiUtil.GetInstance().NewId();
                        GuiUtil.GetInstance().BeginUpdate(MainHorizontalSplitContainer, guiId);
                        foreach (var obj in checkedList)
                        {
                            StripStatusProgressBar.Value++;
                            if(NodeExists(ProjectNode.Nodes, obj))
                            {
                                try
                                {
                                    ProjectNode.SelectedNode = obj;
                                    TreeNode node = ProjectNode.SelectedNode;
                                    if (node.Tag is ProjectModel)
                                    {
                                        RemoveModule(false);
                                    }
                                    else
                                    {
                                        RemoveNode(false);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw Program.ThrowException(ex);
                                }

                            }
                        }
                        GuiUtil.GetInstance().EndUpdate(guiId);
                    }));
                });
                StripStatusLabel.Visible = false;
                StripStatusProgressBar.Visible = false;
                //Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードが存在するかの判定
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool NodeExists(TreeNodeCollection nodes, TreeNode existsNode)
        {
            try
            {
                foreach(TreeNode node in nodes)
                {
                    if (node.Equals(existsNode)) return true;
                    if( NodeExists(node.Nodes, existsNode))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// チェックされているノードリストを取得する
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="checkedList"></param>
        private void GetCheckedNodeListAll(TreeNodeCollection nodes, List<TreeNode> checkedList)
        {
            try
            {
                foreach(TreeNode node in nodes)
                {
                    if (node.Checked)
                    {
                        checkedList.Add(node);
                    }
                    GetCheckedNodeListAll(node.Nodes, checkedList);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
    /// <summary>
    /// 表示モード列挙体
    /// </summary>
    public enum ProcessEditFormViewMode
    {
        新規プロジェクト, プロジェクト修正, 新規モジュール , モジュール修正
    }
}
