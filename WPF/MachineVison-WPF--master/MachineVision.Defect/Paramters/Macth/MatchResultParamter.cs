using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MachineVision.Defect.Paramters.Macth
{
    /// <summary>
    /// 匹配到的参数
    /// </summary>
    public class MatchResultParamter : BindableBase
    {
        private NccMatchParamter nccParamter;

        /// <summary>
        /// NCC模板匹配到的参数
        /// </summary>
        public NccMatchParamter NccParamter
        {
            get { return nccParamter; }
            set
            {
                nccParamter = value;
                RaisePropertyChanged();
            }
        }


        public MatchResultParamter()
        {
            NccParamter = new NccMatchParamter();
        }
    }
}
