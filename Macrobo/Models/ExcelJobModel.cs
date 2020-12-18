using Macrobo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models
{
    /// <summary>
    /// Author : M.Yoshida
    /// Excelジョブモデル
    /// </summary>
    [Serializable]
    public class ExcelJobModel
    {
        /// <summary>
        /// ファイル読み書きモード
        /// </summary>
        public FileReadWriteType FileReadWriteType { get; set; }
        /// <summary>
        /// シート名
        /// </summary>
        public string SheetName { get; set; }
        /// <summary>
        /// セル名称
        /// </summary>
        public string CellName { get; set; }
        /// <summary>
        /// 値
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rwType"></param>
        /// <param name="sheetName"></param>
        /// <param name="cellName"></param>
        /// <param name="value"></param>
        public ExcelJobModel(FileReadWriteType rwType, string sheetName, string cellName, string value)
        {
            FileReadWriteType = rwType;
            SheetName = sheetName;
            CellName = cellName;
            Value = value;
        }
    }
}
