using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.TeamplateMatch
{
    /// <summary>
    /// NCC匹配创建参数
    /// </summary>
    public class NccCreateParamter:BaseParamter
    {

        private int numLevels;
        private double angleStart;
        private double angleExtent;
        private string angleStep;       
        private string metric;
       
      



        /// <summary>
        /// 金字塔层数
        /// </summary>
        public int NumLevels
        {
            get { return numLevels; }
            set { numLevels = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 起始角度
        /// </summary>
        public double AngleStart
        {
            get { return angleStart; }
            set
            {
                angleStart = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 角度范围
        /// </summary>
        public double AngleExtent
        {
            get { return angleExtent; }
            set
            {
                angleExtent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 角度步长
        /// </summary>
        public string AngleStep
        {
            get { return angleStep; }
            set
            {
                angleStep = value;
                RaisePropertyChanged();
            }
        }

      

        /// <summary>
        /// 度量方式
        /// </summary>
        public string Metric
        {
            get { return metric; }
            set
            {
                metric = value;
                RaisePropertyChanged();
            }
        }





        public override void InitParamterValue()
        {
            NumLevels = 0;
            AngleStart = 0;
            AngleExtent = 360;
            AngleStep = "auto";            
            Metric = "use_polarity";
                      
        }
    }
}
