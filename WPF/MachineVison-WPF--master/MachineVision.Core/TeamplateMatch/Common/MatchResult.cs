using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch
{
    /// <summary>
    /// 匹配结果
    /// </summary>
    public class MatchResult : BindableBase
    {
        private int index;
        private double row;
        private double cloumn;
        private double angle;
        private double score;
        private HObject contours;

        /// <summary>
        /// 序号
        /// </summary>
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 中点横坐标
        /// </summary>
        public double Row
        {
            get { return row; }
            set
            {
                row = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 中点纵坐标
        /// </summary>
        public double Cloumn
        {
            get { return cloumn; }
            set
            {
                cloumn = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 旋转角度
        /// </summary>
        public double Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 匹配分数
        /// </summary>
        public double Score
        {
            get { return score; }
            set
            {
                score = value;
                RaisePropertyChanged();
            }
        }

        
        /// <summary>
        /// 匹配的轮廓
        /// </summary>
        public HObject Contours
        {
            get { return contours; }
            set { contours = value; }
        }

    }
}
