using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;
using SqlSugar;

namespace MTHCollection.Models
{
    [SugarTable(TableName ="报警溯源表")]
    public class AlarmModel:BaseTableModel
    {
        [SugarColumn(ColumnName ="报警时间")]
        [ExcelColumn(Name ="报警时间")]
        public DateTime AlarmTime { get; set; }//报警时间


        [SugarColumn(ColumnName ="报警类型")]
        [ExcelColumn(Name ="报警类型")]
        public string AlarmType { get; set; }//报警类型


        [SugarColumn(ColumnName ="报警内容")]
        [ExcelColumn(Name ="报警内容")]
        public string AlarmContent { get; set; }//报警内容


       
        [SugarColumn(ColumnName ="操作员")]
        [ExcelColumn(Name ="操作员")]
        public string UserName { get; set; }//报警操作员



        [SugarColumn(ColumnName ="报警变量")]
        [ExcelColumn(Name ="变量")]
        public string VaribleName { get; set; }//报警变量名

        
    }
}
