using Macrobo.Models;
using Macrobo.Models.Enums;
using Macrobo.Utils;
using Macrobo.Views.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Singleton
{
    /// <summary>
    /// Author : M.Yoshida
    /// カレンダーデータを保持する
    /// </summary>
    public sealed class CalendarInfos
    {
        /// <summary>
        /// カレンダーデータ
        /// 0 : カレンダー名
        /// 1 : CalendarModelクラス
        /// 2 : CDATE
        /// 3 : CalendarType
        /// </summary>
        public Dictionary<int, object[]> CalendarInfoDic { get; set; }
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static CalendarInfos _instance = new CalendarInfos();

        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns></returns>
        public static CalendarInfos GetInstance()
        {
            return _instance;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        private CalendarInfos()
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
                CalendarInfoDic = DbUtil.GetInstance().GetCalendarInfoDic();
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
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <param name="calendarType"></param>
        public void CreateCalendarValue(int id, string name, CalendarModel model, CalendarType calendarType)
        {

            try
            {
                DateTime cdate = DateTime.Now;
                DbUtil.GetInstance().CreateCalendarInfo(id, name, model, cdate, calendarType, CalendarInfoDic);
                Update();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// カレンダーを1件削除する
        /// </summary>
        /// <param name="id"></param>
        internal void RemoveByKey(int id)
        {
            try
            {
                DbUtil.GetInstance().DeleteCalendarInfo(id);

                Update();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }


        /// <summary>
        /// カレンダー初期設定モデルを取得する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CalendarModel GetNewCalendarModel()
        {
            try
            {
                CalendarModel model = new CalendarModel();
                model.CalendarId = DbUtil.GetInstance().GetNewCalendarInfoId();

                return model;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
