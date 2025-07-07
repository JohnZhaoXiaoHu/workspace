using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;
using MTHCollection.Tools;

namespace MTHCollection.Models
{
    public class VaribleModel
    {
        [ExcelColumnName("变量名称")]
        public string VaribleName { get; set; }


        [ExcelColumnName("通信组名称")]
        public string GroupName { get; set; }

        [ExcelColumnName("变量类型")]
        public string VaribleType { get; set; }


        [ExcelColumnName("起始索引")]
        public int StartIndex { get; set; }

        [ExcelColumnName("线性系数")]
        public float Scale { get; set; }

        [ExcelColumnName("偏移量")]
        public int Offset { get; set; }

        [ExcelColumnName("上升沿报警")]
        public bool IsPosEdgeAlarm { get; set; }

        [ExcelColumnName("下降沿报警")]
        public bool IsFallEdgeAlarm { get; set; }

        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore(excelIgnore:true)]
        public object Value { get; set; }

        [ExcelIgnore(excelIgnore: true)]
        public bool LastAlarm { get; set; }


       private R_TRIG r_TRIG = new R_TRIG();
       private F_TRIG f_TRIG = new F_TRIG();

        /// <summary>
        /// 报警触发
        /// </summary>
        /// <returns></returns>
        public bool IsAlarmTrig()
        {
          
            if(IsPosEdgeAlarm)
            {
                r_TRIG.CLK = (float)Value == 1;
            }
            else if(IsFallEdgeAlarm)
            {
                r_TRIG.CLK = (float)Value == 0;
            }
            
            return r_TRIG.Q;
        }


        /// <summary>
        /// 报警消除
        /// </summary>
        /// <returns></returns>
        public bool IsAlarmFallTrig()
        {

            if (IsPosEdgeAlarm)
            {
                f_TRIG.CLK = (float)Value == 1;
            }
            else if (IsFallEdgeAlarm)
            {
                f_TRIG.CLK = (float)Value == 0;
            }
            return f_TRIG.Q;
        }
    }
}
