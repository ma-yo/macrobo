using Macrobo.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Macrobo.Utils;
using System.Drawing.Imaging;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// キャプチャ画面
    /// </summary>
    public partial class CaptureForm : BaseForm
    {
        /// <summary>
        /// デスクトップのキャプチャイメージを保持する
        /// </summary>
        private Image _captureImage;
        /// <summary>
        /// マウスドラッグ開始位置
        /// </summary>
        private MouseEventArgs _startMousePosition;
        /// <summary>
        /// マウスドラッグ終了位置
        /// </summary>
        private MouseEventArgs _endMousePosition;
        /// <summary>
        /// ファイルパスを格納
        /// </summary>
        private string FilePath { get; set; }
        /// <summary>
        /// トリミングイメージパスを格納する
        /// </summary>
        public string TrimImagePath { get; set; }
        /// <summary>
        /// トリミングポイントを格納する
        /// </summary>
        public int[] TrimPoint = new int[] { 0, 0, 0, 0 };
        /// <summary>
        /// キャプチャ結果をセットします。
        /// </summary>
        public DialogResult CaptureResult = DialogResult.None;
        /// <summary>
        /// Constructor
        /// </summary>
        public CaptureForm()
        {
            try
            {
                InitializeComponent();
                //全画面表示させる
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CaptureFormのKeyDownｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="filePath"></param>
        internal void Init(string filePath)
        {
            try
            {
                this.FilePath = filePath;
                _captureImage = Image.FromFile(this.FilePath);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 画面描画を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);
                g.DrawImage(_captureImage, new Point(0, 0));
                //ドラッグエリアを描画する
                if (_startMousePosition != null && _endMousePosition != null)
                {
                    int[] pos = GetMousePosition();
                    g.DrawRectangle(new Pen(new SolidBrush(Color.White), 1), new Rectangle(pos[0], pos[1], pos[2] - pos[0], pos[3] - pos[1]));
                    Brush dragBrush = new SolidBrush(Color.Red);
                    Pen pen = new Pen(dragBrush, 1);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawRectangle(pen, new Rectangle(pos[0], pos[1], pos[2] - pos[0], pos[3] - pos[1]));
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスポジションを取得する
        /// </summary>
        /// <returns></returns>
        private int[] GetMousePosition()
        {
            try
            {
                //マウスポジション逆転の場合、入れ替える
                int posx1 = _startMousePosition.X;
                int posy1 = _startMousePosition.Y;
                int posx2 = _endMousePosition.X;
                int posy2 = _endMousePosition.Y;
                if (posx1 > posx2)
                {
                    int t = posx1;
                    posx1 = posx2;
                    posx2 = t;
                }
                if (posy1 > posy2)
                {
                    int t = posy1;
                    posy1 = posy2;
                    posy2 = t;
                }
                return new int[] { posx1, posy1, posx2, posy2 };
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キャプチャFormのShownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.ShowDialog("キャプチャーしてください。", "マウスの範囲選択にて、画像を特定してください。\r\nESCでキャンセルできます。\r\n(※あまり大きな画像を選択しないでください)");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CaptureFormのMouseDownｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (_endMousePosition == null)
                {
                    _startMousePosition = e;
                }
                this.Invalidate();
                Console.WriteLine("down : " + _startMousePosition.X + ":" + _startMousePosition.Y);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CaptureFormのマウス移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (_startMousePosition == null) return;
                _endMousePosition = e;
                this.Invalidate();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CaptureFormのマウスアップイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureForm_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_startMousePosition == null || _endMousePosition == null) return;
                this.Invalidate();
                if(_startMousePosition != null && _endMousePosition!= null)
                {
                    ExecuteTrimming();
                    return;
                }
                _startMousePosition = null;
                _endMousePosition = null;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// トリミングを行う
        /// </summary>
        private void ExecuteTrimming()
        {
            try
            {
                int[] trimPos = GetMousePosition();
                if (trimPos[0] == trimPos[2] && trimPos[1] == trimPos[3])
                {
                    return;
                }
                Image bmp = new Bitmap(trimPos[2] - trimPos[0], trimPos[3] - trimPos[1]);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle srcRect = new Rectangle(trimPos[0], trimPos[1], trimPos[2] - trimPos[0], trimPos[3] - trimPos[1]);
                Rectangle dstRect = new Rectangle(0, 0, trimPos[2] - trimPos[0], trimPos[3] - trimPos[1]);
                g.DrawImage(_captureImage, dstRect, srcRect, GraphicsUnit.Pixel);
                string saveFilePath = Program.TMP_FOLDER + @"\" + Guid.NewGuid().ToString().Replace("-", "").ToLower() + ".png";
                bmp.Save(saveFilePath, ImageFormat.Png);
                bmp.Dispose();
                this.CaptureResult = DialogResult.OK;
                TrimImagePath = saveFilePath;
                TrimPoint = trimPos;
                this.Close();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
