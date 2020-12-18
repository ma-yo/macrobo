using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Macrobo.Utils;
using System.Drawing.Imaging;
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Components;
using Microsoft.WindowsAPICodePack.Dialogs;
using Macrobo.Views.Forms;
namespace Macrobo.Views
{
    /// <summary>
    /// 画像検索画面
    /// </summary>
    public partial class DetectControl : ProcessBaseControl
    {
        private List<BaseRadioButton> _imageRadioList = new List<BaseRadioButton>();
        /// <summary>
        /// 検出したイメージを保持する
        /// </summary>
        public List<Bitmap> ImageList = new List<Bitmap>() { null, null, null, null, null, null, null, null, null, null };

        /// <summary>
        /// イメージ選択時イベント
        /// </summary>
        private void ImageSetted()
        {
            try
            {
                for(int i = 0; i < ImageList.Count; i++)
                {
                    if(ImageList[i] != null)
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
        /// Constructor
        /// </summary>
        public DetectControl()
        {
            try
            {
                InitializeComponent();

                CreateImageRadioList();

                CaptureImage.ImageChanged += CaptureImage_ImageChanged;

                AddButtonEvent();
                ImageDetectRadio.Checked = true;
                MatchRadio.Checked = true;
                Image1RadioButton.Checked = true;
                FileStateReadableRadio.Checked = true;
                DetectAreaScreenRadio.Checked = true;

                foreach(var imgRadio in _imageRadioList)
                {
                    imgRadio.CheckedChanged += ImageRadioButton_CheckedChanged;
                }

                DetectAreaChoiceButton.Location = new Point(694, 53);

                DetectAreaSXTitleLbl.Location = new Point(266, 76);
                DetectAreaSYTitleLbl.Location = new Point(373, 76);
                DetectAreaEXTitleLbl.Location = new Point(480, 76);
                DetectAreaEYTitleLbl.Location = new Point(587, 76);

                DetectAreaSXTextBox.Location = new Point(330, 76);
                DetectAreaSYTextBox.Location = new Point(437, 76);
                DetectAreaEXTextBox.Location = new Point(544, 76);
                DetectAreaEYTextBox.Location = new Point(651, 76);

                FileDetectTypeTitleLbl.Location = new Point(266, 53);
                FileDetectTypePanel.Location = new Point(368, 53);

                FileStateTitleLbl.Location = new Point(266, 76);
                FileStatePanel.Location = new Point(368, 76);

                DetectAreaTitleLbl.Location = new Point(266, 53);
                DetectAreaPanel.Location = new Point(368, 53);

                VariableTitleLbl.Location = new Point(3, 145);
                VariableButton.Location = new Point(105, 145);

                FolderPathTitleLbl.Location = new Point(3, 99);
                FolderPathTextBox.Location = new Point(105, 99);
                FileOpenButton.Location = new Point(563, 99);
                FileNameTitleLbl.Location = new Point(3, 122);
                FileNameTextBox.Location = new Point(105, 122);

                ImageChoicePanel.Location = new Point(116, 103);
                ClearCaptureButton.Location = new Point(ImageChoicePanel.Location.X + ImageChoicePanel.Width + 1, ImageChoicePanel.Location.Y);
                LoadCaptureImageButton.Location = new Point(ClearCaptureButton.Location.X + ClearCaptureButton.Width + 1, 103);
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
        /// ボタンイベントをセットする
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
                ScrollButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                    ScrollType type = (ScrollType)obj;
                    ScrollSpeedTitleLbl.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                    ScrollSpeedUpDown.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                    ScrollAmountTitleLbl.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                    ScrollAmountUpDown.Visible = !(type == ScrollType.スクロールしない || type == ScrollType.None);
                };
                ScrollButton.Tag = ScrollType.スクロールしない;
                VariableButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                VariableButton.Tag = StringValue.VARIABLE_未設定;
                MoveMouseButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                MoveMouseButton.Tag = MoveMouseType.移動しない;
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
                ExecuteCapture();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キャプチャを実行する
        /// </summary>
        internal void ExecuteCapture()
        {
            try
            {
                string imagePath = CaptureUtil.GetScreenTrimmingImagePath(Screen.PrimaryScreen, Screen.PrimaryScreen.Bounds);
                if (imagePath != null)
                {
                    Image img = Image.FromFile(imagePath);
                    ImageList[GetSelectedImageIndex()] = new Bitmap(img);
                    CaptureImage.Image = img;
                }
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
                if(img == null)
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
                for(int i = 0; i < _imageRadioList.Count; i++)
                {
                    if (_imageRadioList[i].Checked)
                    {
                        return i;
                    }
                }
               
                return 0;
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
                    SetDetectMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル検出Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileDetectRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (FileDetectRadio.Checked)
                {
                    SetDetectMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 検出モードをセットする
        /// </summary>
        private void SetDetectMode()
        {
            try
            {
                DetectAreaSXTitleLbl.Visible = false;
                DetectAreaSYTitleLbl.Visible = false;
                DetectAreaEXTitleLbl.Visible = false;
                DetectAreaEYTitleLbl.Visible = false;
                DetectAreaSXTextBox.Visible = false;
                DetectAreaSYTextBox.Visible = false;
                DetectAreaEXTextBox.Visible = false;
                DetectAreaEYTextBox.Visible = false;
                DetectAreaChoiceButton.Visible = false;

                DetectAreaTitleLbl.Visible = false;
                DetectAreaPanel.Visible = false;
                FileStateTitleLbl.Visible = false;
                FileStatePanel.Visible = false;
                VariableTitleLbl.Visible = false;
                VariableButton.Visible = false;
                FileOpenButton.Visible = false;
                FolderPathTitleLbl.Visible = false;
                FolderPathTextBox.Visible = false;
                FileDetectTypeTitleLbl.Visible = false;
                FileDetectTypePanel.Visible = false;
                FileNameTitleLbl.Visible = false;
                FileNameTextBox.Visible = false;
                ClearCaptureButton.Visible = false;
                LoadCaptureImageButton.Visible = false;
                ImageChoicePanel.Visible = false;
                CaptureStartButton.Visible = false;
                CaptureImageTitleLbl.Visible = false;
                CaptureImage.Visible = false;
                ScrollTitleLbl.Visible = false;
                ScrollButton.Visible = false;
                ScrollSpeedTitleLbl.Visible = false;
                ScrollSpeedUpDown.Visible = false;
                ScrollAmountTitleLbl.Visible = false;
                ScrollAmountUpDown.Visible = false;
                MoveMouseTitleLbl.Visible = false;
                MoveMouseButton.Visible = false;
                TimeoutTitleLbl.Visible = false;
                TimeoutNumericUpDown.Visible = false;
                CompButtonTitleLbl.Visible = false;
                CompButton.Visible = false;
                ErrorButtonTitleLbl.Visible = false;
                ErrorButton.Visible = false;
                if (ImageDetectRadio.Checked)
                {
                    CaptureStartButton.Visible = true;
                    CaptureImageTitleLbl.Visible = true;
                    CaptureImage.Visible = true;
                    ScrollTitleLbl.Visible = true;
                    ScrollButton.Visible = true;
                    ScrollSpeedTitleLbl.Visible = true;
                    ScrollSpeedUpDown.Visible = true;
                    MoveMouseTitleLbl.Visible = true;
                    MoveMouseButton.Visible = true;
                    TimeoutTitleLbl.Visible = true;
                    TimeoutNumericUpDown.Visible = true;
                    CompButtonTitleLbl.Visible = true;
                    CompButton.Visible = true;
                    ErrorButtonTitleLbl.Visible = true;
                    ErrorButton.Visible = true;
                    ImageChoicePanel.Visible = true;
                    ClearCaptureButton.Visible = true;
                    LoadCaptureImageButton.Visible = true;
                    DetectAreaTitleLbl.Visible = true;
                    DetectAreaPanel.Visible = true;

                    if (DetectAreaChoiceRadio.Checked)
                    {
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
                if (FileDetectRadio.Checked)
                {
                    FileStateTitleLbl.Visible = true;
                    FileStatePanel.Visible = true;
                    FileOpenButton.Visible = true;
                    FolderPathTitleLbl.Visible = true;
                    FolderPathTextBox.Visible = true;
                    FileDetectTypeTitleLbl.Visible = true;
                    FileDetectTypePanel.Visible = true;
                    FileNameTitleLbl.Visible = true;
                    FileNameTextBox.Visible = true;
                    TimeoutTitleLbl.Visible = true;
                    TimeoutNumericUpDown.Visible = true;
                    CompButtonTitleLbl.Visible = true;
                    CompButton.Visible = true;
                    ErrorButtonTitleLbl.Visible = true;
                    ErrorButton.Visible = true;
                    VariableTitleLbl.Visible = true;
                    VariableButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ファイルオープンを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog("フォルダの選択");
                // フォルダ選択モード
                dialog.IsFolderPicker = true;
                dialog.Multiselect = false;
                if (dialog.ShowDialog(ParentForm.Handle) == CommonFileDialogResult.Ok)
                {
                    FolderPathTextBox.Text = dialog.FileName;
                }
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
                scrollList.Add(ScrollType.スクロールしない);
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
        /// 変数を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<string> keyList = new List<string>();
                keyList.Add(StringValue.VARIABLE_未設定);
                foreach (var variable in CurrentProjectModel.VariableList)
                {
                    keyList.Add(variable.Key);
                }
                string title = VariableTitleLbl.Text;
                form.Init(title, keyList, (string)VariableButton.Tag);
                form.ShowDialog(this);
                VariableButton.Tag = form.GetSelected<string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マウス移動タイプを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveMouseButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<MoveMouseType> moveMouseTypeList = new List<MoveMouseType>();
                moveMouseTypeList.Add(MoveMouseType.移動しない);
                moveMouseTypeList.Add(MoveMouseType.移動する);
                string title = MoveMouseTitleLbl.Text;
                form.Init(title, moveMouseTypeList, (MoveMouseType)MoveMouseButton.Tag);
                form.ShowDialog(this);
                MoveMouseButton.Tag = form.GetSelected<MoveMouseType>();
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
               
                DialogResult result = this.ShowInfoDialog("キャプチャ画像消去の確認", "キャプチャ済み画像を消去しますか？", MessageBoxButtons.YesNo,MessageBoxDefaultButton.Button1);
                if(result == DialogResult.Yes)
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
        /// フォルダパステキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    FolderPathTextBox.Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// フォルダパステキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル名テキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileNameTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    if (System.IO.File.Exists(files[0]))
                    {
                        FileNameTextBox.Text = System.IO.Path.GetFileName(files[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル名テキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileNameTextBox_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 検出エリア選択Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectAreaScreenRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetectAreaScreenRadio.Checked)
                {
                    SetDetectMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 検出エリア選択Radioのチェック変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectAreaChoiceRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetectAreaChoiceRadio.Checked)
                {
                    SetDetectMode();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 範囲座標取得ﾎﾞﾀﾝのｸﾘｯｸｲﾍﾞﾝﾄ
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
        private void LoadCaptureImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImageChoiceForm form = new ImageChoiceForm();
                form.Init(RootProjectModel.GetBitmapAllCopy(ImageList));
                form.ShowDialog(this);
                if (form.SelectedImage != null)
                {
                    ImageList[GetSelectedImageIndex()] = form.SelectedImage;
                    CaptureImage.Image = ImageList[GetSelectedImageIndex()];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
