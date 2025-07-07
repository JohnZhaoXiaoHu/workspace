using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MTHCollection.Models
{
    [SugarTable(TableName ="用户表")]
    public class UserModel:BaseTableModel
    {
        [SugarColumn(ColumnName ="用户名")]
        public string UserName { get; set; }


        [SugarColumn(ColumnName ="密码")]
        public string Password { get; set; }


        [SugarColumn(ColumnName = "参数设置权限")]
        public string ParamSetPermission { get; set; }

        [SugarColumn(ColumnName = "配方管理权限")]
        public string RecipePermission { get; set; }


        [SugarColumn(ColumnName = "报警追溯权限")]
        public string AlarmTracingPermission { get; set; }


        [SugarColumn(ColumnName = "历史趋势权限")]
        public string HistoryTendPermission { get; set; }

        [SugarColumn(ColumnName = "用户管理权限")]
        public string UserManagerPermission { get; set; }
    }
}
