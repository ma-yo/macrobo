using Macrobo.Components;
using Macrobo.Singleton;
using Macrobo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// 設定画面
    /// </summary>
    public partial class SettingForm : BaseForm
    {
        private List<BaseCheckBox> _checkBoxList = new List<BaseCheckBox>();
        /// <summary>
        /// Constructor
        /// </summary>
        public SettingForm()
        {
            try
            {
                InitializeComponent();
                _checkBoxList.Add(Setting1CheckBox);
                _checkBoxList.Add(Setting2CheckBox);
                _checkBoxList.Add(Setting3CheckBox);
                _checkBoxList.Add(Setting4CheckBox);
                _checkBoxList.Add(Setting5CheckBox);

                int i = 0;
                foreach(var check in _checkBoxList)
                {
                    i++;
                    check.CheckedChanged += SettingCheckBox_CheckedChanged;
                    if (SettingInfos.GetInstance().SettingDic[i] == "1")
                    {
                        check.Checked = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 設定変更確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseCheckBox checkBox = (BaseCheckBox)sender;
                if (checkBox.Checked)
                {
                    checkBox.ForeColor = Color.White;
                    checkBox.Text = "ON";
                }
                else
                {
                    checkBox.ForeColor = Color.Black;
                    checkBox.Text = "OFF";
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 設定値を保存して、閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                int i = 0;
                foreach(var check in _checkBoxList)
                {
                    i++;
                    SettingInfos.GetInstance().CreateSettingValue(i, check.Checked ? "1" : "0");
                }
                SettingInfos.GetInstance().Update();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
