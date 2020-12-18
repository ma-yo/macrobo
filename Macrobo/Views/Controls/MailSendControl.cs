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
using Macrobo.Models;
using Macrobo.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using Macrobo.Views.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// メール送信コントロール
    /// </summary>
    public partial class MailSendControl : ProcessBaseControl
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public MailSendControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();
                FileOpen1Button.Click += FileOpenButton_Click;
                FileOpen2Button.Click += FileOpenButton_Click;
                FileOpen3Button.Click += FileOpenButton_Click;
                FileOpen4Button.Click += FileOpenButton_Click;
                FileOpen5Button.Click += FileOpenButton_Click;
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
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ファイル選択ダイアログを起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new CommonOpenFileDialog("添付ファイルの選択");
                dialog.IsFolderPicker = false;
                dialog.Multiselect = false;
                if (dialog.ShowDialog(ParentForm.Handle) == CommonFileDialogResult.Ok)
                {
                    if (sender.Equals(FileOpen1Button))
                    {
                        MailAttach1TextBox.Text = dialog.FileName;
                    }
                    if (sender.Equals(FileOpen2Button))
                    {
                        MailAttach2TextBox.Text = dialog.FileName;
                    }
                    if (sender.Equals(FileOpen3Button))
                    {
                        MailAttach3TextBox.Text = dialog.FileName;
                    }
                    if (sender.Equals(FileOpen4Button))
                    {
                        MailAttach4TextBox.Text = dialog.FileName;
                    }
                    if (sender.Equals(FileOpen5Button))
                    {
                        MailAttach5TextBox.Text = dialog.FileName;
                    }
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
                SenderNameTextBox.KeyDown += Control_KeyDown;
                SenderAddressTextBox.KeyDown += Control_KeyDown;
                ReceiverNameTextBox.KeyDown += Control_KeyDown;
                ReceiverAddressTextBox.KeyDown += Control_KeyDown;
                MailTitleTextBox.KeyDown += Control_KeyDown;
                MailHostTextBox.KeyDown += Control_KeyDown;
                PortNoTextBox.KeyDown += Control_KeyDown;
                UserNameTextBox.KeyDown += Control_KeyDown;
                PasswordTextBox.KeyDown += Control_KeyDown;
                MailAttach1TextBox.KeyDown += Control_KeyDown;
                MailAttach2TextBox.KeyDown += Control_KeyDown;
                MailAttach3TextBox.KeyDown += Control_KeyDown;
                MailAttach4TextBox.KeyDown += Control_KeyDown;
                MailAttach5TextBox.KeyDown += Control_KeyDown;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// テキストボックスのキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (sender.Equals(SenderNameTextBox))
                    {
                        SenderAddressTextBox.Focus();
                    }
                    if (sender.Equals(SenderAddressTextBox))
                    {
                        ReceiverNameTextBox.Focus();
                    }
                    if (sender.Equals(ReceiverNameTextBox))
                    {
                        ReceiverAddressTextBox.Focus();
                    }
                    if (sender.Equals(ReceiverAddressTextBox))
                    {
                        MailTitleTextBox.Focus();
                    }
                    if (sender.Equals(MailTitleTextBox))
                    {
                        MailAttach1TextBox.Focus();
                    }
                    if (sender.Equals(MailAttach1TextBox))
                    {
                        MailAttach2TextBox.Focus();
                    }
                    if (sender.Equals(MailAttach2TextBox))
                    {
                        MailAttach3TextBox.Focus();
                    }
                    if (sender.Equals(MailAttach3TextBox))
                    {
                        MailAttach4TextBox.Focus();
                    }
                    if (sender.Equals(MailAttach4TextBox))
                    {
                        MailAttach5TextBox.Focus();
                    }
                    if (sender.Equals(MailAttach5TextBox))
                    {
                        MailTextBox.Focus();
                    }
                    if (sender.Equals(MailHostTextBox))
                    {
                        PortNoTextBox.Focus();
                    }
                    if (sender.Equals(PortNoTextBox))
                    {
                        UserNameTextBox.Focus();
                    }
                    if (sender.Equals(UserNameTextBox))
                    {
                        PasswordTextBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// メール送信試験
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SendTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress(SenderNameTextBox.Text, SenderAddressTextBox.Text));

                string[] name = ReceiverNameTextBox.Text.Replace(",", ";").Split(';');
                string[] addresses = ReceiverAddressTextBox.Text.Replace(",", ";").Split(';');


                try
                {
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        message.To.Add(new MimeKit.MailboxAddress(name[i].Trim(), addresses[i].Trim()));
                    }
                }
                catch (Exception)
                {
                    this.ShowErrorDialog("宛先・送信先エラー", "宛先又は送信先が不正です。");
                    return;
                }

                message.Subject = MailTitleTextBox.Text;
                var textPart = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain);
                textPart.Text = MailTextBox.Text;
                message.Body = textPart;
                using(var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {
                        await client.ConnectAsync(MailHostTextBox.Text, int.Parse(PortNoTextBox.Text));
                        if (!string.IsNullOrEmpty(UserNameTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox.Text))
                        {
                            await client.AuthenticateAsync(UserNameTextBox.Text, PasswordTextBox.Text);
                        }
                        await client.SendAsync(message);
                        await client.DisconnectAsync(true);
                        this.ShowDialog("送信成功", "メール送信に成功しました!!");
                    }
                    catch (Exception ex)
                    {
                        this.ShowErrorDialog("メール送信失敗", ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// メール添付テキストボックスのDragDropイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailAttach1TextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // ドラッグ＆ドロップされたファイル
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    ((BaseTextBox)sender).Text = files[0];
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// メール添付テキストボックスのDragEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailAttach1TextBox_DragEnter(object sender, DragEventArgs e)
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
    }
}
