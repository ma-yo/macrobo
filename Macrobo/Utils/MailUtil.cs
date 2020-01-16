using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// </summary>
    public class MailUtil
    {
        /// <summary>
        /// メール送信を実行します。
        /// </summary>
        /// <param name="fromUser"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toUser"></param>
        /// <param name="toAddress"></param>
        /// <param name="title"></param>
        /// <param name="msg"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="attachList"></param>
        public static void Send(string fromUser, string fromAddress, string toUser, string toAddress, string title, string msg, string host, int port, string userName, string password, Dictionary<int, string> attachList)
        {
            try
            {
                List<string> tmpAttachPathList = new List<string>();
                List<Stream> attachStreamList = new List<Stream>();
                var message = new MimeKit.MimeMessage();

                string[] name = toUser.Replace(",", ";").Split(';');
                string[] addresses = toAddress.Replace(",", ";").Split(';');

                message.From.Add(new MimeKit.MailboxAddress(fromUser, fromAddress));

                try
                {
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        message.To.Add(new MimeKit.MailboxAddress(name[i].Trim(), addresses[i].Trim()));
                    }
                }
                catch (Exception)
                {
                    throw new Exception("送信先名・送信先アドレスの数が一致しません。");
                }

                message.Subject = title;
                var textPart = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain);
                textPart.Text = msg;
                
                if (HasAttach(attachList))
                {
                    var multipart = new MimeKit.Multipart("mixed");
                    multipart.Add(textPart);
                    foreach(var attach in attachList)
                    {
                        if (!string.IsNullOrEmpty(attach.Value))
                        {
                            if (!System.IO.File.Exists(attach.Value))
                            {
                                throw new Exception("添付ファイル : [" + attach.Value + "] が見つかりませんでした。");
                            }
                            var attachment = new MimeKit.MimePart();
                            attachment.Content = new MimeKit.MimeContent(System.IO.File.OpenRead(attach.Value));
                            attachStreamList.Add(attachment.Content.Stream);
                            attachment.ContentDisposition = new MimeKit.ContentDisposition();
                            attachment.ContentTransferEncoding = MimeKit.ContentEncoding.Base64;
                            attachment.FileName = System.IO.Path.GetFileName(attach.Value);
                            multipart.Add(attachment);
                        }
                    }
                    message.Body = multipart;
                }
                else
                {
                    message.Body = textPart;
                }
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(host, port);
                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                    {
                        client.Authenticate(userName, password);
                    }
                    client.Send(message);
                    client.Disconnect(true);
                }
                //メール添付ファイルのストリームを閉じる
                foreach(var s in attachStreamList)
                {
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 添付有無の確認
        /// </summary>
        /// <param name="attachList"></param>
        /// <returns></returns>
        private static bool HasAttach(Dictionary<int, string> attachList)
        {
            try
            {
                foreach(var attach in attachList)
                {
                    if (!string.IsNullOrEmpty(attach.Value)) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
