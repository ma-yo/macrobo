using Macrobo.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// キャプチャツール
    /// </summary>
    public class CaptureUtil
    {
        /// <summary>
        /// スクリーンキャプチャを取得する
        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public static Bitmap CaptureScreen(Screen screen, Rectangle captureArea)
        {
            try
            {
                Bitmap bmp = new Bitmap(captureArea.Width, captureArea.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(captureArea.X, captureArea.Y, 0, 0, captureArea.Size, CopyPixelOperation.SourceCopy);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// スクリーンから選択範囲をトリミングします。
        /// </summary>
        /// <returns></returns>
        public static string GetScreenTrimmingImagePath(Screen screen, Rectangle captureArea)
        {
            try
            {
                Image bmp = CaptureUtil.CaptureScreen(screen, captureArea);
                string fileName = Guid.NewGuid().ToString().Replace("-", "").ToLower() + ".png";
                string filePath = Program.TMP_FOLDER + @"\" + fileName;
                bmp.Save(filePath, ImageFormat.Png);
                CaptureForm form = new CaptureForm();
                form.Init(filePath);
                form.TopMost = true;
                form.ShowDialog();
                if (form.CaptureResult == DialogResult.OK)
                {
                    return form.TrimImagePath;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// トリミングポイントを取得する
        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public static int[] GetScreenTrimmingPoint(Screen screen, Rectangle captureArea)
        {

            try
            {
                Image bmp = CaptureUtil.CaptureScreen(screen, captureArea);
                string fileName = Guid.NewGuid().ToString().Replace("-", "").ToLower() + ".png";
                string filePath = Program.TMP_FOLDER + @"\" + fileName;
                bmp.Save(filePath, ImageFormat.Png);
                CaptureForm form = new CaptureForm();
                form.Init(filePath);
                form.TopMost = true;
                form.ShowDialog();
                if (form.CaptureResult == DialogResult.OK)
                {
                    return form.TrimPoint;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
