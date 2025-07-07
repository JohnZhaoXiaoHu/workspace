using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;
using SqlSugar;

namespace MTHCollection.Models
{
    public class BaseTableModel
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        [ExcelIgnore(excelIgnore:true)]
        public int Id { get; set; }
    }
}
