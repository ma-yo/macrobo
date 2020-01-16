using Macrobo.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// 値選択フォーム
    /// </summary>
    public partial class ValueChoiceForm : BaseForm
    {
        /// <summary>
        /// 選択判定
        /// </summary>
        private bool SetSelected { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ValueChoiceForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="list"></param>
        /// <param name="selected"></param>
        public void Init<T>(string title, List<T> list, T selected)
        {
            try
            {
                ValueTypeLbl.Text = title;
                ValueChoiceGrid.Columns[0].Visible = false;
                ValueChoiceGrid.Columns[0].MinimumWidth = 2;
                ValueChoiceGrid.Columns[0].Width = 2;
                ValueChoiceGrid.Rows.Clear();
                ValueChoiceGrid.Tag = selected;
                int no = 0;
                bool selectedFlag = false;
                foreach (var l in list)
                {
                    int row = ValueChoiceGrid.Rows.Add("[" + string.Format("{0:000}", no) + "]", l.ToString());
                    ValueChoiceGrid.Rows[row].Tag = l;
                    if (l.Equals(selected))
                    {
                        ValueChoiceGrid.CurrentCell = ValueChoiceGrid.Rows[row].Cells[1];
                        selectedFlag = true;
                    }
                    no++;
                }
                if (!selectedFlag && ValueChoiceGrid.Rows.Count > 0)
                {
                    ValueChoiceGrid.CurrentCell = ValueChoiceGrid.Rows[0].Cells[1];
                }
                ValueChoiceGrid_SizeChanged(null, null);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="list"></param>
        /// <param name="selected"></param>
        public void InitNodeChoice<T>(string title, List<T> list, List<object> allList, T selected )
        {
            try
            {
                ValueTypeLbl.Text = title;
                ValueChoiceGrid.Rows.Clear();
                ValueChoiceGrid.Tag = selected;
                int no = -1;
                bool selectedFlag = false;
                foreach (var l in list)
                {
                    for(int i = 0; i < allList.Count; i++)
                    {
                        if (allList[i].Equals(l))
                        {
                            no = i + 2;
                            break;
                        }
                    }
                    int row = ValueChoiceGrid.Rows.Add("[" + string.Format("{0:000}", no) + "]", l.ToString());
                    ValueChoiceGrid.Rows[row].Tag = l;
                    if (l.Equals(selected))
                    {
                        ValueChoiceGrid.CurrentCell = ValueChoiceGrid.Rows[row].Cells[1];
                        selectedFlag = true;
                    }
                    no++;
                }
                if (!selectedFlag && ValueChoiceGrid.Rows.Count > 0)
                {
                    ValueChoiceGrid.CurrentCell = ValueChoiceGrid.Rows[0].Cells[1];
                }
                ValueChoiceGrid_SizeChanged(null, null);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 選択されたアイテムを取得する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSelected<T>()
        {
            try
            {
                if (SetSelected)
                {
                    return (T)ValueChoiceGrid.SelectedRows[0].Tag;
                }
                return (T)ValueChoiceGrid.Tag;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ValueListBoxのDoubleClickｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueListBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SetSelected = true;
                this.Close();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ValueChoiceGridのサイズ変更ｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChoiceGrid_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //ノード項目のカラム幅を調整する
                ValueChoiceGrid.Columns[1].Width = ValueChoiceGrid.Width - ValueChoiceGrid.Columns[0].Width - ValueChoiceGrid.VScrollBar.Width;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// CellContentのDoubleClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChoiceGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    SetSelected = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ﾀﾞﾌﾞﾙｸﾘｯｸｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChoiceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ValueChoiceGrid_CellContentDoubleClick(sender, e);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ValueChoiceGridのKeyDownｲﾍﾞﾝﾄ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChoiceGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Enterで確定する
                if(e.KeyData == Keys.Enter)
                {
                    e.Handled = true;
                    if (ValueChoiceGrid.SelectedRows[0].Index >= 0)
                    {
                        SetSelected = true;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
