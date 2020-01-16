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
using static System.Windows.Forms.DataGridView;
using Macrobo.Models.Enums;
using System.Text.RegularExpressions;
using Macrobo.Views.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// プロジェクトコントロール
    /// </summary>
    public partial class ProjectControl : BaseUserControl
    {
        /// <summary>
        /// プロジェクトデータ
        /// </summary>
        private ProjectModel ProjectModel { get; set; }
        /// <summary>
        /// 変数列Index番号
        /// </summary>
        public int COL_変数 = 0;
        /// <summary>
        /// 値列Index番号
        /// </summary>
        public int COL_値 = 0;
        /// <summary>
        /// 説明列Index番号
        /// </summary>
        public int COL_説明 = 0;
        /// <summary>
        /// 変数配列Index番号
        /// </summary>
        public int COL_変数配列 = 0;
        /// <summary>
        /// 変数配列Index番号
        /// </summary>
        public int COL_変数列数 = 0;
        /// <summary>
        /// 配列説明Index番号
        /// </summary>
        public int COL_配列説明 = 0;
        /// <summary>
        /// 配列変数の列数最大数
        /// </summary>
        private const int MAX_ARRAY_VARIABLE_COLUMN_COUNT = 10000;
        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectControl()
        {
            InitializeComponent();
            COL_変数 = VARIABLE_GRID_COL_変数.Index;
            COL_値 = VARIABLE_GRID_COL_値.Index;
            COL_説明 = VARIABLE_GRID_COL_説明.Index;
            COL_変数配列 = ARRAY_VARIABLE_GRID_COL_変数.Index;
            COL_変数列数 = ARRAY_VARIABLE_GRID_COL_列数.Index;
            COL_配列説明 = ARRAY_VARIABLE_GRID_COL_説明.Index;

            CreateArrayVariableColumnCountComboBox();



            CreateDateTimeFuncForm.LoadCalendarToComboBox(CalendarComboBox);
        }
        /// <summary>
        /// 変数配列の列数コンボボックスを作成する
        /// </summary>
        private void CreateArrayVariableColumnCountComboBox()
        {
            try
            {
                DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)ArrayVariableGrid.Columns[COL_変数列数];
                for (int i = 0; i < MAX_ARRAY_VARIABLE_COLUMN_COUNT; i++)
                {
                    column.Items.Add("" + (i + 1));
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
        /// <param name="execMode">編集時のモード</param>
        /// <param name="projectModel"></param>
        internal void Init(ProjectModel projectModel)
        {
            try
            {
                ProjectModel = projectModel;
                MouseSpeedUpDown.Value = projectModel.MouseSpeed;

                foreach(CalendarModel model in CalendarComboBox.Items)
                {
                    if(model.CalendarId == projectModel.ExecCalendarId)
                    {
                        CalendarComboBox.SelectedItem = model;
                        break;
                    }
                }
                if(CalendarComboBox.SelectedItem == null)
                {
                    CalendarComboBox.SelectedIndex = 0;
                }

                if (projectModel.ExecDataType != ExecDataType.PROJECT)
                {
                    LogViewTitleLbl.Visible = false;
                    LogViewPanel.Visible = false;
                    CalendarComboBox.Visible = false;
                    CalendarComboTitleLbl.Visible = false;
                }
                switch (projectModel.ViewLogType)
                {
                    case ViewLogType.表示する:
                        LogViewRadio.Checked = true;
                        break;
                    case ViewLogType.表示しない:
                        LogNotViewRadio.Checked = true;
                        break;
                }
                foreach (var variable in projectModel.VariableList.OrderByDescending(a => a.Key == StringValue.VARIABLE_VAR0).ThenBy(a => a.Key))
                {
                    VariableGrid.Rows.Add(variable.Key, variable.Value.Value, variable.Value.Description);
                }
                foreach (var variable in projectModel.ArrayVariableList.OrderByDescending(a => a.Key == StringValue.VARIABLE_ARY_VAR0).ThenBy(a => a.Key))
                {
                    int colCount = variable.Value.ColumnCount;
                    if(colCount > MAX_ARRAY_VARIABLE_COLUMN_COUNT)
                    {
                        colCount = MAX_ARRAY_VARIABLE_COLUMN_COUNT;
                    }
                    ArrayVariableGrid.Rows.Add(variable.Key, "" + colCount, variable.Value.Description);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// VariableGridのMouseClickｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableGrid_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    VariableContextMenuStrip.Show(Cursor.Position, ToolStripDropDownDirection.BelowRight);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ArrayVariableGridのMouseClickｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrayVariableGrid_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ArrayVariableContextMenuStrip.Show(Cursor.Position, ToolStripDropDownDirection.BelowRight);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 追加ArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteArrayVariableInsert();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 削除ArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteArrayVariableDelete();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数を追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteVariableInsert();

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数を追加する
        /// </summary>
        public void ExecuteVariableInsert()
        {
            try
            {
                string variable = Microsoft.VisualBasic.Interaction.InputBox("", "変数名を入力してください。", "");
                if (string.IsNullOrEmpty(variable)) return;

                if (!IsVariableAllowedString(variable))
                {
                    this.ShowErrorDialog("変数名エラー", "変数名に[" + string.Join(" ", GetVariableNotAllowedList().ToArray()) + "]を使用する事は出来ません。");
                    return;
                }
                 
                foreach (DataGridViewRow row in VariableGrid.Rows)
                {
                    string v = "" + row.Cells[COL_変数].Value;
                    if (v == variable)
                    {
                        this.ShowErrorDialog("変数名重複エラー", "変数名が重複しています。別の変数名を指定してください。");
                        return;
                    }
                }
                foreach (DataGridViewRow row in ArrayVariableGrid.Rows)
                {
                    string v = "" + row.Cells[COL_変数配列].Value;
                    if (v == variable)
                    {
                        this.ShowErrorDialog("変数名重複エラー", "変数名が重複しています。別の変数名を指定してください。");
                        return;
                    }
                }
                VariableGrid.Rows.Add(variable);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数として使用不可な文字列をチェックする
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        private bool IsVariableAllowedString(string variable)
        {
            try
            {
                if (string.IsNullOrEmpty(variable)) return false;
                List<string> list = GetVariableNotAllowedList();
                return !list.Exists(a => variable.Contains(a));
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数として使用不可な文字を取得する
        /// </summary>
        /// <returns></returns>
        private List<string> GetVariableNotAllowedList()
        {
            try
            {
                List<string> list = new List<string>();
                list.Add(@"!");
                list.Add("\"");
                list.Add(@"#");
                list.Add(@"$");
                list.Add(@"%");
                list.Add(@"&");
                list.Add(@"'");
                list.Add(@"(");
                list.Add(@")");
                list.Add(@"=");
                list.Add(@"-");
                list.Add(@"^");
                list.Add(@"~");
                list.Add(@"|");
                list.Add(@"\");
                list.Add(@"{");
                list.Add(@"}");
                list.Add(@"[");
                list.Add(@"]");
                list.Add(@"<");
                list.Add(@">");
                list.Add(@"?");
                list.Add(@"/");
                list.Add(@"_");
                list.Add(@"+");
                list.Add(@";");
                list.Add(@"*");
                list.Add(@":");
                list.Add(@"@");
                list.Add(@"`");
                list.Add(@",");
                list.Add(@".");
                return list;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 変数配列を追加する
        /// </summary>
        public void ExecuteArrayVariableInsert()
        {
            try
            {
                string variable = Microsoft.VisualBasic.Interaction.InputBox("", "変数名を入力してください。", "");
                if (string.IsNullOrEmpty(variable)) return;

                if (!IsVariableAllowedString(variable))
                {
                    this.ShowErrorDialog("変数名エラー", "変数名に[" + string.Join(" ", GetVariableNotAllowedList().ToArray()) + "]を使用する事は出来ません。");
                    return;
                }

                foreach (DataGridViewRow row in ArrayVariableGrid.Rows)
                {
                    string v = "" + row.Cells[COL_変数配列].Value;
                    if (v == variable)
                    {
                        this.ShowErrorDialog("変数名重複エラー", "変数名が重複しています。別の変数名を指定してください。");
                        return;
                    }
                }
                foreach (DataGridViewRow row in VariableGrid.Rows)
                {
                    string v = "" + row.Cells[COL_変数].Value;
                    if (v == variable)
                    {
                        this.ShowErrorDialog("変数名重複エラー", "変数名が重複しています。別の変数名を指定してください。");
                        return;
                    }
                }
                ArrayVariableGrid.Rows.Add(variable, "100", "");
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 変数を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteVariableDelete();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数を削除する
        /// </summary>
        public void ExecuteVariableDelete()
        {
            try
            {
                foreach (DataGridViewRow row in VariableGrid.SelectedRows)
                {
                    if (row.Index == 0)
                    {
                        this.ShowInfoDialog("削除不可ダイアログ", StringValue.VARIABLE_VAR0 + "は削除できません。");
                        return;
                    }
                    DialogResult result = this.ShowInfoDialog("変数の削除確認", "変数 : [" + row.Cells[COL_変数].Value + "]を削除しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                    VariableGrid.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列を削除する
        /// </summary>
        public void ExecuteArrayVariableDelete()
        {
            try
            {
                foreach (DataGridViewRow row in ArrayVariableGrid.SelectedRows)
                {
                    if (row.Index == 0)
                    {
                        this.ShowInfoDialog("削除不可ダイアログ", StringValue.VARIABLE_ARY_VAR0 + "は削除できません。");
                        return;
                    }
                    DialogResult result = this.ShowInfoDialog("変数の削除確認", "変数 : [" + row.Cells[COL_変数配列].Value + "]を削除しますか？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No) return;
                    ArrayVariableGrid.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// VariableGridのKeyDownｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Insert)
                {
                    ExecuteVariableInsert();
                }
                if(e.KeyCode == Keys.Delete)
                {
                    ExecuteVariableDelete();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 変数配列GridのKeyDownｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrayVariableGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Insert)
                {
                    ExecuteArrayVariableInsert();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    ExecuteArrayVariableDelete();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
