using Newtonsoft.Json;
using Macrobo.Components;
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// プロジェクト読み込み画面
    /// </summary>
    public partial class LoadProjectForm : BaseForm
    {
        /// <summary>
        /// 0:修正
        /// 1:実行
        /// </summary>
        private LoadProjectMode LoadMode { get; set; }
        public DialogResult LoadResult = DialogResult.None;
        public ProjectModel ProjectModel;
        private ExecDataType ExecDataType = ExecDataType.PROJECT;
        /// <summary>
        /// Constructor
        /// </summary>
        public LoadProjectForm()
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
        /// 初期化処理
        /// </summary>
        /// <param name="mode"></param>
        public void Init(LoadProjectMode mode)
        {
            try
            {
                LoadMode = mode;
                switch (LoadMode)
                {
                    case LoadProjectMode.プロジェクト読込_削除: //0
                        this.Text = "Macrobo - プロジェクト読込・削除";
                        ProjectGrid.Columns[COL_読込.Index].Visible = true;
                        ProjectGrid.Columns[COL_削除.Index].Visible = true;
                        ProjectGrid.Columns[COL_CDATE.Index].Visible = true;
                        break;
                    case LoadProjectMode.プロジェクト実行: //1
                        this.Text = "Macrobo - プロジェクト実行";
                        ProjectGrid.Columns[COL_実行.Index].Visible = true;
                        ProjectGrid.Columns[COL_ショートカット.Index].Visible = true;
                        break;
                    case LoadProjectMode.プロジェクトエクスポート: //2
                        this.Text = "Macrobo - プロジェクトエクスポート";
                        ProjectGrid.Columns[COL_出力.Index].Visible = true;
                        break;
                    case LoadProjectMode.モジュール読込_削除: //3
                        this.Text = "Macrobo - モジュール読込・削除";
                        ProjectGrid.Columns[COL_読込.Index].Visible = true;
                        ProjectGrid.Columns[COL_削除.Index].Visible = true;
                        ProjectGrid.Columns[COL_CDATE.Index].Visible = true;
                        ExecDataType = ExecDataType.MACRO;
                        break;
                    case LoadProjectMode. モジュール実行: //4
                        this.Text = "Macrobo - モジュール実行";
                        ProjectGrid.Columns[COL_実行.Index].Visible = true;
                        ProjectGrid.Columns[COL_ショートカット.Index].Visible = true;
                        ExecDataType = ExecDataType.MACRO;
                        break;
                    case LoadProjectMode. モジュールエクスポート: //5
                        this.Text = "Macrobo - モジュールエクスポート";
                        ProjectGrid.Columns[COL_出力.Index].Visible = true;
                        ExecDataType = ExecDataType.MACRO;
                        break;
                    case LoadProjectMode. モジュール読込: //6
                        this.Text = "Macrobo - モジュール読込";
                        ProjectGrid.Columns[COL_読込.Index].Visible = true;
                        ExecDataType = ExecDataType.MACRO;
                        break;
                }
                switch (ExecDataType)
                {
                    case ExecDataType.MACRO:
                        ProjectGrid.Columns[COL_プロジェクト名.Index].HeaderText = "モジュール名";
                        break;
                }
                LoadProjects();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトグリッドをサイズ変更する
        /// </summary>
        private void ResizeProjectGrid()
        {
            try
            {
                int width = 0;
                foreach (DataGridViewColumn col in ProjectGrid.Columns)
                {
                    if (col.Visible)
                    {
                        width += col.Width;
                    }
                }
                width += ProjectGrid.VScrollBar.Width;
                ProjectGrid.Width = width;
                if(ProjectGrid.Width > this.Width)
                {
                    this.Width = ProjectGrid.Width + 20;
                }
                //バグ???
                ProjectGrid.Location = new Point(this.Width / 2 - (width + ProjectGrid.VScrollBar.Width) / 2, ProjectGrid.Location.Y);
                this.ProjectGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクトを読み込む
        /// </summary>
        private void LoadProjects()
        {
            try
            {
                ProjectGrid.Rows.Clear();

                List<string[]> result = DbUtil.GetInstance().Get_Project_Macro_InfoAll(ExecDataType);

                foreach(var data in result)
                {
                    string id = data[0];
                    string pName = data[1];
                    string cdate = data[2];
                    int row = ProjectGrid.Rows.Add(pName);
                    ProjectGrid.Rows[row].Tag = id;

                    ProjectGrid.Rows[row].Cells[COL_CDATE.Index].Value = cdate;
                    ProjectGrid.Rows[row].Cells[COL_読込.Index] = GetDefaultButtonCell();
                    ProjectGrid.Rows[row].Cells[COL_出力.Index] = GetDefaultButtonCell();
                    ProjectGrid.Rows[row].Cells[COL_削除.Index] = GetDefaultButtonCell();
                    ProjectGrid.Rows[row].Cells[COL_実行.Index] = GetDefaultButtonCell();
                    ProjectGrid.Rows[row].Cells[COL_ショートカット.Index] = GetDefaultButtonCell();
                    switch (LoadMode)
                    {
                        case LoadProjectMode.プロジェクト読込_削除:
                        case LoadProjectMode.モジュール読込_削除:
                            ProjectGrid.Rows[row].Cells[COL_読込.Index].Value = "読込";
                            ProjectGrid.Rows[row].Cells[COL_削除.Index].Value = "削除";
                            break;
                        case LoadProjectMode.プロジェクト実行:
                        case LoadProjectMode.モジュール実行:
                            ProjectGrid.Rows[row].Cells[COL_実行.Index].Value = "実行";
                            ProjectGrid.Rows[row].Cells[COL_ショートカット.Index].Value = "作成";
                            break;
                        case LoadProjectMode.プロジェクトエクスポート:
                        case LoadProjectMode.モジュールエクスポート:
                            ProjectGrid.Rows[row].Cells[COL_出力.Index].Value = "ｴｸｽﾎﾟｰﾄ";
                            break;
                        case LoadProjectMode.モジュール読込:
                            ProjectGrid.Rows[row].Cells[COL_読込.Index].Value = "読込";
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
        /// DataGridViewButtonCellを取得する
        /// </summary>
        /// <returns></returns>
        private DataGridViewCell GetDefaultButtonCell()
        {
            try
            {
                DataGridViewButtonCell bc = new DataGridViewButtonCell();
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = Color.FromArgb(255, 0, 64, 64);
                bc.Style.SelectionBackColor = Color.FromArgb(255, 0, 64, 64);
                bc.Style.ForeColor = Color.White;
                bc.Style.SelectionForeColor = Color.White;
                return bc;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 読込 or 削除を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if(e.ColumnIndex == COL_出力.Index)
                {
                    ExportProject(e.RowIndex);
                }
                if (e.ColumnIndex == COL_読込.Index
                    || e.ColumnIndex == COL_実行.Index)
                {
                    LoadProject(e.RowIndex);
                    Close();
                }
                if (e.ColumnIndex == COL_削除.Index)
                {
                    RemoveProject(e.RowIndex);
                }
                if (e.ColumnIndex == COL_ショートカット.Index)
                {
                    CreateShortcut(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトを出力します。
        /// </summary>
        /// <param name="rowIndex"></param>
        private void ExportProject(int rowIndex)
        {
            try
            {
                string projName = "" + ProjectGrid.Rows[rowIndex].Cells[COL_プロジェクト名.Index].Value;
                SaveFileDialog sfd = new SaveFileDialog();

                string ftype1 = "";
                string ftype2 = "";
                switch (ExecDataType)
                {
                    case ExecDataType.PROJECT:
                        ftype1 = "mcrp";
                        ftype2 = "MCRP";
                        break;
                    case ExecDataType.MACRO:
                        ftype1 = "mcrm";
                        ftype2 = "MCRM";
                        break;
                }
                sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + FileUtil.GetInvalidEscapeFileName(projName, "_") + "." + ftype1;
                sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                sfd.Filter = ftype2 + "ファイル(*." + ftype1 + ")| *." + ftype1;
                sfd.FilterIndex = 2;
                sfd.Title = "保存先のフォルダを選択してください";
                sfd.RestoreDirectory = true;
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string jsonString = GetProjectJsonString("" + ProjectGrid.Rows[rowIndex].Tag, ExecDataType);
                    using(StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default))
                    {
                        sw.WriteLine(jsonString);
                    }
                    this.ShowDialog("ファイルエクスポート実行", "ファイルをエクスポートしました。");
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ショートカットを作成する
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CreateShortcut(int rowIndex)
        {
            try
            {
                string projName = "" + ProjectGrid.Rows[rowIndex].Cells[COL_プロジェクト名.Index].Value;
                string fileName = FileUtil.GetInvalidEscapeFileName(projName, " ");
                string shortcutPath = System.IO.Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), fileName + @".lnk");
                if (System.IO.File.Exists(shortcutPath))
                {
                    DialogResult delQ = this.ShowInfoDialog("削除の確認", "既に存在するショートカットを削除し、新たに作成しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (delQ == DialogResult.Yes)
                    {
                        try
                        {
                            System.IO.File.Delete(shortcutPath);
                        }
                        catch (Exception ex)
                        {
                            this.ShowErrorDialog("削除エラー", ex.Message);
                        }
                    }
                }
                string targetPath = Application.ExecutablePath;
                Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
                dynamic shell = Activator.CreateInstance(t);
                var shortcut = shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = targetPath;
                string arg = "-p";
                if(ExecDataType == ExecDataType.MACRO)
                {
                    arg = "-m";
                }
                shortcut.Arguments = arg + " " + ProjectGrid.Rows[rowIndex].Tag;
                shortcut.IconLocation = Application.ExecutablePath + ",0";
                shortcut.Save();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);
                this.ShowDialog("作成成功", "ショートカットを作成しました。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクトを削除する
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RemoveProject(int rowIndex)
        {
            try
            {
                string name = "";
                switch (ExecDataType)
                {
                    case ExecDataType.PROJECT:
                        name = "プロジェクト";
                        break;
                    case ExecDataType.MACRO:
                        name = "モジュール";
                        break;
                }
                string projName = "" + ProjectGrid.Rows[rowIndex].Cells[COL_プロジェクト名.Index].Value;
                DialogResult result = this.ShowInfoDialog("削除確認", name + "[" + projName + "]を削除しますか?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No) return;
                DeleteProject("" + ProjectGrid.Rows[rowIndex].Tag, ExecDataType);
                this.ShowDialog("削除成功", name + "を削除しました。");
                LoadProjects();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクトを読み込む
        /// </summary>
        /// <param name="rowIndex"></param>
        private void LoadProject(int rowIndex)
        {
            try
            {
                ProjectModel = GetProject("" + ProjectGrid.Rows[rowIndex].Tag, ExecDataType);
                if (ProjectModel != null)
                {
                    LoadResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトのJsonStringを取得する
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetProjectJsonString(string projectId, ExecDataType type)
        {
            try
            {
                string name = "";
                switch (type)
                {
                    case ExecDataType.PROJECT:
                        name = "PROJECT";
                        break;
                    case ExecDataType.MACRO:
                        name = "MACRO";
                        break;
                }
                string result = "";
                result = DbUtil.GetInstance().Get_Project_Macro_Value(name, projectId);

                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトを取得する
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ProjectModel GetProject(string projectId, ExecDataType type)
        {
            try
            {
                return GetProjectFromJsonString(GetProjectJsonString(projectId, type));
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// JsonStringからProjectModelへ変換する
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static ProjectModel GetProjectFromJsonString(string jsonString)
        {
            try
            {
                ProjectModel model = JsonConvert.DeserializeObject<ProjectModel>(jsonString);

                return RebuildProject(model);
                
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクトを再構築する
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProjectModel RebuildProject(ProjectModel model)
        {
            try
            {
                List<ProcessModel> allModel = model.GetOneDimensionProcessModelList();

                foreach (var ary in model.ArrayVariableList)
                {
                    ary.Value.ArrayToList();
                }
                foreach (var proc in model.ProcessModelList)
                {
                    proc.ByteArrayToBitmap(true);
                    //データはシリアライズされている別オブジェクトなので、IDを元に参照を再設定する
                    if (!string.IsNullOrEmpty(proc.NextProcessId))
                    {
                        proc.NextProcess = allModel.FirstOrDefault(a => a.ProcessId == proc.NextProcessId) ?? ProcessModel.GetEndProcessModel();
                    }
                    else
                    {
                        proc.NextProcess = ProcessModel.GetEndProcessModel();
                    }
                    //データはシリアライズされている別オブジェクトなので、IDを元に参照を再設定する
                    if (!string.IsNullOrEmpty(proc.ErrorProcessId))
                    {
                        proc.ErrorProcess = allModel.FirstOrDefault(a => a.ProcessId == proc.ErrorProcessId) ?? ProcessModel.GetErrorProcessModel();
                    }
                    else
                    {
                        proc.ErrorProcess = ProcessModel.GetErrorProcessModel();
                    }
                }
                foreach (var macro in model.MacroModelList)
                {
                    foreach (var ary in macro.ArrayVariableList)
                    {
                        ary.Value.ArrayToList();
                    }
                    foreach (var proc in macro.ProcessModelList)
                    {
                        proc.ByteArrayToBitmap(true);
                        //データはシリアライズされている別オブジェクトなので、IDを元に参照を再設定する
                        if (!string.IsNullOrEmpty(proc.NextProcessId))
                        {
                            proc.NextProcess = allModel.FirstOrDefault(a => a.ProcessId == proc.NextProcessId) ?? ProcessModel.GetEndProcessModel();
                        }
                        else
                        {
                            proc.NextProcess = ProcessModel.GetEndProcessModel();
                        }
                        //データはシリアライズされている別オブジェクトなので、IDを元に参照を再設定する
                        if (!string.IsNullOrEmpty(proc.ErrorProcessId))
                        {
                            proc.ErrorProcess = allModel.FirstOrDefault(a => a.ProcessId == proc.ErrorProcessId) ?? ProcessModel.GetErrorProcessModel();
                        }
                        else
                        {
                            proc.ErrorProcess = ProcessModel.GetErrorProcessModel();
                        }
                    }
                }

                return model;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロジェクトを削除する
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="type"></param>
        private void DeleteProject(string projectId, ExecDataType type)
        {
            try
            {
                DbUtil.GetInstance().Delete_Project_Macro_Info(type, projectId);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// プロジェクト画面の表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadProjectForm_Shown(object sender, EventArgs e)
        {
            try
            {
                ResizeProjectGrid();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
