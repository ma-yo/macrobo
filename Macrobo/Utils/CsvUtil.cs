using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// CsvUtil
    /// </summary>
    public class CsvUtil
    {
        /// <summary>
        /// 文字列のリストをCSV行データとして取得する
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListToRowString(List<string> list)
        {
            string sr = "";
            //レコードを書き込む
            for (int i = 0; i < list.Count; i++)
            {
                //フィールドの取得
                string field = list[i].ToString();
                //"で囲む
                field = EncloseDoubleQuotesIfNeed(field);
                //フィールドを書き込む
                sr += (field);
                //カンマを書き込む
                if (list.Count > i)
                {
                    sr += (',');
                }
            }
            return sr;
        }
        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotesIfNeed(string field)
        {
            if (NeedEncloseDoubleQuotes(field))
            {
                return EncloseDoubleQuotes(field);
            }
            return field;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotes(string field)
        {
            if (field.IndexOf('"') > -1)
            {
                //"を""とする
                field = field.Replace("\"", "\"\"");
            }
            return "\"" + field + "\"";
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        private static bool NeedEncloseDoubleQuotes(string field)
        {
            return field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") ||
                field.StartsWith("\t") ||
                field.EndsWith(" ") ||
                field.EndsWith("\t");
        }
    }
}
