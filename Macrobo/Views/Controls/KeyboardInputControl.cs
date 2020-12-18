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
using Macrobo.Utils;
using Macrobo.Models;
using Macrobo.Views.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// キーボード入力コントロール
    /// </summary>
    public partial class KeyboardInputControl : ProcessBaseControl
    {
        /// <summary>
        /// 入力KeyCodeを保持する
        /// </summary>
        List<Keys> inputList = new List<Keys>();
        /// <summary>
        /// 
        /// </summary>
        List<Keys> inputDownList = new List<Keys>();

        /// <summary>
        /// Constructor
        /// </summary>
        public KeyboardInputControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();
                KeyboardInputRadio.Checked = true;

                OnDeactivate = ParentForm_OnDeactivate;
                this.OnKeyboardHook = KeyboardHook_KeyboardHooked;
                this.Disposed += (sender, args) =>
                {
                    this.OnKeyboardHook = null;
                };
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 親フォームのDeactivateｲﾍﾞﾝﾄ
        /// </summary>
        private void ParentForm_OnDeactivate()
        {
            try
            {
                inputDownList.Clear();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="rootProjectModel"></param>
        /// <param name="projModel"></param>
        /// <param name="procModel"></param>
        public override void Init(ProjectModel rootProjectModel, ProjectModel projModel, ProcessModel procModel)
        {
            try
            {
                this.RootProjectModel = rootProjectModel;
                this.CurrentProjectModel = projModel;
                this.ProcessModel = procModel;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }

        }

        /// <summary>
        /// ボタンイベントを作成する
        /// </summary>
        private void AddButtonEvent()
        {
            try
            {
                CompButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                CompButton.Tag = ProcessModel.GetEndProcessModel();
                VariableButton.OnTagChanged = (BaseButton sender, object obj) => {
                    if (obj != null)
                    {
                        sender.Text = obj.ToString();
                    }
                };
                VariableButton.Tag = StringValue.VARIABLE_未設定;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// KeyboardInputRadioの選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardInputRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!KeyboardInputRadio.Checked) return;
                StringInputTextBox.ReadOnly = true;
                AlertLbl.Visible = true;
                AlertLbl.BorderStyle = BorderStyle.None;
                AlertLbl.BackColor = Color.White;
                StringInputTextBox.Text = "";
                StringInputTextBox.Tag = null;
                VariableTitleLbl.Visible = false;
                VariableButton.Visible = false;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// StringInputRadioの選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StringInputRadio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!StringInputRadio.Checked) return;
                StringInputTextBox.ReadOnly = false;
                AlertLbl.Visible = false;
                StringInputTextBox.Text = "";
                StringInputTextBox.Tag = null;
                VariableTitleLbl.Visible = true;
                VariableButton.Visible = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// キーボード入力をフックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardHook_KeyboardHooked(object sender, Macrobo.Utils.Gui.KeyboardHookedEventArgs e, out bool result)
        {
            try
            {
                result = false;
                if (!StringInputTextBox.Focused) return;
                if (!KeyboardInputRadio.Checked) return;
                if (inputDownList.Count == 0)
                {
                    inputList.Clear();
                }
                if (e.UpDown == Macrobo.Utils.Gui.KeyboardUpDown.Down)
                {
                    if (!inputList.Contains(e.KeyCode))
                    {
                        inputList.Add(e.KeyCode);
                    }
                    if (!inputDownList.Contains(e.KeyCode))
                    {
                        inputDownList.Add(e.KeyCode);
                    }
                }
                else
                {
                    if (inputDownList.Contains(e.KeyCode))
                    {
                        inputDownList.Remove(e.KeyCode);
                    }
                }

                StringInputTextBox.Text = "";
                foreach (var key in inputList)
                {
                    if (string.IsNullOrEmpty(StringInputTextBox.Text))
                    {
                        StringInputTextBox.Text = key.ToString();
                    }
                    else
                    {
                        StringInputTextBox.Text += " , " + key.ToString();
                    }
                }
                StringInputTextBox.Tag = inputList.DeepCopy();
                result = true;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 変数を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariableButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                List<string> keyList = new List<string>();
                keyList.Add(StringValue.VARIABLE_未設定);
                foreach (var variable in CurrentProjectModel.VariableList)
                {
                    keyList.Add(variable.Key);
                }
                string title = VariableTitleLbl.Text;
                form.Init(title, keyList, (string)VariableButton.Tag);
                form.ShowDialog(this);
                VariableButton.Tag = form.GetSelected<string>();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
