using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// ファイルユーティリティ
    /// </summary>
    public class FileUtil
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = false)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(
    IntPtr hWnd, out int lpdwProcessId);
        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle,
    uint DesiredAccess,
    out IntPtr TokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);

        /// <summary>
        /// ファイル名禁止文字をエスケープしたファイル名を取得する
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="escapeString"></param>
        /// <returns></returns>
        public static string GetInvalidEscapeFileName(string fileName, string escapeString)
        {
            try
            {
                char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
                if (fileName.IndexOfAny(invalidChars) >= 0)
                {
                    string result = "";
                    foreach (var c in fileName)
                    {
                        if (invalidChars.Contains(c))
                        {
                            result += escapeString;
                        }
                        else
                        {
                            result += c;
                        }
                    }
                    return result;
                }
                else
                {
                    return fileName;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ファイルロックチェック
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string path)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch
            {
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return false;
        }
        /// <summary>
        /// ファイル読込可否チェック
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFileNotReadable(string path)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch
            {
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return false;
        }
        /// <summary>
        /// ディレクトリをコピーする
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        public static void CopyDirectory(string sourceDirName, string destDirName)
        {

            try
            {
                if (!System.IO.Directory.Exists(destDirName))
                {
                    System.IO.Directory.CreateDirectory(destDirName);
                    System.IO.File.SetAttributes(destDirName,
                        System.IO.File.GetAttributes(sourceDirName));
                }
                if (destDirName[destDirName.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;
                }

                string[] files = System.IO.Directory.GetFiles(sourceDirName);
                foreach (string file in files)
                {
                    System.IO.File.Copy(file, destDirName + System.IO.Path.GetFileName(file), true);
                }


                string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }

        }

       
        /// <summary>
        /// ファイルを関連付けられたアプリケーションで実行する
        /// </summary>
        /// <param name="path"></param>
        public static void ViewFile(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                Thread t = new Thread(new ParameterizedThreadStart(FileNotOpenMsg));
                t.Start(path);
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルオープンエラー
        /// </summary>
        /// <param name="filePath"></param>
        private static void FileNotOpenMsg(object filePath)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show(filePath.ToString() + "は開けませんでした。", "ファイルオープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }

}
