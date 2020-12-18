using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Macrobo.Models.Enums;
using Macrobo.Utils;

namespace Macrobo.Models
{
    /// <summary>
    /// Author : M.Yoshida
    /// プロジェクトデータ
    /// </summary>
    [Serializable]
    public class ProjectModel
    {
        /// <summary>
        /// 一意のID
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// プロジェクトの説明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 処理データ
        /// </summary>
        public List<ProcessModel> ProcessModelList { get; set; }
        /// <summary>
        /// マクロ処理データ
        /// </summary>
        public List<ProjectModel> MacroModelList { get; set; }
        /// <summary>
        /// マウススピード
        /// </summary>
        public int MouseSpeed { get; set; }
        /// <summary>
        /// 変数リスト
        /// </summary>
        public Dictionary<string, VariableModel> VariableList { get; set; }
        /// <summary>
        /// 変数配列リスト
        /// </summary>
        public Dictionary<string, ArrayVariableModel> ArrayVariableList { get; set; }
        /// <summary>
        /// データタイプ
        /// </summary>
        public ExecDataType ExecDataType { get; set; }
        /// <summary>
        /// ツリーの並び順リスト
        /// </summary>
        public List<string> NodeIdList { get; set; }
        /// <summary>
        /// ログ表示可否
        /// </summary>
        public ViewLogType ViewLogType { get; set; }
        /// <summary>
        /// 実行カレンダーのIDを保持
        /// </summary>
        public int ExecCalendarId { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectModel()
        {
            NodeIdList = new List<string>();
            ProjectId = NewId();
            ExecDataType = ExecDataType.PROJECT;
            ProcessModelList = new List<ProcessModel>();
            MacroModelList = new List<ProjectModel>();
            MouseSpeed = 1;
            VariableList = new Dictionary<string, VariableModel>();
            VariableList.Add(StringValue.VARIABLE_VAR0, new VariableModel());
            ArrayVariableList = new Dictionary<string, ArrayVariableModel>();
            ArrayVariableList.Add(StringValue.VARIABLE_ARY_VAR0, new ArrayVariableModel());
        }
        /// <summary>
        /// ツリーノードを作成する
        /// </summary>
        /// <returns></returns>
        internal TreeNode CreateTreeNode()
        {
            try
            {
                TreeNode root = new TreeNode(Name);
                root.Tag = this;
                root.ImageIndex = 0;
                CreateChildNode(root);
                return root;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 新規ﾌﾟﾛｾｽIDを取得する
        /// </summary>
        /// <returns></returns>
        public static string NewId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }
        /// <summary>
        /// ツリーノードを再帰的に作成する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="procList"></param>
        public void CreateChildNode(TreeNode node)
        {
            try
            {
                for(int i = 0; i < NodeIdList.Count; i++)
                {
                    string id = NodeIdList[i];
                    ProcessModel procModel = ProcessModelList.FirstOrDefault(a => a.ProcessId == id);
                    if (procModel != null)
                    {
                        TreeNode newNode = new TreeNode(procModel.Name);
                        newNode.Tag = procModel;
                        newNode.ImageIndex = GetImageIndex(procModel.ProcessType);
                        newNode.SelectedImageIndex = newNode.ImageIndex;
                        node.Nodes.Add(newNode);
                        continue;
                    }
                    ProjectModel projModel = MacroModelList.FirstOrDefault(a => a.ProjectId == id);
                    if (projModel != null)
                    {
                        TreeNode newNode = new TreeNode(projModel.Name);
                        newNode.Tag = projModel;
                        newNode.ImageIndex = 1;
                        newNode.SelectedImageIndex = 1;
                        node.Nodes.Add(newNode);
                        projModel.CreateChildNode(newNode);
                        continue;
                    }
                    //該当しない場合は削除する
                    NodeIdList.RemoveAt(i);
                    i--;
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ノードイメージのIndex番号を取得する
        /// </summary>
        /// <param name="processType"></param>
        /// <returns></returns>
        public static int GetImageIndex(ProcessType processType)
        {
            try
            {
                switch (processType)
                {
                    case ProcessType.None:
                    case ProcessType.検出:
                        return 2;
                    case ProcessType.キーボード入力:
                        return 3;
                    case ProcessType.マウス入力:
                        return 4;
                    case ProcessType.待機:
                        return 5;
                    case ProcessType.メール送信:
                        return 6;
                    case ProcessType.アプリ実行:
                        return 7;
                    case ProcessType.変数:
                        return 8;
                    case ProcessType.ファイルフォルダー処理:
                        return 9;
                    case ProcessType.ダイアログ:
                        return 10;
                    case ProcessType.Excel:
                        return 11;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// プロセスモデルを1次元にて取得する
        /// </summary>
        /// <returns></returns>
        public List<ProcessModel> GetOneDimensionProcessModelList()
        {
            try
            {
                List<ProcessModel> list = new List<ProcessModel>();
                foreach (var id in NodeIdList)
                {
                    var proc = ProcessModelList.FirstOrDefault(a => a.ProcessId == id);
                    if (proc != null)
                    {
                        list.Add(proc);
                    }
                    else
                    {
                        var macro = MacroModelList.FirstOrDefault(a => a.ProjectId == id);
                        if (macro != null)
                        {
                            foreach (var macroId in macro.NodeIdList)
                            {
                                var proc2 = macro.ProcessModelList.FirstOrDefault(a => a.ProcessId == macroId);
                                if (proc2 != null)
                                {
                                    list.Add(proc2);
                                }
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノード、モジュールを1次元にて取得する
        /// </summary>
        /// <returns></returns>
        public List<object> GetOneDimensionListAll()
        {
            try
            {
                List<object> list = new List<object>();
                foreach (var id in NodeIdList)
                {
                    var proc = ProcessModelList.FirstOrDefault(a => a.ProcessId == id);
                    if (proc != null)
                    {
                        list.Add(proc);
                    }
                    else
                    {
                        var macro = MacroModelList.FirstOrDefault(a => a.ProjectId == id);
                        if (macro != null)
                        {
                            list.Add(macro);
                            foreach (var macroId in macro.NodeIdList)
                            {
                                var proc2 = macro.ProcessModelList.FirstOrDefault(a => a.ProcessId == macroId);
                                if (proc2 != null)
                                {
                                    list.Add(proc2);
                                }
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// マクロモデルを削除する
        /// </summary>
        /// <param name="macroModelList"></param>
        /// <param name="macroModel"></param>
        internal void RemoveMacroModel(List<ProjectModel> macroModelList, ProjectModel macroModel)
        {
            try
            {
                for (int i = 0; i < macroModelList.Count; i++)
                {
                    if (macroModelList[i].Equals(macroModel))
                    {
                        //ノードIDリストのIDも削除する
                        NodeIdList.Remove(macroModelList[i].ProjectId);
                        macroModelList.RemoveAt(i);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// モデルを削除する
        /// </summary>
        /// <param name="procModel"></param>
        internal void RemoveModel(List<ProcessModel> modelList, ProcessModel procModel)
        {
            try
            {
                for(int i = 0; i < modelList.Count; i++)
                {
                    if (modelList[i].Equals(procModel))
                    {
                        //ノードIDリストのIDも削除する
                        NodeIdList.Remove(modelList[i].ProcessId);
                        modelList.RemoveAt(i);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// 処理が正常に登録されているかの判定を行う
        /// </summary>
        /// <returns></returns>
        internal List<string> CheckMacroInput()
        {
            try
            {
                List<string> errorList = new List<string>();
                if(ProcessModelList.Count == 0 && MacroModelList.Count == 0)
                {
                    errorList.Add(this.Name + " : 処理は１つも登録されていません。");
                }
                CheckProcessInput(errorList, ProcessModelList);
                foreach(var macro in MacroModelList)
                {
                    if (macro.ProcessModelList.Count == 0)
                    {
                        errorList.Add(macro.Name + " : 処理は１つも登録されていません。");
                    }
                    CheckProcessInput(errorList, macro.ProcessModelList);
                }
                
                return errorList;
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 実行前の入力チェックを行う
        /// </summary>
        /// <param name="errorList"></param>
        /// <param name="processModelList"></param>
        private void CheckProcessInput(List<string> errorList, List<ProcessModel> processModelList)
        {
            try
            {
                foreach (ProcessModel model in processModelList)
                {
                    switch (model.ProcessType)
                    {
                        case ProcessType.検出:
                            switch (model.DetectType)
                            {
                                case DetectType.画像:
                                    bool isExists = false;
                                    foreach (var c in model.CaptureImage)
                                    {
                                        if (c.Value != null)
                                        {
                                            isExists = true;
                                            break;
                                        }
                                    }
                                    if (!isExists)
                                    {
                                        errorList.Add(model.Name + " : 検出画像が登録されていません。");
                                    }
                                    if(model.DetectAreaType == DetectAreaType.CHOICE)
                                    {
                                        if(!int.TryParse(model.DetectAreaSX, out int sx)
                                            || !int.TryParse(model.DetectAreaSY, out int sy)
                                            || !int.TryParse(model.DetectAreaEX, out int ex)
                                            || !int.TryParse(model.DetectAreaEY, out int ey))
                                        {
                                            errorList.Add(model.Name + " : 画像検出範囲が入力されていないか不正です。");
                                        }
                                        else
                                        {
                                            if (sx >= ex || sy >= ey)
                                            {
                                                errorList.Add(model.Name + " : 画像検出範囲が正しくありません。");
                                            }
                                        }

                                    }
                                    break;
                                case DetectType.ファイル:
                                    if (string.IsNullOrEmpty(model.DetectFolderPath))
                                    {
                                        errorList.Add(model.Name + " : 検出ディレクトリが登録されていません。");
                                    }
                                    if (string.IsNullOrEmpty(model.DetectFileName))
                                    {
                                        errorList.Add(model.Name + " : 検出ファイル名が登録されていません。");
                                    }
                                    break;
                            }

                            break;
                        case ProcessType.キーボード入力:
                            if (string.IsNullOrEmpty(model.KeyboardInput))
                            {
                                errorList.Add(model.Name + " : キーボード入力が登録されていません。");
                            }
                            break;
                        case ProcessType.マウス入力:
                            switch (model.MouseExecType)
                            {
                                case MouseInputType.クリック:
                                    if (model.MouseClickDetectType == MouseInputDetectType.画像検出)
                                    {
                                        bool isExists = false;
                                        foreach(var c in model.CaptureImage)
                                        {
                                            if(c.Value != null)
                                            {
                                                isExists = true;
                                                break;
                                            }
                                        }
                                        if (!isExists)
                                        {
                                            errorList.Add(model.Name + " : クリック先画像が登録されていません。");
                                        }
                                        if(model.DetectAreaType == DetectAreaType.CHOICE)
                                        {
                                            if (!int.TryParse(model.DetectAreaSX, out int sx)
                                            || !int.TryParse(model.DetectAreaSY, out int sy)
                                            || !int.TryParse(model.DetectAreaEX, out int ex)
                                            || !int.TryParse(model.DetectAreaEY, out int ey))
                                            {
                                                errorList.Add(model.Name + " : 画像検出範囲が入力されていないか不正です。");
                                            }
                                            else
                                            {
                                                if (sx >= ex || sy >= ey)
                                                {
                                                    errorList.Add(model.Name + " : 画像検出範囲が正しくありません。");
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case MouseInputType.移動:
                                    if (model.MouseClickDetectType == MouseInputDetectType.画像検出)
                                    {
                                        if (model.CaptureImage[0] == null)
                                        {
                                            errorList.Add(model.Name + " : クリック先画像が登録されていません。");
                                        }
                                    }
                                    break;
                                case MouseInputType.ドラッグドロップ:
                                    if (model.MouseClickDetectType == MouseInputDetectType.画像検出)
                                    {
                                        if (model.CaptureImage[0] == null)
                                        {
                                            errorList.Add(model.Name + " : クリック先画像が登録されていません。");
                                        }
                                        if (model.CaptureImage[1] == null)
                                        {
                                            errorList.Add(model.Name + " : ドラッグ先画像が登録されていません。");
                                        }
                                    }
                                    if (model.MouseClickDetectType == MouseInputDetectType.座標検出)
                                    {
                                        if (model.CaptureImage[0] == null)
                                        {
                                            errorList.Add(model.Name + " : ドラッグ元画像が登録されていません。");
                                        }
                                    }
                                    break;
                            }
                            break;
                        case ProcessType.メール送信:
                            if (string.IsNullOrEmpty(model.Mail_SenderName))
                            {
                                errorList.Add(model.Name + " : 送信元名が入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_SenderAddress))
                            {
                                errorList.Add(model.Name + " : 送信元アドレスが入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_ReceiverName))
                            {
                                errorList.Add(model.Name + " : 送信先名が入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_ReceiverAddress))
                            {
                                errorList.Add(model.Name + " : 送信先アドレスが入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_Title))
                            {
                                errorList.Add(model.Name + " : メールタイトルが入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_Text))
                            {
                                errorList.Add(model.Name + " : メール本文が入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_Host))
                            {
                                errorList.Add(model.Name + " : 送信メールサーバーが入力されていません。");
                            }
                            if (string.IsNullOrEmpty(model.Mail_Port))
                            {
                                errorList.Add(model.Name + " : サーバーポートが入力されていません。");
                            }
                            break;
                        case ProcessType.待機:
                            break;
                        case ProcessType.アプリ実行:
                            if (string.IsNullOrEmpty(model.AppExecutePath))
                            {
                                errorList.Add(model.Name + " : 実行パスが入力されていません。");
                            }
                            break;
                        case ProcessType.変数:
                            switch (model.VariableExecType)
                            {
                                case VariableExecType.ファイル入力:
                                    if (string.IsNullOrEmpty(model.VariableInoutFilePath))
                                    {
                                        errorList.Add(model.Name + " : 入力元ファイルパスが指定されていません。");
                                    }
                                    break;
                                case VariableExecType.ファイル出力:
                                    if (string.IsNullOrEmpty(model.VariableInoutFilePath))
                                    {
                                        errorList.Add(model.Name + " : 出力先ファイルパスが指定されていません。");
                                    }
                                    break;
                                case VariableExecType.キーボード入力:

                                    break;
                            }
                            break;
                        case ProcessType.ファイルフォルダー処理:
                            switch (model.FileFolderExecType)
                            {
                                case FileFolderExecType.Create:
                                case FileFolderExecType.Detect:
                                case FileFolderExecType.Remove:
                                case FileFolderExecType.SaveUdate:
                                    if (string.IsNullOrEmpty(model.FileFolderPath1))
                                    {
                                        errorList.Add(model.Name + " : ファイル又はフォルダが指定されていません。");
                                    }
                                    break;
                                case FileFolderExecType.Move:
                                case FileFolderExecType.Copy:
                                    if (string.IsNullOrEmpty(model.FileFolderPath1))
                                    {
                                        errorList.Add(model.Name + " : 移動元ファイル又はフォルダが指定されていません。");
                                    }
                                    if (string.IsNullOrEmpty(model.FileFolderPath2))
                                    {
                                        errorList.Add(model.Name + " : 移動先ファイル又はフォルダが指定されていません。");
                                    }
                                    break;
                            }
                            break;
                        case ProcessType.ダイアログ:
                            if (string.IsNullOrEmpty(model.DialogText))
                            {
                                errorList.Add(model.Name + " : ダイアログメッセージが入力されていません。");
                            }
                            break;
                        case ProcessType.Excel:
                            {
                                if (string.IsNullOrEmpty(model.FileFolderPath2))
                                {
                                    errorList.Add(model.Name + " : 出力先パスが指定されていません。");
                                }
                                switch (model.ExcelSourceType)
                                {
                                    case ExcelSourceType.既存ファイル:
                                        if (string.IsNullOrEmpty(model.FileFolderPath1))
                                        {
                                            errorList.Add(model.Name + " : 読込元パスが指定されていません。");
                                        }
                                        if (Path.GetExtension(model.FileFolderPath1).ToUpper() != Path.GetExtension(model.FileFolderPath2).ToUpper())
                                        {
                                            errorList.Add(model.Name + " : 異なるバージョン間のブック同士のやり取りは出来ません。xls ≠ xlsx");
                                        }
                                        break;
                                }
                                if (model.ExcelJobList.Count == 0)
                                {
                                    errorList.Add(model.Name + " : Excelジョブが入力されていません。");
                                }
                            }
                            break;
                        default:
                            errorList.Add(model.Name + " : 処理タイプが選択されていません。");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// 全てのIDを振りなおす
        /// </summary>
        internal void RenewId()
        {
            try
            {
                this.ProjectId = NewId();
                Dictionary<string, string> idDic = new Dictionary<string, string>();
                foreach (var process in ProcessModelList)
                {
                    string newID = ProjectModel.NewId();
                    idDic.Add(process.ProcessId, newID);
                    process.ProcessId = newID;
                }
                foreach (var macro in MacroModelList)
                {
                    string newID = ProjectModel.NewId();
                    idDic.Add(macro.ProjectId, newID);
                    macro.ProjectId = newID;
                    foreach (var process in macro.ProcessModelList)
                    {
                        newID = ProjectModel.NewId();
                        idDic.Add(process.ProcessId, newID);
                        process.ProcessId = newID;
                    }
                }
                foreach (var process in ProcessModelList)
                {
                    if (process.NextProcess != null)
                    {
                        if (idDic.ContainsKey(process.NextProcess.ProcessId))
                        {
                            process.NextProcess.ProcessId = idDic[process.NextProcess.ProcessId];
                        }
                    }
                    if (process.ErrorProcess != null)
                    {
                        if (idDic.ContainsKey(process.ErrorProcess.ProcessId))
                        {
                            process.ErrorProcess.ProcessId = idDic[process.ErrorProcess.ProcessId];
                        }
                    }
                }
                for (int i = 0; i < NodeIdList.Count; i++)
                {
                    if (idDic.ContainsKey(NodeIdList[i]))
                    {
                        NodeIdList[i] = idDic[NodeIdList[i]];
                    }
                }

                for (int x = 0; x < MacroModelList.Count; x++)
                {
                    var macro = MacroModelList[x];
                    foreach (var process in macro.ProcessModelList)
                    {
                        if (process.NextProcess != null)
                        {
                            if (idDic.ContainsKey(process.NextProcess.ProcessId))
                            {
                                process.NextProcess.ProcessId = idDic[process.NextProcess.ProcessId];
                            }
                        }
                        if (process.ErrorProcess != null)
                        {
                            if (idDic.ContainsKey(process.ErrorProcess.ProcessId))
                            {
                                process.ErrorProcess.ProcessId = idDic[process.ErrorProcess.ProcessId];
                            }
                        }
                    }
                    for (int i = 0; i < macro.NodeIdList.Count; i++)
                    {
                        if (idDic.ContainsKey(macro.NodeIdList[i]))
                        {
                            macro.NodeIdList[i] = idDic[macro.NodeIdList[i]];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        /// <summary>
        /// ノードのIDをセットする
        /// </summary>
        /// <param name="addId"></param>
        /// <param name="id"></param>
        internal void SetNodeId(string addId, string id)
        {
            try
            {
                for(int i = 0; i < NodeIdList.Count; i++)
                {
                    if(NodeIdList[i] == id)
                    {
                        NodeIdList.Insert(i + 1, addId);
                        return;
                    }
                }
                NodeIdList.Insert(0, addId);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// ビットマップのコピーを取得する
        /// </summary>
        /// <param name="addImageList">追加のImageListがある場合セットする</param>
        /// <returns></returns>
        public List<Bitmap> GetBitmapAllCopy(List<Bitmap> addImageList)
        {
            List<Bitmap> list = new List<Bitmap>();
            foreach (var proc in GetOneDimensionProcessModelList())
            {
                foreach(var img in proc.CaptureImage)
                {
                    Bitmap bmp = img.Value;
                    if (bmp == null) continue;
                    bool exists = false;
                    foreach(var listbmp in list)
                    {
                        if(ImageUtil.CompareImage(bmp, listbmp))
                        {
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        list.Add((Bitmap)bmp.DeepCopy());
                    }
                }
            }
            if(addImageList!=null && addImageList.Count > 0)
            {
                foreach (var img in addImageList)
                {
                    Bitmap bmp = img;
                    if (bmp == null) continue;
                    bool exists = false;
                    foreach (var listbmp in list)
                    {
                        if (ImageUtil.CompareImage(bmp, listbmp))
                        {
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        list.Add((Bitmap)bmp.DeepCopy());
                    }
                }
            }

            return list;
        }

    }
}
