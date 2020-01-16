using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models.Enums
{
    /// <summary>
    /// Author : M.Yoshida
    /// 処理タイプ
    /// </summary>
    public enum ProcessType
    {
        None, 検出, キーボード入力, マウス入力, 待機, メール送信, アプリ実行, 変数,ファイルフォルダー処理,ダイアログ, Excel
    }
}
