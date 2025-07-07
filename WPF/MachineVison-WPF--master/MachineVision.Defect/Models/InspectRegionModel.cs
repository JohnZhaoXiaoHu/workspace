using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Defect.Paramters;
using Newtonsoft.Json;

namespace MachineVision.Defect.Models
{
    public class InsectRegionModel : BaseTableModel
    {
        private string name;

        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                RaisePropertyChanged();
            }
        }

        private int projectId;

        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectId
        {
            get { return projectId; }
            set
            {
                projectId = value;
                RaisePropertyChanged();
            }
        }

        private string regionInfo;

        /// <summary>
        /// 检测区域相关信息
        /// </summary>
        public string RegionInfo
        {
            get { return regionInfo; }
            set
            {
                regionInfo = value;
                RaisePropertyChanged();
            }
        }

        private TeamplateParamter regionParamter;

        /// <summary>
        /// 检测区域的模版参数(包含矩形坐标参数，模板图片，模板文件等)
        /// </summary>
        public TeamplateParamter RegionParamter
        {
            get { return regionParamter; }
            set
            {
                regionParamter = value;
                RaisePropertyChanged();
            }
        }

        private double rowSpacing;

        /// <summary>
        /// 行方向与参考点中心点的间距
        /// </summary>
        public double RowSpacing
        {
            get { return rowSpacing; }
            set
            {
                rowSpacing = value;
                RaisePropertyChanged();
            }
        }

        private double columnSpacing;

        /// <summary>
        /// 列方向与参考点中心点的间距
        /// </summary>
        public double ColumnSpacing
        {
            get { return columnSpacing; }
            set
            {
                columnSpacing = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 差异模型文件名
        /// </summary>
        public string VariationModelFileName { get; set; }

        /// <summary>
        /// 差异模型ID
        /// </summary>
        [JsonIgnore]
        public HTuple VariationModelID { get; set; } = null;

        //初始化检测区域参数
        public void InitRegionParamter()
        {
            if (!string.IsNullOrWhiteSpace(RegionInfo))
            {
                //反序列化出检测区域参数
                RegionParamter = JsonConvert.DeserializeObject<TeamplateParamter>(RegionInfo);

                //初始化模版ID
                RegionParamter.InitModleID(ProjectName);
            }
            else
            {
                RegionParamter = new TeamplateParamter();
            }
        }

        public void InitVaritionModelID(string projectName)
        {
            if(!string.IsNullOrWhiteSpace(VariationModelFileName))
            {
                string basePath= AppDomain.CurrentDomain.BaseDirectory + $"project\\{projectName}\\";
                string variationFullFileName = basePath + VariationModelFileName;
                HOperatorSet.ReadVariationModel(variationFullFileName, out HTuple ModelID);
                VariationModelID = ModelID;
            }
        }

    }
}
