using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models
{
    /// <summary>
    /// 変数モデル
    /// Author : M.Yoshida
    /// </summary>
    [Serializable]
    public class VariableModel
    {
        /// <summary>
        /// 変数の値
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public VariableModel()
        {
            Value = "";
            Description = "";
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="description"></param>
        public VariableModel(string value, string description)
        {
            this.Value = value;
            this.Description = description;
        }
    }
}
