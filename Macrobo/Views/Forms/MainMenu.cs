using Macrobo.Utils.Gui;
using Macrobo.Components;
using Macrobo.Logics;
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Utils;
using Macrobo.Views;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Macrobo.Views.Forms;
using Macrobo.Singleton;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Macrobo
{
    /// <summary>
    /// Author : M.Yoshida
    /// 自動実行処理システム
    /// メインメニュー
    /// </summary>
    public partial class MainMenu : BaseForm
    {
        /// <summary>
        /// ログファイルパス
        /// </summary>
        private string LogFilePath { get; set; }
        /// <summary>
        /// Shiftキーのダウンフラグ
        /// </summary>
        private bool ShiftKeyDown { get; set; }
        /// <summary>
        /// Controlキーのダウンフラグ
        /// </summary>
        private bool ControlKeyDown { get; set; }
        /// <summary>
        /// Sキーのダウンフラグ
        /// </summary>
        private bool SKeyDown { get; set; }
        /// <summary>
        /// マクロ実行クラス
        /// </summary>
        private MacroExecutor _macroExecutor;
        /// <summary>
        /// マクロ実行スレッド
        /// </summary>
        private Thread _execThread;
        /// <summary>
        /// 自動モード
        /// </summary>
        private bool _autoMode = false;
        /// <summary>
        /// キーボードフック
        /// </summary>
        private KeyboardHook _keyboardHook;
        /// <summary>
        /// Constructor
        /// </summary>
        public MainMenu()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 新規作成ﾎﾞﾀﾝのｸﾘｯｸｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewProjectButton_Click(object sender, EventArgs e)
        {
            try
            {

                ProcessEditForm form = new ProcessEditForm();
                ProjectModel projectModel = new ProjectModel();
                projectModel.Name = StringValue.NEW_PROJECT_NAME;
                projectModel.ExecDataType = ExecDataType.PROJECT;
                ProcessModel model = new ProcessModel();
                model.Name = StringValue.PROCESS_NAME;
                projectModel.ProcessModelList.Add(model);
                projectModel.SetNodeId(model.ProcessId, "");
                form.Init(ProcessEditFormViewMode.新規プロジェクト, projectModel);
                this.Hide();
                form.ShowDialog(this);
                this.Show();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトを実行する
        /// </summary>
        /// <param name="projId"></param>
        internal void StartProject(string projId, ExecDataType type, MacroStartType startType)
        {
            try
            {
                _autoMode = true;
                ProjectModel model = LoadProjectForm.GetProject(projId, type);
                StartProject(model, startType);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 修正ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEditProject(this, 0, MacroStartType.EDITORSTART);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクト修正画面を起動する
        /// mode 0:プロジェクト修正 1:モジュール修正
        /// </summary>
        public static void ShowEditProject(BaseForm parentForm, int mode, MacroStartType startType)
        {
            try
            {
                LoadProjectForm form = new LoadProjectForm();
                switch (mode)
                {
                    case 0:
                        form.Init(0);
                        break;
                    case 1:
                        form.Init(LoadProjectMode.モジュール読込_削除);
                        break;
                }
                form.ShowDialog();
                if (form.LoadResult != DialogResult.OK) return;

                ProcessEditForm procForm = new ProcessEditForm();
                switch (mode)
                {
                    case 0:
                        procForm.Init(ProcessEditFormViewMode.プロジェクト修正, form.ProjectModel);
                        break;
                    case 1:
                        procForm.Init(ProcessEditFormViewMode.モジュール修正, form.ProjectModel);
                        break;
                }
                procForm.ShowDialog(parentForm);
                parentForm.Show();
                ShowEditProject(parentForm, mode, startType);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクトを実行します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProjectForm form = new LoadProjectForm();
                form.Init(LoadProjectMode.プロジェクト実行);
                form.ShowDialog();
                if (form.LoadResult != DialogResult.OK) return;

                DialogResult result = this.ShowInfoDialog("プロジェクト実行確認", "プロジェクトを実行しますか？");
                if (result == DialogResult.No) return;
                StartProject(form.ProjectModel, MacroStartType.MENUSTART);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュールを開始する
        /// </summary>
        /// <param name="projectModel"></param>
        private void StartProject(ProjectModel projectModel, MacroStartType macroStartType)
        {
            try
            {
                List<string> errorList = projectModel.CheckMacroInput();
                if (errorList.Count > 0)
                {
                    if (errorList.Count > 0)
                    {
                        string msg = "";
                        foreach (var m in errorList)
                        {
                            if (string.IsNullOrEmpty(msg))
                            {
                                msg = m;
                            }
                            else
                            {
                                msg += "\r\n" + m;
                            }
                            this.ShowErrorDialog(StringValue.PROCESS_NAME + "登録エラー", msg);
                        }
                        return;
                    }
                }
                if (!_autoMode)
                {
                    Hide();
                }

                if(_keyboardHook != null)
                {
                    _keyboardHook.KeyboardHooked -= KeyboardHook_KeyboardHooked;
                    _keyboardHook.Dispose();
                }
                _keyboardHook = new KeyboardHook();
                _keyboardHook.KeyboardHooked += KeyboardHook_KeyboardHooked;
                _execThread = new Thread(new ThreadStart(() => {
                    _macroExecutor = new MacroExecutor(projectModel, macroStartType);
                    _macroExecutor.OnLogEvent = SetLogText;
                    LogFilePath = Program.EXEC_LOG_PATH;
                    if (!Directory.Exists(LogFilePath))
                    {
                        Directory.CreateDirectory(LogFilePath);
                    }
                    LogFilePath += @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + FileUtil.GetInvalidEscapeFileName(projectModel.Name, " ") + ".log";
                    _macroExecutor.Run(true);
                    if (!_autoMode)
                    {
                        Invoke(new MethodInvoker(() => {
                            _keyboardHook.KeyboardHooked -= KeyboardHook_KeyboardHooked;
                            _keyboardHook.Dispose();
                            Show();
                        }));
                    }
                }));
                _execThread.Start();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ログテキスト出力を行う
        /// </summary>
        /// <param name="msg"></param>
        private void SetLogText(LogType logType, string msg, ProjectModel projectModel)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(LogFilePath, true, Encoding.Default))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "][" + logType + "] " + msg);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キー入力をクリアする
        /// </summary>
        public void ClearKeyInput()
        {
            try
            {
                ShiftKeyDown = false;
                ControlKeyDown = false;
                SKeyDown = false;
               
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
                SetKeyInputFlag(e);
                if (ShiftKeyDown && ControlKeyDown && SKeyDown)
                {
                    if (_execThread != null && _execThread.IsAlive)
                    {
                        if (_macroExecutor != null)
                        {
                            _macroExecutor._stopFlag = true;
                            ClearKeyInput();
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
        /// キーダウン/アップフラグをセットする
        /// </summary>
        /// <param name="e"></param>
        private void SetKeyInputFlag(KeyboardHookedEventArgs e)
        {
            try
            {
                if (e.KeyCode.ToString() == "LShiftKey" || e.KeyCode.ToString() == "RShiftKey")
                {
                    ShiftKeyDown = e.UpDown == Macrobo.Utils.Gui.KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "LControlKey" || e.KeyCode.ToString() == "RControlKey")
                {
                    ControlKeyDown = e.UpDown == Macrobo.Utils.Gui.KeyboardUpDown.Down;
                }
                if (e.KeyCode.ToString() == "S")
                {
                    SKeyDown = e.UpDown == Macrobo.Utils.Gui.KeyboardUpDown.Down;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトエクスポート画面を起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProjectForm form = new LoadProjectForm();
                form.Init(LoadProjectMode.プロジェクトエクスポート);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトインポートボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportProject_Click(object sender, EventArgs e)
        {
            try
            {
                ImportFromFile(ExecDataType.PROJECT);
                
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog("インポートエラー", "プロジェクトファイルの読み込みに失敗しました。\r\n\r\n" + ex.Message);
            }
        }
        /// <summary>
        /// ファイルからプロジェクト、又はモジュールをインポートします。
        /// </summary>
        /// <param name="type"></param>
        private void ImportFromFile(ExecDataType type)
        {
            try
            {
                string kana = "プロジェクト";
                string file1 = "mcrp";
                string file2 = "MCRP";
                switch (type)
                {
                    case ExecDataType.MACRO:
                        kana = "モジュール";
                        file1 = "mcrm";
                        file2 = "MCRM";
                        break;
                }
                var dialog = new CommonOpenFileDialog(kana + "ファイルの選択");
                // ファイル選択モード
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                dialog.Filters.Add(new CommonFileDialogFilter(file2 + "ファイル(*." + file1+")", "*."+ file1));
                if (dialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
                {
                    ProjectModel model = null;

                    //平文フォーマット
                    using (StreamReader sr = new StreamReader(dialog.FileName, Encoding.Default))
                    {
                        try
                        {
                            string jsonString = sr.ReadToEnd();
                            model = JsonConvert.DeserializeObject<ProjectModel>(jsonString);
                            model = LoadProjectForm.RebuildProject(model);
                        }
                        catch (Exception) { }
                    }

                    //新フォーマット
                    if (model == null)
                    {
                        using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            try
                            {
                                BinaryFormatter f = new BinaryFormatter();
                                model = (ProjectModel)f.Deserialize(fs);
                                model = LoadProjectForm.RebuildProject(model);
                            }
                            catch (Exception) { }
                        }
                    }

                    //旧フォーマット
                    if (model == null)
                    {
                        using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            BinaryFormatter f = new BinaryFormatter();
                            string jsonString = (string)f.Deserialize(fs);
                            jsonString = CryptUtil.DecryptString(jsonString, StringValue.CRYPT_PASSWORD);
                            model = LoadProjectForm.GetProjectFromJsonString(jsonString);
                        }
                    }

                    switch (type)
                    {
                        case ExecDataType.PROJECT:
                            if (model.ExecDataType != ExecDataType.PROJECT)
                            {
                                throw new Exception(kana + "ファイルではありません。");
                            }
                            break;
                        case ExecDataType.MACRO:
                            if (model.ExecDataType != ExecDataType.MACRO)
                            {
                                throw new Exception(kana + "ファイルではありません。");
                            }
                            break;
                    }
                    model.Name = DateTime.Now.ToString("yyyyMMddHHmmss_") + model.Name;
                    //IDを更新する
                    model.RenewId();

                    DialogResult result = this.ShowInfoDialog("保存確認", kana + "をインポートしますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                    ProcessEditForm.SaveProject(model);
                    this.ShowDialog("保存成功", kana + "を保存しました。");
                    switch (type)
                    {
                        case ExecDataType.PROJECT:
                            ShowEditProject(this, 0, MacroStartType.EDITORSTART);
                            break;
                        case ExecDataType.MACRO:
                            ShowEditProject(this, 1, MacroStartType.EDITORSTART);
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
        /// モジュール作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowModuleCreateForm(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュールを新規作成する
        /// </summary>
        /// <param name="parentForm"></param>
        public static void ShowModuleCreateForm(BaseForm parentForm)
        {

            try
            {
                ProcessEditForm form = new ProcessEditForm();
                ProjectModel projectModel = new ProjectModel();
                projectModel.Name = StringValue.NEW_MACRO_NAME;
                projectModel.ExecDataType = ExecDataType.MACRO;
                ProcessModel model = new ProcessModel();
                model.Name = StringValue.PROCESS_NAME;
                projectModel.ProcessModelList.Add(model);
                projectModel.SetNodeId(model.ProcessId, "");
                form.Init(ProcessEditFormViewMode.新規モジュール, projectModel);
                parentForm.Hide();
                form.ShowDialog(parentForm);
                parentForm.Show();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュール修正ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModuleButton_Click(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    ShowEditProject(this, 1, MacroStartType.EDITORSTART);
                }
                catch (Exception ex)
                {
                    throw Program.ThrowException(ex);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュール実行ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProjectForm form = new LoadProjectForm();
                form.Init(LoadProjectMode. モジュール実行);
                form.ShowDialog();
                if (form.LoadResult != DialogResult.OK) return;
                DialogResult result = this.ShowInfoDialog("モジュール実行確認", "モジュールを実行しますか？");
                StartProject(form.ProjectModel, MacroStartType.MENUSTART);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュールのエクスポートボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportMacroButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProjectForm form = new LoadProjectForm();
                form.Init(LoadProjectMode. モジュールエクスポート);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モジュールのインポートボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportMacroButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportFromFile(ExecDataType.MACRO);
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog("インポートエラー", "モジュールファイルの読み込みに失敗しました。\r\n\r\n" + ex.Message);
            }
        }
        /// <summary>
        /// メインメニューの表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Shown(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Program.USERPROFILE_PATH + @"\backup_db.sqlite"))
                {
                    DialogResult result = this.ShowInfoDialog("データ復元の確認", "前回終了時に異常が発生した可能性があります。\r\n前回正常終了時にデータを復旧しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        System.IO.File.Delete(Program.USERPROFILE_PATH + @"\db.sqlite");
                        System.IO.File.Move(Program.USERPROFILE_PATH + @"\backup_db.sqlite", Program.USERPROFILE_PATH + @"\db.sqlite");
                    }
                    else
                    {
                        System.IO.File.Delete(Program.USERPROFILE_PATH + @"\backup_db.sqlite");
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        

        /// <summary>
        /// ﾌｫｰﾑの終了時ｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DbUtil db = DbUtil.GetInstance();
                db.Vacuum();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダー管理を起動します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCalendarForm form = new LoadCalendarForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 共通設定を起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingButton_Click(object sender, EventArgs e)
        {
            try
            {
                SettingForm form = new SettingForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// データベースエクスポートのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                string dbName = "macrobo-db-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".db";
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.FileName = dbName;
                sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                sfd.Filter = "DBファイル(*.db)| *.db";
                sfd.FilterIndex = 2;
                sfd.Title = "保存先のフォルダを選択してください";
                sfd.RestoreDirectory = true;
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.Copy(Program.USERPROFILE_PATH + @"\db.sqlite", sfd.FileName);
                    this.ShowDialog("ファイルエクスポート実行", "ファイルをエクスポートしました。");
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// データベースをインポートする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog("DBファイルの選択");
                // ファイル選択モード
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                dialog.Filters.Add(new CommonFileDialogFilter("DBファイル(*.db)", "*.db"));
                if (dialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
                {
                    try
                    {
                        string dataSource = "Data Source=" + dialog.FileName + @";Version=3;";
                        using (SQLiteConnection con = new SQLiteConnection(dataSource))
                        {
                            con.Open();
                            StringBuilder sql = new StringBuilder();
                            sql.Append("SELECT * FROM PROJECT_INFO LIMIT 1");

                            using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                            {
                                command.ExecuteReader();
                            }
                        }
                    }
                    catch (Exception){
                        this.ShowInfoDialog("データ不整合エラー", "選択されたファイルはMacrobo用データベースではありません。", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    DialogResult result = this.ShowWarningDialog("データベースインポート", "データベースをインポートすると既存のデータベースは消去されます。\r\nインポートしますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;

                    System.IO.File.Copy(dialog.FileName, Program.USERPROFILE_PATH + @"\db.sqlite", true);
                    this.ShowDialog("インポートの成功", "データベースインポートに成功しました。\r\nシステムを再起動します。");

                    this.Close();

                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = Application.ExecutablePath;
                    Process.Start(info);

                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ログビューワーを起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogViewerButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExecLogForm form = new ExecLogForm();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
