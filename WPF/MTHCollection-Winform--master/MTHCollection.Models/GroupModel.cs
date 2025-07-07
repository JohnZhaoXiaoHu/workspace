using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace MTHCollection.Models
{
    public class GroupModel
    {
        [ExcelColumnName("通信组名称")]
        public string GroupName { get; set; }

        [ExcelColumnName("起始地址")]
        public int StartAddress { get; set; }

        [ExcelColumnName("长度")]
        public int Length { get; set; }


        [ExcelColumnName("存储区名称")]
        public string SaveAreaName { get; set; }

        [ExcelColumnName("备注")]
        public string Remark { get; set; }


        [ExcelIgnore(excelIgnore: true)]
        public List<VaribleModel> VaribleList { get; set; } = null;
    }
}
