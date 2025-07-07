using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineVision.Core.TeamplateMatch;
using Prism.Mvvm;

namespace MachineVision.Core.ObjectMessure
{
    public class CircleFindParamter : BaseParamter
    {
        private double row;
        private double column;
        private double radius;
        private double measureLength1;
        private double measureLength2;
        private double measureSigma;
        private double measureThreshold;

        /// <summary>
        /// 圆心横坐标
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
        /// 圆心纵坐标
        /// </summary>
        public double Column
        {
            get { return column; }
            set
            {
                column = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 半径
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 卡尺尺寸(长)
        /// </summary>
        public double MeasureLength1
        {
            get { return measureLength1; }
            set
            {
                measureLength1 = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 卡尺尺寸(宽)
        /// </summary>
        public double MeasureLength2
        {
            get { return measureLength2; }
            set
            {
                measureLength2 = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 边缘系数
        /// </summary>
        public double MeasureSigma
        {
            get { return measureSigma; }
            set
            {
                measureSigma = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 边缘阈值
        /// </summary>
        public double MeasureThreshold
        {
            get { return measureThreshold; }
            set
            {
                measureThreshold = value;
                RaisePropertyChanged();
            }
        }

        public CircleFindParamter()
        {
            InitParamterValue();
        }

        public override void InitParamterValue()
        {
            MeasureLength1 = 20;
            MeasureLength2 = 5;
            MeasureSigma = 1;
            MeasureThreshold = 30;
        }
    }
}
