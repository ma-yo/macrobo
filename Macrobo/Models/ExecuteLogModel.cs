using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Models
{
    /// <summary>
    /// Author : M.Yoshida
    /// ExecuteLogデータ
    /// </summary>
    public class ExecuteLogModel
    {
        public string Id { get; set; }
        public string Cdate { get; set; }
        public string ExecId { get; set; }
        public string ExecType { get; set; }
        public string ExecName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ExecTime { get; set; }
        public string Description { get; set; }
        public int Result { get; set; }
    }
}
