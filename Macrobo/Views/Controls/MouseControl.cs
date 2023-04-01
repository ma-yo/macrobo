using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Macrobo.Components;
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Utils;
using System.Drawing.Imaging;
using Macrobo.Views.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// マウスコントロール
    /// </summary>
    public partial class MouseControl : ProcessBaseControl
    {
        /// <summary>
        /// ImageRadioのコレクション
        /// </summary>
        private List<BaseRadioButton> _imageRadioList = new List<BaseRadioButton>();
        /// <summary>
        /// 検出画像を保持
        /// </summary>
        public List<Bitmap> ImageList = new List<Bitmap>() { null, null, null, null, null, null, null, null, null, null };
        /// <summary>
        /// 入力Keyコード
        /// </summary>
        List<Keys> inputList = new List<Keys>();
        /// <summary>
        /// 入力Keyコード
        /// </summary>
        List<Keys> inputDownList = new List<Keys>();

        /// <summary>
        /// Constructor
        /// </summary>
        public MouseControl()
        {
            try
            {
                InitializeComponent();
                CreateImageRadioList();
                AddButtonEvent();

                OnDeactivate = ParentForm_OnDeactivate;
                CaptureImage.AddPaint += AddCaptureImagePaint;
                CaptureImage.ImageChanged += CaptureImage_ImageChanged;
                CaptureImage2.ImageChanged += CaptureImage_ImageChanged;
                foreach (var imgRadio in _imageRadioList)
                {
                    imgRadio.CheckedChanged += ImageRadioButton_CheckedChanged;
                }
                Image1RadioButton.Checked = true;

                DetectAreaScreenRadio.CheckedChanged += DetectAreaRadio_CheckedChanged;
                DetectAreaChoiceRadio.CheckedChanged += DetectAreaRadio_CheckedChanged;
                DetectAreaScreenRadio.Checked = true;

                this.OnKeyboardHook = KeyboardHook_KeyboardHooked;
                this.Disposed += (object sender, EventArgs e) => {
                    this.OnKeyboardHook = null;
                };
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キャプチャイメージ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureImage_ImageChanged(object sender, EventArgs e)
        {
            try
            {
                ImageSetted();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ImageRadioのコレクションを作成する
        /// </summary>
        private void CreateImageRadioList()
        {
            try
            {
                _imageRadioList.Add(Image1RadioButton);
                _imageRadioList.Add(Image2RadioButton);
                _imageRadioList.Add(Image3RadioButton);
                _imageRadioList.Add(Image4RadioButton);
                _imageRadioList.Add(Image5RadioButton);
                _imageRadioList.Add(Image6RadioButton);
                _imageRadioList.Add(Image7RadioButton);
                _imageRadioList.Add(Image8RadioButton);
                _imageRadioList.Add(Image9RadioButton);
                _imageRadioList.Add(Image10RadioButton);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// イメージ選択時イベント
        /// </summary>
        private void ImageSetted()
        {
            try
            {
                for (int i = 0; i < ImageList.Count; i++)
                {
                    if (ImageList[i] != null)
                    {
                        _imageRadioList[i].BackColor = Color.FromArgb(255, 0, 64, 64);
                        _imageRadioList[i].ForeColor = Color.White;
                    }
                    else
                    {
                        _imageRadioList[i].BackColor = Color.White;
                        _imageRadioList[i].ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 親フォームのDeactivateｲﾍﾞﾝﾄ
        /// </summary>
        private void ParentForm_OnDeactivate()
        {
            try
            {
                inputDownList.Clear();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 検出エリアの変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectAreaRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (radio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ボタンイベントを作成する
        /// </summary>
        private void AddButtonEvent()
        {
            try
            {
                CompButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CompButton.Tag = ProcessModel.GetEndProcessModel();
                ErrorButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                ErrorButton.Tag = ProcessModel.GetErrorProcessModel();
                ClickPosButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                ClickPosButton.Tag = MouseClickPosition.左クリック;
                ScrollButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                    SetScrollSpeedVisible();
                };
                ScrollButton.Tag = ScrollType.スクロールしない;
                PointTypeButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                    SetScrollSpeedVisible();
                };
                PointTypeButton.Tag = PointType.相対座標;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ImageRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseRadioButton radio = (BaseRadioButton)sender;
                if (!radio.Checked) return;
                ChangeImage();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ペイントを行う
        /// </summary>
        /// <param name="pe"></param>
        private void AddCaptureImagePaint(PaintEventArgs pe)
        {
            try
            {
                if (CaptureImage.Image == null) return;
                if (!OffsetXTextBox.Visible) return;

                Graphics g = pe.Graphics;
                int posx = CaptureImage.Width / 2;
                int posy = CaptureImage.Height / 2;
                int.TryParse(OffsetXTextBox.Text, out int oX);
                int.TryParse(OffsetYTextBox.Text, out int oY);
                posx += oX;
                posy += oY;
                Pen redPen = new Pen(new SolidBrush(Color.Red), 2);
                g.DrawLine(redPen, new Point(posx - 5, posy), new Point(posx + 5, posy));
                g.DrawLine(redPen, new Point(posx, posy - 5), new Point(posx, posy + 5));

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// イメージを変更する
        /// </summary>
        private void ChangeImage()
        {
            try
            {
                Bitmap img = ImageList[GetSelectedImageIndex()];
                if (img == null)
                {
                    CaptureImage.Image = null;
                }
                else
                {
                    CaptureImage.Image = img;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択中のイメージIndexを取得する
        /// </summary>
        /// <returns></returns>
        private int GetSelectedImageIndex()
        {
            try
            {
                if (Image1RadioButton.Checked)
                {
                    return 0;
                }
                if (Image2RadioButton.Checked)
                {
                    return 1;
                }
                if (Image3RadioButton.Checked)
                {
                    return 2;
                }
                if (Image4RadioButton.Checked)
                {
                    return 3;
                }
                if (Image5RadioButton.Checked)
                {
                    return 4;
                }

                if (Image6RadioButton.Checked)
                {
                    return 5;
                }

                if (Image7RadioButton.Checked)
                {
                    return 6;
                }

                if (Image8RadioButton.Checked)
                {
                    return 7;
                }

                if (Image9RadioButton.Checked)
                {
                    return 8;
                }

                if (Image10RadioButton.Checked)
                {
                    return 9;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="rootProjectModel"></param>
        /// <param name="projModel"></param>
        /// <param name="procModel"></param>
        public override void Init(ProjectModel rootProjectModel, ProjectModel projModel, ProcessModel procModel)
        {
            try
            {
                this.RootProjectModel = rootProjectModel;
                this.CurrentProjectModel = projModel;
                this.ProcessModel = procModel;
                ImageDetectRadio.Checked = true;
                MouseClickRadio.Checked = true;
                OffsetXTextBox.Text = "0";
                OffsetYTextBox.Text = "0";
                ClickCountUpDown.Text = "0";
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キャプチャボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureStartButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteCapture(0);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キャプチャボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capture2StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteCapture(1);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キャプチャを実行する
        /// </summary>
        internal void ExecuteCapture(int index)
        {
            try
            {
                string imagePath = CaptureUtil.GetScreenTrimmingImagePath(Screen.PrimaryScreen, Screen.PrimaryScreen.Bounds);
               
                if (imagePath != null)
                {
                    switch (index)
                    {
                        case 0:
                            if (ImageChoicePanel.Visible)
                            {
                                ImageList[GetSelectedImageIndex()] = new Bitmap(Image.FromFile(imagePath));
                                CaptureImage.Image = ImageList[GetSelectedImageIndex()];
                            }
                            else
                            {
                                ImageList[0] = new Bitmap(Image.FromFile(imagePath));
                                CaptureImage.Image = ImageList[0];
                            }
                            break;
                        default:
                            ImageList[1] = new Bitmap(Image.FromFile(imagePath));
                            CaptureImage.Image = ImageList[1];
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// OffsetXTextBoxのKeyUpｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffsetXTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CaptureImage.Invalidate();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// OffsetYTextBoxのKeyUpｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffsetYTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CaptureImage.Invalidate();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 画像検出Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageDetectRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ImageDetectRadio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 座標Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointInputRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (PointInputRadio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスクリックRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseClickRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (MouseClickRadio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウス移動Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMoveRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (MouseMoveRadio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスホイールRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheelRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (MouseWheelRadio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスドラッグドロップRadioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDragDropRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (MouseDragDropRadio.Checked)
                {
                    SetExecuteMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 処理モード変更時イベント
        /// </summary>
        private void SetExecuteMode()
        {
            try
            {
                ScrollCountTitleLbl.Visible = false;
                ScrollCountUpDown.Visible = false;
                StringInputTitleLbl.Visible = false;
                StringInputTextBox.Visible = false;
                StringInputClearButton.Visible = false;
                AlertLbl.Visible = false;

                ScrollTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                ScrollButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                ScrollSpeedTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                ScrollSpeedUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                ScrollAmountTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                ScrollAmountUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

                ScrollTitleLbl.Location = new Point(OffsetXTextBox.Location.X + OffsetXTextBox.Width + 1, OffsetXTextBox.Location.Y);
                ScrollButton.Location = new Point(ScrollTitleLbl.Location.X + ScrollTitleLbl.Width - 1, ScrollTitleLbl.Location.Y);
                ScrollSpeedTitleLbl.Location = new Point(OffsetYTextBox.Location.X + OffsetYTextBox.Width + 1, OffsetYTextBox.Location.Y);
                ScrollSpeedUpDown.Location = new Point(ScrollSpeedTitleLbl.Location.X + ScrollSpeedTitleLbl.Width - 1, ScrollSpeedTitleLbl.Location.Y);
                ScrollAmountTitleLbl.Location = new Point(ScrollSpeedUpDown.Location.X + ScrollSpeedUpDown.Width + 1, ScrollSpeedUpDown.Location.Y);
                ScrollAmountUpDown.Location = new Point(ScrollAmountTitleLbl.Location.X + ScrollAmountTitleLbl.Width - 1, ScrollAmountTitleLbl.Location.Y);
                DetectAreaTitleLbl.Visible = false;
                DetectAreaPanel.Visible = false;
                DetectAreaSXTitleLbl.Visible = false;
                DetectAreaSYTitleLbl.Visible = false;
                DetectAreaEXTitleLbl.Visible = false;
                DetectAreaEYTitleLbl.Visible = false;
                DetectAreaSXTextBox.Visible = false;
                DetectAreaSYTextBox.Visible = false;
                DetectAreaEXTextBox.Visible = false;
                DetectAreaEYTextBox.Visible = false;
                DetectAreaChoiceButton.Visible = false;

                CaptureStartButton.Visible = false;
                LoadCaptureImageButton.Visible = false;
                Capture2StartButton.Visible = false;
                LoadCaptureImageButton2.Visible = false;
                CaptureImageTitleLbl.Visible = false;
                CaptureImage.Visible = false;
                CaptureImage2TitleLbl.Visible = false;
                CaptureImage2.Visible = false;
                ClickPointTitleLbl.Visible = false;
                ClickPosButton.Visible = false;
                ClickCountTitleLbl.Visible = false;
                ClickCountUpDown.Visible = false;
                OffsetXTitleLbl.Visible = false;
                OffsetXTextBox.Visible = false;
                OffsetYTitleLbl.Visible = false;
                OffsetYTextBox.Visible = false;
                PointTypeTitleLbl.Visible = false;
                PointTypeButton.Visible = false;
                TimeoutTitleLbl.Visible = false;
                TimeoutNumericUpDown.Visible = false;
                CompButtonTitleLbl.Visible = false;
                CompButton.Visible = false;
                ErrorButtonTitleLbl.Visible = false;
                ErrorButton.Visible = false;
                ScrollTitleLbl.Visible = false;
                ScrollButton.Visible = false;
                ScrollSpeedTitleLbl.Visible = false;
                ScrollSpeedUpDown.Visible = false;
                ScrollAmountTitleLbl.Visible = false;
                ScrollAmountUpDown.Visible = false;
                ImageChoicePanel.Visible = false;
                ClearCaptureButton.Visible = false;
                if (MouseClickRadio.Checked)
                {
                    StringInputTitleLbl.Visible = true;
                    StringInputTextBox.Visible = true;
                    StringInputClearButton.Visible = true;
                    AlertLbl.Visible = true;
                    if (ImageDetectRadio.Checked)
                    {
                        CaptureStartButton.Visible = true;
                        LoadCaptureImageButton.Visible = true;
                        CaptureStartButton.Text = "画像キャプチャ\r\n(Ctrl+Shift+C)";
                        CaptureImageTitleLbl.Visible = true;
                        CaptureImage.Visible = true;
                        CaptureImageTitleLbl.Text = "検出画像";
                        ClickPointTitleLbl.Visible = true;
                        ClickPosButton.Visible = true;
                        ClickCountTitleLbl.Visible = true;
                        ClickCountUpDown.Visible = true;
                        OffsetXTitleLbl.Visible = true;
                        OffsetXTextBox.Visible = true;
                        OffsetXTitleLbl.Text = "オフセットX座標";
                        OffsetYTitleLbl.Visible = true;
                        OffsetYTextBox.Visible = true;
                        OffsetYTitleLbl.Text = "オフセットY座標";
                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;
                        ScrollTitleLbl.Visible = true;
                        ScrollButton.Visible = true;
                        SetScrollSpeedVisible();
                        CompButtonTitleLbl.Visible = true;
                        CompButton.Visible = true;
                        CompButtonTitleLbl.Text = "検出成功移動先";
                        ErrorButtonTitleLbl.Visible = true;
                        ErrorButton.Visible = true;
                        ImageChoicePanel.Visible = true;
                        ClearCaptureButton.Visible = true;
                        DetectAreaTitleLbl.Visible = true;
                        DetectAreaPanel.Visible = true;
                        if (DetectAreaChoiceRadio.Checked)
                        {
                            DetectAreaTitleLbl.Visible = true;
                            DetectAreaPanel.Visible = true;
                            DetectAreaSXTitleLbl.Visible = true;
                            DetectAreaSYTitleLbl.Visible = true;
                            DetectAreaEXTitleLbl.Visible = true;
                            DetectAreaEYTitleLbl.Visible = true;
                            DetectAreaSXTextBox.Visible = true;
                            DetectAreaSYTextBox.Visible = true;
                            DetectAreaEXTextBox.Visible = true;
                            DetectAreaEYTextBox.Visible = true;
                            DetectAreaChoiceButton.Visible = true;
                        }
                    }
                    if (PointInputRadio.Checked)
                    {
                        ClickPointTitleLbl.Visible = true;
                        ClickPosButton.Visible = true;
                        ClickCountTitleLbl.Visible = true;
                        ClickCountUpDown.Visible = true;
                        OffsetXTitleLbl.Visible = true;
                        OffsetXTextBox.Visible = true;
                        OffsetXTitleLbl.Text = "スクリーンX座標";
                        OffsetYTitleLbl.Visible = true;
                        OffsetYTextBox.Visible = true;
                        OffsetYTitleLbl.Text = "スクリーンY座標";
                        PointTypeTitleLbl.Visible = true;
                        PointTypeButton.Visible = true;
                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;
                        CompButtonTitleLbl.Visible = true;
                        CompButton.Visible = true;
                        CompButtonTitleLbl.Text = "次移動先";
                    }
                }
                if (MouseMoveRadio.Checked)
                {
                    if (ImageDetectRadio.Checked)
                    {
                        CaptureStartButton.Visible = true;
                        LoadCaptureImageButton.Visible = true;
                        CaptureStartButton.Text = "画像キャプチャ\r\n(Ctrl+Shift+C)";
                        CaptureImageTitleLbl.Visible = true;
                        CaptureImage.Visible = true;
                        CaptureImageTitleLbl.Text = "検出画像";
                        OffsetXTitleLbl.Visible = true;
                        OffsetXTextBox.Visible = true;
                        OffsetXTitleLbl.Text = "オフセットX座標";
                        OffsetYTitleLbl.Visible = true;
                        OffsetYTextBox.Visible = true;
                        OffsetYTitleLbl.Text = "オフセットY座標";
                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;
                        ScrollTitleLbl.Visible = true;
                        ScrollButton.Visible = true;
                        SetScrollSpeedVisible();
                        CompButtonTitleLbl.Visible = true;
                        CompButton.Visible = true;
                        CompButtonTitleLbl.Text = "検出成功移動先";
                        ErrorButtonTitleLbl.Visible = true;
                        ErrorButton.Visible = true;
                        ImageChoicePanel.Visible = true;
                        ClearCaptureButton.Visible = true;
                    }
                    if (PointInputRadio.Checked)
                    {
                        OffsetXTitleLbl.Visible = true;
                        OffsetXTextBox.Visible = true;
                        OffsetXTitleLbl.Text = "スクリーンX座標";
                        OffsetYTitleLbl.Visible = true;
                        OffsetYTextBox.Visible = true;
                        OffsetYTitleLbl.Text = "スクリーンY座標";
                        PointTypeTitleLbl.Visible = true;
                        PointTypeButton.Visible = true;
                        CompButtonTitleLbl.Visible = true;
                        CompButton.Visible = true;
                        CompButtonTitleLbl.Text = "次移動先";
                    }
                    StringInputTitleLbl.Visible = false;
                    StringInputTextBox.Visible = false;
                    StringInputClearButton.Visible = false;
                    AlertLbl.Visible = false;
                }
                if (MouseWheelRadio.Checked)
                {
                    CompButtonTitleLbl.Visible = true;
                    CompButton.Visible = true;
                    CompButtonTitleLbl.Text = "処理成功移動先";
                    ErrorButtonTitleLbl.Visible = true;
                    ErrorButton.Visible = true;

                    ScrollTitleLbl.Visible = true;
                    ScrollButton.Visible = true;
                    ScrollSpeedTitleLbl.Visible = true;
                    ScrollSpeedUpDown.Visible = true;
                    ScrollAmountTitleLbl.Visible = true;
                    ScrollAmountUpDown.Visible = true;

                    ScrollTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                    ScrollButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                    ScrollSpeedTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                    ScrollSpeedUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                    ScrollAmountTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                    ScrollAmountUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));

                    ScrollTitleLbl.Location = new Point(3, 76);
                    ScrollButton.Location = new Point(105, 76);

                    ScrollSpeedTitleLbl.Location = new Point(ScrollButton.Location.X + ScrollButton.Width + 1, 76);
                    ScrollSpeedUpDown.Location = new Point(ScrollSpeedTitleLbl.Location.X + ScrollSpeedTitleLbl.Width - 1, 76);

                    ScrollAmountTitleLbl.Location = new Point(ScrollSpeedUpDown.Location.X + ScrollSpeedUpDown.Width + 1, 76);
                    ScrollAmountUpDown.Location = new Point(ScrollAmountTitleLbl.Location.X + ScrollAmountTitleLbl.Width - 1, 76);

                    ScrollCountTitleLbl.Visible = true;
                    ScrollCountUpDown.Visible = true;

                    if(ScrollButton.Tag != null && ((ScrollType)ScrollButton.Tag == ScrollType.スクロールしない || (ScrollType)ScrollButton.Tag == ScrollType.None))
                    {
                        ScrollButton.Tag = ScrollType.下スクロール;
                    }
                }
                if (MouseDragDropRadio.Checked)
                {
                    if (ImageDetectRadio.Checked)
                    {
                        CaptureStartButton.Visible = true;
                        LoadCaptureImageButton.Visible = true;
                        CaptureStartButton.Text = "画像キャプチャ\r\n(Ctrl+Shift+C)";
                        CaptureImageTitleLbl.Visible = true;
                        CaptureImage.Visible = true;
                        CaptureImageTitleLbl.Text = "ドラッグ元検出画像";

                        Capture2StartButton.Visible = true;
                        Capture2StartButton.Text = "画像キャプチャ\r\n(Ctrl+Shift+X)";
                        CaptureImage2TitleLbl.Visible = true;
                        CaptureImage2.Visible = true;
                        CaptureImage2TitleLbl.Text = "ドラッグ先検出画像";

                        LoadCaptureImageButton2.Visible = true;

                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;

                        CompButtonTitleLbl.Visible = true;
                        CompButton.Visible = true;
                        CompButtonTitleLbl.Text = "検出成功移動先";
                        ErrorButtonTitleLbl.Visible = true;
                        ErrorButton.Visible = true;
                    }
                    if (PointInputRadio.Checked)
                    {
                        CaptureStartButton.Visible = true;
                        LoadCaptureImageButton.Visible = true;
                        CaptureStartButton.Text = "画像キャプチャ\r\n(Ctrl+Shift+C)";
                        CaptureImageTitleLbl.Visible = true;
                        CaptureImage.Visible = true;
                        CaptureImageTitleLbl.Text = "ドラッグ元検出画像";

                        OffsetXTitleLbl.Visible = true;
                        OffsetXTextBox.Visible = true;
                        OffsetXTitleLbl.Text = "スクリーンX座標";

                        OffsetYTitleLbl.Visible = true;
                        OffsetYTextBox.Visible = true;
                        OffsetYTitleLbl.Text = "スクリーンY座標";

                        PointTypeTitleLbl.Visible = true;
                        PointTypeButton.Visible = true;

                        TimeoutTitleLbl.Visible = true;
                        TimeoutNumericUpDown.Visible = true;

                        CompButtonTitleLbl.Visible = true;
                        CompButton.Visible = true;
                        CompButtonTitleLbl.Text = "検出成功移動先";
                        ErrorButtonTitleLbl.Visible = true;
                        ErrorButton.Visible = true;
                    }
                    StringInputTitleLbl.Visible = false;
                    StringInputTextBox.Visible = false;
                    StringInputClearButton.Visible = false;
                    AlertLbl.Visible = false;
                }
                if (ClearCaptureButton.Visible)
                {
                    LoadCaptureImageButton.Location = new Point(ClearCaptureButton.Location.X + ClearCaptureButton.Width + 1, ClearCaptureButton.Location.Y);
                }
                else
                {
                    LoadCaptureImageButton.Location = new Point(CaptureStartButton.Location.X + CaptureStartButton.Width + 1, CaptureStartButton.Location.Y);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// コントロールのサイズ変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseControl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //均等配置する
                CaptureImage.Width = this.Width / 2 - 8;
                CaptureImage2.Width = this.Width / 2 - 8;
                CaptureImage2.Location = new Point(CaptureImage.Location.X + CaptureImage.Width + 4, CaptureImage2.Location.Y);
                
                Capture2StartButton.Location = new Point(CaptureImage2.Location.X, Capture2StartButton.Location.Y);
                LoadCaptureImageButton2.Location = new Point(Capture2StartButton.Location.X + Capture2StartButton.Width + 1, Capture2StartButton.Location.Y);
                CaptureImageTitleLbl.Width = CaptureImage.Width;
                CaptureImage2TitleLbl.Width = CaptureImage2.Width;
                CaptureImage2TitleLbl.Location = new Point(CaptureImage2.Location.X, CaptureImage2TitleLbl.Location.Y);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// スクロールコンボボックスの選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetScrollSpeedVisible();

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// スクロールスピードの表示制御
        /// </summary>
        private void SetScrollSpeedVisible()
        {
            try
            {
                if (ScrollButton.Tag == null) return;
                ScrollType type = (ScrollType)ScrollButton.Tag;
                ScrollSpeedTitleLbl.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                ScrollSpeedUpDown.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                ScrollAmountTitleLbl.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                ScrollAmountUpDown.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウスクリック場所を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickPosButton_Click(object sender, EventArgs e)
        {

            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<MouseClickPosition> list = new List<MouseClickPosition>();
                list.Add(MouseClickPosition.左クリック);
                list.Add(MouseClickPosition.右クリック);
                list.Add(MouseClickPosition.ホイールクリック);
                string title = CompButtonTitleLbl.Text;
                form.Init(title, list, (MouseClickPosition)ClickPosButton.Tag);
                form.ShowDialog(this);
                ClickPosButton.Tag = form.GetSelected<MouseClickPosition>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ｽｸﾛｰﾙﾀｲﾌﾟを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<ScrollType> scrollList = new List<ScrollType>();
                if (!MouseWheelRadio.Checked)
                {
                    scrollList.Add(ScrollType.スクロールしない);
                }
                scrollList.Add(ScrollType.下スクロール);
                scrollList.Add(ScrollType.上スクロール);
                form.Init(ScrollTitleLbl.Text, scrollList, (ScrollType)ScrollButton.Tag);
                form.ShowDialog(this);
                ScrollButton.Tag = form.GetSelected<ScrollType>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ポイントタイプを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointTypeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<PointType> list = new List<PointType>();
                list.Add(PointType.絶対座標);
                list.Add(PointType.相対座標);
                form.Init(ScrollTitleLbl.Text, list, (PointType)PointTypeButton.Tag);
                form.ShowDialog(this);
                PointTypeButton.Tag = form.GetSelected<PointType>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }


        /// <summary>
        /// キーボード入力をフックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardHook_KeyboardHooked(object sender, Macrobo.Utils.Gui.KeyboardHookedEventArgs e, out bool result)
        {
            try
            {
                result = false;
                if (!StringInputTextBox.Focused) return;
                if (inputDownList.Count == 0)
                {
                    inputList.Clear();
                }
                if (e.UpDown == Macrobo.Utils.Gui.KeyboardUpDown.Down)
                {
                    if (!inputList.Contains(e.KeyCode))
                    {
                        inputList.Add(e.KeyCode);
                    }
                    if (!inputDownList.Contains(e.KeyCode))
                    {
                        inputDownList.Add(e.KeyCode);
                    }
                }
                else
                {
                    if (inputDownList.Contains(e.KeyCode))
                    {
                        inputDownList.Remove(e.KeyCode);
                    }
                }

                StringInputTextBox.Text = "";
                foreach (var key in inputList)
                {
                    if (string.IsNullOrEmpty(StringInputTextBox.Text))
                    {
                        StringInputTextBox.Text = key.ToString();
                    }
                    else
                    {
                        StringInputTextBox.Text += " , " + key.ToString();
                    }
                }
                StringInputTextBox.Tag = inputList.DeepCopy();
                result = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 入力をクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StringInputClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                StringInputTextBox.Tag = null;
                StringInputTextBox.Text = "";
                inputDownList.Clear();
                inputList.Clear();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キャプチャイメージを削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCaptureButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = GetSelectedImageIndex();
                if (ImageList[idx] == null) return;

                DialogResult result = this.ShowInfoDialog("キャプチャ画像消去の確認", "キャプチャ済み画像を消去しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    ImageList[idx] = null;
                    ChangeImage();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キャプチャ画像リストから選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadCaptureImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImageChoiceForm form = new ImageChoiceForm();
                form.Init(RootProjectModel.GetBitmapAllCopy(ImageList));
                form.ShowDialog(this);
                if(form.SelectedImage != null)
                {
                    if (ImageChoicePanel.Visible)
                    {
                        ImageList[GetSelectedImageIndex()] = form.SelectedImage;
                        CaptureImage.Image = ImageList[GetSelectedImageIndex()];
                    }
                    else
                    {
                        CaptureImage.Image = ImageList[0];
                        ImageList[0] = form.SelectedImage;
                        CaptureImage.Image = ImageList[0];
                    }

                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 検出エリア選択のクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectAreaChoiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                int[] trimPos = CaptureUtil.GetScreenTrimmingPoint(Screen.PrimaryScreen, Screen.PrimaryScreen.Bounds);
                if (trimPos != null)
                {
                    DetectAreaSXTextBox.Text = "" + trimPos[0];
                    DetectAreaSYTextBox.Text = "" + trimPos[1];
                    DetectAreaEXTextBox.Text = "" + trimPos[2];
                    DetectAreaEYTextBox.Text = "" + trimPos[3];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// キャプチャ画像リストから選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadCaptureImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ImageChoiceForm form = new ImageChoiceForm();
                form.Init(RootProjectModel.GetBitmapAllCopy(ImageList));
                form.ShowDialog(this);
                if (form.SelectedImage != null)
                {
                    ImageList[1] = form.SelectedImage;
                    CaptureImage2.Image = ImageList[1];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}

