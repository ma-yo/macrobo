using Macrobo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models
{
    /// <summary>
    /// Author : M.Yoshida
    /// カレンダーデータ
    /// </summary>
    [Serializable]
    public class CalendarModel
    {
        /// <summary>
        /// カレンダーID
        /// </summary>
        public int CalendarId { get; set; }
        
        /// <summary>
        /// 補足
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 休日ONOFF設定
        /// </summary>
        public Dictionary<string, bool> Value { get; set; }
        /// <summary>
        /// カレンダー種類
        /// 0:固定カレンダー
        /// 1:WEBカレンダー
        /// </summary>
        public CalendarType CalendarType { get; set; }
        /// <summary>
        /// カレンダーデータフォーマット CSV OR TXT
        /// </summary>
        public CalendarDataFormatType CalendarDataFormatType { get; set; }

        /// <summary>
        /// 取得元URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// URLパラメーター
        /// </summary>
        public Dictionary<string, string> UrlParams { get; set; }
        /// <summary>
        /// WEBサービスからの取得時の文字コード
        /// </summary>
        public EncodeType EncodeType { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public CalendarModel()
        {
            try
            {
                Value = new Dictionary<string, bool>();
                UrlParams = new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ﾃﾞﾘﾐｯﾀｰを取得する
        /// </summary>
        /// <returns></returns>
        public char GetDelimitter()
        {
            return CalendarDataFormatType == CalendarDataFormatType.CSV ? ',' : '\t';
        }
        /// <summary>
        /// ToStringをオーバーライド
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CalendarId + " : " + Description;
        }
    }
}
