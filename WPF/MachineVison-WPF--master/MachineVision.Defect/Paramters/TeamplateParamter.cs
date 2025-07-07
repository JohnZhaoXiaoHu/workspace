using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using Newtonsoft.Json;

namespace MachineVision.Defect.Paramters
{
    /// <summary>
    /// 参考点模板参数
    /// </summary>
    public class TeamplateParamter : RectangleParamter
    {
        private string imageFileName;

        /// <summary>
        /// 模板图片文件名
        /// </summary>
        public string IamgeFileName
        {
            get { return imageFileName; }
            set
            {
                imageFileName = value;
                RaisePropertyChanged();
            }
        }

        private string teamplateFileName;

        /// <summary>
        /// 模板文件名称
        /// </summary>
        public string TeamplateFileName
        {
            get { return teamplateFileName; }
            set
            {
                teamplateFileName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 模板ID
        /// </summary>
        [JsonIgnore]
        public HTuple ModleId { get; set; } = null;

        /// <summary>
        /// 初始化模板ID,从本地文件夹获取
        /// </summary>
        /// <param name="projectName"></param>
        public void InitModleID(string projectName)
        {
            string baseDirectory =
                AppDomain.CurrentDomain.BaseDirectory + $"project\\{projectName}\\";
            if (!string.IsNullOrWhiteSpace(TeamplateFileName))
            {
                if (TeamplateFileName.Contains("ncm"))
                {
                    //读取NCC匹配模板的内容
                    HOperatorSet.ReadNccModel(
                        baseDirectory + TeamplateFileName,
                        out HTuple currentModleId
                    );
                    ModleId = currentModleId;
                }
                else if (TeamplateFileName.Contains("dfm"))
                {
                    //读取缺陷检测匹配模板的内容
                    HOperatorSet.ReadDeformableModel(
                        baseDirectory + TeamplateFileName,
                        out HTuple currentModleId
                    );
                    ModleId = currentModleId;
                }
            }
        }
    }
}
