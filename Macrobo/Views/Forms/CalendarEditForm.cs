using Macrobo.Components;
using Macrobo.Models;
using Macrobo.Singleton;
using Macrobo.Utils;
using Macrobo.Views.Controls;
using Newtonsoft.Json;
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

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Calendar作成画面
    /// </summary>
    public partial class CalendarEditForm : BaseForm
    {
        /// <summary>
        /// カレンダーID
        /// </summary>
        private CalendarModel _calendarModel;
        /// <summary>
        /// 日付コントロールを格納
        /// </summary>
        private List<DateControl> _dateCtrl = new List<DateControl>();

        /// <summary>
        /// 基準日
        /// </summary>
        private string _currentMonth;
        /// <summary>
        /// データ変更フラグ
        /// </summary>
        private bool _isDataChanged;
        /// <summary>
        /// Constructor
        /// </summary>
        public CalendarEditForm()
        {
            try
            {
                InitializeComponent();
                _currentMonth = DateTime.Now.ToString("yyyyMM");
                CreateDateControlCollection();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init(int id)
        {
            try
            {
                if (id == 0)
                {
                    _calendarModel = CalendarInfos.GetNewCalendarModel();

                }
                else
                {
                    _calendarModel = (CalendarModel)CalendarInfos.GetInstance().CalendarInfoDic[id][1];
                }
                LoadCalendarForm();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーを読み込む
        /// </summary>
        /// <param name="model"></param>
        private void LoadCalendarForm()
        {
            try
            {
                CalendarIDLbl.Text = "" + _calendarModel.CalendarId;
                DescriptionTextBox.Text = _calendarModel.Description;
                MonthLbl.Text = _currentMonth.Insert(4, "年") + "月";
                string year = _currentMonth.Insert(4, "/").Split('/')[0];
                string month = _currentMonth.Insert(4, "/").Split('/')[1];
                DateTime start = DateTime.Parse(_currentMonth.Insert(4, "/") + "/01");
                DateTime end = DateTime.Parse(_currentMonth.Insert(4, "/") + "/01").AddMonths(1).AddDays(-1);

                foreach(var dayCtrl in _dateCtrl)
                {
                    dayCtrl.Visible = false;
                    dayCtrl.Value = false;
                    if (dayCtrl.Week != DayOfWeek.Saturday && dayCtrl.Week != DayOfWeek.Sunday)
                    {
                        dayCtrl.Value = true;
                    }
                }
                int startIdx = 0;
                for(startIdx = 0; startIdx < _dateCtrl.Count; startIdx++)
                {
                    if(_dateCtrl[startIdx].Week == start.DayOfWeek)
                    {
                        break;
                    }
                }
                int dt = 0;
                for (int i = startIdx; i <  (end.Day + startIdx); i++)
                {
                    dt++;
                    _dateCtrl[i].Visible = true;
                    _dateCtrl[i].Day = dt;
                    string ymd = _currentMonth + string.Format("{0:00}", dt);
                    if (_calendarModel.Value.ContainsKey(ymd))
                    {
                        _dateCtrl[i].Value = _calendarModel.Value[ymd];
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 日付コントロールコレクションを作成する
        /// </summary>
        private void CreateDateControlCollection()
        {
            try
            {
                //週をセットする
                Date1.Week = DayOfWeek.Sunday;
                Date2.Week = DayOfWeek.Monday;
                Date3.Week = DayOfWeek.Tuesday;
                Date4.Week = DayOfWeek.Wednesday;
                Date5.Week = DayOfWeek.Thursday;
                Date6.Week = DayOfWeek.Friday;
                Date7.Week = DayOfWeek.Saturday;

                Date8.Week = DayOfWeek.Sunday;
                Date9.Week = DayOfWeek.Monday;
                Date10.Week = DayOfWeek.Tuesday;
                Date11.Week = DayOfWeek.Wednesday;
                Date12.Week = DayOfWeek.Thursday;
                Date13.Week = DayOfWeek.Friday;
                Date14.Week = DayOfWeek.Saturday;

                Date15.Week = DayOfWeek.Sunday;
                Date16.Week = DayOfWeek.Monday;
                Date17.Week = DayOfWeek.Tuesday;
                Date18.Week = DayOfWeek.Wednesday;
                Date19.Week = DayOfWeek.Thursday;
                Date20.Week = DayOfWeek.Friday;
                Date21.Week = DayOfWeek.Saturday;

                Date22.Week = DayOfWeek.Sunday;
                Date23.Week = DayOfWeek.Monday;
                Date24.Week = DayOfWeek.Tuesday;
                Date25.Week = DayOfWeek.Wednesday;
                Date26.Week = DayOfWeek.Thursday;
                Date27.Week = DayOfWeek.Friday;
                Date28.Week = DayOfWeek.Saturday;

                Date29.Week = DayOfWeek.Sunday;
                Date30.Week = DayOfWeek.Monday;
                Date31.Week = DayOfWeek.Tuesday;
                Date32.Week = DayOfWeek.Wednesday;
                Date33.Week = DayOfWeek.Thursday;
                Date34.Week = DayOfWeek.Friday;
                Date35.Week = DayOfWeek.Saturday;

                Date36.Week = DayOfWeek.Sunday;
                Date37.Week = DayOfWeek.Monday;
                _dateCtrl.Add(Date1);
                _dateCtrl.Add(Date2);
                _dateCtrl.Add(Date3);
                _dateCtrl.Add(Date4);
                _dateCtrl.Add(Date5);
                _dateCtrl.Add(Date6);
                _dateCtrl.Add(Date7);
                _dateCtrl.Add(Date8);
                _dateCtrl.Add(Date9);
                _dateCtrl.Add(Date10);
                _dateCtrl.Add(Date11);
                _dateCtrl.Add(Date12);
                _dateCtrl.Add(Date13);
                _dateCtrl.Add(Date14);
                _dateCtrl.Add(Date15);
                _dateCtrl.Add(Date16);
                _dateCtrl.Add(Date17);
                _dateCtrl.Add(Date18);
                _dateCtrl.Add(Date19);
                _dateCtrl.Add(Date20);
                _dateCtrl.Add(Date21);
                _dateCtrl.Add(Date22);
                _dateCtrl.Add(Date23);
                _dateCtrl.Add(Date24);
                _dateCtrl.Add(Date25);
                _dateCtrl.Add(Date26);
                _dateCtrl.Add(Date27);
                _dateCtrl.Add(Date28);
                _dateCtrl.Add(Date29);
                _dateCtrl.Add(Date30);
                _dateCtrl.Add(Date31);
                _dateCtrl.Add(Date32);
                _dateCtrl.Add(Date33);
                _dateCtrl.Add(Date34);
                _dateCtrl.Add(Date35);
                _dateCtrl.Add(Date36);
                _dateCtrl.Add(Date37);

                foreach(var dctrl in _dateCtrl)
                {
                    dctrl.OnOffButton.Click += (object sender, EventArgs e)=> {
                        _isDataChanged = true;
                    };
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 次の月へ移動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextMonth_Click(object sender, EventArgs e)
        {
            try
            {
                SetCalendarModel();
                SetNextMonth(1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 前の月へ移動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeforeMonth_Click(object sender, EventArgs e)
        {
            try
            {
                SetCalendarModel();
                SetNextMonth(-1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーモデルデータにコントロールから保存する
        /// </summary>
        private void SetCalendarModel()
        {
            try
            {
                foreach(var ctrl in _dateCtrl)
                {
                    bool isSave = false;
                    switch (ctrl.Week)
                    {
                        case DayOfWeek.Saturday:
                        case DayOfWeek.Sunday:
                            if (ctrl.Value)
                            {
                                isSave = true;
                            }
                            break;

                        default:
                            if (!ctrl.Value)
                            {
                                isSave = true;
                            }
                            break;
                    }
                    string ymd = _currentMonth + string.Format("{0:00}", ctrl.Day);
                    if (isSave)
                    {
                        if (_calendarModel.Value.ContainsKey(ymd))
                        {
                            _calendarModel.Value[ymd] = ctrl.Value;
                        }
                        else
                        {
                            _calendarModel.Value.Add(ymd, ctrl.Value);
                        }
                    }
                    else
                    {
                        if (_calendarModel.Value.ContainsKey(ymd))
                        {
                            _calendarModel.Value.Remove(ymd);
                        }
                    }
                }
                _calendarModel.Description = DescriptionTextBox.Text.Trim();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 月を移動する
        /// </summary>
        /// <param name="next"></param>
        private void SetNextMonth(int next)
        {
            try
            {
                DateTime r = DateTime.Parse(_currentMonth.Insert(4, "/") + "/01").AddMonths(next);
                _currentMonth = r.ToString("yyyyMM");
                LoadCalendarForm();
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
                SaveCalendarData(true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーをDBに保存する
        /// </summary>
        /// <param name="dialog">保存確認ダイアログ表示フラグ</param>
        private bool SaveCalendarData(bool dialog)
        {
            try
            {
                if (string.IsNullOrEmpty(DescriptionTextBox.Text.Trim()))
                {
                    this.ShowWarningDialog("カレンダー名未入力", "カレンダー名を入力してください。");
                    return false;
                }
                if (dialog)
                {
                    DialogResult result = this.ShowInfoDialog("カレンダーの保存", "カレンダーを保存しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return false;
                }

                SetCalendarModel();
                CalendarInfos.GetInstance().CreateCalendarValue(_calendarModel.CalendarId, _calendarModel.Description, _calendarModel, _calendarModel.CalendarType);
                if (dialog)
                {
                    this.ShowDialog("カレンダーの保存", "カレンダーを保存しました。");
                }
                _isDataChanged = false;
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダー作成画面の終了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_isDataChanged)
                {
                    DialogResult result = this.ShowInfoDialog("データ未保存の確認", "データは変更されていますが、保存しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No) return;
                    if (!SaveCalendarData(false))
                    {
                        e.Cancel = true;
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
