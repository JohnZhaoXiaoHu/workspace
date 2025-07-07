using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineVision.Defect.Paramters;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace MachineVision.Defect.Models
{
    public class ProjectModel : BaseTableModel
    {
       
        private string name;


        /// <summary>
        /// 项目名称
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

        private TeamplateParamter referPointParamtter;

        /// <summary>
        /// 参考点参数
        /// </summary>
        public TeamplateParamter ReferPointParamtter
        {
            get { return referPointParamtter; }
            set
            {
                referPointParamtter = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 参考点信息字符串
        /// </summary>
        public string ReferPointInfo { get; set; }


        public void InitReferParamter()
        {
            if(!string.IsNullOrWhiteSpace(ReferPointInfo))
            {
                //反序列化参考点信息字符串，以获取参考点参数
                ReferPointParamtter = JsonConvert.DeserializeObject<TeamplateParamter>(ReferPointInfo);

                //初始化设置参考点模板ID
                ReferPointParamtter.InitModleID(Name);
            }
            else
            {
                ReferPointParamtter = new TeamplateParamter();
            }
        }
    }
}
