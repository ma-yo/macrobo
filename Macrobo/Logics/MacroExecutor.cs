using Macrobo.Utils.Gui;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Data.SQLite;
using Newtonsoft.Json;
using Macrobo.Singleton;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System.Threading.Tasks;
using System.Net.Http;

namespace Macrobo.Logics
{
    /// <summary>
    /// Author : M.Yoshida
    /// マクロ実行クラス
    /// </summary>
    public class MacroExecutor
    {
        #region Win32API

        /// <summary>
        /// ｷｰﾎﾞｰﾄﾞｲﾍﾞﾝﾄを送る
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        /// <summary>
        /// ｶｰｿﾙ位置をｾｯﾄする
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void SetCursorPos(int X, int Y);
        /// <summary>
        /// ﾏｳｽｲﾍﾞﾝﾄを送る
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetMessageExtraInfo();
        /// <summary>
        /// マウスカーソル座標を取得する
        /// </summary>
        /// <param name="lppoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lppoint);
        /// <summary>
        /// マウス座標取得用構造体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int X { get; set; }
            public int Y { get; set; }
            public static implicit operator System.Drawing.Point(POINT point)
            {
                return new System.Drawing.Point(point.X, point.Y);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// ログイベント
        /// </summary>
        /// <param name="msg"></param>
        public delegate void LogEvent(LogType logType, string msg, ProjectModel projectModel);
        /// <summary>
        /// ログイベント
        /// </summary>
        public LogEvent OnLogEvent;
        /// <summary>
        /// プロセス実行イベント
        /// </summary>
        /// <param name="processModel"></param>
        public delegate void ProcessRunEvent(ProcessModel processModel);
        /// <summary>
        /// プロセスｲﾍﾞﾝﾄ実装
        /// </summary>
        public ProcessRunEvent OnBeforeProcessStart;

        #endregion

        #region Datas
        /// <summary>
        /// ログテキストを保持する
        /// </summary>
        private StringBuilder _logText;
        /// <summary>
        /// プロジェクトを保持する
        /// </summary>
        public ProjectModel _projectModel;

        /// <summary>
        /// 停止フラグ
        /// </summary>
        public volatile bool _stopFlag = false;
        /// <summary>
        /// マクロ実行モード
        /// </summary>
        public MacroExecMode MacroExecMode = MacroExecMode.ALL;
        /// <summary>
        /// マクロ実行開始ProcessID
        /// </summary>
        public string MacroStartProcessId = "";

        private MacroStartType MacroStartType { get; set; }
        #endregion

        #region Const
        /// <summary>
        /// 待機状態のミリ秒
        /// </summary>
        private const int WAIT_TIME2 = 100;
        /// <summary>
        /// 待機状態のミリ秒
        /// </summary>
        private const int WAIT_TIME1 = 50;
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectModel"></param>
        public MacroExecutor(ProjectModel projectModel, MacroStartType macroStartType)
        {
            _projectModel = projectModel.DeepCopy();
            MacroStartType = macroStartType;
        }

        /// <summary>
        /// 処理を実行する
        /// </summary>
        public void Run(bool execMode)
        {
            try
            {
                _logText = new StringBuilder();
                //実行カレンダーチェック
                if (execMode)
                {
                    //実行当日でなければ実行しない
                    if (!CheckExecCalendar())
                    {
                        return;
                    }
                }

                DateTime startTime = DateTime.Now;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                string id = "";
                switch (MacroExecMode)
                {
                    case MacroExecMode.ALL:                  //最初からすべて実行する
                        id = _projectModel.NodeIdList[0];
                        break;
                    case MacroExecMode.SINGLE:               //1処理のみを実行する
                    case MacroExecMode.BELOWSELECTION:       //選択処理以下から実行する
                    case MacroExecMode.SELECTION:            //選択を実行する
                        id = MacroStartProcessId;
                        break;
                }

                Dictionary<string, VariableModel> variableList = null;
                Dictionary<string, ArrayVariableModel> arrayVariableList = null;
                ProcessModel nextProcess = null;
                MacroResultData result = null;
                ProjectModel startMacroModel = null;

                if (_projectModel.ProcessModelList.Exists(a => a.ProcessId == id))
                {
                    variableList = _projectModel.VariableList;
                    arrayVariableList = _projectModel.ArrayVariableList;
                    nextProcess = _projectModel.ProcessModelList.First(a => a.ProcessId == id);
                    result = new MacroResultData(variableList, arrayVariableList, nextProcess, 0);
                }
                else if(_projectModel.MacroModelList.Exists(a => a.ProjectId == id))
                {
                    var macro = _projectModel.MacroModelList.First(a => a.ProjectId == id);
                    startMacroModel = macro;
                    string id2 = macro.NodeIdList[0];
                    variableList = macro.VariableList;
                    arrayVariableList = macro.ArrayVariableList;
                    nextProcess = macro.ProcessModelList.First(a => a.ProcessId == id2);
                    result = new MacroResultData(variableList, arrayVariableList, nextProcess, 0);
                }
                else
                {
                    foreach(var macro in _projectModel.MacroModelList)
                    {
                        if(macro.ProcessModelList.Exists(a => a.ProcessId == id))
                        {
                            variableList = macro.VariableList;
                            arrayVariableList = macro.ArrayVariableList;
                            nextProcess = macro.ProcessModelList.First(a => a.ProcessId == id);
                            result = new MacroResultData(variableList, arrayVariableList, nextProcess, 0);
                            break;
                        }
                    }
                }

                while (true)
                {
                    result = ExecuteMacro(result.VariableList, result.ArrayVariableList, result.Process);
                    if (result.ReturnCode == 1 || result.ReturnCode == 2) break;
                    if (MacroExecMode == MacroExecMode.SINGLE)
                    {
                        if (startMacroModel == null) break;
                        //モジュールの場合モジュールを抜けたら終了させる
                        if (!startMacroModel.NodeIdList.Contains(result.Process.ProcessId)) break;
                    }
                }


                sw.Stop();
                DateTime endTime = DateTime.Now;
 
                ExecuteLogModel logData = new ExecuteLogModel();
                logData.Id = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                logData.Cdate = startTime.ToString("yyyy/MM/dd HH:mm:ss");
                logData.ExecId = _projectModel.ProjectId;
                logData.ExecType = MacroStartType.ToString();
                logData.ExecName = _projectModel.Name;
                logData.StartTime = startTime.ToString("yyyy/MM/dd HH:mm:ss");
                logData.EndTime = endTime.ToString("yyyy/MM/dd HH:mm:ss");
                logData.ExecTime = sw.Elapsed.Seconds;
                logData.Description = !string.IsNullOrEmpty(result.ErrorMessage) ? result.ErrorMessage : null;
                logData.Result = result.ReturnCode;

                DbUtil.GetInstance().CreateExecuteLog(logData);
                
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行カレンダーチェック
        /// </summary>
        /// <returns></returns>
        private bool CheckExecCalendar()
        {
            try
            {
                bool result = true;
                DateTime today = DateTime.Now;
                if (CalendarInfos.GetInstance().CalendarInfoDic.ContainsKey(_projectModel.ExecCalendarId))
                {
                    CalendarModel model = (CalendarModel)CalendarInfos.GetInstance().CalendarInfoDic[_projectModel.ExecCalendarId][1];
                    if (model.CalendarId != 0)
                    {
                        if (model.Value.ContainsKey(today.ToString("yyyyMMdd")))
                        {
                            if (!model.Value[today.ToString("yyyyMMdd")])
                            {
                                //スキップ
                                result = false;
                            }
                        }
                        else
                        {
                            if (today.DayOfWeek == DayOfWeek.Sunday || today.DayOfWeek == DayOfWeek.Saturday)
                            {
                                //スキップ
                                result = false;
                            }
                        }
                    }
                    if (!result)
                    {
                        OnLogEvent?.Invoke(LogType.INFO, SetLog("実行カレンダーがOFFの日にちの為終了します。"), _projectModel);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// モジュールを実行する
        /// </summary>
        /// <param name="variableList">実行する処理</param>
        /// <param name="process">実行する処理</param>
        private MacroResultData ExecuteMacro(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                bool result = false;
                if (proc.ValidType == ValidType.有効)
                {
                    Thread.Sleep(proc.BeforeWaitMilliTime);
                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.ProcessType.ToString() + " ⇒ " + proc.Name), _projectModel);
                    OnBeforeProcessStart?.Invoke(proc);
                    switch (proc.ProcessType)
                    {
                        case ProcessType.検出:
                            result = ActionDetect(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.キーボード入力:
                            result = ActionKeyboardInput(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.マウス入力:
                            result = ActionMouseInput(proc);
                            break;
                        case ProcessType.待機:
                            result = ActionWait(proc);
                            break;
                        case ProcessType.メール送信:
                            result = ActionSendMail(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.アプリ実行:
                            result = ActionAppStart(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.変数:
                            result = ActionVariable(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.ファイルフォルダー処理:
                            result = ActionFileFolder(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.ダイアログ:
                            result = ActionDialog(variableList, arrayVariableList, proc);
                            break;
                        case ProcessType.Excel:
                            result = ActionExcel(variableList, arrayVariableList, proc);
                            break;
                    }
                    OnLogEvent?.Invoke((result) ? LogType.SUCCESS : LogType.WARN, SetLog(proc.ProcessType.ToString() + " ⇒ " + proc.Name + " 結果 ⇒ " + ((result) ? "OK" : "NG")), _projectModel);
                    Thread.Sleep(proc.AfterWaitMilliTime);
                }
                else
                {
                    OnLogEvent?.Invoke(LogType.INFO, SetLog("[" + proc.Name + "]処理が無効化されているため、スキップします。 ⇒ " + proc.Name), _projectModel);
                    //無効の場合は次の処理へ移動する
                    result = true;
                }

                if (_stopFlag)
                {
                    OnLogEvent?.Invoke(LogType.WARN, SetLog("停止が実行されました。"), _projectModel);
                    return new MacroResultData(3, "USER STOP");
                }
                if (result)
                {
                    if (proc.NextProcess.Name == StringValue.END_PROCESS) return new MacroResultData(1, "END");
                    if (proc.NextProcess.Name == StringValue.END_PROCESS_ERROR) return new MacroResultData(2, "ERROR");

                    if (_projectModel.ProcessModelList.Exists(a => a.ProcessId == proc.NextProcess.ProcessId))
                    {
                        return new MacroResultData(_projectModel.VariableList, _projectModel.ArrayVariableList, _projectModel.ProcessModelList.First(a => a.ProcessId == proc.NextProcess.ProcessId), 0);
                    }
                    else
                    {
                        foreach (var proj in _projectModel.MacroModelList)
                        {
                            if (proj.ProcessModelList.Exists(a => a.ProcessId == proc.NextProcess.ProcessId))
                            {
                                return new MacroResultData(proj.VariableList, proj.ArrayVariableList, proj.ProcessModelList.First(a => a.ProcessId == proc.NextProcess.ProcessId), 0);
                            }
                        }
                    }
                }
                else
                {
                    if (proc.ErrorProcess.Name == StringValue.END_PROCESS) return new MacroResultData(1, "END");
                    if (proc.ErrorProcess.Name == StringValue.END_PROCESS_ERROR) return new MacroResultData(2, "ERROR");

                    if (_projectModel.ProcessModelList.Exists(a => a.ProcessId == proc.ErrorProcess.ProcessId))
                    {
                        return new MacroResultData(_projectModel.VariableList, _projectModel.ArrayVariableList, _projectModel.ProcessModelList.First(a => a.ProcessId == proc.ErrorProcess.ProcessId), 0);
                    }
                    else
                    {
                        foreach (var proj in _projectModel.MacroModelList)
                        {
                            if (proj.ProcessModelList.Exists(a => a.ProcessId == proc.ErrorProcess.ProcessId))
                            {
                                return new MacroResultData(proj.VariableList, proj.ArrayVariableList, proj.ProcessModelList.First(a => a.ProcessId == proc.ErrorProcess.ProcessId), 0);
                            }
                        }
                    }
                }
                //終了を通過せずに流れてしまった場合エラー
                return new MacroResultData(2, "SYSTEMERROR");
            }
            catch (Exception ex)
            {
                return new MacroResultData(2, "SYSTEMERROR " + ex.Message);
            }
        }
        /// <summary>
        /// 指定秒数の待機を行う
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionWait(ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                DateTime currentTime = DateTime.Now;
                DateTime endTime = currentTime.AddMilliseconds(proc.Timeout);
                while (currentTime <= endTime)
                {
                    if (_stopFlag) return false;
                    Thread.Sleep(WAIT_TIME2);
                    currentTime = DateTime.Now;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ログをセットする
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        private string SetLog(string log)
        {
            try
            {
                if (string.IsNullOrEmpty(_logText.ToString()))
                {
                    _logText.Append("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "] " + log);
                }
                else
                {
                    _logText.Append("\r\n[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "] " + log);
                }
                return log;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キーボード入力を行う
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionKeyboardInput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                switch (proc.KeyboardInputType)
                {
                    case KeyboardInputType.KEYBOARD:
                        List<Keys> keyList = proc.KeyboardInputKeycodes;
                        //KeyDown
                        foreach (var key in keyList)
                        {
                            keybd_event((byte)key, 0, 0, new UIntPtr(0));
                        }
                        Thread.Sleep(WAIT_TIME2);
                        //KeyUp
                        foreach (var key in keyList)
                        {
                            keybd_event((byte)key, 0, 0x0002, new UIntPtr(0));
                        }
                        break;
                    case KeyboardInputType.STRING:
                        string sendValue = SetFunction(variableList, arrayVariableList, proc.KeyboardInput, proc);
                        if (_projectModel.VariableList.ContainsKey("" + proc.VariableKey))
                        {
                            _projectModel.VariableList[proc.VariableKey].Value = sendValue;
                        }
                        sendValue = ReplaceSendKeysSpecialKey(sendValue);

                        SendKeys.SendWait(sendValue);
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
        /// SendKeysの特殊キーをエスケープする
        /// </summary>
        /// <param name="sendValue"></param>
        /// <returns></returns>
        private string ReplaceSendKeysSpecialKey(string sendValue)
        {
            try
            {
                if (string.IsNullOrEmpty(sendValue)) return sendValue;
                string result = "";
                foreach (var c in sendValue)
                {
                    if (c.ToString() == "{") { result += "+([)"; continue; }
                    if (c.ToString() == "}") { result += "+(])"; continue; }
                    if (c.ToString() == "(") { result += "{(}"; continue; }
                    if (c.ToString() == ")") { result += "{)}"; continue; }
                    if (c.ToString() == "+") { result += "{+}"; continue; }
                    if (c.ToString() == "^") { result += "{^}"; continue; }
                    if (c.ToString() == "~") { result += "{~}"; continue; }
                    if (c.ToString() == "%") { result += "{%}"; continue; }
                    result += c;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }

        }

        /// <summary>
        /// ファンクションを設定する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="keyInput"></param>
        /// <returns></returns>
        private string SetFunction(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, string keyInput, ProcessModel proc)
        {
            try
            {
                if (string.IsNullOrEmpty(keyInput)) return "";
                keyInput = SetEscape(keyInput);
                keyInput = SetVariable(variableList, keyInput);
                keyInput = SetArrayVariable(variableList, arrayVariableList, keyInput);
                keyInput = SetDateTimeFunc(keyInput);
                keyInput = SetPrintLogFunc(keyInput);
                return keyInput;
            }
            catch (Exception ex)
            {
                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 関数又は、配列の書式が不正です。" + ex.Message), _projectModel);
                return keyInput;
            }
        }
        /// <summary>
        /// エスケープ文字列を設定する
        /// </summary>
        /// <param name="keyInput"></param>
        /// <returns></returns>
        private string SetEscape(string keyInput)
        {
            try
            {
                keyInput = keyInput.Replace("{TAB}", "\t");
                keyInput = keyInput.Replace("$Desktop", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                keyInput = keyInput.Replace("$Document", System.Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                keyInput = keyInput.Replace("$UserProfile", System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                return keyInput;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 実行ログを解析しセットする
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string SetPrintLogFunc(string input)
        {
            try
            {

                //ログ出力
                if (input.Contains("$PrintLog"))
                {
                    input = input.Replace("$PrintLog", _logText.ToString());
                }
                return input;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// DateTime関数を解析し、セットする
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string SetDateTimeFunc(string input)
        {
            try
            {
                //日付関数
                if (input.Contains("$DateTime("))
                {
                    string args = "";
                    string func = "";
                    int idx = input.IndexOf("$DateTime(") + "$DateTime(".Length;
                    for (int i = idx; i < input.Length; i++)
                    {
                        if (input[i] == ')') break;
                        args += input[i];
                    }
                    string ptn = args.Split(',')[0].Trim();
                    int interval = int.Parse(args.Split(',')[1].Trim());
                    string format = args.Split(',')[2].Trim();
                    CalendarModel calendarModel = null;
                    if (args.Split(',').Length >= 4)
                    {
                        if (CalendarInfos.GetInstance().CalendarInfoDic.ContainsKey(int.Parse(args.Split(',')[3].Trim())))
                        {
                            calendarModel = (CalendarModel)CalendarInfos.GetInstance().CalendarInfoDic[int.Parse(args.Split(',')[3].Trim())][1];
                        }
                    }
                    func = "$DateTime(" + args + ")";
                    if (ptn == "d")
                    {
                        if (calendarModel == null)
                        {
                            input = input.Replace(func, DateTime.Now.AddDays(interval).ToString(format));
                        }
                        else
                        {
                            DateTime current = DateTime.Now;
                            if (interval > 0)
                            {
                                for (int i = 0; i < interval; i++)
                                {
                                    current = current.AddDays(1);
                                    if (calendarModel.Value.ContainsKey(current.ToString("yyyyMMdd")))
                                    {
                                        if (!calendarModel.Value[current.ToString("yyyyMMdd")])
                                        {
                                            i--;
                                        }
                                    }
                                    else
                                    {
                                        //手動設定が無い場合は、土日は休み
                                        if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            else if (interval < 0)
                            {
                                for (int i = 0; i < Math.Abs(interval); i++)
                                {
                                    current = current.AddDays(-1);
                                    if (calendarModel.Value.ContainsKey(current.ToString("yyyyMMdd")))
                                    {
                                        if (!calendarModel.Value[current.ToString("yyyyMMdd")])
                                        {
                                            i--;
                                        }
                                    }
                                    else
                                    {
                                        //手動設定が無い場合は、土日は休み
                                        if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            input = input.Replace(func, current.ToString(format));
                        }
                    }
                    if (ptn == "M") input = input.Replace(func, DateTime.Now.AddMonths(interval).ToString(format));
                    if (ptn == "y") input = input.Replace(func, DateTime.Now.AddYears(interval).ToString(format));
                    if (ptn == "h") input = input.Replace(func, DateTime.Now.AddHours(interval).ToString(format));
                    if (ptn == "m") input = input.Replace(func, DateTime.Now.AddMinutes(interval).ToString(format));
                    if (ptn == "s") input = input.Replace(func, DateTime.Now.AddSeconds(interval).ToString(format));
                    //他に置き換えがあるか再帰する
                    input = SetDateTimeFunc(input);
                }
                return input;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を解析しセットする
        /// </summary>
        /// <param name="arrayVariableList"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private string SetArrayVariable(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, string input)
        {
            try
            {
                foreach (KeyValuePair<string, ArrayVariableModel> valuePair in _projectModel.ArrayVariableList)
                {
                    string key = "$$" + valuePair.Key;
                    input = SetArrayVariable(valuePair.Value, key, input, variableList, arrayVariableList);
                }
                foreach (KeyValuePair<string, ArrayVariableModel> valuePair in arrayVariableList)
                {
                    string key = "$" + valuePair.Key;
                    input = SetArrayVariable(valuePair.Value, key, input, variableList, arrayVariableList);
                }
                return input;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を解析しセットする
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="input"></param>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <returns></returns>
        private string SetArrayVariable(ArrayVariableModel value, string key, string input, Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList)
        {
            try
            {
                if (input.Contains(key))
                {
                    GetArrayVariableElementNo(variableList, key, input, out string arg, out int[] index);
                    if (index != null)
                    {
                        string func = key + arg;
                        input = input.Replace(func, value.ValueList[index[0]][index[1]]);
                        input = SetArrayVariable(variableList, arrayVariableList, input);
                    }
                }
                return input;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// インデックス番号と配列の要素番号文字列を取得する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="key"></param>
        /// <param name="input"></param>
        /// <param name="arg"></param>
        /// <param name="index"></param>
        public void GetArrayVariableElementNo(Dictionary<string, VariableModel> variableList, string key, string input, out string arg, out int[] index)
        {

            try
            {
                if (input.Contains(key))
                {
                    string args = "";
                    int stCnt = 0;
                    int endCnt = 0;
                    int rowIndex = -1;
                    int colIndex = -1;
                    int idx = input.IndexOf(key) + key.Length;
                    for (int i = idx; i < input.Length; i++)
                    {
                        if (input[i] == '[')
                        {
                            stCnt++;
                        }
                        if (input[i] == ']')
                        {
                            endCnt++;
                        }
                        args += input[i];
                        if (endCnt == 2) break;
                    }

                    if (endCnt < 2 || stCnt < 2)
                    {
                        arg = "";
                        index = null;
                        return;
                    }
                    arg = args;
                    string argTmp = args.Replace("][", ",").Replace("[", "").Replace("]", "");
                    rowIndex = int.Parse(SetVariable(variableList, argTmp.Split(',')[0]));
                    colIndex = int.Parse(SetVariable(variableList, argTmp.Split(',')[1]));
                    index = new int[] { rowIndex, colIndex };
                }
                else
                {
                    arg = "";
                    index = null;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数の値をセットする
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private string SetVariable(Dictionary<string, VariableModel> variableList, string input)
        {
            try
            {
                //ルートの変数をセットする
                foreach (KeyValuePair<string, VariableModel> valuePair in _projectModel.VariableList)
                {
                    input = input.Replace("$$" + valuePair.Key, valuePair.Value.Value);
                }

                //変数をセットする
                foreach (KeyValuePair<string, VariableModel> valuePair in variableList)
                {
                    input = input.Replace("$" + valuePair.Key, valuePair.Value.Value);
                }
                return input;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// マウスインプット処理を実行する
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionMouseInput(ProcessModel proc)
        {
            try
            {
                switch (proc.MouseExecType)
                {
                    case MouseInputType.クリック:
                        switch (proc.MouseClickDetectType)
                        {
                            case MouseInputDetectType.画像検出:
                                if (ActionMouseImageDetectMove(proc, -1))
                                {
                                    ActionMouseClick(proc);
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            case MouseInputDetectType.座標検出:
                                ActionMouseMove(proc);
                                ActionMouseClick(proc);
                                return true;
                        }
                        break;
                    case MouseInputType.移動:
                        switch (proc.MouseClickDetectType)
                        {
                            case MouseInputDetectType.画像検出:
                                return ActionMouseImageDetectMove(proc, -1);
                            case MouseInputDetectType.座標検出:
                                ActionMouseMove(proc);
                                return true;
                        }
                        break;
                    case MouseInputType.ホイール操作:
                        for(int i = 0; i < proc.ScrollCount; i++)
                        {
                            if (_stopFlag) return false;
                            SetMouseScroll(proc);
                            OnLogEvent?.Invoke(LogType.INFO, SetLog("[" + proc.Name + "]ホイールスクロール " + (i + 1) + "回目"), _projectModel);
                        }
                        return true;
                    case MouseInputType.ドラッグドロップ:
                        switch (proc.MouseClickDetectType)
                        {
                            case MouseInputDetectType.画像検出:
                                {
                                    DetectImageObject pos1 = GetImageDetectPoint(proc, 0);
                                    if (pos1.DetectPoint.IsEmpty)
                                    {
                                        return false;
                                    }
                                    DetectImageObject pos2 = GetImageDetectPoint(proc, 1);
                                    if (pos2.DetectPoint.IsEmpty)
                                    {
                                        return false;
                                    }
                                    System.Drawing.Point dragPos = new System.Drawing.Point(pos1.DetectPoint.X, pos1.DetectPoint.Y);
                                    System.Drawing.Point dropPos = new System.Drawing.Point(pos2.DetectPoint.X, pos2.DetectPoint.Y);
                                    ActionDragDrop(proc, dragPos, dropPos);
                                    return true;
                                }
                            case MouseInputDetectType.座標検出:
                                {
                                    DetectImageObject pos1 = GetImageDetectPoint(proc, 0);
                                    if (pos1.DetectPoint.IsEmpty)
                                    {
                                        return false;
                                    }
                                    System.Drawing.Point dragPos = new System.Drawing.Point(pos1.DetectPoint.X + proc.CaptureImage[0].Width / 2, pos1.DetectPoint.Y + proc.CaptureImage[0].Height / 2);
                                    System.Drawing.Point dropPos = GetMousePoint(proc);
                                    ActionDragDrop(proc, dragPos, dropPos);
                                    return true;
                                }
                        }
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ドラッグドロップを実行する
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="dragPos"></param>
        /// <param name="dropPos"></param>
        private void ActionDragDrop(ProcessModel proc, System.Drawing.Point dragPos, System.Drawing.Point dropPos)
        {
            try
            {

                if (_stopFlag) return;
                MoveMouse(dragPos.X, dragPos.Y);
                mouse_event(0x2, 0, 0, 0, 0);
                MoveMouse(dropPos.X, dropPos.Y);
                mouse_event(0x4, 0, 0, 0, 0);
                OnLogEvent?.Invoke(LogType.INFO, SetLog("ドラッグドロップしました。 ⇒ [" + dragPos.X + "," + dragPos.Y + "]⇒[" + dropPos.X + "," + dropPos.Y + "]"), _projectModel);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスカーソルを移動する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MoveMouse(int x, int y)
        {
            try
            {
                int loop = 20;
                System.Drawing.Point point = GetMousePoint(null);
                double moveX = 0;
                double moveY = 0;
                if (x > point.X)
                {
                    moveX = (x - (double)point.X) / loop;
                }
                else if (x < point.X)
                {
                    moveX = (point.X - (double)x) / loop;
                }
                else
                {
                    moveX = 0;
                }
                if (y > point.Y)
                {
                    moveY = (y - (double)point.Y) / loop;
                }
                else if (y < point.Y)
                {
                    moveY = (point.Y - (double)y) / loop;
                }
                else
                {
                    moveY = 0;
                }
                double currentX = point.X;
                double currentY = point.Y;
                for (int i = 0; i < loop; i++)
                {
                    if (_stopFlag) return;
                    Thread.Sleep(_projectModel.MouseSpeed);
                    if (currentX < x)
                    {
                        currentX += moveX;
                    }
                    else
                    {
                        currentX -= moveX;
                    }
                    if (currentY < y)
                    {
                        currentY += moveY;
                    }
                    else
                    {
                        currentY -= moveY;
                    }
                    SetCursorPos((int)currentX, (int)currentY);
                }
                SetCursorPos(x, y);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 画像位置を検出し画像中央の座標を取得する
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="imageIndex"></param>
        /// <param name="detectIndex"></param>
        /// <returns></returns>
        private DetectImageObject GetImageDetectPoint(ProcessModel proc, int imageIndex)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                DateTime endTime = currentTime.AddMilliseconds(proc.Timeout);

                bool areaDetectFlag = false;
                switch (proc.ProcessType)
                {
                    case ProcessType.マウス入力:
                        switch (proc.MouseExecType)
                        {
                            case MouseInputType.クリック:
                                switch (proc.MouseClickDetectType)
                                {
                                    case MouseInputDetectType.画像検出:
                                        if (proc.DetectAreaType == DetectAreaType.CHOICE)
                                        {
                                            areaDetectFlag = true;
                                        }
                                        break;
                                }
                                break;
                        }

                        break;
                    case ProcessType.検出:
                        switch (proc.DetectType)
                        {
                            case DetectType.画像:
                                if (proc.DetectAreaType == DetectAreaType.CHOICE)
                                {
                                    areaDetectFlag = true;
                                }
                                break;
                        }
                        break;

                }

                bool isFirst = true;
                while (currentTime <= endTime)
                {
                    if (_stopFlag) return new DetectImageObject(System.Drawing.Point.Empty, null);
                    Thread.Sleep(WAIT_TIME1);
                    if (!isFirst)
                    {
                        SetMouseScroll(proc);
                    }
                    isFirst = false;
                    List<Bitmap> tmpList = new List<Bitmap>();
                    switch (imageIndex)
                    {
                        case -1:
                            foreach (var img in proc.CaptureImage)
                            {
                                if (_stopFlag) return new DetectImageObject(System.Drawing.Point.Empty, null);
                                if (img.Value != null)
                                {
                                    tmpList.Add(img.Value);
                                }
                            }
                            break;
                        default:
                            tmpList.Add(proc.CaptureImage[imageIndex]);
                            break;
                    }
                    foreach (var screen in Screen.AllScreens)
                    {
                        if (_stopFlag) return new DetectImageObject(System.Drawing.Point.Empty, null);
                        Thread.Sleep(WAIT_TIME1);
                        Cursor.Hide();
                        Bitmap src = null;
                        //範囲選択検出の場合
                        if (areaDetectFlag)
                        {
                            int sx = int.Parse(proc.DetectAreaSX);
                            int sy = int.Parse(proc.DetectAreaSY);
                            int ex = int.Parse(proc.DetectAreaEX);
                            int ey = int.Parse(proc.DetectAreaEY);
                            if (screen.Bounds.X <= sx && screen.Bounds.Y <= sy && screen.Bounds.Width >= ex - sx && screen.Bounds.Height >= ey - sy)
                            {
                                src = CaptureUtil.CaptureScreen(screen, new Rectangle(sx, sy, ex - sx, ey - sy));
                            }
                            else
                            {
                                //2画面目等、キャプチャエリアに範囲が収まっていない場合はスキップ
                                continue;
                            }
                        }
                        else
                        {
                            //ｽｸﾘｰﾝ全体をｷｬﾌﾟﾁｬ
                            src = CaptureUtil.CaptureScreen(screen, screen.Bounds);
                        }
                        Cursor.Show();
                        foreach (var tmp in tmpList)
                        {
                            if (_stopFlag) return new DetectImageObject(System.Drawing.Point.Empty, null);
                            OpenCvSharp.Point[] matchPoint = MatchTemplate(src, tmp);
                            if (matchPoint[0] != null && matchPoint[1] != null)
                            {
                                if (matchPoint[1].X > 0 || matchPoint[1].Y > 0)
                                {
                                    int centerX = screen.Bounds.X + matchPoint[1].X + tmp.Width / 2;
                                    int centerY = screen.Bounds.Y + matchPoint[1].Y + tmp.Height / 2;
                                    //範囲指定検出の場合、差分を加算
                                    if (areaDetectFlag)
                                    {
                                        centerX += int.Parse(proc.DetectAreaSX);
                                        centerY += int.Parse(proc.DetectAreaSY);
                                    }
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog("画像検出しました。 ⇒ [" + (screen.Bounds.X + matchPoint[1].X) + "," + (screen.Bounds.Y + matchPoint[1].Y) + "]"), _projectModel);
                                    src.Dispose();
                                    return new DetectImageObject(new System.Drawing.Point(centerX, centerY), tmp);
                                }
                            }
                        }
                        src.Dispose();
                    }
                    if (proc.Timeout > 0)
                    {
                        currentTime = DateTime.Now;
                    }
                }
                return new DetectImageObject(System.Drawing.Point.Empty, null);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 画像検出し、マウスを移動する
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="imageIndex"></param>
        /// <returns></returns>
        private bool ActionMouseImageDetectMove(ProcessModel proc, int imageIndex)
        {
            try
            {
                DetectImageObject pos = GetImageDetectPoint(proc, imageIndex);
                if (pos.DetectPoint == System.Drawing.Point.Empty) return false;

                if (_stopFlag) return false;

                int centerX = pos.DetectPoint.X + proc.OffsetXPoint;
                int centerY = pos.DetectPoint.Y + proc.OffsetYPoint;
                MoveMouse(centerX, centerY);
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウス座標を取得する
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private System.Drawing.Point GetMousePoint(ProcessModel proc)
        {
            try
            {
                int centerX = 0;
                int centerY = 0;
                POINT point;
                GetCursorPos(out point);
                if (proc != null)
                {
                    centerX = proc.OffsetXPoint;
                    centerY = proc.OffsetYPoint;
                    switch (proc.PointType)
                    {
                        case PointType.相対座標:
                            centerX += point.X;
                            centerY += point.Y;
                            break;
                    }
                }
                else
                {
                    centerX = point.X;
                    centerY = point.Y;
                }
                return new System.Drawing.Point(centerX, centerY);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウス移動を実行する
        /// </summary>
        /// <param name="proc"></param>
        private void ActionMouseMove(ProcessModel proc)
        {
            try
            {
                System.Drawing.Point pos = GetMousePoint(proc);
                MoveMouse(pos.X, pos.Y);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// マウスクリックを実行する
        /// </summary>
        /// <param name="proc"></param>
        private void ActionMouseClick(ProcessModel proc)
        {
            try
            {
                for (int i = 0; i < proc.ClickCount; i++)
                {
                    if (_stopFlag) return;
                    //KeyDown
                    if (proc.KeyboardInputKeycodes != null)
                    {
                        foreach (var input in proc.KeyboardInputKeycodes)
                        {
                            keybd_event((byte)input, 0, 0, new UIntPtr(0));
                        }
                        Thread.Sleep(WAIT_TIME2);
                    }
                    switch (proc.ClickPosition)
                    {
                        case MouseClickPosition.左クリック:

                            mouse_event(0x2, 0, 0, 0, 0);
                            Thread.Sleep(WAIT_TIME2);
                            mouse_event(0x4, 0, 0, 0, 0);

                            break;
                        case MouseClickPosition.ホイールクリック:
                            mouse_event(0x0080, 0, 0, 0, 0);
                            Thread.Sleep(WAIT_TIME2);
                            mouse_event(0x0100, 0, 0, 0, 0);
                            break;
                        case MouseClickPosition.右クリック:
                            mouse_event(0x0008, 0, 0, 0, 0);
                            Thread.Sleep(WAIT_TIME2);
                            mouse_event(0x0010, 0, 0, 0, 0);
                            Thread.Sleep(WAIT_TIME2);
                            break;
                    }
                    //KeyUp
                    if (proc.KeyboardInputKeycodes != null)
                    {
                        foreach (var input in proc.KeyboardInputKeycodes)
                        {
                            keybd_event((byte)input, 0, 0x0002, new UIntPtr(0));
                        }
                        Thread.Sleep(WAIT_TIME2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// メール送信を行う
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionSendMail(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                Dictionary<int, string> attachList = (Dictionary<int, string>)proc.Mail_AttachList.DeepCopy();
                for (int i = 0; i < attachList.Count; i++)
                {
                    if (_stopFlag) return false;
                    int key = attachList.ElementAt(i).Key;
                    string value = attachList.ElementAt(i).Value;
                    attachList[key] = SetFunction(variableList, arrayVariableList, value, proc);
                }
                MailUtil.Send(proc.Mail_SenderName
                    , proc.Mail_SenderAddress
                    , proc.Mail_ReceiverName
                    , proc.Mail_ReceiverAddress
                    , SetFunction(variableList, arrayVariableList, proc.Mail_Title, proc)
                    , SetFunction(variableList, arrayVariableList, proc.Mail_Text, proc)
                    , proc.Mail_Host
                    , int.Parse(proc.Mail_Port)
                    , proc.Mail_Username
                    , proc.Mail_Password
                    , attachList);
                return true;
            }
            catch (Exception ex)
            {
                OnLogEvent?.Invoke(LogType.ERROR, SetLog("メール送信に失敗 : " + ex.Message), _projectModel);
                return false;
            }
        }
        /// <summary>
        /// 外部アプリを起動する
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionAppStart(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                ProcessStartInfo info = new ProcessStartInfo();
                info.Arguments = SetFunction(variableList, arrayVariableList, proc.AppExecuteArgs, proc);
                info.FileName = SetFunction(variableList, arrayVariableList, proc.AppExecutePath, proc);
                info.WindowStyle = proc.AppWindowStyle;
                Process process = Process.Start(info);

                switch (proc.AppStartType)
                {
                    case AppStartType.待機する:
                        if (proc.Timeout > 0)
                        {
                            process.WaitForExit(proc.Timeout);
                        }
                        else
                        {
                            process.WaitForExit();
                        }
                        if (!process.HasExited)
                        {
                            OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 外部アプリは終了していません。"), _projectModel);
                            return false;
                        }
                        OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : 外部アプリ実行終了コード ⇒ " + process.ExitCode), _projectModel);
                        return process.ExitCode == proc.AppExitCode;
                }
                return true;

            }
            catch (Exception ex)
            {
                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 外部アプリ実行エラー ⇒ " + ex.Message), _projectModel);
                return false;
            }
        }

        /// <summary>
        /// ファイルフォルダー処理を実行する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionFileFolder(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                string path1 = SetFunction(variableList, arrayVariableList, proc.FileFolderPath1, proc);
                string path2 = SetFunction(variableList, arrayVariableList, proc.FileFolderPath2, proc);
                switch (proc.FileFolderActionType)
                {
                    case FileFolderActionType.ファイル:
                        switch (proc.FileFolderExecType)
                        {
                            case FileFolderExecType.Detect:
                                {
                                    DateTime currentTime = DateTime.Now;
                                    DateTime endTime = currentTime.AddMilliseconds(proc.Timeout);
                                    while (currentTime <= endTime)
                                    {
                                        if (_stopFlag) return false;
                                        if (System.IO.File.Exists(path1))
                                        {
                                            OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイル検出 ⇒ " + path1), _projectModel);
                                            return true;
                                        }
                                        Thread.Sleep(WAIT_TIME2);
                                        if (proc.Timeout > 0)
                                        {
                                            currentTime = DateTime.Now;
                                        }
                                    }
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル検出失敗 ⇒ " + path1), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Create:
                                try
                                {
                                    System.IO.File.Create(path1);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイル作成成功 ⇒ " + path1), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル作成失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Remove:
                                try
                                {
                                    System.IO.File.Delete(path1);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイル削除成功 ⇒ " + path1), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル削除失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Move:
                                try
                                {
                                    System.IO.File.Move(path1, path2);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイル移動成功 ⇒ " + path1 + " ⇒ " + path2), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル移動失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Copy:
                                try
                                {
                                    System.IO.File.Copy(path1, path2, true);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイルコピー成功 ⇒ " + path1 + " ⇒ " + path2), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルコピー失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.SaveUdate:
                                try
                                {
                                    System.IO.FileInfo info = new FileInfo(path1);
                                    variableList[proc.VariableKey].Value = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイル日時取得成功 ⇒ " + variableList[proc.VariableKey]), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル日時取得失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Archive:
                                try
                                {
                                    ZipUtil.CompressFile(path1, path2, SetFunction(variableList, arrayVariableList, proc.ArchiveFilePassword, proc));
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル圧縮失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.UnArchive:
                                try
                                {
                                    ZipUtil.ExtractZipFile(path1, path2, SetFunction(variableList, arrayVariableList, proc.ArchiveFilePassword, proc));
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイル解凍失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                        }
                        break;
                    case FileFolderActionType.フォルダ:
                        switch (proc.FileFolderExecType)
                        {
                            case FileFolderExecType.Detect:
                                {
                                    DateTime currentTime = DateTime.Now;
                                    DateTime endTime = currentTime.AddMilliseconds(proc.Timeout);
                                    while (currentTime <= endTime)
                                    {
                                        if (_stopFlag) return false;
                                        if (System.IO.Directory.Exists(path1))
                                        {
                                            OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : フォルダ検出 ⇒ " + path1), _projectModel);
                                            return true;
                                        }
                                        Thread.Sleep(WAIT_TIME2);
                                        if (proc.Timeout > 0)
                                        {
                                            currentTime = DateTime.Now;
                                        }
                                    }
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ検出失敗 ⇒ " + path1), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Create:
                                try
                                {
                                    System.IO.Directory.CreateDirectory(path1);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : フォルダ作成成功 ⇒ " + path1), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ作成失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Remove:
                                try
                                {
                                    System.IO.Directory.Delete(path1, true);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : フォルダ削除成功 ⇒ " + path1), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ削除失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Move:
                                try
                                {
                                    System.IO.Directory.Move(path1, path2);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : フォルダ移動成功 ⇒ " + path1 + " ⇒ " + path2), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ移動失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Copy:
                                try
                                {
                                    FileUtil.CopyDirectory(path1, path2);
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : フォルダコピー成功 ⇒ " + path1 + " ⇒ " + path2), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダコピー失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.SaveUdate:
                                try
                                {
                                    System.IO.DirectoryInfo info = new DirectoryInfo(path1);
                                    variableList[proc.VariableKey].Value = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
                                    OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : フォルダ日時取得成功 ⇒ " + variableList[proc.VariableKey]), _projectModel);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ日時取得失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.Archive:
                                try
                                {
                                    ZipUtil.CompressFolder(path1, path2, SetFunction(variableList, arrayVariableList, proc.ArchiveFilePassword, proc));
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ圧縮失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                            case FileFolderExecType.UnArchive:
                                try
                                {
                                    ZipUtil.ExtractFolder(path1, path2, SetFunction(variableList, arrayVariableList, proc.ArchiveFilePassword, proc));
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : フォルダ解凍失敗 ⇒ " + ex.Message), _projectModel);
                                }
                                break;
                        }
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ダイアログ処理を実行する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionDialog(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                DialogResult result = MessageBox.Show(null, SetFunction(variableList, arrayVariableList, proc.DialogText, proc), "Macrobo - ダイアログ", proc.DialogButtonType, proc.DialogType, MessageBoxDefaultButton.Button1);
                return (result == DialogResult.OK || result == DialogResult.Yes);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// Excel処理を実行する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionExcel(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                IWorkbook workbook = null;
                string loadPath = "";
                string savePath = proc.FileFolderPath2;
                Dictionary<string, VariableModel> vlist;
                Dictionary<string, ArrayVariableModel> avlist;


                switch (proc.ExcelSourceType)
                {
                    case ExcelSourceType.新規作成:
                        var extension = Path.GetExtension(savePath);
                        if (extension.ToUpper() == ".XLS")
                        {
                            workbook = new HSSFWorkbook();
                        }
                        else
                        {
                            workbook = new XSSFWorkbook();
                        }
                        break;
                    case ExcelSourceType.既存ファイル:
                        loadPath = SetFunction(variableList, arrayVariableList, proc.FileFolderPath1, proc);
                        if (!System.IO.File.Exists(loadPath))
                        {
                            OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルが見つかりません。"), _projectModel);
                            return false;
                        }
                        if (FileUtil.IsFileLocked(loadPath))
                        {
                            OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルがオープン出来ません。"), _projectModel);
                            return false;
                        }
                        if (System.IO.Path.GetExtension(loadPath).ToUpper() != ".XLS"
                            && System.IO.Path.GetExtension(loadPath).ToUpper() != ".XLSX")
                        {
                            OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : Excelファイルではありません。"), _projectModel);
                            return false;
                        }
                        workbook = WorkbookFactory.Create(loadPath);
                        break;
                }
                foreach(KeyValuePair<int, ExcelJobModel> pair in proc.ExcelJobList)
                {

                    if (_stopFlag) return false;
                    ExcelJobModel model = pair.Value;
                    string sheetName = SetFunction(variableList, arrayVariableList, model.SheetName, proc);
                    string cellName = SetFunction(variableList, arrayVariableList, model.CellName, proc);
                    

                    ISheet sheet = workbook.GetSheet(sheetName);
                    if(sheet == null)
                    {
                        sheet = workbook.CreateSheet(sheetName);
                    }
                    IRow row = null;
                    ICell cell = null;
                    try
                    {
                        CellReference reference = new CellReference(cellName);
                        row = sheet.GetRow(reference.Row);
                        if (row == null)
                        {
                            row = sheet.CreateRow(reference.Row);
                        }
                        // セルを取得
                        cell = row.GetCell(reference.Col);
                        if (cell == null)
                        {
                            cell = row.CreateCell(reference.Col);
                        }
                    }
                    catch (Exception)
                    {
                        OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : セルの位置が不正です。[" + cellName + "]"), _projectModel);
                        return false;
                    }

                    switch (model.FileReadWriteType)
                    {
                        case FileReadWriteType.Read:
                            {
                                string variable = model.Value;
                                if (model.Value.Length > 2 && model.Value.Substring(0, 2) == "$$")
                                {
                                    vlist = _projectModel.VariableList;
                                    avlist = _projectModel.ArrayVariableList;
                                }
                                else
                                {
                                    vlist = variableList;
                                    avlist = arrayVariableList;
                                }
                                while (true)
                                {
                                    if (variable[0] == '$')
                                    {
                                        variable = variable.Substring(1);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                variable = SetFunction(vlist, avlist, variable, proc);
                                string arrayIndex = "";
                                int idx1 = 0;
                                int idx2 = 0;
                                if (variable.Contains("[") && variable.Contains("]"))
                                {
                                    arrayIndex = variable.Substring(variable.IndexOf('['));
                                    variable = variable.Replace(arrayIndex, "");
                                    arrayIndex = arrayIndex.Replace("][", ":").Replace("[", "").Replace("]", "");
                                    if (!arrayIndex.Contains(":"))
                                    {
                                        OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 配列の定義が不正です。"), _projectModel);
                                        return false;
                                    }
                                    if (!int.TryParse(arrayIndex.Split(':')[0], out idx1))
                                    {
                                        OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 配列のIndex1指示が不正です。"), _projectModel);
                                        return false;
                                    }
                                    if (!int.TryParse(arrayIndex.Split(':')[1], out idx2))
                                    {
                                        OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 配列のIndex2指示が不正です。"), _projectModel);
                                        return false;
                                    }
                                }
                                string setValue = "";
                                switch (cell.CellType)
                                {
                                    case CellType.Blank:
                                    case CellType.Error:
                                    case CellType.Formula:
                                    case CellType.Unknown:
                                        setValue = "";
                                        break;
                                    case CellType.Boolean:
                                        setValue = "" + cell.BooleanCellValue.ToString();
                                        break;
                                    case CellType.String:
                                        setValue = "" + cell.StringCellValue;
                                        break;
                                    case CellType.Numeric:
                                        setValue = "" + cell.NumericCellValue;
                                        break;
                                }
                                if (vlist.ContainsKey(variable))
                                {
                                    vlist[variable].Value = setValue;
                                }
                                else if (avlist.ContainsKey(variable))
                                {
                                    ArrayVariableModel avModel = avlist[variable];
                                    bool setFlag = false;
                                    if (avModel.ValueList != null)
                                    {
                                        if (avModel.ValueList.Count > 0 && avModel.ValueList.Count - 1 <= idx1)
                                        {
                                            if (avModel.ValueList[idx1].Count - 1 < idx2)
                                            {
                                                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 配列のIndex2の指示が要素数[" + avModel.ColumnCount + "]を超えています。"), _projectModel);
                                                return false;
                                            }
                                            else
                                            {
                                                avModel.ValueList[idx1][idx2] = setValue;
                                                setFlag = true;
                                            }
                                        }
                                    }
                                    if (!setFlag)
                                    {
                                        while (avModel.ValueList.Count - 1 < idx1)
                                        {
                                            avModel.ValueList.Add(GetNewStringList("", avModel.ColumnCount));
                                        }
                                        if (avModel.ValueList[idx1].Count - 1 < idx2)
                                        {
                                            OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 配列のIndex2の指示が要素数[" + avModel.ColumnCount + "]を超えています。"), _projectModel);
                                            return false;
                                        }
                                        avModel.ValueList[idx1][idx2] = setValue;
                                    }
                                }
                            }
                            break;
                        case FileReadWriteType.Write:
                            {
                                cell.SetCellValue(SetFunction(variableList, arrayVariableList, model.Value, proc));
                            }
                            break;
                    }
                }

                if (_stopFlag) return false;
                //ブックを保存
                using (var fs = new FileStream(savePath, FileMode.Create))
                {
                    workbook.Write(fs);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 配列を指定の値で、指定要素分初期化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        private List<string> GetNewStringList(string value, int columnCount)
        {
            try
            {
                return Enumerable.Repeat(value, columnCount).ToList(); ;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 変数入出力を実行する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariable(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                if (_stopFlag) return false;
                switch (proc.VariableExecType)
                {
                    case VariableExecType.キーボード入力:
                        return ActionVariableKeyboadInput(variableList, arrayVariableList, proc);
                    case VariableExecType.ファイル入力:
                        return ActionVariableFileInput(variableList, arrayVariableList, proc);
                    case VariableExecType.ファイル出力:
                        return ActionVariableFileOutput(variableList, arrayVariableList, proc);
                    case VariableExecType.クリップボード入力:
                        return ActionVariableClipboardInput(variableList, arrayVariableList, proc);
                    case VariableExecType.クリップボード出力:
                        return ActionVariableClipboardOutput(variableList, arrayVariableList, proc);
                    case VariableExecType.変数比較:
                        return ActionVariableContain(variableList, arrayVariableList, proc);
                    case VariableExecType.加算減算:
                        return ActionVariableCalc(variableList, arrayVariableList, proc);
                    case VariableExecType.Excel入力:
                        return ActionVariableExcelInput(variableList, arrayVariableList, proc);
                    case VariableExecType.Excel出力:
                        return ActionVariableExcelOutput(variableList, arrayVariableList, proc);
                    case VariableExecType.WEBサービス入力:
                        return ActionVariableWebInput(variableList, arrayVariableList, proc);
                }
               return false;
            }
            catch (Exception ex)
            {
                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 実行エラー ⇒ " + ex.Message), _projectModel);
                return false;
            }
        }
        /// <summary>
        /// WEBサービスよりデータを変数にセットする
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableWebInput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string url = SetFunction(variableList, arrayVariableList, proc.VariableInoutFilePath, proc);

                Dictionary<string, string> param = new Dictionary<string, string>();
                foreach(var p in proc.UrlParam)
                {
                    string key = SetFunction(variableList, arrayVariableList, p.Key, proc);
                    string value = SetFunction(variableList, arrayVariableList, p.Value, proc);
                    param.Add(key, value);
                }

                List<string[]> errMsg = new List<string[]>();
               string result = AsyncUtil.RunSync(() => GetValueFromWeb(proc, errMsg, url, param));
                if (errMsg.Count > 0)
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : " + errMsg[0][0] + " ⇒ " + errMsg[0][1]), _projectModel);
                    return false;
                }

                switch (proc.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        switch (proc.FileOutputType)
                        {
                            case FileOutputType.上書き:
                                variableList[proc.VariableKey].Value = result;
                                break;
                            case FileOutputType.追記:
                                variableList[proc.VariableKey].Value += result;
                                break;
                        }
                        break;
                    case VariableChoiceType.変数配列:
                        switch (proc.VariableInputTargetType)
                        {
                            case InputTargetType.変数:
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromString(result, proc, false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromString(result, proc, true);
                                        break;
                                }
                                variableList[proc.VariableKey].Value = "" + arrayVariableList[proc.ArrayVariableKey].ValueList.Count;
                                break;
                            case InputTargetType.要素:
                                string rowIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableRowIndex, proc);
                                string columnIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableColumnIndex, proc);
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromString(result, int.Parse(rowIndex), int.Parse(columnIndex), false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromString(result, int.Parse(rowIndex), int.Parse(columnIndex), true);
                                        break;
                                }
                                break;
                        }

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
        /// カレンダーをWEBより取得する
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="errorMsg"></param>
        /// <param name="siteUrl"></param>
        /// <param name="delimitter"></param>
        /// <returns></returns>
        public async Task<string> GetValueFromWeb(ProcessModel proc, List<string[]> errorMsg, string siteUrl, Dictionary<string, string> parameters)
        {
            try
            {
                string resultDates = "";
                var content = new FormUrlEncodedContent(parameters);
                string encode = "";
                switch (proc.EncodeType)
                {
                    case EncodeType.SHIFT_JIS:
                        encode = "Shift_JIS";
                        break;
                    case EncodeType.UTF8:
                        encode = "UTF-8";
                        break;
                    case EncodeType.EUC_JP:
                        encode = "EUC-JP";
                        break;
                    case EncodeType.UTF16:
                        encode = "UTF-16";
                        break;
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
                            resultDates = await reader.ReadToEndAsync();
                            resultDates = resultDates.Replace("\r", "");
                            resultDates = resultDates.TrimEnd('\n');

                            if (string.IsNullOrEmpty(resultDates))
                            {
                                errorMsg?.Add(new string[] { "データエラー", "データを取得できませんでした。取得先URLやパラメーターをご確認ください。" });
                                return null;
                            }
                            else
                            {
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
        /// 変数アクション、変数への加算減算
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableCalc(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                switch (proc.VariableCalcType)
                {
                    case VariableCalcType.加算:
                        variableList[proc.VariableKey].Value = "" + (decimal.Parse(variableList[proc.VariableKey].Value) + proc.VariableCalcCount);
                        OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : 加算しました。 ⇒ " + variableList[proc.VariableKey].Value), _projectModel);
                        break;
                    case VariableCalcType.減算:
                        variableList[proc.VariableKey].Value = "" + (decimal.Parse(variableList[proc.VariableKey].Value) - proc.VariableCalcCount);
                        OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : 減算しました。 ⇒ " + variableList[proc.VariableKey].Value), _projectModel);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 変数アクション、変数比較
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableContain(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                switch (proc.CompareTypeType)
                {
                    case CompareTypeType.数値:
                        {
                            try
                            {
                                double dat1 = double.Parse(SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey].Value, proc));
                                double dat2 = 0;
                                switch (proc.VariableCompareTargetType)
                                {
                                    case VariableCompareTargetType.入力:
                                        dat2 = double.Parse(SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc));
                                        break;
                                    case VariableCompareTargetType.変数:
                                        dat2 = double.Parse(SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey2].Value, proc));
                                        break;
                                }
                                switch (proc.CompareOperatorType)
                                {
                                    case CompareOperatorType.以上:
                                        return dat1 >= dat2;
                                    case CompareOperatorType.以下:
                                        return dat1 <= dat2;
                                    case CompareOperatorType.同値:
                                        return dat1 == dat2;
                                    case CompareOperatorType.大きい:
                                        return dat1 > dat2;
                                    case CompareOperatorType.小さい:
                                        return dat1 < dat2;
                                }
                            }
                            catch (Exception ex)
                            {
                                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 数値比較エラー ⇒ " + ex.Message), _projectModel);
                                return false;
                            }

                        }
                        break;
                    case CompareTypeType.文字列:
                        {

                            try
                            {
                                string dat1 = "" + SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey].Value, proc);
                                string dat2 = "";
                                switch (proc.VariableCompareTargetType)
                                {
                                    case VariableCompareTargetType.入力:
                                        dat2 = "" + SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc);
                                        break;
                                    case VariableCompareTargetType.変数:
                                        dat2 = "" + SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey2].Value, proc);
                                        break;
                                }
                                switch (proc.CompareOperatorType)
                                {
                                    case CompareOperatorType.同値:
                                        return dat1 == dat2;
                                    case CompareOperatorType.含む:
                                        return dat1.Contains(dat2);
                                    case CompareOperatorType.含まない:
                                        return !dat1.Contains(dat2);
                                }
                            }
                            catch (Exception ex)
                            {
                                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 文字列比較エラー ⇒ " + ex.Message), _projectModel);
                                return false;
                            }

                        }
                        break;
                    case CompareTypeType.日付:
                        {
                            try
                            {
                                DateTime dat1 = DateTime.Parse(SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey].Value, proc));
                                DateTime dat2 = DateTime.Now;
                                switch (proc.VariableCompareTargetType)
                                {
                                    case VariableCompareTargetType.入力:
                                        dat2 = DateTime.Parse(SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc));
                                        break;
                                    case VariableCompareTargetType.変数:
                                        dat2 = DateTime.Parse(SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey2].Value, proc));
                                        break;
                                }
                                switch (proc.CompareOperatorType)
                                {
                                    case CompareOperatorType.以上:
                                        return dat1 >= dat2;
                                    case CompareOperatorType.以下:
                                        return dat1 <= dat2;
                                    case CompareOperatorType.同値:
                                        return dat1 == dat2;
                                    case CompareOperatorType.大きい:
                                        return dat1 > dat2;
                                    case CompareOperatorType.小さい:
                                        return dat1 < dat2;
                                }
                            }
                            catch (Exception ex)
                            {
                                OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : 日付比較エラー ⇒ " + ex.Message), _projectModel);
                                return false;
                            }

                        }
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 変数アクション、クリップボード出力
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableClipboardOutput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string clipBoardTxt = "";
                switch (proc.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        switch (proc.FileOutputType)
                        {
                            case FileOutputType.上書き:
                                clipBoardTxt = SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey].Value, proc);
                                break;
                            case FileOutputType.追記:
                                {
                                    Thread t2 = new Thread(new ThreadStart(() => {
                                        clipBoardTxt = Clipboard.GetText();
                                    }));
                                    t2.SetApartmentState(ApartmentState.STA);
                                    t2.Start();
                                    t2.Join();
                                    clipBoardTxt += SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey].Value, proc);
                                }
                                break;
                        }
                        break;
                    case VariableChoiceType.変数配列:
                        switch (proc.FileOutputType)
                        {
                            case FileOutputType.追記:
                                {
                                    Thread t2 = new Thread(new ThreadStart(() => {
                                        clipBoardTxt = Clipboard.GetText();
                                    }));
                                    t2.SetApartmentState(ApartmentState.STA);
                                    t2.Start();
                                    t2.Join();
                                }
                                break;
                        }
                        ArrayVariableModel model = arrayVariableList[proc.ArrayVariableKey];
                        switch (proc.VariableInputTargetType)
                        {
                            case InputTargetType.変数:
                                foreach (var rows in model.ValueList)
                                {
                                    string result = String.Join(proc.ArraySeparateType == ArraySeparateType.CSV ? "," : "\t", rows);
                                    clipBoardTxt += result + "\r\n";
                                }
                                clipBoardTxt = SetFunction(variableList, arrayVariableList, clipBoardTxt, proc);
                                break;
                            case InputTargetType.要素:
                                string rowIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableRowIndex, proc);
                                string columnIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableColumnIndex, proc);
                                clipBoardTxt += SetFunction(variableList, arrayVariableList, model.ValueList[int.Parse(rowIndex)][int.Parse(columnIndex)], proc);
                                break;
                        }

                        break;
                }

                Thread t = new Thread(new ThreadStart(() => {
                    if (string.IsNullOrEmpty(clipBoardTxt))
                    {
                        Clipboard.Clear();
                    }
                    else
                    {
                        Clipboard.SetText(clipBoardTxt);
                    }
                    
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 変数アクション、クリップボード入力
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableClipboardInput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string clipBoardTxt = "";
                Thread t = new Thread(new ThreadStart(() => {
                    clipBoardTxt = Clipboard.GetText();
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                switch (proc.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        switch (proc.FileOutputType)
                        {
                            case FileOutputType.上書き:
                                variableList[proc.VariableKey].Value = clipBoardTxt;
                                break;
                            case FileOutputType.追記:
                                variableList[proc.VariableKey].Value += clipBoardTxt;
                                break;
                        }
                        break;
                    case VariableChoiceType.変数配列:
                        switch (proc.VariableInputTargetType)
                        {
                            case InputTargetType.変数:
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromString(clipBoardTxt, proc, false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromString(clipBoardTxt, proc, true);
                                        break;
                                }
                                variableList[proc.VariableKey].Value = "" + arrayVariableList[proc.ArrayVariableKey].ValueList.Count;
                                break;
                            case InputTargetType.要素:
                                string rowIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableRowIndex, proc);
                                string columnIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableColumnIndex, proc);
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromString(clipBoardTxt, int.Parse(rowIndex), int.Parse(columnIndex), false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromString(clipBoardTxt, int.Parse(rowIndex), int.Parse(columnIndex), true);
                                        break;
                                }
                                break;
                        }

                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 変数アクション、ファイル出力
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableFileOutput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string filePath = SetFunction(variableList, arrayVariableList, proc.VariableInoutFilePath, proc);
                if (System.IO.File.Exists(filePath) && FileUtil.IsFileLocked(filePath))
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルがオープン出来ません。"), _projectModel);
                    return false;
                }
                switch (proc.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        using (StreamWriter sw = new StreamWriter(filePath, proc.FileOutputType == FileOutputType.追記, System.Text.Encoding.Default))
                        {
                            sw.Write(SetFunction(variableList, arrayVariableList, variableList[proc.VariableKey].Value, proc));
                        }
                        break;
                    case VariableChoiceType.変数配列:
                        ArrayVariableModel model = arrayVariableList[proc.ArrayVariableKey];
                        switch (proc.VariableInputTargetType)
                        {
                            case InputTargetType.変数:
                                using (StreamWriter sw = new StreamWriter(filePath, proc.FileOutputType == FileOutputType.追記, System.Text.Encoding.Default))
                                {
                                    foreach (var rows in model.ValueList)
                                    {
                                        string result = "";
                                        switch (proc.ArraySeparateType)
                                        {
                                            case ArraySeparateType.CSV:
                                                result = CsvUtil.ListToRowString(rows);
                                                break;
                                            case ArraySeparateType.TEXT:
                                                result = String.Join("\t", rows);
                                                break;
                                        }
                                        sw.WriteLine(SetFunction(variableList, arrayVariableList, result, proc));
                                    }
                                }
                                break;
                            case InputTargetType.要素:
                                using (StreamWriter sw = new StreamWriter(filePath, proc.FileOutputType == FileOutputType.追記, System.Text.Encoding.Default))
                                {
                                    string rowIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableRowIndex, proc);
                                    string columnIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableColumnIndex, proc);
                                    sw.WriteLine(SetFunction(variableList,arrayVariableList, model.ValueList[int.Parse(rowIndex)][int.Parse(columnIndex)], proc));
                                }
                                break;
                        }
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 変数の値をExcelに出力する。
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableExcelOutput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string filePath = SetFunction(variableList, arrayVariableList, proc.VariableInoutFilePath, proc);
                if (System.IO.File.Exists(filePath))
                {
                    if (FileUtil.IsFileLocked(filePath))
                    {
                        OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルがオープン出来ません。"), _projectModel);
                        return false;
                    }
                    if (System.IO.Path.GetExtension(filePath).ToUpper() != ".XLS"
                        && System.IO.Path.GetExtension(filePath).ToUpper() != ".XLSX")
                    {
                        OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : Excelファイルではありません。"), _projectModel);
                        return false;
                    }
                }
                arrayVariableList[proc.ArrayVariableKey].CreateExcel(filePath, proc.ExcelSheetName, proc.FileOutputType);
                return true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数アクション、Excel入力
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableExcelInput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string filePath = SetFunction(variableList, arrayVariableList, proc.VariableInoutFilePath, proc);
                if (!System.IO.File.Exists(filePath))
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルが見つかりません。"), _projectModel);
                    return false;
                }
                if (FileUtil.IsFileLocked(filePath))
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルがオープン出来ません。"), _projectModel);
                    return false;
                }
                if(System.IO.Path.GetExtension(filePath).ToUpper() != ".XLS"
                    && System.IO.Path.GetExtension(filePath).ToUpper() != ".XLSX")
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : Excelファイルではありません。"), _projectModel);
                    return false;
                }
                arrayVariableList[proc.ArrayVariableKey].SetValueFromExcelFile(filePath, proc.ExcelSheetName);
                variableList[proc.VariableKey].Value = "" + arrayVariableList[proc.ArrayVariableKey].ValueList.Count;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 変数アクション、ファイル入力
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionVariableFileInput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                string filePath = SetFunction(variableList, arrayVariableList, proc.VariableInoutFilePath, proc);
                if (!System.IO.File.Exists(filePath))
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルが見つかりません。"), _projectModel);
                    return false;
                }
                if (FileUtil.IsFileLocked(filePath))
                {
                    OnLogEvent?.Invoke(LogType.ERROR, SetLog(proc.Name + " : ファイルがオープン出来ません。"), _projectModel);
                    return false;
                }
                switch (proc.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        switch (proc.FileOutputType)
                        {
                            case FileOutputType.上書き:
                                variableList[proc.VariableKey].Value = File.ReadAllText(filePath);
                                break;
                            case FileOutputType.追記:
                                variableList[proc.VariableKey].Value += File.ReadAllText(filePath);
                                break;
                        }
                        break;
                    case VariableChoiceType.変数配列:
                        switch (proc.VariableInputTargetType)
                        {
                            case InputTargetType.変数:
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromFile(filePath, proc, false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromFile(filePath, proc, true);
                                        break;
                                }
                                variableList[proc.VariableKey].Value = "" + arrayVariableList[proc.ArrayVariableKey].ValueList.Count;
                                break;
                            case InputTargetType.要素:
                                string rowIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableRowIndex, proc);
                                string columnIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableColumnIndex, proc);
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromFile(proc, filePath, int.Parse(rowIndex), int.Parse(columnIndex), false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromFile(proc, filePath, int.Parse(rowIndex), int.Parse(columnIndex), true);
                                        break;
                                }
                                break;
                        }

                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 変数アクション、キーボード入力
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="proc"></param>
        private bool ActionVariableKeyboadInput(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                switch (proc.VariableChoiceType)
                {
                    case VariableChoiceType.単一変数:
                        switch (proc.FileOutputType)
                        {
                            case FileOutputType.上書き:
                                variableList[proc.VariableKey].Value = SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc);
                                break;
                            case FileOutputType.追記:
                                variableList[proc.VariableKey].Value += SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc);
                                break;
                        }
                        break;
                    case VariableChoiceType.変数配列:
                        switch (proc.VariableInputTargetType)
                        {
                            case InputTargetType.変数:
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromString(SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc), proc, false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetValueFromString(SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc), proc, true);
                                        break;
                                }
                                variableList[proc.VariableKey].Value = "" + arrayVariableList[proc.ArrayVariableKey].ValueList.Count;
                                break;
                            case InputTargetType.要素:
                                string elemValue = SetFunction(variableList, arrayVariableList, proc.VariableValueText, proc);
                                string rowIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableRowIndex, proc);
                                string columnIndex = SetFunction(variableList, arrayVariableList, proc.ArrayVariableColumnIndex, proc);
                                switch (proc.FileOutputType)
                                {
                                    case FileOutputType.上書き:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromString(elemValue, int.Parse(rowIndex), int.Parse(columnIndex), false);
                                        break;
                                    case FileOutputType.追記:
                                        arrayVariableList[proc.ArrayVariableKey].SetElementFromString(elemValue, int.Parse(rowIndex), int.Parse(columnIndex), true);
                                        break;
                                }
                                
                                break;
                        }

                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 検出を実行する
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool ActionDetect(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                switch (proc.DetectType)
                {
                    case DetectType.ファイル:
                        return DetectFileOrFolder(variableList, arrayVariableList, proc);
                    case DetectType.画像:
                        DetectImageObject point = GetImageDetectPoint(proc, -1);
                        if (point.DetectPoint == System.Drawing.Point.Empty) return false;
                        if (proc.MoveMouseType == MoveMouseType.移動する)
                        {
                            int centerX = point.DetectPoint.X;
                            int centerY = point.DetectPoint.Y;
                            MoveMouse(centerX, centerY);
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
        /// ファイル検出を行う
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        private bool DetectFileOrFolder(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel proc)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                DateTime endTime = currentTime.AddMilliseconds(proc.Timeout);
                while (currentTime <= endTime)
                {
                    if (_stopFlag) return false;
                    Thread.Sleep(WAIT_TIME1);
                    string folderPath = SetFunction(variableList, arrayVariableList, proc.DetectFolderPath, proc);
                    string detectFileName = SetFunction(variableList, arrayVariableList, proc.DetectFileName, proc).ToUpper();

                    if (System.IO.Directory.Exists(folderPath))
                    {
                        foreach (var file in System.IO.Directory.GetFiles(folderPath))
                        {
                            bool detectFlag = false;
                            switch (proc.FileDetectType)
                            {
                                case FileDetectType.完全一致:
                                    detectFlag = System.IO.Path.GetFileName(file).ToUpper() == detectFileName;
                                    break;
                                case FileDetectType.前方一致:
                                    detectFlag = System.IO.Path.GetFileName(file).ToUpper().StartsWith(detectFileName);
                                    break;
                                case FileDetectType.後方一致:
                                    detectFlag = System.IO.Path.GetFileName(file).ToUpper().EndsWith(detectFileName);
                                    break;
                                case FileDetectType.部分一致:
                                    detectFlag = System.IO.Path.GetFileName(file).ToUpper().Contains(detectFileName);
                                    break;
                            }
                            if (detectFlag)
                            {
                                switch (proc.DetectFileModeType)
                                {
                                    case DetectFileModeType.Exists:
                                        OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイルを検出しました。 ⇒ " + file), _projectModel);
                                        if (proc.VariableKey != StringValue.VARIABLE_未設定)
                                        {
                                            variableList[proc.VariableKey].Value = file;
                                        }
                                        return true;
                                    case DetectFileModeType.Readable:
                                        if (!FileUtil.IsFileNotReadable(file))
                                        {
                                            OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイルを検出しました。 ⇒ " + file), _projectModel);
                                            if (proc.VariableKey != StringValue.VARIABLE_未設定)
                                            {
                                                variableList[proc.VariableKey].Value = file;
                                            }
                                            return true;
                                        }
                                        break;
                                    case DetectFileModeType.Writable:
                                        if (!FileUtil.IsFileLocked(file))
                                        {
                                            OnLogEvent?.Invoke(LogType.INFO, SetLog(proc.Name + " : ファイルを検出しました。 ⇒ " + file), _projectModel);
                                            if (proc.VariableKey != StringValue.VARIABLE_未設定)
                                            {
                                                variableList[proc.VariableKey].Value = file;
                                            }
                                            return true;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    if(proc.Timeout > 0)
                    {
                        currentTime = DateTime.Now;
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
        /// マウススクロールを行う
        /// </summary>
        /// <param name="proc"></param>
        private void SetMouseScroll(ProcessModel proc)
        {
            try
            {
                switch (proc.ScrollType)
                {
                    case ScrollType.下スクロール:
                        mouse_event(0x0800, 0, 0, -60 * proc.ScrollAmount, 0);
                        Thread.Sleep(proc.ScrollSpeed * WAIT_TIME1);
                        break;
                    case ScrollType.上スクロール:
                        mouse_event(0x0800, 0, 0, 60 * proc.ScrollAmount, 0);
                        Thread.Sleep(proc.ScrollSpeed * WAIT_TIME1);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// テンプレートマッチングを行う
        /// </summary>
        /// <param name="src"></param>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public OpenCvSharp.Point[] MatchTemplate(Bitmap src , Bitmap tmp)
        {
            try
            {
                OpenCvSharp.Point minPoint;
                OpenCvSharp.Point maxPoint;
                var convSrc = BitmapConverter.ToMat(src);
                var convTmp = BitmapConverter.ToMat(tmp);
                var result = new Mat();
                Cv2.MatchTemplate(convSrc, convTmp, result, TemplateMatchModes.CCoeffNormed);
                Cv2.Threshold(result, result, 0.99, 1.0, ThresholdTypes.Binary);
                Cv2.MinMaxLoc(result, out minPoint, out maxPoint);
                result.Dispose();
                convTmp.Dispose();
                convSrc.Dispose();
                result = null;
                convTmp = null;
                convSrc = null;
                return new OpenCvSharp.Point[] { minPoint, maxPoint };
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
    /// <summary>
    /// 検出画像イメージクラス
    /// </summary>
    public class DetectImageObject
    {
        /// <summary>
        /// 検出座標を保持
        /// </summary>
        public System.Drawing.Point DetectPoint { get; set; }
        /// <summary>
        /// 検出画像を保持
        /// </summary>
        public Bitmap DetectImage { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="bmp"></param>
        public DetectImageObject(System.Drawing.Point dp, Bitmap bmp)
        {
            DetectPoint = dp;
            DetectImage = bmp;
        }
    }
    /// <summary>
    /// Macro実行後の次処理用オブジェクトを格納する
    /// </summary>
    public class MacroResultData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="variableList"></param>
        /// <param name="arrayVariableList"></param>
        /// <param name="process"></param>
        /// <param name="returnCode"></param>
        public MacroResultData(Dictionary<string, VariableModel> variableList, Dictionary<string, ArrayVariableModel> arrayVariableList, ProcessModel process, int returnCode)
        {
            VariableList = variableList;
            ArrayVariableList = arrayVariableList;
            Process = process;
            ReturnCode = returnCode;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="errorMsg"></param>
        public MacroResultData(int returnCode, string errorMsg)
        {
            ErrorMessage = errorMsg;
            ReturnCode = returnCode;
        }
        /// <summary>
        /// 変数リスト
        /// </summary>
        public Dictionary<string, VariableModel> VariableList { get; set; }
        /// <summary>
        /// 変数配列リスト
        /// </summary>
        public Dictionary<string, ArrayVariableModel> ArrayVariableList { get; set; }
        /// <summary>
        /// プロセスモデル
        /// </summary>
        public ProcessModel Process { get; set; }
        /// <summary>
        /// 0 : 正常終了
        /// 1 : 以上終了
        /// 2 : キャンセル
        /// </summary>
        public int ReturnCode { get; set; }
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage { get; set; }
    }
    /// <summary>
    /// マクロ実行モード
    /// </summary>
    public enum MacroExecMode
    {
        ALL, SINGLE, BELOWSELECTION, SELECTION
    }
}
