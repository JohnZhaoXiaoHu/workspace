using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MTHCollection.Models
{
    [SugarTable(TableName ="实时数据表")]
    public class RealTimeDataModel:BaseTableModel
    {
        [SugarColumn(ColumnName ="插入时间")]
        public DateTime InsertTime { get; set; }

        [SugarColumn(ColumnName ="站点1温度")]
        public float Station1Temp { get; set; }

        [SugarColumn(ColumnName ="站点1湿度")]
        public float Station1Humidity { get; set; }

        [SugarColumn(ColumnName = "站点2温度")]
        public float Station2Temp { get; set; }

        [SugarColumn(ColumnName = "站点2湿度")]
        public float Station2Humidity { get; set; }

        [SugarColumn(ColumnName = "站点3温度")]
        public float Station3Temp { get; set; }

        [SugarColumn(ColumnName = "站点3湿度")]
        public float Station3Humidity { get; set; }

        [SugarColumn(ColumnName = "站点4温度")]
        public float Station4Temp { get; set; }

        [SugarColumn(ColumnName = "站点4湿度")]
        public float Station4Humidity { get; set; }

        [SugarColumn(ColumnName = "站点5温度")]
        public float Station5Temp { get; set; }

        [SugarColumn(ColumnName = "站点5湿度")]
        public float Station5Humidity { get; set; }

        [SugarColumn(ColumnName = "站点6温度")]
        public float Station6Temp { get; set; }

        [SugarColumn(ColumnName = "站点6湿度")]
        public float Station6Humidity { get; set; }

    }
}
