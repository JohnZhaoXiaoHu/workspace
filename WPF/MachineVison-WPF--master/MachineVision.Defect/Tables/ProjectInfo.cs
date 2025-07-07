using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Tables
{
    [Table(Name ="T_Projects")]
    public class ProjectInfo:BaseTable
    {
        public string Name { get; set; }

        /// <summary>
        /// 参考点信息
        /// </summary>
        public string ReferPointInfo { get; set; } 
    }
}
