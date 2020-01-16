using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Utils
{
    /// <summary>
    /// 圧縮解凍ユーティリティー
    /// </summary>
    public class ZipUtil
    {
        /// <summary>
        /// 圧縮ファイルを作成する
        /// </summary>
        /// <param name="archveName"></param>
        /// <param name="outputFolderName"></param>
        /// <param name="password"></param>
        public static void CompressFolder(string archveName, string outputFolderName, string password)
        {
            try
            {
                FastZip zip = new FastZip();
                zip.Password = password;
                zip.CreateZip(outputFolderName, archveName, false, "");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// フォルダを解凍する
        /// </summary>
        /// <param name="archveName"></param>
        /// <param name="outputFolderName"></param>
        /// <param name="password"></param>
        public static void ExtractFolder(string archveName, string outputFolderName, string password)
        {
            try
            {
                FastZip zip = new FastZip();
                zip.Password = password;
                zip.ExtractZip(archveName, outputFolderName, "");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイルを圧縮する
        /// </summary>
        /// <param name="srcFilename"></param>
        /// <param name="archiveName"></param>
        /// <param name="password"></param>
        public static void CompressFile(string srcFilename, string archiveName, string password)
        {
            using (ZipFile z = ZipFile.Create(archiveName))
            {
                z.BeginUpdate();
                z.Add(new StaticDiskDataSource(srcFilename), srcFilename.Replace(System.IO.Path.GetDirectoryName(srcFilename) + "\\" ,""), CompressionMethod.Stored, false);
                z.Password = password;
                z.CommitUpdate();
            }
        }
        /// <summary>
        /// Zipファイルを解凍する
        /// </summary>
        /// <param name="archiveFilenameIn"></param>
        /// <param name="outFolder"></param>
        /// <param name="password"></param>
        public static void ExtractZipFile(string archiveFilenameIn, string outFolder, string password)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;
                    }
                    String entryFileName = zipEntry.Name;
                    byte[] buffer = new byte[4096];
                    Stream zipStream = zf.GetInputStream(zipEntry);
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true;
                    zf.Close();
                }
            }
        }

    }
}
