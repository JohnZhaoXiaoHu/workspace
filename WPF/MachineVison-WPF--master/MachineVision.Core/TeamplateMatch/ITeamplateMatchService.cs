using HalconDotNet;
using MachineVision.Core.TeamplateMatch.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.TeamplateMatch
{
    public interface ITeamplateMatchService
    {
       /* /// <summary>
        /// 创建匹配模板参数
        /// </summary>
        public CreateTeamplateParamter CreateParamter { get; set; }

        /// <summary>
        /// 查找匹配模板参数
        /// </summary>
        public FindTeamplateParamter FindParamter { get; set; }


        /// <summary>
        /// 匹配的结果内容
        /// </summary>
        public TeamplateMatchResult MatchResult { get; set; }*/

        /// <summary>
        /// ROI图像
        /// </summary>
        public ROIParamter ROI { get; set; }

        /// <summary>
        /// 创建匹配模板
        /// </summary>
        public  Task CreateMachTeamplate(HObject EditImage, HObject ho_teamplateImage);

        /// <summary>
        /// 查找匹配模板
        /// </summary>
        public Task<TeamplateMatchResult> FindMatchTeamplate(HObject EditImage);
    }
}
