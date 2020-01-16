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
using Macrobo.Views.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// 待機コントロール
    /// </summary>
    public partial class WaitControl : ProcessBaseControl
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public WaitControl()
        {
            try
            {
                InitializeComponent();
                AddButtonEvent();
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
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
