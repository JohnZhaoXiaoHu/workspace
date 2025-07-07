using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Tools
{
    /// <summary>
    /// 下降沿类
    /// </summary>
    public class F_TRIG
    {
        //记录上一次的状态为ON还是False
        private bool last;

        //时钟标志
        public bool CLK

        {
            set
            {
                Q = !value && last;//1变0 上次为真本次为假
                last = value;
            }
        }

        //下降沿的输出标志
        public bool Q { get; private set; }

    }
}
