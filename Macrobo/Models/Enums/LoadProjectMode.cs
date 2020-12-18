using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models.Enums
{
    /// <summary>
    /// Author : M.Yoshida
    /// プロジェクトロードフォームの起動モード
    /// </summary>
    public enum LoadProjectMode
    {
        プロジェクト読込_削除
            ,プロジェクト実行
            ,プロジェクトエクスポート
            ,モジュール読込_削除
            , モジュール実行
            , モジュールエクスポート
            , モジュール読込
    }
}
