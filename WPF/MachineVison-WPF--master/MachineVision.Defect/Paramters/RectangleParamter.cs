using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MachineVision.Defect.Paramters
{
    //矩形参数
    public class RectangleParamter : BindableBase
    {
        private double row1;

        /// <summary>
        /// 起始点行坐标
        /// </summary>
        public double Row1
        {
            get { return row1; }
            set
            {
                row1 = value;
                RaisePropertyChanged();
            }
        }

        private double column1;

        /// <summary>
        /// 起始点列坐标
        /// </summary>
        public double Column1
        {
            get { return column1; }
            set
            {
                column1 = value;
                RaisePropertyChanged();
            }
        }

        private double row2;

        /// <summary>
        /// 结束点行坐标
        /// </summary>
        public double Row2
        {
            get { return row2; }
            set
            {
                row2 = value;
                RaisePropertyChanged();
            }
        }

        private double column2;

        /// <summary>
        /// 结束点列坐标
        /// </summary>
        public double Column2
        {
            get { return column2; }
            set { column2 = value; }
        }

        private double rowCenter;

        /// <summary>
        /// 矩形中心点行坐标
        /// </summary>
        public double RowCenter
        {
            get { return rowCenter; }
            set
            {
                rowCenter = value;
                RaisePropertyChanged();
            }
        }

        private double columnCenter;

        /// <summary>
        /// 矩形中心点列坐标
        /// </summary>
        public double ColumnCenter
        {
            get { return columnCenter; }
            set
            {
                columnCenter = value;
                RaisePropertyChanged();
            }
        }

       /// <summary>
       /// 矩形宽度
       /// </summary>
       public double Width { get; set; }


        /// <summary>
        /// 矩形高度
        /// </summary>
        public double Height { get; set; }

    }
}
