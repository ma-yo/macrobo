using Macrobo.Components;
using Macrobo.Utils;
using Macrobo.Views.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// キャプチャ画像を選択する
    /// </summary>
    public partial class ImageChoiceForm : BaseForm
    {
        public Bitmap SelectedImage { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ImageChoiceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="list"></param>
        public void Init(List<Bitmap> list)
        {
            try
            {
                CaptureChoicePanel.ClearControls();
                foreach(var bmp in list)
                {
                    CaptureImageChoiceControl ctrl = new CaptureImageChoiceControl();
                    ctrl.ImageBox.Image = bmp;
                    ctrl.ImageBox.Width = bmp.Width;
                    ctrl.ImageBox.Height = bmp.Height;
                    ctrl.ImageBox.Location = new Point(8, 8);
                    ctrl.Width = bmp.Width + 16;
                    ctrl.Height = bmp.Height + 16;
                    ctrl.OnSelected = (Control c) => {
                        foreach (CaptureImageChoiceControl ctrl2 in CaptureChoicePanel.Controls)
                        {
                            ctrl2.Selected = c.Equals(ctrl2);
                            ctrl2.Invalidate();
                        }
                    };
                    ctrl.OnImageChoice = (Bitmap b) => {
                        SelectedImage = b;
                        Close();
                    };
                    CaptureChoicePanel.Controls.Add(ctrl);
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
