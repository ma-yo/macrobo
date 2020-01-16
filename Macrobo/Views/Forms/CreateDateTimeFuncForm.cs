using Macrobo.Components;
using Macrobo.Models;
using Macrobo.Singleton;
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

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// 日付関数の作成画面
    /// </summary>
    public partial class CreateDateTimeFuncForm : BaseForm
    {
        private List<BaseRadioButton> _formatRadioList;
        /// <summary>
        /// Constructor
        /// </summary>
        public CreateDateTimeFuncForm()
        {
            try
            {
                InitializeComponent();
                IntervalDayRadio.Checked = true;
                Format1Radio.Checked = true;
                CustomInputTitleLbl.Enabled = false;
                CustomInputTextBox.Enabled = false;
                CalendarComboBox.Items.Clear();

                LoadCalendarToComboBox(CalendarComboBox);

                CalendarComboBox.SelectedIndex = 0;

                _formatRadioList = new List<BaseRadioButton>();
                _formatRadioList.Add(Format1Radio);
                _formatRadioList.Add(Format2Radio);
                _formatRadioList.Add(Format3Radio);
                _formatRadioList.Add(Format4Radio);
                _formatRadioList.Add(Format5Radio);
                _formatRadioList.Add(Format6Radio);
                _formatRadioList.Add(Format7Radio);
                _formatRadioList.Add(Format8Radio);
                _formatRadioList.Add(Format9Radio);
                _formatRadioList.Add(Format10Radio);
                _formatRadioList.Add(Format11Radio);
                _formatRadioList.Add(Format12Radio);
                _formatRadioList.Add(FormatCustomRadio);

                Format1Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format2Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format3Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format4Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format5Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format6Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format7Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format8Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format9Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format10Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format11Radio.CheckedChanged += FormatRadio_CheckedChanged;
                Format12Radio.CheckedChanged += FormatRadio_CheckedChanged;
                FormatCustomRadio.CheckedChanged += FormatRadio_CheckedChanged;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーをコンボボックスへ読み込む
        /// </summary>
        /// <param name="calendarComboBox"></param>
        public static void LoadCalendarToComboBox(BaseComboBox calendarComboBox)
        {
            try
            {
                DbUtil util = DbUtil.GetInstance();
                CalendarModel model = new CalendarModel();
                model.CalendarId = 0;
                model.Description = "--未設定--";
                calendarComboBox.Items.Add(model);
                foreach(KeyValuePair<int, object[]> pair in CalendarInfos.GetInstance().CalendarInfoDic)
                {
                    calendarComboBox.Items.Add((CalendarModel)pair.Value[1]);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// フォーマットRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (!radio.Checked) return;
                CustomInputTitleLbl.Enabled = radio.Equals(FormatCustomRadio);
                CustomInputTextBox.Enabled = radio.Equals(FormatCustomRadio);
                if (!CustomInputTextBox.Enabled)
                {
                    CustomInputTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 日付関数を作成する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFuncButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fmt = "";
                if (FormatCustomRadio.Checked)
                {
                    fmt = CustomInputTextBox.Text.Trim();
                }
                else
                {
                    foreach(var radio in _formatRadioList)
                    {
                        if (radio.Checked)
                        {
                            fmt = radio.Text;
                            break;
                        }
                    }
                }
                if (string.IsNullOrEmpty(fmt))
                {
                    this.ShowWarningDialog("日付フォーマットエラー", "日付フォーマットを入力してください。\r\n\r\n" + fmt);
                    return;
                }

                string itv = "";
                if (IntervalYearRadio.Checked)
                {
                    itv = "y";
                }
                if (IntervalMonthRadio.Checked)
                {
                    itv = "M";
                }
                if (IntervalDayRadio.Checked)
                {

                    itv = "d";
                }
                if (IntervalHourRadio.Checked)
                {
                    itv = "h";
                }
                if (IntervalMinuteRadio.Checked)
                {
                    itv = "m";
                }
                if (IntervalSecondRadio.Checked)
                {
                    itv = "s";

                }
                string func = "$DateTime(" + itv + "," + IntervalUpDown.Value + "," + fmt;
                CalendarModel model = (CalendarModel)CalendarComboBox.SelectedItem;
                if(model.CalendarId > 0)
                {
                    func += "," + model.CalendarId;
                }
                func += ")";

                Clipboard.SetText(func);
                this.ShowDialog("日付関数作成成功", "日付関数をクリップボードにコピーしました。");
                this.Close();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
