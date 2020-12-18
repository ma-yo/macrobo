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
using Microsoft.WindowsAPICodePack.Dialogs;
using Macrobo.Components;
using Macrobo.Views.Forms;
using Macrobo.Models.Enums;
using System.IO;
using Macrobo.Utils;
using System.Net.Http;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// 変数コントロール
    /// </summary>
    public partial class VariableControl : ProcessBaseControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VariableControl()
        {
            try
            {
                InitializeComponent();

                this.FlowLayoutPanel1.SuspendLayout();
                this.FlowLayoutPanel1.Controls.Add(this.VariableChoiceContainer);
                this.FlowLayoutPanel1.Controls.Add(this.TargetContainer);
                this.FlowLayoutPanel1.Controls.Add(this.FileOutputTypeContainer);
                this.FlowLayoutPanel1.Controls.Add(this.CellNoContainer);
                this.FlowLayoutPanel1.Controls.Add(this.Variable1Container);
                this.FlowLayoutPanel1.Controls.Add(this.EncodeContainer);
                this.FlowLayoutPanel1.Controls.Add(this.Variable2Container);
                this.FlowLayoutPanel1.Controls.Add(this.CalcContainer);
                this.FlowLayoutPanel1.Controls.Add(this.ArrayVariableContainer);
                this.FlowLayoutPanel1.Controls.Add(this.CompareOperatorContainer);
                this.FlowLayoutPanel1.Controls.Add(this.CompareTypeContainer);
                this.FlowLayoutPanel1.Controls.Add(this.ArrayVariableFileFormatContainer);
                this.FlowLayoutPanel1.Controls.Add(this.CalcValueContainer);
                this.FlowLayoutPanel1.Controls.Add(this.FileInoutPathContainer);
                this.FlowLayoutPanel1.Controls.Add(this.ExcelSheetNameContainer);
                this.FlowLayoutPanel1.Controls.Add(this.UrlParamContainer);
                this.FlowLayoutPanel1.Controls.Add(this.StringInputContainer);
                this.FlowLayoutPanel1.ResumeLayout();

                AddButtonEvent();
                InputFromKeyboardRadio.Checked = true;
                OverWriteRadio.Checked = true;
                VariableRadio.Checked = true;
                VariableTargetRadio.Checked = true;
                CompareTargetVariableRadio.Checked = true;
                TextSeparateRadio.Checked = true;
                EncodeSJISRadio.Checked = true;
                RowNoTextBox.Text = "0";
                ColumnNoTextBox.Text = "0";
                ExcelSheetNameTextBox.Text = "Sheet1";
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
                CompButton.Tag = ProcessModel.GetEndProcessModel();
                ErrorButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                ErrorButton.Tag = ProcessModel.GetErrorProcessModel();
                Variable1Button.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                Variable1Button.Tag = StringValue.VARIABLE_VAR0;
                Variable2Button.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                Variable2Button.Tag = StringValue.VARIABLE_VAR0;

                ArrayVariableButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                ArrayVariableButton.Tag = StringValue.VARIABLE_ARY_VAR0;

                CompareTypeButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CompareTypeButton.Tag = CompareTypeType.文字列;
                CompareOperatorButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CompareOperatorButton.Tag = CompareOperatorType.同値;

                CalcButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CalcButton.Tag = VariableCalcType.加算;
                VariableRadio.CheckedChanged += VariableRadio_CheckedChanged;
                ArrayVariableRadio.CheckedChanged += VariableRadio_CheckedChanged;
                VariableTargetRadio.CheckedChanged += VariableTargetRadio_CheckedChanged;
                ElementTargetRadio.CheckedChanged += VariableTargetRadio_CheckedChanged;
                CompareTargetVariableRadio.CheckedChanged += CompareTargetRadio_CheckedChanged; ;
                CompareTargetInputRadio.CheckedChanged += CompareTargetRadio_CheckedChanged;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 比較ターゲットRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareTargetRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (radio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 入力先を指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableTargetRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (radio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 対象変数を指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (radio.Checked)
                {
                    SetExecuteType();
                }
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
        private void InputFromKeyboardRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (InputFromKeyboardRadio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル入力Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFromFileRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (InputFromFileRadio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル出力Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputToFileRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (OutputToFileRadio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// クリップボード入力Radioのチェック変更機能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFromClipBoardRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (InputFromClipBoardRadio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// クリップボード出力Radioのチェック変更機能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputToClipBoardRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (OutputToClipBoardRadio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数比較Radioのチェック変更機能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableCompareRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (VariableCompareRadio.Checked)
                {
                    VariableRadio.Checked = true;
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 加算減算Radioのチェック変更機能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CalcRadio.Checked)
                {
                    VariableRadio.Checked = true;
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Excelからの読み込みRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelInputRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ExcelInputRadio.Checked)
                {
                    ArrayVariableRadio.Checked = true;
                    VariableTargetRadio.Checked = true;
                    TextSeparateRadio.Checked = true;
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Excelへの出力Radioのチェック変更ｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelOutputRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ExcelOutputRadio.Checked)
                {
                    ArrayVariableRadio.Checked = true;
                    VariableTargetRadio.Checked = true;
                    TextSeparateRadio.Checked = true;
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// WEBデータ読み込み時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFromWebRadio_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (InputFromWebRadio.Checked)
                {
                    SetExecuteType();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行タイプをセットする
        /// </summary>
        private void SetExecuteType()
        {
            try
            {
                UrlParamContainer.Visible = false;
                EncodeContainer.Visible = false;

                ArrayVariableFileFormatPanel.Enabled = true;
                ArrayVariableFileFormatContainer.Visible = false;

                CompareTargetContainer.Visible = false;

                ExcelSheetNameContainer.Visible = false;

                TargetContainer.Visible = false;

                CellNoContainer.Visible = false;

                CalcContainer.Visible = false;

                CalcValueContainer.Visible = false;

                VariableChoiceTitleLbl.Enabled = true;
                VariableChoicePanel.Enabled = true;
                TargetTitleLbl.Enabled = true;
                TargetPanel.Enabled = true;

                FileOutputTypeContainer.Visible = false;

                FileInoutPathContainer.Visible = false;

                StringInputContainer.Visible = false;

                Variable2Container.Visible = false;

                Variable1Container.Visible = false;

                ArrayVariableContainer.Visible = false;

                CompareTypeContainer.Visible = false;

                CompareOperatorContainer.Visible = false;

                Variable1TitleLbl.Text = "対象変数";
                CompButtonTitleLbl.Text = "処理成功移動先";
                ErrorButtonTitleLbl.Text = "処理エラー移動先";
                FileOutputTypeTitleLbl.Text = "出力方法";
                StringInputTitleLbl.Text = "入力";
                FileOpenButton.Text = "参照";
                if (InputFromKeyboardRadio.Checked)
                {
                    StringInputContainer.Visible = true;

                    FileOutputTypeTitleLbl.Text = "入力方法";
                    FileOutputTypeContainer.Visible = true;

                    if (VariableRadio.Checked)
                    {
                        Variable1Container.Visible = true;
                    }
                    else
                    {
                        ArrayVariableFileFormatContainer.Visible = true;

                        TargetContainer.Visible = true;

                        if (VariableTargetRadio.Checked)
                        {
                            Variable1TitleLbl.Text = "行数をセット";
                            Variable1Container.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }
                        else
                        {
                            FileOutputTypeTitleLbl.Text = "入力方法";
                            FileOutputTypeContainer.Visible = true;

                            CellNoContainer.Visible = true;
                            ArrayVariableContainer.Visible = true;
                        }
                    }

                }
                if (InputFromFileRadio.Checked)
                {
                    FileInoutPathContainer.Visible = true;
                    FileInoutPathTitleLbl.Text = "読込元ファイル";
                    EncodeContainer.Visible = true;
                    if (VariableRadio.Checked)
                    {
                        FileOutputTypeTitleLbl.Text = "入力方法";
                        FileOutputTypeContainer.Visible = true;

                        Variable1Container.Visible = true;
                    }
                    else
                    {
                        ArrayVariableFileFormatContainer.Visible = true;

                        TargetContainer.Visible = true;

                        FileOutputTypeTitleLbl.Text = "入力方法";
                        FileOutputTypeContainer.Visible = true;

                        if (VariableTargetRadio.Checked)
                        {
                            Variable1TitleLbl.Text = "行数をセット";
                            Variable1Container.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }
                        else
                        {
                            CellNoContainer.Visible = true;
                            ArrayVariableContainer.Visible = true;
                        }

                    }
                }
                if (OutputToFileRadio.Checked)
                {
                    EncodeContainer.Visible = true;
                    FileOutputTypeContainer.Visible = true;

                    FileInoutPathContainer.Visible = true;
                    FileInoutPathTitleLbl.Text = "出力先ファイル";
                    FileOpenButton.Visible = true;
                    if (VariableRadio.Checked)
                    {
                        Variable1Container.Visible = true;
                    }
                    else
                    {
                        ArrayVariableFileFormatContainer.Visible = true;

                        TargetContainer.Visible = true;
                        if (VariableTargetRadio.Checked)
                        {
                            ArrayVariableContainer.Visible = true;
                        }
                        else
                        {
                            FileOutputTypeTitleLbl.Text = "出力方法";
                            FileOutputTypeContainer.Visible = true;

                            CellNoContainer.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }
                    }
                }
                if (InputFromClipBoardRadio.Checked)
                {
                    FileOutputTypeTitleLbl.Text = "入力方法";
                    FileOutputTypeContainer.Visible = true;
                    if (VariableRadio.Checked)
                    {
                        Variable1Container.Visible = true;
                    }
                    else
                    {
                        ArrayVariableFileFormatContainer.Visible = true;
                        TargetContainer.Visible = true;
                        if (VariableTargetRadio.Checked)
                        {
                            Variable1TitleLbl.Text = "行数をセット";
                            Variable1Container.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }
                        else
                        {
                            FileOutputTypeTitleLbl.Text = "入力方法";
                            FileOutputTypeContainer.Visible = true;

                            CellNoContainer.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }

                    }
                }
                if (OutputToClipBoardRadio.Checked)
                {
                    if (VariableRadio.Checked)
                    {
                        FileOutputTypeTitleLbl.Text = "入力方法";
                        FileOutputTypeContainer.Visible = true;

                        Variable1Container.Visible = true;
                    }
                    else
                    {
                        ArrayVariableFileFormatContainer.Visible = true;

                        TargetContainer.Visible = true;

                        if (VariableTargetRadio.Checked)
                        {
                            ArrayVariableContainer.Visible = true;
                        }
                        else
                        {
                            FileOutputTypeTitleLbl.Text = "出力方法";
                            FileOutputTypeContainer.Visible = true;

                            CellNoContainer.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }
                    }
                }
                if (VariableCompareRadio.Checked)
                {
                    CompareTargetContainer.Visible = true;

                    if (CompareTargetVariableRadio.Checked)
                    {
                        Variable2TitleLbl.Text = "比較先変数";
                        Variable2Container.Visible = true;
                    }
                    else
                    {
                        StringInputTitleLbl.Text = "比較先入力";
                        StringInputContainer.Visible = true;
                    }

                    Variable1TitleLbl.Text = "比較元変数";
                    CompareTypeContainer.Visible = true;

                    CompareOperatorContainer.Visible = true;

                    CompButtonTitleLbl.Text = "比較一致移動先";
                    ErrorButtonTitleLbl.Text = "比較不一致移動先";
                    Variable1Container.Visible = true;

                    VariableChoiceContainer.Enabled = false;

                }
                if (CalcRadio.Checked)
                {
                    Variable1Container.Visible = true;

                    CalcContainer.Visible = true;

                    CalcValueContainer.Visible = true;

                    VariableChoiceContainer.Enabled = false;
                }
                if (ExcelInputRadio.Checked)
                {
                    ArrayVariableFileFormatContainer.Visible = true;
                    ArrayVariableFileFormatPanel.Enabled = false;
                    FileInoutPathTitleLbl.Text = "入力元ファイル";
                    VariableChoiceTitleLbl.Enabled = false;
                    VariableChoicePanel.Enabled = false;
                    TargetTitleLbl.Enabled = false;
                    TargetPanel.Enabled = false;

                    TargetContainer.Visible = true;

                    Variable1TitleLbl.Text = "行数をセット";
                    Variable1Container.Visible = true;

                    ArrayVariableContainer.Visible = true;

                    ExcelSheetNameContainer.Visible = true;

                    FileInoutPathContainer.Visible = true;
                }
                if (ExcelOutputRadio.Checked)
                {
                    ArrayVariableFileFormatContainer.Visible = true;

                    ArrayVariableFileFormatPanel.Enabled = false;

                    FileOutputTypeContainer.Visible = true;

                    FileInoutPathTitleLbl.Text = "出力先ファイル";
                    VariableChoiceTitleLbl.Enabled = false;
                    VariableChoicePanel.Enabled = false;
                    TargetTitleLbl.Enabled = false;
                    TargetPanel.Enabled = false;

                    TargetContainer.Visible = true;

                    ArrayVariableContainer.Visible = true;

                    ExcelSheetNameContainer.Visible = true;

                    FileInoutPathContainer.Visible = true;
                }
                if (InputFromWebRadio.Checked)
                {
                    UrlParamContainer.Visible = true;

                    FileInoutPathContainer.Visible = true;

                    FileInoutPathTitleLbl.Text = "取得先URL";
                    FileOpenButton.Text = "試験";

                    EncodeContainer.Visible = true;

                    if (VariableRadio.Checked)
                    {
                        FileOutputTypeTitleLbl.Text = "入力方法";
                        FileOutputTypeContainer.Visible = true;
                        Variable1Container.Visible = true;
                    }
                    else
                    {
                        ArrayVariableFileFormatContainer.Visible = true;

                        TargetContainer.Visible = true;

                        FileOutputTypeTitleLbl.Text = "入力方法";

                        FileOutputTypeContainer.Visible = true;

                        if (VariableTargetRadio.Checked)
                        {
                            Variable1TitleLbl.Text = "行数をセット";
                            Variable1Container.Visible = true;

                            ArrayVariableContainer.Visible = true;
                        }
                        else
                        {
                            CellNoContainer.Visible = true;
                            ArrayVariableContainer.Visible = true;
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
        /// ファイルオープンを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputFromWebRadio.Checked)
                {
                    var data = GetWebData();
                    if (data == null)
                    {
                        return;
                    }
                    string filePath = Program.TMP_FOLDER + @"\" + Guid.NewGuid().ToString().Replace("-", "") + ".txt";
                    using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default))
                    {
                        foreach (var rowData in data)
                        {
                            string d = "";
                            foreach(var colData in rowData)
                            {
                                if (d != "")
                                {
                                    d += "\t";
                                }
                                d += colData;
                            }
                            sw.WriteLine(d);
                        }
                    }
                    FileUtil.ViewFile(filePath);
                    this.ShowDialog("データ取得成功", "正常なデータを取得しました。");
                }
                else
                {
                    var dialog = new CommonOpenFileDialog("ファイルの選択");
                    dialog.IsFolderPicker = false;
                    dialog.Multiselect = false;
                    if (dialog.ShowDialog(ParentForm.Handle) == CommonFileDialogResult.Ok)
                    {
                        FileInoutPathTextBox.Text = dialog.FileName;
                    }
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// WEBデータを取得する
        /// </summary>
        /// <returns></returns>
        private List<List<string>> GetWebData()
        {
            try
            {
                string siteUrl = FileInoutPathTextBox.Text.Trim();
                var parameters = GetParameter();
                char delimit = CsvSeparateRadio.Checked ? ',' : '\t';
                List<string[]> errMsg = new List<string[]>();
                List<List<string>> result = AsyncUtil.RunSync(() => GetValueFromWeb(errMsg, siteUrl, parameters, delimit));
                if (errMsg.Count > 0)
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
        /// カレンダーをWEBより取得する
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="siteUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="delimitter"></param>
        /// <returns></returns>
        public async Task<List<List<string>>> GetValueFromWeb(List<string[]> errorMsg, string siteUrl, Dictionary<string, string> parameters, char delimitter)
        {
            try
            {
                List<List<string>> resultDates = new List<List<string>>();
                var content = new FormUrlEncodedContent(parameters);
                string encode = "";
                if (EncodeSJISRadio.Checked)
                {
                    encode = "Shift_JIS";
                }
                if (EncodeEUCRadio.Checked)
                {
                    encode = "EUC-JP";
                }
                if (EncodeUTF8Radio.Checked)
                {
                    encode = "UTF-8";
                }
                if (EncodeUTF16Radio.Checked)
                {
                    encode = "UTF-16";
                }
                content.Headers.Add("charset", encode);

                bool exists = false;
                using (var client = new HttpClient())
                {
                    var response =
                           await client.PostAsync(siteUrl, content);
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(encode), true) as TextReader)
                        {
                            string val = await reader.ReadToEndAsync();
                            val = val.Replace("\r", "");
                            val = val.TrimEnd('\n');
                            string[] rows = val.Split('\n');

                            if (rows == null || rows.Length == 0)
                            {
                                errorMsg?.Add(new string[] { "データエラー", "データを取得できませんでした。取得先URLやパラメーターをご確認ください。" });
                                return null;
                            }
                            for (int i = 0; i < rows.Length; i++)
                            {
                                string[] col = rows[i].Split(delimitter);
                                resultDates.Add(col.ToList());
                                exists = true;
                            }
                        }
                    }
                }
                if (!exists)
                {
                    errorMsg?.Add(new string[] { "データエラー", "データは取得できませんでした。" });
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
                    string paramName = ("" + row.Cells[0].Value).Trim().Replace("\r", "").Replace("\n", "");
                    string paramValue = ("" + row.Cells[1].Value).Trim().Replace("\r", "").Replace("\n", "");
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
        /// 変数を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Variable1Button_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<string> keyList = new List<string>();
                foreach (var variable in CurrentProjectModel.VariableList)
                {
                    keyList.Add(variable.Key);
                }
                string title = Variable1TitleLbl.Text;
                form.Init(title, keyList, (string)Variable1Button.Tag);
                form.ShowDialog(this);
                Variable1Button.Tag = form.GetSelected<string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Variable2Button_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<string> keyList = new List<string>();
                foreach (var variable in CurrentProjectModel.VariableList)
                {
                    keyList.Add(variable.Key);
                }
                string title = Variable2TitleLbl.Text;
                form.Init(title, keyList, (string)Variable2Button.Tag);
                form.ShowDialog(this);
                Variable2Button.Tag = form.GetSelected<string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrayVariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<string> keyList = new List<string>();
                foreach (var variable in CurrentProjectModel.ArrayVariableList)
                {
                    keyList.Add(variable.Key);
                }
                string title = ArrayVariableTitleLbl.Text;
                form.Init(title, keyList, (string)ArrayVariableButton.Tag);
                form.ShowDialog(this);
                ArrayVariableButton.Tag = form.GetSelected<string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 比較する型を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareTypeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<CompareTypeType> compareTypeList = new List<CompareTypeType>();
                compareTypeList.Add(CompareTypeType.数値);
                compareTypeList.Add(CompareTypeType.文字列);
                compareTypeList.Add(CompareTypeType.日付);
                string title = CompareTypeTitleLbl.Text;
                form.Init(title, compareTypeList, (CompareTypeType)CompareTypeButton.Tag);
                form.ShowDialog(this);
                CompareTypeButton.Tag = form.GetSelected<CompareTypeType>();
                switch ((CompareTypeType)CompareTypeButton.Tag)
                {
                    case CompareTypeType.文字列:
                        switch ((CompareOperatorType)CompareOperatorButton.Tag)
                        {
                            case CompareOperatorType.以上:
                            case CompareOperatorType.以下:
                            case CompareOperatorType.大きい:
                            case CompareOperatorType.小さい:
                                break;
                            default:
                                CompareOperatorButton.Tag = CompareOperatorType.同値;
                                break;
                        }
                        break;
                    case CompareTypeType.数値:
                    case CompareTypeType.日付:
                        switch ((CompareOperatorType)CompareOperatorButton.Tag)
                        {
                            case CompareOperatorType.含む:
                            case CompareOperatorType.含まない:
                                CompareOperatorButton.Tag = CompareOperatorType.同値;
                                break;
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
        /// 比較演算子を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareOperatorButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<CompareOperatorType> compareOperatorList = new List<CompareOperatorType>();
                switch ((CompareTypeType)CompareTypeButton.Tag)
                {
                    case CompareTypeType.文字列:
                        compareOperatorList.Add(CompareOperatorType.同値);
                        compareOperatorList.Add(CompareOperatorType.含む);
                        compareOperatorList.Add(CompareOperatorType.含まない);
                        break;
                    case CompareTypeType.数値:
                    case CompareTypeType.日付:
                        compareOperatorList.Add(CompareOperatorType.同値);
                        compareOperatorList.Add(CompareOperatorType.以上);
                        compareOperatorList.Add(CompareOperatorType.以下);
                        compareOperatorList.Add(CompareOperatorType.大きい);
                        compareOperatorList.Add(CompareOperatorType.小さい);
                        break;
                }
                string title = CompareOperatorTitleLbl.Text;
                form.Init(title, compareOperatorList, (CompareOperatorType)CompareOperatorButton.Tag);
                form.ShowDialog(this);
                CompareOperatorButton.Tag = form.GetSelected<CompareOperatorType>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 加算減算を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<VariableCalcType> calcList = new List<VariableCalcType>();
                calcList.Add(VariableCalcType.加算);
                calcList.Add(VariableCalcType.減算);

                string title = CalcTitleLbl.Text;
                form.Init(title, calcList, (VariableCalcType)CalcButton.Tag);
                form.ShowDialog(this);
                CalcButton.Tag = form.GetSelected<VariableCalcType>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル入出力パステキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileInoutPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    FileInoutPathTextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル入出力パステキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileInoutPathTextBox_DragEnter(object sender, DragEventArgs e)
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
        /// ParamGridのCellDirtyStateChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParamGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                //セルの編集を確定する
                ParamGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
