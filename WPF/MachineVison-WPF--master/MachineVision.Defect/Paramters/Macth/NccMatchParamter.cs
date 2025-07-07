using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using Prism.Mvvm;

namespace MachineVision.Defect.Paramters.Macth
{
    public class NccMatchParamter : BindableBase
    {
        private HTuple row1;
        private HTuple column1;
        private HTuple row2;
        private HTuple column2;

        /// <summary>
        /// 矩形左上角行坐标
        /// </summary>
        public HTuple Row1
        {
            get { return row1; }
            set
            {
                row1 = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 矩形左上角列坐标
        /// </summary>
        public HTuple Column1
        {
            get { return column1; }
            set
            {
                column1 = value;
                RaisePropertyChanged();
            }
        }

       /// <summary>
       /// 矩形右下角行坐标
       /// </summary>
        public HTuple Row2
        {
            get { return row2; }
            set
            {
                row2 = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 矩形右下角列坐标
        /// </summary>
        public HTuple Column2
        {
            get { return column2; }
            set
            {
                column2 = value;
                RaisePropertyChanged();
            }
        }
    }
}
