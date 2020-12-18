using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macrobo.Models;
using Macrobo.Models.Enums;
using Macrobo.Views.Forms;
using Newtonsoft.Json;

namespace Macrobo.Utils
{
    /// <summary>
    /// Author : M.Yoshida
    /// データベースユーティリティー
    /// </summary>
    public class DbUtil
    {
        private static DbUtil _instance = new DbUtil();

        public static DbUtil GetInstance()
        {
            return _instance;
        }
        /// <summary>
        /// データベースイベント
        /// </summary>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        public delegate void DatabaseEvent(SQLiteConnection con, SQLiteTransaction tran);

        /// <summary>
        /// 実行ログデータを取得する
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal List<ExecuteLogModel> GetExecuteLog(DateTime fromDate, DateTime endDate)
        {
            try
            {
                List<ExecuteLogModel> resultList = new List<ExecuteLogModel>();
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append("SELECT");
                        sql.Append(" ID,");
                        sql.Append(" CDATE,");
                        sql.Append(" EXECID,");
                        sql.Append(" EXECTYPE,");
                        sql.Append(" EXECNAME,");
                        sql.Append(" STARTTIME,");
                        sql.Append(" ENDTIME,");
                        sql.Append(" EXECTIME,");
                        sql.Append(" DESCRIPTION,");
                        sql.Append(" RESULT");
                        sql.Append(" FROM EXECUTE_LOG");
                        sql.Append(" WHERE CDATE BETWEEN @FROMDATE AND @TODATE");
                        sql.Append(" ORDER BY CDATE");
                        using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@FROMDATE", fromDate.ToString("yyyy/MM/dd 00:00:00")));
                            command.Parameters.Add(new SQLiteParameter("@TODATE", endDate.ToString("yyyy/MM/dd 23:59:59")));
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    ExecuteLogModel data = new ExecuteLogModel();
                                    data.Id = "" + reader.GetValue(0);
                                    data.Cdate = "" + reader.GetValue(1);
                                    data.ExecId = "" + reader.GetValue(2);
                                    data.ExecType = "" + reader.GetValue(3);
                                    data.ExecName = "" + reader.GetValue(4);
                                    data.StartTime = "" + reader.GetValue(5);
                                    data.EndTime = "" + reader.GetValue(6);
                                    data.ExecTime = int.Parse("" + reader.GetValue(7));
                                    data.Description = "" + reader.GetValue(8);
                                    data.Result = int.Parse("" + reader.GetValue(9));
                                    resultList.Add(data);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw Program.ThrowException(ex);
                    }
                };
                Execute(false);
                return resultList;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 実行イベント登録
        /// </summary>
        public DatabaseEvent OnExecute;

        private string DATABASE_PATH;
        /// <summary>
        /// Constructor
        /// </summary>
        public DbUtil()
        {
            if (!System.IO.Directory.Exists(Program.USERPROFILE_PATH))
            {
                System.IO.Directory.CreateDirectory(Program.USERPROFILE_PATH);
            }
            DATABASE_PATH = "Data Source=" + Program.USERPROFILE_PATH + @"\db.sqlite;Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(DATABASE_PATH))
            {
                con.Open();
                StringBuilder sql = new StringBuilder();
                sql.Append("CREATE TABLE IF NOT EXISTS PROJECT_INFO (");
                sql.Append("    ID TEXT,");
                sql.Append("    PROJECTNAME TEXT,");
                sql.Append("    PROJECTVALUE TEXT,");
                sql.Append("    CDATE TEXT,");
                sql.Append("    PRIMARY KEY(ID)");
                sql.Append(");");
                sql.Append("CREATE TABLE IF NOT EXISTS MACRO_INFO (");
                sql.Append("    ID TEXT,");
                sql.Append("    MACRONAME TEXT,");
                sql.Append("    MACROVALUE TEXT,");
                sql.Append("    CDATE TEXT,");
                sql.Append("    PRIMARY KEY(ID)");
                sql.Append(");");
                sql.Append("CREATE TABLE IF NOT EXISTS CALENDAR_INFO (");
                sql.Append("    ID INT,");
                sql.Append("    CALENDARNAME TEXT,");
                sql.Append("    CALENDARVALUE TEXT,");
                sql.Append("    CDATE TEXT,");
                sql.Append("    PRIMARY KEY(ID)");
                sql.Append(");");
                sql.Append("CREATE TABLE IF NOT EXISTS SETTING_INFO (");
                sql.Append("    ID INT,");
                sql.Append("    VALUE TEXT,");
                sql.Append("    PRIMARY KEY(ID)");
                sql.Append(");");
                sql.Append("CREATE TABLE IF NOT EXISTS UPDATE_IGNORE_INFO (");
                sql.Append("    IGNOREVERSION INT,");
                sql.Append("    PRIMARY KEY(IGNOREVERSION)");
                sql.Append(");");
                sql.Append("CREATE TABLE IF NOT EXISTS EXECUTE_LOG (");
                sql.Append("    ID TEXT,");
                sql.Append("    CDATE TEXT,");
                sql.Append("    EXECID TEXT,");
                sql.Append("    EXECTYPE TEXT,");
                sql.Append("    EXECNAME TEXT,");
                sql.Append("    STARTTIME TEXT,");
                sql.Append("    ENDTIME TEXT,");
                sql.Append("    EXECTIME INT,");
                sql.Append("    DESCRIPTION TEXT,");
                sql.Append("    RESULT INT,");
                sql.Append("    PRIMARY KEY(ID)");
                sql.Append(");");

                ExecuteNonQuery(sql.ToString(), con);

                //20190605 列追加
                if (!ColumnExists(con, "CALENDAR_INFO", "CALENDARTYPE"))
                {
                    ExecuteNonQuery("ALTER TABLE CALENDAR_INFO ADD COLUMN CALENDARTYPE INT DEFAULT 0;", con);
                }
                if (!ColumnExists(con, "PROJECT_INFO", "DESCRIPTION"))
                {
                    ExecuteNonQuery("ALTER TABLE PROJECT_INFO ADD COLUMN DESCRIPTION TEXT;", con);
                }
                if (!ColumnExists(con, "MACRO_INFO", "DESCRIPTION"))
                {
                    ExecuteNonQuery("ALTER TABLE MACRO_INFO ADD COLUMN DESCRIPTION TEXT;", con);
                }
            }
        }
        /// <summary>
        /// 設定値情報を作成する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        internal void CreateSettingInfo(int id, string value)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {

                    try
                    {
                        string sql = "INSERT OR REPLACE INTO SETTING_INFO (ID, VALUE) VALUES(@ID,@VALUE)";
                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", id));
                            command.Parameters.Add(new SQLiteParameter("@VALUE", value));
                            command.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw Program.ThrowException(ex);
                    }

                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 設定値情報を取得する
        /// </summary>
        /// <returns></returns>
        internal Dictionary<int, string> GetSettingInfoAll()
        {
            try
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    string sql = "SELECT ID, VALUE FROM SETTING_INFO ORDER BY ID";
                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = int.Parse("" + reader.GetValue(0));
                                string value = "" + reader.GetValue(1);
                                dic.Add(id, value);
                            }
                        }
                    }
                };
                Execute(false);
                return dic;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// CalendarInfoDicにカレンダー情報を取得する
        /// </summary>
        /// <param name="calendarInfoDic"></param>
        internal Dictionary<int, object[]> GetCalendarInfoDic()
        {
            try
            {
                Dictionary<int, object[]> calendarInfoDic = new Dictionary<int, object[]>();
                DbUtil util = DbUtil.GetInstance();
                util.OnExecute = (SQLiteConnection con, SQLiteTransaction tran) =>
                {
                    string sql = "SELECT ID, CALENDARNAME, CALENDARVALUE, CDATE, CALENDARTYPE FROM CALENDAR_INFO ORDER BY ID";
                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = int.Parse("" + reader.GetValue(0));
                                string name = "" + reader.GetValue(1);
                                CalendarModel model = JsonConvert.DeserializeObject<CalendarModel>("" + reader.GetValue(2));
                                DateTime cdate = DateTime.Parse("" + reader.GetValue(3));
                                CalendarType calendarType = (CalendarType)reader.GetValue(4);
                                if (calendarType == CalendarType.外部カレンダー)
                                {
                                    var dic = AsyncUtil.RunSync(() => WebCalendarEditForm.GetCalendarValueFromWeb(null, model.Url, model.UrlParams, model.GetDelimitter(), model.EncodeType));
                                    if (dic != null)
                                    {
                                        model.Value = dic;
                                    }
                                }
                                calendarInfoDic.Add(id, new object[] { name, model, cdate, calendarType });
                            }
                        }
                    }
                };
                util.Execute(false);
                return calendarInfoDic;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行ログを削除する
        /// </summary>
        /// <param name="idList"></param>
        internal void DeleteExecuteLog(List<string> idList)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        string sql = "DELETE FROM EXECUTE_LOG WHERE EXECID IN (";
                        int i = 0;
                        foreach (var id in idList)
                        {
                            i++;
                            if(i == 1)
                            {
                                sql += "@EXECID" + i;
                            }
                            else
                            {
                                sql += ",@EXECID" + i;
                            }
                        }
                        sql += ")";
                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            i = 0;
                            foreach (var id in idList)
                            {
                                i++;
                                command.Parameters.Add(new SQLiteParameter("@EXECID" + i, id));
                            }
                            
                            command.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<string[]> Get_Project_Macro_InfoAll(ExecDataType execDataType)
        {
            try
            {
                List<string[]> resultList = new List<string[]>();
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    StringBuilder sql = new StringBuilder();
                    string name = "";
                    switch (execDataType)
                    {
                        case ExecDataType.PROJECT:
                            name = "PROJECT";
                            break;
                        case ExecDataType.MACRO:
                            name = "MACRO";
                            break;
                    }
                    sql.Append("SELECT ID, " + name + "NAME, CDATE FROM " + name + "_INFO ORDER BY " + ((name != "PROJECT") ? name + "NAME" : "CDATE DESC"));
                    using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = "" + reader.GetValue(0);
                                string pName = "" + reader.GetValue(1);
                                string cdate = "" + reader.GetValue(2);
                                resultList.Add(new string[] { id, pName, cdate });
                            }
                        }
                    }
                };
                Execute(false);
                return resultList;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// CalendarInfoを削除する
        /// </summary>
        /// <param name="id"></param>
        internal void DeleteCalendarInfo(int id)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        string sql = "DELETE FROM CALENDAR_INFO WHERE ID = @ID";
                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", id));
                            command.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// CalendarInfoの新規IDを取得する
        /// </summary>
        /// <returns></returns>
        internal int GetNewCalendarInfoId()
        {
            try
            {
                int result = 0;
                OnExecute = (SQLiteConnection con, SQLiteTransaction transaction) => {
                    string sql = "SELECT CASE WHEN MAX(ID) IS NOT NULL THEN MAX(ID) + 1 ELSE 1 END FROM CALENDAR_INFO";
                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result = int.Parse("" + reader.GetValue(0));
                            }
                        }
                    }
                };
                Execute(false);
                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// カレンダーインフォを作成する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <param name="cdate"></param>
        /// <param name="calendarType"></param>
        /// <param name="calendarInfoDic"></param>
        internal void CreateCalendarInfo(int id, string name, CalendarModel model, DateTime cdate, CalendarType calendarType, Dictionary<int, object[]> calendarInfoDic)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        string sql = "INSERT OR REPLACE INTO CALENDAR_INFO (ID, CALENDARNAME, CALENDARVALUE, CDATE, CALENDARTYPE) VALUES(@ID,@CALENDARNAME, @CALENDARVALUE, @CDATE, @CALENDARTYPE)";
                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", id));
                            command.Parameters.Add(new SQLiteParameter("@CALENDARNAME", name));
                            command.Parameters.Add(new SQLiteParameter("@CALENDARVALUE", JsonConvert.SerializeObject(model)));
                            command.Parameters.Add(new SQLiteParameter("@CDATE", cdate));
                            command.Parameters.Add(new SQLiteParameter("@CALENDARTYPE", calendarType));
                            command.ExecuteNonQuery();
                            if (calendarInfoDic.ContainsKey(id))
                            {
                                calendarInfoDic[id][0] = name;
                                calendarInfoDic[id][1] = model;
                                calendarInfoDic[id][2] = cdate;
                                calendarInfoDic[id][3] = calendarType;
                            }
                            else
                            {
                                calendarInfoDic.Add(id, new object[] { name, model, cdate, calendarType });
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw Program.ThrowException(ex);
                    }
                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// Queryを実施する
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="con"></param>
        private void ExecuteNonQuery(string sql, SQLiteConnection con)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// テーブルカラムが存在するかの判定
        /// </summary>
        /// <param name="con"></param>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private bool ColumnExists(SQLiteConnection con, string tableName, string columnName)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand("PRAGMA table_info('"+ tableName+"');", con))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string result = "" + reader.GetValue(1);
                            if(columnName.ToUpper() == result.ToUpper())
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// データベース処理を実行する
        /// </summary>
        /// <param name="transaction"></param>
        public void Execute(bool transaction)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DATABASE_PATH))
                {
                    con.Open();
                    if (transaction)
                    {
                        using (SQLiteTransaction tran = con.BeginTransaction())
                        {
                            OnExecute?.Invoke(con, tran);
                            OnExecute = null;
                        }
                    }
                    else
                    {
                        OnExecute?.Invoke(con, null);
                        OnExecute = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// データベースをクリーンアップする
        /// </summary>
        internal void Vacuum()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DATABASE_PATH))
                {
                    con.Open();
                    using (SQLiteCommand command = new SQLiteCommand("vacuum;", con))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// UpdateIgnoreInfoを更新する
        /// </summary>
        /// <param name="version"></param>
        internal void CreateUpdateIgnoreInfo(string version)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    string sql = "REPLACE INTO UPDATE_IGNORE_INFO (IGNOREVERSION) VALUES (@VERSION)";
                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        try
                        {
                            command.Parameters.Add(new SQLiteParameter("@VERSION", version));
                            command.ExecuteNonQuery();
                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                        }

                    }
                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ExecuteLogを作成する
        /// </summary>
        /// <param name="calendarModel"></param>
        internal void CreateExecuteLog(ExecuteLogModel execModel)
        {

            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("INSERT INTO EXECUTE_LOG (");
                    sql.Append("ID,");
                    sql.Append("CDATE,");
                    sql.Append("EXECID,");
                    sql.Append("EXECTYPE,");
                    sql.Append("EXECNAME,");
                    sql.Append("STARTTIME,");
                    sql.Append("ENDTIME,");
                    sql.Append("EXECTIME,");
                    sql.Append("DESCRIPTION,");
                    sql.Append("RESULT");
                    sql.Append(")VALUES(");
                    sql.Append("@ID,");
                    sql.Append("@CDATE,");
                    sql.Append("@EXECID,");
                    sql.Append("@EXECTYPE,");
                    sql.Append("@EXECNAME,");
                    sql.Append("@STARTTIME,");
                    sql.Append("@ENDTIME,");
                    sql.Append("@EXECTIME,");
                    sql.Append("@DESCRIPTION,");
                    sql.Append("@RESULT");
                    sql.Append(")");
                    using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                    {
                        try
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", execModel.Id));
                            command.Parameters.Add(new SQLiteParameter("@CDATE", execModel.Cdate));
                            command.Parameters.Add(new SQLiteParameter("@EXECID", execModel.ExecId));
                            command.Parameters.Add(new SQLiteParameter("@EXECTYPE", execModel.ExecType));
                            command.Parameters.Add(new SQLiteParameter("@EXECNAME", execModel.ExecName));
                            command.Parameters.Add(new SQLiteParameter("@STARTTIME", execModel.StartTime));
                            command.Parameters.Add(new SQLiteParameter("@ENDTIME", execModel.EndTime));
                            command.Parameters.Add(new SQLiteParameter("@EXECTIME", execModel.ExecTime));
                            command.Parameters.Add(new SQLiteParameter("@DESCRIPTION", execModel.Description));
                            command.Parameters.Add(new SQLiteParameter("@RESULT", execModel.Result));
                            command.ExecuteNonQuery();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        /// <summary>
        /// プロジェクト又はマクロのValue値を取得する
        /// </summary>
        /// <param name="name"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        internal string Get_Project_Macro_Value(string name, string projectId)
        {
            try
            {
                string result = "";
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append("SELECT " + name + "VALUE FROM " + name + "_INFO WHERE ID = @ID");
                        using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", projectId));
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    result = "" + reader.GetValue(0);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw Program.ThrowException(ex);
                    }
                };
                Execute(false);
                return result;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ProjectInfo又はMacroInfoを作成する
        /// </summary>
        /// <param name="model"></param>
        internal void Create_Project_Module_Info(ProjectModel model)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        string jsonString = JsonConvert.SerializeObject(model, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            Formatting = Formatting.Indented
                        });
                        StringBuilder sql = new StringBuilder();

                        string name = "";
                        switch (model.ExecDataType)
                        {
                            case ExecDataType.PROJECT:
                                name = "PROJECT";
                                break;
                            case ExecDataType.MACRO:
                                name = "MACRO";
                                break;
                        }
                        sql.Append("DELETE FROM " + name + "_INFO WHERE ID = @ID");
                        using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", model.ProjectId));
                            command.ExecuteNonQuery();
                        }
                        sql.Clear();
                        sql.Append("INSERT INTO " + name + "_INFO(");
                        sql.Append("ID");
                        sql.Append("," + name + "NAME");
                        sql.Append("," + name + "VALUE");
                        sql.Append(",DESCRIPTION");
                        sql.Append(",CDATE");
                        sql.Append(")VALUES(");
                        sql.Append("@ID");
                        sql.Append(",@NAME");
                        sql.Append(",@VALUE");
                        sql.Append(",@DESCRIPTION");
                        sql.Append(",@CDATE");
                        sql.Append(")");
                        using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", model.ProjectId));
                            command.Parameters.Add(new SQLiteParameter("@NAME", model.Name));
                            command.Parameters.Add(new SQLiteParameter("@VALUE", jsonString));
                            command.Parameters.Add(new SQLiteParameter("@DESCRIPTION", model.Description));
                            command.Parameters.Add(new SQLiteParameter("@CDATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                            command.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// プロジェクト又はマクロを削除する
        /// </summary>
        /// <param name="type"></param>
        /// <param name="projectId"></param>
        internal void Delete_Project_Macro_Info(ExecDataType type, string projectId)
        {
            try
            {
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    try
                    {
                        StringBuilder sql = new StringBuilder();
                        string name = "";
                        switch (type)
                        {
                            case ExecDataType.PROJECT:
                                name = "PROJECT";
                                break;
                            case ExecDataType.MACRO:
                                name = "MACRO";
                                break;
                        }
                        sql.Append("DELETE FROM " + name + "_INFO WHERE ID = @ID");
                        using (SQLiteCommand command = new SQLiteCommand(sql.ToString(), con))
                        {
                            command.Parameters.Add(new SQLiteParameter("@ID", projectId));
                            command.ExecuteNonQuery();
                            tran.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw Program.ThrowException(ex);
                    }

                };
                Execute(true);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 指定したバージョンのUpdateIgnoreInfoが存在するかの判定
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <returns></returns>
        internal bool UpdateIgnoreInfoExists(string currentVersion)
        {
            try
            {
                bool hasRow = false;
                OnExecute = (SQLiteConnection con, SQLiteTransaction tran) => {
                    string sql = "SELECT IGNOREVERSION FROM UPDATE_IGNORE_INFO WHERE IGNOREVERSION = @VERSION";
                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        command.Parameters.Add(new SQLiteParameter("@VERSION", currentVersion));
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            hasRow = reader.HasRows;
                        }
                    }
                };
                Execute(false);
                return hasRow;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
