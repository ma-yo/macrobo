using Macrobo.Components;
using Macrobo.Models;
using Macrobo.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// 実行ログ確認フォーム
    /// </summary>
    public partial class ExecLogForm : BaseForm
    {
        List<ExecuteLogModel> _logData;
        /// <summary>
        /// Constructor
        /// </summary>
        public ExecLogForm()
        {

            try
            {
                InitializeComponent();
                DayTaniRadio.Checked = true;
                EndRadio.Checked = true;
                DayTaniRadio.CheckedChanged += FilterRadio_CheckedChanged;
                MonthTaniRadio.CheckedChanged += FilterRadio_CheckedChanged;
                EndRadio.CheckedChanged += FilterRadio_CheckedChanged;
                ErrorRadio.CheckedChanged += FilterRadio_CheckedChanged;
                AllRadio.CheckedChanged += FilterRadio_CheckedChanged;
                LoadData();
                CreateProjectGrid();
                CreateChart();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }



        }
        /// <summary>
        /// FilterRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (radio.Checked)
                {
                    CreateChart();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// チャートデータを作成する
        /// </summary>
        private void CreateChart()
        {
            try
            {
                ExecLogChart.Series[0].Points.Clear();

                List<string> chartModel = GetSelectedProjects();

                if (MonthTaniRadio.Checked)
                {
                    this.ExecLogChart.Titles[0].Text = "月間稼働チャート";
                    this.ExecLogChart.ChartAreas[0].AxisX.Title = "Month";
                    var pointsData = from a in _logData
                                     where chartModel.Contains(a.ExecId) && ExecuteFilter(a.Result)
                                     group a by new
                                     {
                                         YM = a.StartTime.Substring(0, 7)
                                     } into b
                                     select new { b.Key, TotalTime = (int)(b.Sum(c => c.ExecTime)) };

                    ExecLogChart.Series[0]["PixelPointWidth"] = "8";

                    foreach (var p in pointsData.OrderBy(a => a.Key.YM))
                    {
                        int point = ExecLogChart.Series[0].Points.AddXY(int.Parse(p.Key.YM.Substring(2, 2)) + "/" + int.Parse(p.Key.YM.Substring(5, 2)), p.TotalTime);
                    }
                }
                if (DayTaniRadio.Checked)
                {
                    this.ExecLogChart.Titles[0].Text = "日別稼働チャート";
                    this.ExecLogChart.ChartAreas[0].AxisX.Title = "Day";
                    var pointsData = from a in _logData
                                     where chartModel.Contains(a.ExecId) && ExecuteFilter(a.Result)
                                     group a by new
                                     {
                                         YM = a.StartTime.Substring(0, 10)
                                     } into b
                                     select new { b.Key, TotalTime = (int)(b.Sum(c => c.ExecTime)) };

                    ExecLogChart.Series[0]["PixelPointWidth"] = "8";

                    foreach (var p in pointsData.OrderBy(a => a.Key.YM))
                    {
                        int point = ExecLogChart.Series[0].Points.AddXY(int.Parse(p.Key.YM.Substring(5, 2)) + "/" + int.Parse(p.Key.YM.Substring(8, 2)), p.TotalTime);
                    }
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択されているプロジェクトを取得する
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelectedProjects()
        {
            try
            {
                List<string> chartModel = new List<string>();
                foreach (DataGridViewRow row in ProjectGrid.Rows)
                {
                    if ((bool)row.Cells[COL_選択.Index].Value
                        || (bool)row.Cells[COL_選択.Index].EditedFormattedValue)
                    {
                        chartModel.Add((string)row.Tag);
                    }
                }
                return chartModel;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 抽出条件を適用する
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ExecuteFilter(int result)
        {
            try
            {
                if (EndRadio.Checked && result == 1)
                {
                    return true;
                }
                if (ErrorRadio.Checked && (result == 2 || result == 3))
                {
                    return true;
                }

                if (AllRadio.Checked)
                {
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
        /// プロジェクトグリッドを作成する
        /// </summary>
        private void CreateProjectGrid()
        {
            try
            {
                ProjectGrid.Rows.Clear();
                var linq = from a in _logData group a by new { a.ExecId, a.ExecName } into b select b;
                foreach (var data in linq)
                {
                    int row = ProjectGrid.Rows.Add(true, data.Key.ExecName);
                    ProjectGrid.Rows[row].Tag = data.Key.ExecId;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// データをロードする
        /// </summary>
        private void LoadData()
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddYears(-3);
                DateTime endDate = DateTime.Now;
                _logData = DbUtil.GetInstance().GetExecuteLog(fromDate, endDate);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ProjectGridのCellDirtyStateChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                ProjectGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ProjectGridのCellClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if(e.ColumnIndex == COL_選択.Index)
                {
                    CreateChart();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ProjectGridのCellDoubleClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ProjectGrid_CellContentClick(sender, e);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "保存先のファイルを選択してください";
                dialog.FileName = "macrobo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
                dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                dialog.Filter = "LOGファイル(*.log)|*.log|すべてのファイル(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using(StreamWriter sw = new StreamWriter(dialog.FileName, false, Encoding.Default))
                    {
                        List<string> chartModel = GetSelectedProjects();
                        var logdata = from a in _logData
                                         where chartModel.Contains(a.ExecId) && ExecuteFilter(a.Result)
                                         orderby a.Cdate
                                         select a;

                        foreach (var log in logdata)
                        {
                            sw.WriteLine("[" + log.Cdate + "]"
                                + "\t" + "[ID]" + "\t" + log.ExecId
                                + "\t" + "[NAME]" + "\t" + log.ExecName
                                + "\t" + "[START]" + "\t" + log.StartTime
                                + "\t" + "[END]" + "\t" + log.EndTime
                                + "\t" + "[TIME]" + "\t" + log.ExecTime
                                + "\t" + "[RESULT]" + "\t" + log.Result
                                + "\t" + "[DESCRIPTION]" + "\t" + log.Description);
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
        /// 選択されているログをクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogDeleteButton_Click(object sender, EventArgs e)
        {

            try
            {
                List<string> idList = GetSelectedProjects();
                if(idList.Count == 0)
                {
                    this.ShowInfoDialog( "未選択" , "削除するプロジェクトを選択してください。");
                    return;
                }
                else
                {
                    DialogResult result = this.ShowInfoDialog( "削除の確認", "選択ログを消去しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;

                    DbUtil.GetInstance().DeleteExecuteLog(idList);
                    this.ShowDialog("ログ削除成功", "ログを削除しました。");
                    LoadData();
                    CreateProjectGrid();
                    CreateChart();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルログフォルダを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileLogButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.Directory.Exists(Program.EXEC_LOG_PATH))
                {
                    FileUtil.ViewFile(Program.EXEC_LOG_PATH);
                }
                else
                {
                    this.ShowDialog("ログ未検出", "ログ出力フォルダが見つかりません。");
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
