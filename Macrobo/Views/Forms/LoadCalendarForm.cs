using Macrobo.Components;
using Macrobo.Models;
using Macrobo.Models.Enums;
using Macrobo.Singleton;
using Macrobo.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// カレンダー作成・修正・削除ボタン
    /// </summary>
    public partial class LoadCalendarForm : BaseForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoadCalendarForm()
        {
            try
            {
                InitializeComponent();
                LoadCalendarData();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダー情報を読み込む
        /// </summary>
        private void LoadCalendarData()
        {
            try
            {
                CalendarGrid.Rows.Clear();

                foreach(var data in CalendarInfos.GetInstance().CalendarInfoDic)
                {
                    int row = CalendarGrid.Rows.Add(data.Key, (CalendarType)data.Value[3], "" + data.Value[0]);

                    DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                    cell1.FlatStyle = FlatStyle.Flat;
                    cell1.Style.BackColor = Color.FromArgb(255, 0, 64, 64);
                    cell1.Style.SelectionBackColor = Color.FromArgb(255, 0, 64, 64);
                    cell1.Style.ForeColor = Color.White;
                    cell1.Style.SelectionForeColor = Color.White;
                    CalendarGrid.Rows[row].Cells[COL_修正.Index] = cell1;
                    CalendarGrid.Rows[row].Cells[COL_修正.Index].Value = "修正";

                    cell1 = new DataGridViewButtonCell();
                    cell1.FlatStyle = FlatStyle.Flat;
                    cell1.Style.BackColor = Color.FromArgb(255, 0, 64, 64);
                    cell1.Style.SelectionBackColor = Color.FromArgb(255, 0, 64, 64);
                    cell1.Style.ForeColor = Color.White;
                    cell1.Style.SelectionForeColor = Color.White;
                    CalendarGrid.Rows[row].Cells[COL_削除.Index] = cell1;
                    CalendarGrid.Rows[row].Cells[COL_削除.Index].Value = "削除";
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        // <summary>
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
        /// カレンダー新規作成ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCalendarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CalendarEditForm form = new CalendarEditForm();
                //nullは新規作成
                form.Init(0);
                form.ShowDialog(this);
                LoadCalendarData();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// WEBカレンダー新規作成ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateWebCalendarButton_Click(object sender, EventArgs e)
        {
            try
            {
                WebCalendarEditForm form = new WebCalendarEditForm();
                form.Init(0);
                form.ShowDialog(this);
                LoadCalendarData();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーセルのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //修正
                if(e.RowIndex >= 0 && e.ColumnIndex == COL_修正.Index)
                {
                    switch (CalendarGrid.Rows[e.RowIndex].Cells[COL_CALENDARTYPE.Index].Value)
                    {
                        case CalendarType.固定カレンダー:
                            {
                                CalendarEditForm form = new CalendarEditForm();
                                //nullは新規作成
                                form.Init(int.Parse("" + CalendarGrid.Rows[e.RowIndex].Cells[COL_ID.Index].Value));
                                form.ShowDialog(this);
                            }
                            break;
                        default:
                            {
                                WebCalendarEditForm form = new WebCalendarEditForm();
                                //nullは新規作成
                                form.Init(int.Parse("" + CalendarGrid.Rows[e.RowIndex].Cells[COL_ID.Index].Value));
                                form.ShowDialog(this);
                            }
                            break;
                    }

                    LoadCalendarData();
                }
                //削除
                if (e.RowIndex >= 0 && e.ColumnIndex == COL_削除.Index)
                {
                    DialogResult result = this.ShowWarningDialog("カレンダーの削除の確認", "カレンダーを削除すると、利用中のプロジェクトに障害が発生する可能性がありますが、続行しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No) return;

                    CalendarInfos.GetInstance().RemoveByKey(int.Parse("" + CalendarGrid.Rows[e.RowIndex].Cells[COL_ID.Index].Value));


                    this.ShowDialog("カレンダーの削除", "カレンダーを削除しました。");

                    LoadCalendarData();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// カレンダーのインポート処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                string kana = "カレンダー";
                string file1 = "mcrc";
                string file2 = "MCRC";
               
                var dialog = new CommonOpenFileDialog(kana + "ファイルの選択");
                // ファイル選択モード
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                dialog.Filters.Add(new CommonFileDialogFilter(file2 + "ファイル(*." + file1 + ")", "*." + file1));
                if (dialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
                {
                    CalendarModel model = null;
                    //新取込
                    using (StreamReader sr = new StreamReader(dialog.FileName, Encoding.Default))
                    {
                        string jsonString = sr.ReadToEnd();

                        try
                        {
                            model = JsonConvert.DeserializeObject<CalendarModel>(jsonString);
                        }
                        catch (Exception){}
                    }
                    if(model == null)
                    {
                        using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            BinaryFormatter f = new BinaryFormatter();
                            string jsonString = (string)f.Deserialize(fs);
                            jsonString = CryptUtil.DecryptString(jsonString, StringValue.CRYPT_PASSWORD);
                            model = JsonConvert.DeserializeObject<CalendarModel>(jsonString);
                        }
                    }

                    //IDを更新する
                    model.CalendarId = CalendarInfos.GetNewCalendarModel().CalendarId;

                    DialogResult result = this.ShowInfoDialog("保存確認", kana + "をインポートしますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;

                    CalendarInfos.GetInstance().CreateCalendarValue(model.CalendarId, model.Description, model, model.CalendarType);
                    LoadCalendarData();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Exportボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CalendarGrid.Rows.Count == 0) return;
                if (CalendarGrid.SelectedRows.Count == 0) return;
                string id = "" + CalendarGrid.SelectedRows[0].Cells[COL_ID.Index].Value;
                SaveFileDialog sfd = new SaveFileDialog();

                string ftype1 = "mcrc";
                string ftype2 = "MCRC";

                sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_CALENDAR_" + id + "." + ftype1;
                sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                sfd.Filter = ftype2 + "ファイル(*." + ftype1 + ")| *." + ftype1;
                sfd.FilterIndex = 2;
                sfd.Title = "保存先のフォルダを選択してください";
                sfd.RestoreDirectory = true;
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string jsonString = JsonConvert.SerializeObject((CalendarModel)CalendarInfos.GetInstance().CalendarInfoDic[int.Parse(id)][1], new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    });
                    using(StreamWriter sw = new StreamWriter(sfd.FileName, false , Encoding.Default))
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

    }
}
