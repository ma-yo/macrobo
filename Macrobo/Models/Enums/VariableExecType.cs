using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models.Enums
{
    /// <summary>
    /// Author : M.Yoshida
    /// 変数実行タイプ
    /// </summary>
    public enum VariableExecType
    {
        キーボード入力, ファイル入力, ファイル出力, クリップボード入力, クリップボード出力, 変数比較, 加算減算, Excel入力, Excel出力, WEBサービス入力
    }
}
