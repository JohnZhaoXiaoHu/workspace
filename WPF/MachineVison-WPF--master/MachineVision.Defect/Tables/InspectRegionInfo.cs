using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Tables
{
    [Table(Name ="T_InspectRegionInfos")]
    public class InspectRegionInfo:BaseTable
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set;}


        /// <summary>
        /// 所属的项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 检测区域相关参数
        /// </summary>
       public string RegionInfo { get; set; }

        /// <summary>
        /// 中点行坐标与参考点行左边的间距
        /// </summary>
        public double RowSpacing { get; set; }

        /// <summary>
        /// 中点列坐标与参考点列左边的间距
        /// </summary>
        public double ColumnSpacing { get; set; }

        /// <summary>
        /// 差异模型文件名称
        /// </summary>
        public string VariationModelFileName { get; set; }

    }
}
