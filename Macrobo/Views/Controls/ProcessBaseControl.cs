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
using Macrobo.Models.Enums;
using Macrobo.Models;
using Macrobo.Views.Forms;

namespace Macrobo.Views
{
    /// <summary>
    /// Author : M.Yoshida
    /// プロセスベースコントロール
    /// </summary>
    public partial class ProcessBaseControl : BaseUserControl
    { 
        /// <summary>
        /// ルートプロジェクトモデルの参照を保持する
        /// </summary>
        protected ProjectModel RootProjectModel { get; set; }
        /// <summary>
        /// プロジェクトモデル
        /// </summary>
        protected ProjectModel CurrentProjectModel { get; set; }
        /// <summary>
        /// マクロデータ
        /// </summary>
        protected ProcessModel ProcessModel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public delegate void DeactivateEvent();
        public DeactivateEvent OnDeactivate;

        /// <summary>
        /// キーボードフックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="result"></param>
        public delegate void KeyboardHookEvent(object sender, Macrobo.Utils.Gui.KeyboardHookedEventArgs e, out bool result);
        /// <summary>
        /// キーボードフックイベントハンドラー
        /// </summary>
        public KeyboardHookEvent OnKeyboardHook;
        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessBaseControl()
        {
            InitializeComponent();
            ValidRadio.Checked = true;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="rootProjectModel"></param>
        /// <param name="projectModel"></param>
        /// <param name="procModel"></param>
        public virtual void Init(ProjectModel rootProjectModel, ProjectModel projectModel, ProcessModel procModel)
        {
            try
            {
                this.RootProjectModel = rootProjectModel;
                this.CurrentProjectModel = projectModel;
                this.ProcessModel = procModel;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 基本となる値をセットする
        /// </summary>
        /// <param name="procModel"></param>
        public void SetBaseValues(ProcessModel procModel)
        {
            try
            {
                BeforeWaitTimeUpDown.Value = procModel.BeforeWaitMilliTime;
                AfterWaitTimeUpDown.Value = procModel.AfterWaitMilliTime;
                switch (procModel.ValidType)
                {
                    case ValidType.有効:
                        ValidRadio.Checked = true;
                        break;
                    case ValidType.無効:
                        InValidRadio.Checked = true;
                        break;
                }
                CompButton.Tag = GetProcessModel(procModel.NextProcess, ProcessModel.GetEndProcessModel());
                ErrorButton.Tag = GetProcessModel(procModel.ErrorProcess, ProcessModel.GetErrorProcessModel());
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロセスモデルを取得する
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private object GetProcessModel(ProcessModel proc, ProcessModel defaultValue)
        {
            try
            {
                ProcessModel model = RootProjectModel.GetOneDimensionProcessModelList().FirstOrDefault(a => a.Equals(proc));
                return model != null ? proc : defaultValue;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// 基本となる値を取得する
        /// </summary>
        /// <param name="procModel"></param>
        public void GetBaseValues(ProcessModel procModel)
        {
            try
            {
                procModel.ValidType = ValidRadio.Checked ? ValidType.有効 : ValidType.無効;
                procModel.BeforeWaitMilliTime = (int)BeforeWaitTimeUpDown.Value;
                procModel.AfterWaitMilliTime = (int)AfterWaitTimeUpDown.Value;
                procModel.NextProcess = (ProcessModel)CompButton.Tag;
                procModel.ErrorProcess = (ProcessModel)ErrorButton.Tag;

            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 成功時、失敗時移動先の設定を行う
        /// </summary>
        /// <param name="button"></param>
        private void SetCompErrorButtonValue(BaseButton button)
        {
            try
            {
                ValueChoiceForm form = new ValueChoiceForm();
                ProcessModel endModel = ProcessModel.GetEndProcessModel();
                ProcessModel errorModel = ProcessModel.GetErrorProcessModel();
                List<ProcessModel> modelList = RootProjectModel.GetOneDimensionProcessModelList();
                List<object> allList = RootProjectModel.GetOneDimensionListAll();
                //modelList.Remove(ProcessModel);
                modelList.Insert(0, endModel);
                modelList.Insert(0, errorModel);
                string title = CompButtonTitleLbl.Text;
                if (button.Equals(ErrorButton))
                {
                    title = ErrorButtonTitleLbl.Text;
                }
                form.InitNodeChoice(title, modelList, allList, (ProcessModel)button.Tag);
                form.ShowDialog(this);
                button.Tag = form.GetSelected<ProcessModel>() ?? endModel;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 成功時移動先を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetCompErrorButtonValue(CompButton);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 失敗時移動先を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetCompErrorButtonValue(ErrorButton);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
