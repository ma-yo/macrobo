using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// イメージユーティリティークラス
    /// </summary>
    public class ImageUtil
    {
        /// <summary>
        /// Imageの比較を行う
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        /// <returns></returns>
        public static bool CompareImage(Image image1, Image image2)
        {
            Bitmap img1 = (Bitmap)image1;
            Bitmap img2 = (Bitmap)image2;

            //高さが違えばfalse
            if (img1.Width != img2.Width || img1.Height != img2.Height) return false;
            //BitmapData取得
            BitmapData bd1 = img1.LockBits(new Rectangle(0, 0, img1.Width, img1.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, img1.PixelFormat);
            BitmapData bd2 = img2.LockBits(new Rectangle(0, 0, img2.Width, img2.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, img2.PixelFormat);
            //スキャン幅が違う場合はfalse
            if (bd1.Stride != bd2.Stride)
            {
                //ロックを解除
                img1.UnlockBits(bd1);
                img2.UnlockBits(bd2);
                return false;
            }
            int bsize = bd1.Stride * img1.Height;
            byte[] byte1 = new byte[bsize];
            byte[] byte2 = new byte[bsize];
            //バイト配列にコピー
            Marshal.Copy(bd1.Scan0, byte1, 0, bsize);
            Marshal.Copy(bd2.Scan0, byte2, 0, bsize);
            //ロックを解除
            img1.UnlockBits(bd1);
            img2.UnlockBits(bd2);

            //MD5ハッシュを取る
            System.Security.Cryptography.MD5CryptoServiceProvider md5 =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash1 = md5.ComputeHash(byte1);
            byte[] hash2 = md5.ComputeHash(byte2);

            //ハッシュを比較
            return hash1.SequenceEqual(hash2);
        }
    }
}
