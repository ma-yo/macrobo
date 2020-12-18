using Macrobo.Components;
using Macrobo.Models;
using Macrobo.Models.Enums;
using Macrobo.Singleton;
using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// Webカレンダー作成編集フォーム
    /// </summary>
    public partial class WebCalendarEditForm : BaseForm
    {
        /// <summary>
        /// 列Index
        /// </summary>
        private const int PARAMGRID_PARAMNAME = 0;
        private const int PARAMGRID_PARAMVALUE = 1;
        /// <summary>
        /// データ変更フラグ
        /// </summary>
        public bool _isDataChanged;
        /// <summary>
        /// カレンダーID
        /// </summary>
        private CalendarModel _calendarModel;
        /// <summary>
        /// Constructor
        /// </summary>
        public WebCalendarEditForm()
        {
            InitializeComponent();

            EncodeSJISRadio.Checked = true;
        }
        /// <summary>
        /// カレンダーを初期化する
        /// </summary>
        /// <param name="id"></param>
        internal void Init(int id)
        {
            try
            {
                if (id == 0)
                {
                    //新規カレンダー
                    _calendarModel = CalendarInfos.GetNewCalendarModel();
                    _calendarModel.CalendarType = Models.Enums.CalendarType.外部カレンダー;
                }
                else
                {
                    //DBより読み込み
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
        /// カレンダーフォームを作成する
        /// </summary>
        private void LoadCalendarForm()
        {
            try
            {
                CalendarIDLbl.Text = "" + _calendarModel.CalendarId;
                DescriptionTextBox.Text = _calendarModel.Description;
                switch (_calendarModel.EncodeType)
                {
                    case Models.Enums.EncodeType.SHIFT_JIS:
                        EncodeSJISRadio.Checked = true;
                        break;
                    case Models.Enums.EncodeType.EUC_JP:
                        EncodeEUCRadio.Checked = true;
                        break;
                    case Models.Enums.EncodeType.UTF8:
                        EncodeUTF8Radio.Checked = true;
                        break;
                    case Models.Enums.EncodeType.UTF16:
                        EncodeUTF16Radio.Checked = true;
                        break;
                }
                switch (_calendarModel.CalendarDataFormatType)
                {
                    case Models.Enums.CalendarDataFormatType.CSV:
                        CsvTypeRadio.Checked = true;
                        break;
                    default:
                        TxtTypeRadio.Checked = true;
                        break;
                }
                UrlTextBox.Text = _calendarModel.Url;

                ParamGrid.AllowUserToAddRows = false;
                ParamGrid.Rows.Clear();
                foreach (var param in _calendarModel.UrlParams)
                {
                    ParamGrid.Rows.Add(param.Key, param.Value);
                }
                ParamGrid.AllowUserToAddRows = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーをWEBより取得する
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="siteUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="delimitter"></param>
        /// <returns></returns>
        public static async Task<Dictionary<string, bool>> GetCalendarValueFromWeb(List<string[]> errorMsg, string siteUrl, Dictionary<string, string> parameters, char delimitter, EncodeType encode)
        {
            try
            {
                Dictionary<string, bool> resultDates = new Dictionary<string, bool>();
                var content = new FormUrlEncodedContent(parameters);
                string charset = "UTF-8";
                switch (encode)
                {
                    case EncodeType.SHIFT_JIS:
                        charset = "Shift_JIS";
                        break;
                    case EncodeType.EUC_JP:
                        charset = "EUC-JP";
                        break;
                    case EncodeType.UTF8:
                        charset = "UTF-8";
                        break;
                    case EncodeType.UTF16:
                        charset = "UTF-16";
                        break;
                }
                content.Headers.Add("charset", charset);
                bool exists = false;
                using (var client = new HttpClient())
                {
                    var response =
                           await client.PostAsync(siteUrl, content);
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(charset), true) as TextReader)
                        {
                            string val = await reader.ReadToEndAsync();
                            val = val.Replace("\r", "");
                            val = val.TrimEnd('\n');
                            string[] rows = val.Split('\n');

                            Console.WriteLine(rows.Length);
                            if (rows == null || rows.Length == 0)
                            {
                                errorMsg?.Add(new string[] { "データエラー", "データを取得できませんでした。取得先URLやパラメーターをご確認ください。" });
                                return null;
                            }
                            for (int i = 0; i < rows.Length; i++)
                            {
                                string[] col = rows[i].Split(delimitter);
                                if (col.Length != 2)
                                {
                                    errorMsg?.Add(new string[] { "データエラー", "データフォーマットが不正です。フォーマットはマニュアルにてご確認ください。" });
                                    return null;
                                }
                                string dateStr = "";
                                DayOfWeek week = DayOfWeek.Sunday;
                                if (string.IsNullOrEmpty(col[0])) continue;
                                if (col[0].Length == 8 && DateTime.TryParse(col[0].Insert(4, "/").Insert(7, "/"), out DateTime date1))
                                {
                                    dateStr = date1.ToString("yyyyMMdd");
                                    week = date1.DayOfWeek;
                                }
                                else if (col[0].Length == 10 && DateTime.TryParse(col[0], out DateTime date2))
                                {
                                    dateStr = date2.ToString("yyyyMMdd");
                                    week = date2.DayOfWeek;
                                }
                                if (string.IsNullOrEmpty(dateStr) && i > 0)
                                {
                                    errorMsg?.Add(new string[] { "日付フォーマットエラー", "日付文字列が不正です。\r\n文字列 ⇒ [" + col[0] + "]" });
                                    
                                    return null;
                                }
                                if (!int.TryParse(col[1], out int holidayFlag) && i > 0)
                                {
                                    errorMsg?.Add(new string[] { "休日フラグエラー", "休日フラグは0又は1のみ有効です。\r\n文字列 ⇒ [" + col[1] + "]" });
         
                                    return null;
                                }
                                if(i > 0)
                                {
                                    exists = true;
                                }
                                switch (week)
                                {
                                    case DayOfWeek.Sunday:
                                    case DayOfWeek.Saturday:
                                        if(holidayFlag == 1)
                                        {
                                            if (!resultDates.ContainsKey(dateStr))
                                            {
                                                resultDates.Add(dateStr, true);
                                            }
                                        }
                                        break;
                                    default:
                                        if (holidayFlag == 0)
                                        {
                                            if (!resultDates.ContainsKey(dateStr))
                                            {
                                                resultDates.Add(dateStr, false);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                if(!exists)
                {
                    errorMsg?.Add(new string[] { "データエラー", "カレンダーデータは取得できませんでした。" });
                    return null;
                }
                return resultDates;
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
                if (string.IsNullOrEmpty(DescriptionTextBox.Text.Trim()))
                {
                    this.ShowWarningDialog("カレンダー名未入力", "カレンダー名を入力してください。");
                    return;
                }
                if (string.IsNullOrEmpty(UrlTextBox.Text.Trim()))
                {
                    this.ShowWarningDialog("URL未入力", "カレンダーデータ取得元URLを入力してください。");
                    return;
                }

                var dic = GetCalendarData();

                if (dic == null) return;

                DialogResult result = this.ShowInfoDialog("カレンダーの保存", "カレンダーを保存しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No) return;

                _calendarModel.Description = DescriptionTextBox.Text.Trim();
                _calendarModel.Url = UrlTextBox.Text.Trim();
                _calendarModel.UrlParams = GetParameter();
                _calendarModel.Value = dic;
                _calendarModel.CalendarDataFormatType = (CsvTypeRadio.Checked) ? Models.Enums.CalendarDataFormatType.CSV : Models.Enums.CalendarDataFormatType.TXT;
                CalendarInfos.GetInstance().CreateCalendarValue(_calendarModel.CalendarId, _calendarModel.Description, _calendarModel, _calendarModel.CalendarType);
                this.ShowDialog("カレンダーの保存", "カレンダーを保存しました。");
                _isDataChanged = false;
                return;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーデータを取得する
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, bool> GetCalendarData()
        {
            try
            {
                string siteUrl = UrlTextBox.Text.Trim();
                var parameters = GetParameter();
                char delimit = CsvTypeRadio.Checked ? ',' : '\t';
                List<string[]> errMsg = new List<string[]>();
                EncodeType charset = EncodeType.UTF8;
                if (EncodeSJISRadio.Checked)
                {
                    charset = EncodeType.SHIFT_JIS;
                }
                if (EncodeEUCRadio.Checked)
                {
                    charset = EncodeType.EUC_JP;
                }
                if (EncodeUTF16Radio.Checked)
                {
                    charset = EncodeType.UTF16;
                }
                Dictionary<string, bool> result = AsyncUtil.RunSync(() => GetCalendarValueFromWeb(errMsg, siteUrl, parameters, delimit, charset));
                if(errMsg.Count > 0)
                {
                    this.ShowWarningDialog(errMsg[0][0], errMsg[0][1]);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Gridからパラメーターを取得する
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetParameter()
        {

            try
            {
                var parameters = new Dictionary<string, string>();
                foreach (DataGridViewRow row in ParamGrid.Rows)
                {
                    string paramName = ("" + row.Cells[PARAMGRID_PARAMNAME].Value).Trim().Replace("\r", "").Replace("\n", "");
                    string paramValue = ("" + row.Cells[PARAMGRID_PARAMVALUE].Value).Trim().Replace("\r", "").Replace("\n", "");
                    if (!string.IsNullOrEmpty(paramName) && !string.IsNullOrEmpty(paramValue))
                    {
                        if (!parameters.ContainsKey(paramName))
                        {
                            parameters.Add(paramName, paramValue);
                        }
                    }
                }
                return parameters;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 出力試験を実行します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestButton_Click(object sender, EventArgs e)
        {
            try
            {
                var data = GetCalendarData();
                if(data == null)
                {
                    return;
                }
                string filePath = Program.TMP_FOLDER + @"\" + Guid.NewGuid().ToString().Replace("-", "") + ".txt";
                using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default))
                {
                    foreach(var d in data)
                    {
                        sw.WriteLine(d.Key + "\t" + (d.Value ? 1 : 0));
                    }
                }
                FileUtil.ViewFile(filePath);
                this.ShowDialog("データ取得成功", "正常なデータを取得しました。");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
