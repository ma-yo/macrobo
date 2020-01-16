using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Controls
{
    /// <summary>
    /// Author : M.Yoshida
    /// キャプチャイメージ表示コントロール
    /// </summary>
    public partial class CaptureImageChoiceControl : UserControl
    {
        private const int MARGIN = 4;
        public delegate void ImageChoiceEvent(Bitmap bmp);
        public ImageChoiceEvent OnImageChoice;
        public delegate void SelectedEvent(Control ctrl);
        public SelectedEvent OnSelected;
        public bool Selected { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public CaptureImageChoiceControl()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Color color = Color.Teal;
            if (Selected)
            {
                color = Color.Magenta;
            }
            e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(MARGIN, MARGIN, this.Width - MARGIN * 2, this.Height - MARGIN * 2));
            base.OnPaint(e);
        }
        /// <summary>
        /// キャプチャイメージを選択する
        /// </summary>
        private void SetImageChoiceEvent()
        {
            try
            {

                OnImageChoice?.Invoke((Bitmap)ImageBox.Image);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ImageBoxのﾀﾞﾌﾞﾙｸﾘｯｸｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OnSelected?.Invoke(this);
                SetImageChoiceEvent();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CaptureImageChoiceControlのﾀﾞﾌﾞﾙｸﾘｯｸｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureImageChoiceControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OnSelected?.Invoke(this);
                SetImageChoiceEvent();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CaptureImageChoiceControlのｸﾘｯｸｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureImageChoiceControl_Click(object sender, EventArgs e)
        {
            try
            {
                OnSelected?.Invoke(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ImageBoxのｸﾘｯｸｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBox_Click(object sender, EventArgs e)
        {
            try
            {
                OnSelected?.Invoke(this);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
