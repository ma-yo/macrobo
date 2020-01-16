using log4net;
using Macrobo.Models.Enums;
using Macrobo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo
{
    /// <summary>
    /// Author : M.Yoshida
    /// マクロボメインエントリポイントクラス
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 例外発生時のﾀﾞｲｱﾛｸﾞを表示するかのﾌﾗｸﾞ
        /// </summary>
        public bool ShowErrorDialog = true;
        /// <summary>
        /// ログ出力
        /// </summary>
        public static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 一時フォルダ
        /// </summary>
        public static string TMP_FOLDER;
        /// <summary>
        /// アプリケーションの開始フォルダパス
        /// </summary>
        public static string EXEC_FOLDER_PATH;
        /// <summary>
        /// ユーザープロファイルパス
        /// </summary>
        public static string USERPROFILE_PATH;
        /// <summary>
        /// ログフォルダパス
        /// </summary>
        public static string EXEC_LOG_PATH;
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start(args);
        }
        /// <summary>
        /// 定数を初期化
        /// </summary>
        static Program(){
            EXEC_FOLDER_PATH = Application.StartupPath;
            USERPROFILE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Roaming\AK soft\Macrobo";
            EXEC_LOG_PATH = USERPROFILE_PATH + @"\execlogs";
            TMP_FOLDER = USERPROFILE_PATH + @"\tmp";
        }
        /// <summary>
        /// プログラムを開始する
        /// </summary>
        private void Start(string[] args)
        {
            ClearTmpFolder();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string projId = "";
            ExecDataType type = ExecDataType.PROJECT;
            if (args != null)
            {
                for(int i = 0; i < args.Length; i++)
                {
                    if (args[i].ToUpper() == "-P" || args[i].ToUpper() == "-M")
                    {
                        if (args[i].ToUpper() == "-P")
                        {
                            type = ExecDataType.PROJECT;
                        }
                        if (args[i].ToUpper() == "-M")
                        {
                            type = ExecDataType.MACRO;
                        }
                        projId = args[i + 1];
                        i++;
                    }
                }
            }
            if (string.IsNullOrEmpty(projId))
            {
                Application.Run(new MainMenu());
            }
            else
            {
                using (MainMenu form = new MainMenu())
                {
                    form.StartProject(projId, type, MacroStartType.SHORTCUTSTART);
                }
            }
        }
        /// <summary>
        /// ＴＭＰフォルダを削除する
        /// </summary>
        private void ClearTmpFolder()
        {
            try
            {
                if (System.IO.Directory.Exists(TMP_FOLDER))
                {
                    System.IO.Directory.Delete(TMP_FOLDER, true);
                }
                System.IO.Directory.CreateDirectory(TMP_FOLDER);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 例外時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            if (ShowErrorDialog)
            {
                MessageBox.Show(null, "ご不便をおかけして申し訳ございません。\r\n下記エラーが発生しましたので、システムを終了します。\r\n\r\n" + ex.Exception.Message + "\r\n\r\n" + ex.Exception.StackTrace, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            Application.ExitThread();
        }

        /// <summary>
        /// 例外のﾄﾚｰｽを作成する
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static Exception ThrowException(Exception ex)
        {
            logger.Error(ex.Message + "\t" + ex.StackTrace);
            try
            {
                string methodName = "";
                string formName = "";
                StackFrame stack = new StackFrame(1);
                methodName = stack.GetMethod().Name;
                formName = stack.GetMethod().ReflectedType.Name;
                Exception exception = new Exception(formName + ":" + methodName + ":" + ex.Message + " ");
                return exception;
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
        }
    }
}
