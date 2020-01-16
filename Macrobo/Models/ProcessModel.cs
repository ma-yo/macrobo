using Newtonsoft.Json;
using Macrobo.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Macrobo.Models.Enums;

namespace Macrobo.Models
{
    /// <summary>
    /// Author : M.Yoshida
    /// マクロデータ
    /// </summary>
    [Serializable]
    public class ProcessModel
    {
        /// <summary>
        /// 一意の処理ID
        /// </summary>
        public string ProcessId { get; set; }
        /// <summary>
        /// 処理名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// プロセスの説明文
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 処理タイプ
        /// </summary>
        public ProcessType ProcessType { get; set; }
        /// <summary>
        /// キャプチャイメージ
        /// </summary>
        [JsonIgnore]
        public Dictionary<int, Bitmap> CaptureImage { get; set; }
        /// <summary>
        /// キャプチャイメージのバイト配列
        /// </summary>
        public Dictionary<int, byte[]> CaptureImageByte { get; set; }
        /// <summary>
        /// タイムアウト
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 次の処理への移動先
        /// </summary>
        [JsonIgnore]
        public ProcessModel NextProcess { get; set; }
        public string NextProcessId;
        /// <summary>
        /// タイムアウト時の処理の移動先
        /// </summary>
        [JsonIgnore]
        public ProcessModel ErrorProcess { get; set; }
        public string ErrorProcessId;
        /// <summary>
        /// キーボード入力タイプ
        /// </summary>
        public KeyboardInputType KeyboardInputType { get; set; }
        /// <summary>
        /// キーボード入力文字列
        /// </summary>
        public string KeyboardInput { get; set; }
        /// <summary>
        /// キーボード入力キーコードを保持する
        /// </summary>
        public List<Keys> KeyboardInputKeycodes { get; set; }
        /// <summary>
        /// クリック回数を保持する
        /// </summary>
        public decimal ClickCount { get; set; }
        /// <summary>
        /// マウスクリック場所を保持する
        /// </summary>
        public MouseClickPosition ClickPosition { get; set; }
        /// <summary>
        /// オフセットX座標
        /// </summary>
        public int OffsetXPoint { get; set; }
        /// <summary>
        /// オフセットY座標
        /// </summary>
        public int OffsetYPoint { get; set; }
        /// <summary>
        /// スクロールタイプ
        /// </summary>
        public ScrollType ScrollType { get; set; }
        /// <summary>
        /// マウス移動有無
        /// </summary>
        public MoveMouseType MoveMouseType { get; set; }
        /// <summary>
        /// マウスクリック検出タイプ
        /// </summary>
        public MouseInputDetectType MouseClickDetectType { get; set; }
        /// <summary>
        /// 座標タイプ
        /// </summary>
        public PointType PointType { get; set; }
        /// <summary>
        /// マウスイベント実行タイプ
        /// </summary>
        public MouseInputType MouseExecType { get; set; }
        /// <summary>
        /// 送信者名
        /// </summary>
        public string Mail_SenderName { get; set; }
        /// <summary>
        /// 送信者アドレス
        /// </summary>
        public string Mail_SenderAddress { get; set; }
        /// <summary>
        /// 受信者名
        /// </summary>
        public string Mail_ReceiverName { get; set; }
        /// <summary>
        /// 受信者アドレス
        /// </summary>
        public string Mail_ReceiverAddress { get; set; }
        /// <summary>
        /// メールSubject
        /// </summary>
        public string Mail_Title { get; set; }
        /// <summary>
        /// メール本文
        /// </summary>
        public string Mail_Text { get; set; }
        /// <summary>
        /// SMTPホスト
        /// </summary>
        public string Mail_Host { get; set; }
        /// <summary>
        /// ポート番号
        /// </summary>
        public string Mail_Port { get; set; }
        /// <summary>
        /// SMTP認証パスワード
        /// </summary>
        public string Mail_Password { get; set; }
        /// <summary>
        /// SMTP認証ユーザー名
        /// </summary>
        public string Mail_Username { get; set; }
        /// <summary>
        /// メール添付リスト
        /// </summary>
        public Dictionary<int, string> Mail_AttachList { get; set; }
        /// <summary>
        /// 有効区分
        /// </summary>
        public ValidType ValidType { get; set; }
        /// <summary>
        /// 実行前待機時間
        /// </summary>
        public int BeforeWaitMilliTime { get; set; }
        /// <summary>
        /// 実行後待機時間
        /// </summary>
        public int AfterWaitMilliTime { get; set; }
        /// <summary>
        /// 画面スクロールスピード
        /// </summary>
        public int ScrollSpeed { get; set; }
        /// <summary>
        /// スクロール量
        /// </summary>
        public int ScrollAmount { get; set; }
        /// <summary>
        /// スクロール回数
        /// </summary>
        public int ScrollCount { get; set; }
        /// <summary>
        /// アプリケーション実行タイプ
        /// </summary>
        public AppStartType AppStartType { get; set; }
        /// <summary>
        /// アプリケーション実行パス
        /// </summary>
        public string AppExecutePath { get; set; }
        /// <summary>
        /// アプリケーション起動引数
        /// </summary>
        public string AppExecuteArgs { get; set; }
        /// <summary>
        /// アプリ起動時のウインドウスタイル
        /// </summary>
        public ProcessWindowStyle AppWindowStyle { get; set; }
        /// <summary>
        /// 正常終了時終了コード
        /// </summary>
        public int AppExitCode { get; set; }
        /// <summary>
        /// 検出ファイルのディレクトリパス
        /// </summary>
        public string DetectFolderPath { get; set; }
        /// <summary>
        /// 検出タイプ
        /// </summary>
        public DetectType DetectType { get; set; }
        /// <summary>
        /// ファイル検出タイプ
        /// </summary>
        public FileDetectType FileDetectType { get; set; }
        /// <summary>
        /// 検出ファイル名
        /// </summary>
        public string DetectFileName { get; set; }
        /// <summary>
        /// 変数実行タイプ
        /// </summary>
        public VariableExecType VariableExecType { get; set; }
        /// <summary>
        /// ファイル出力タイプ
        /// </summary>
        public FileOutputType FileOutputType { get; set; }
        /// <summary>
        /// 変数ファイル入出力先パス
        /// </summary>
        public string VariableInoutFilePath { get; set; }
        /// <summary>
        /// 変数に格納する文字列
        /// </summary>
        public string VariableValueText { get; set; }
        /// <summary>
        /// 変数キー
        /// </summary>
        public string VariableKey { get; set; }
        /// <summary>
        /// 変数キー
        /// </summary>
        public string VariableKey2 { get; set; }
        /// <summary>
        /// 変数配列キー
        /// </summary>
        public string ArrayVariableKey { get; set; }
        /// <summary>
        /// ファイルフォルダアクションタイプ
        /// </summary>
        public FileFolderActionType FileFolderActionType { get; set; }
        /// <summary>
        /// ファイルフォルダ実行タイプ
        /// </summary>
        public FileFolderExecType FileFolderExecType { get; set; }
        /// <summary>
        /// ファイルフォルダパス保存先1
        /// </summary>
        public string FileFolderPath1 { get; set; }
        /// <summary>
        /// ファイルフォルダパス保存先2
        /// </summary>
        public string FileFolderPath2 { get; set; }
        /// <summary>
        /// 変数同士を比較する型
        /// </summary>
        public CompareTypeType CompareTypeType { get; set; }
        /// <summary>
        /// 変数を比較する演算子
        /// </summary>
        public CompareOperatorType CompareOperatorType { get; set; }
        /// <summary>
        /// 変数タイプ
        /// </summary>
        public VariableChoiceType VariableChoiceType { get; set; }
        /// <summary>
        /// 変数の値への計算タイプ
        /// </summary>
        public VariableCalcType VariableCalcType { get; set; }
        /// <summary>
        /// 変数の値への加算値
        /// </summary>
        public int VariableCalcCount { get; set; }
        /// <summary>
        /// 変数へのセットか要素へのセットかをセットする
        /// </summary>
        public InputTargetType VariableInputTargetType { get; set; }
        /// <summary>
        /// 行NoIndex
        /// </summary>
        public string ArrayVariableRowIndex { get; set; }
        /// <summary>
        /// 列NoIndex
        /// </summary>
        public string ArrayVariableColumnIndex { get; set; }
        /// <summary>
        /// Excelのシート名
        /// </summary>
        public string ExcelSheetName { get; set; }
        /// <summary>
        /// 変数の比較先
        /// </summary>
        public VariableCompareTargetType VariableCompareTargetType { get; set; }
        /// <summary>
        /// ダイアログボックス表示テキスト
        /// </summary>
        public string DialogText { get;  set; }
        /// <summary>
        /// ダイアログタイプを保持
        /// </summary>
        public MessageBoxIcon DialogType { get; set; }
        /// <summary>
        /// ダイアログボタンタイプを保持
        /// </summary>
        public MessageBoxButtons DialogButtonType { get; set; }
        /// <summary>
        /// 圧縮ファイルパスワード
        /// </summary>
        public string ArchiveFilePassword { get; set; }
        /// <summary>
        /// ファイル読込モード
        /// </summary>
        public DetectFileModeType DetectFileModeType { get; set; }
        /// <summary>
        /// 変数配列への読み込みフォーマット
        /// </summary>
        public ArraySeparateType ArraySeparateType { get; set; }
        /// <summary>
        /// 文字コードタイプ
        /// </summary>
        public EncodeType EncodeType { get; set; }
        /// <summary>
        /// Excelソースタイプ
        /// </summary>
        public ExcelSourceType ExcelSourceType { get; set; }

        public Dictionary<int, ExcelJobModel> ExcelJobList { get; set; }
        /// <summary>
        /// 検出エリアタイプ
        /// </summary>
        public DetectAreaType DetectAreaType { get; set; }
        /// <summary>
        /// 検出エリアSX
        /// </summary>
        public string DetectAreaSX { get; set; }
        /// <summary>
        /// 検出エリアSX
        /// </summary>
        public string DetectAreaSY { get; set; }
        /// <summary>
        /// 検出エリアSX
        /// </summary>
        public string DetectAreaEX { get; set; }
        /// <summary>
        /// 検出エリアSX
        /// </summary>
        public string DetectAreaEY { get; set; }
        /// <summary>
        /// WEBサービスからの取得用URLパラメーターを保持する
        /// </summary>
        public Dictionary<string, string> UrlParam { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessModel()
        {
            ProcessId = ProjectModel.NewId();
            ProcessType =  ProcessType.None;
            Timeout = 30;
            ScrollSpeed = 1;
            BeforeWaitMilliTime = 0;
            AfterWaitMilliTime = 0;
            ScrollAmount = 2;
            ScrollCount = 1;
            Mail_AttachList = new Dictionary<int, string>();
            Mail_AttachList.Add(0, "");
            Mail_AttachList.Add(1, "");
            Mail_AttachList.Add(2, "");
            Mail_AttachList.Add(3, "");
            Mail_AttachList.Add(4, "");
            CaptureImage = new Dictionary<int, Bitmap>();
            CaptureImage.Add(0, null);
            CaptureImage.Add(1, null);
            CaptureImage.Add(2, null);
            CaptureImage.Add(3, null);
            CaptureImage.Add(4, null);
            CaptureImage.Add(5, null);
            CaptureImage.Add(6, null);
            CaptureImage.Add(7, null);
            CaptureImage.Add(8, null);
            CaptureImage.Add(9, null);
            CaptureImageByte = new Dictionary<int, byte[]>();
            CaptureImageByte.Add(0, null);
            CaptureImageByte.Add(1, null);
            CaptureImageByte.Add(2, null);
            CaptureImageByte.Add(3, null);
            CaptureImageByte.Add(4, null);
            CaptureImageByte.Add(5, null);
            CaptureImageByte.Add(6, null);
            CaptureImageByte.Add(7, null);
            CaptureImageByte.Add(8, null);
            CaptureImageByte.Add(9, null);
            ExcelJobList = new Dictionary<int, ExcelJobModel>();
            ExcelJobList.Add(0, new ExcelJobModel(FileReadWriteType.Read, "", "", ""));
            UrlParam = new Dictionary<string, string>();
        }
        /// <summary>
        /// 終了のProcessModelを取得する
        /// </summary>
        /// <returns></returns>
        public static ProcessModel GetEndProcessModel()
        {
            ProcessModel endModel = new ProcessModel();
            endModel.Name = StringValue.END_PROCESS;
            return endModel;
        }
        /// <summary>
        /// ERRORのProcessModelを取得する
        /// </summary>
        /// <returns></returns>
        public static ProcessModel GetErrorProcessModel()
        {
            ProcessModel endModel = new ProcessModel();
            endModel.Name = StringValue.END_PROCESS_ERROR;
            return endModel;
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// ビットマップからバイト配列へ変換する
        /// </summary>
        public void BitmapToByteArray(bool imageClear)
        {
            try
            {
                for (int i = 0; i < CaptureImage.Count; i++)
                {
                    var captureImage = CaptureImage[i];
                    if (captureImage == null) continue;
                    MemoryStream ms = new MemoryStream();
                    captureImage.Save(ms, ImageFormat.Png);
                    CaptureImageByte[i] = ms.GetBuffer();
                    if (imageClear)
                    {
                        captureImage.Dispose();
                        CaptureImage[i] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }

        }
        /// <summary>
        /// バイト配列からBitmapへ変換する
        /// </summary>
        public void ByteArrayToBitmap(bool byteAryClear)
        {
            try
            {
                for(int i = 0; i < CaptureImageByte.Count; i++)
                {
                    var captureImageByte = CaptureImageByte[i];
                    if (captureImageByte == null) continue;
                    MemoryStream ms = new MemoryStream(captureImageByte);
                    CaptureImage[i] = new Bitmap(ms);
                    ms.Close();
                    if (byteAryClear)
                    {
                        CaptureImageByte[i] = null;
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
