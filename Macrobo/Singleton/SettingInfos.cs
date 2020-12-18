using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Singleton
{
    /// <summary>
    /// 設定値情報を保持
    /// </summary>
    public sealed class SettingInfos
    {
        /// <summary>
        /// 設定辞書
        /// </summary>
        public Dictionary<int, string> SettingDic { get; set; }
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static SettingInfos _instance = new SettingInfos();
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns></returns>
        public static SettingInfos GetInstance()
        {
            return _instance;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private SettingInfos()
        {
            try
            {
                Update();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 更新を行う
        /// </summary>
        public void Update()
        {

            try
            {
                SettingDic = DbUtil.GetInstance().GetSettingInfoAll();

                //編集中、処理タイプを変更する場合に、ダイアログによる警告を表示する。
                if (!SettingDic.ContainsKey(0))
                {
                    CreateSettingValue(0, "0");
                }
                //ノード・モジュールを移動等した場合の処理後移動先を自動設定する。
                if (!SettingDic.ContainsKey(1))
                {
                    CreateSettingValue(1, "1");
                }
                //単体実行前にカウントダウンを行う
                if (!SettingDic.ContainsKey(3))
                {
                    CreateSettingValue(3, "1");
                }
                //ノード・モジュールを追加した場合、追加した場所へ移動する。
                if (!SettingDic.ContainsKey(2))
                {
                    CreateSettingValue(2, "1");
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 設定値を登録する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void CreateSettingValue(int id, string value)
        {
            try
            {
                DbUtil.GetInstance().CreateSettingInfo(id, value);
                if (SettingDic.ContainsKey(id))
                {
                    SettingDic[id] = value;
                }
                else
                {
                    SettingDic.Add(id, value);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
