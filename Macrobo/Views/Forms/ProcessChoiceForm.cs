using Macrobo.Components;
using Macrobo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macrobo.Views.Forms
{
    /// <summary>
    /// Author : M.Yoshida
    /// 処理を選択する
    /// </summary>
    public partial class ProcessChoiceForm : BaseForm
    {
        public TreeNode SelectedNode { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessChoiceForm()
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

        public void Init(BaseTreeView treeView, TreeNode nd)
        {

            try
            {
                if(nd.Parent.Parent == null)
                {
                    //通常ノード
                    ProcessChoiceList.Items.Add(new TreeNodeHelper(treeView.Nodes[0]));
                    foreach (TreeNode node in treeView.Nodes[0].Nodes)
                    {
                        ProcessChoiceList.Items.Add(new TreeNodeHelper(node));
                    }
                }
                else
                {
                    //モジュールノード

                    ProcessChoiceList.Items.Add(new TreeNodeHelper(nd.Parent));
                    foreach (TreeNode node in nd.Parent.Nodes)
                    {
                        ProcessChoiceList.Items.Add(new TreeNodeHelper(node));
                    }
                }
                //List<TreeNodeHelper> nodeList = new List<TreeNodeHelper>();
                //CreateOneDimensionNodeList(treeView.Nodes, nodeList);
                //foreach (var node in nodeList)
                //{
                //    ProcessChoiceList.Items.Add(node);
                //}
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }

        private void CreateOneDimensionNodeList(TreeNodeCollection nodeCollection, List<TreeNodeHelper> nodeList)
        {
            try
            {
                foreach (TreeNode node in nodeCollection)
                {
                    nodeList.Add(new TreeNodeHelper(node));
                    foreach(TreeNode childNode in node.Nodes)
                    {
                        nodeList.Add(new TreeNodeHelper(childNode));
                        CreateOneDimensionNodeList(childNode.Nodes, nodeList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
        /// <summary>
        /// TreeNodeヘルパークラス
        /// </summary>
        private class TreeNodeHelper
        {
            /// <summary>
            /// TreeNodeを保持
            /// </summary>
            public TreeNode Node { get; set; }
            /// <summary>
            /// ToStringをOverride
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Node.Text;
            }
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="node"></param>
            public TreeNodeHelper(TreeNode node)
            {
                Node = node;
            }
        }
        /// <summary>
        /// リストからプロセスを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessChoiceList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                SelectedNode = ((TreeNodeHelper)ProcessChoiceList.SelectedItem).Node;
                this.Close();
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
        }
    }
}
