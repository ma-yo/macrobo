using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Controls
{
    /// <summary>
    /// Author : M.Yoshida
    /// 日付コントロール
    /// </summary>
    public partial class DateControl : UserControl
    { 
        /// <summary>
        /// 週を保持
        /// </summary>
        public DayOfWeek Week { get; set; }
        
        /// <summary>
        /// 日付数値を保持
        /// </summary>
        private int _day = 0;
        public int Day { get { return _day; } set { _day = value; SetDateString(); } }

        /// <summary>
        /// OnOff値を保持
        /// </summary>
        private bool _value = false;
        public bool Value { get { return _value; } set { _value = value; SetValue(); } }

        /// <summary>
        /// OnOff値をセットする
        /// </summary>
        private void SetValue()
        {
            try
            {
                OnOffButton.Text = _value ? "◎" : "×";
                if (_value)
                {
                    OnOffButton.ForeColor = Color.Blue;
                }
                else
                {
                    OnOffButton.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 日付文字列をセットする
        /// </summary>
        private void SetDateString()
        {
            try
            {
                DayLbl.Text = "" + _day;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DateControl()
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
        /// OnOffボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                Value = !Value;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
