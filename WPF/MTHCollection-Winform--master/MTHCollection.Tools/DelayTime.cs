using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Tools
{
    public class DelayTime
    {
        /*
       * 类库名称:延时指令FB
       * 创建时间:2020.12.28
       * 修改时间:2020.12.28
       * 使用说明:
       * 1.访问器 只读 时间过程值获取 double subTimeUser
       * 2.访问器 只写 时间设定 double setTimeUser
       * 3.访问器 只写 计时器触发 bool timerOn
       * 4.访问器 只读 时间到达标志 bool timerCheckUser
       */

        #region 私有变量

        private double subTime;//时间相差数
        private DateTime dtRecord;//时间记忆
        private bool firstTimeRecord;//运行第一次记录标志
        private double setTime;//设定时间
        private bool timerCheck;//时间到

        #endregion

        #region 公共访问器
        /// <summary>
        ///时间过程值 只读
        /// </summary>
        public double subTimeUser //只读
        {
            get { return subTime; }
        }

        /// <summary>
        /// 时间设定 只写
        /// </summary>
        public double setTimeUser //只写
        {
            set
            {
                setTime = value;
            }
        }

        /// <summary>
        /// 计时器触发 只写
        /// </summary>
        public bool timerOn //只写
        {
            set
            {
                timerOnFun(value);
            }
        }

        /// <summary>
        /// 时间到达标志 只读
        /// </summary>
        public bool timerCheckUser //只读
        {
            get { return timerCheck; }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 计数开始方法(开始标志)
        /// </summary>
        /// <param name="on"></param>
        private void timerOnFun(bool on)
        {
            if (on) //当前延时计算开始
            {
                if (!firstTimeRecord) //当前第一次获取时间值标志
                {
                    dtRecord = DateTime.Now; //赋值至时间记录
                    firstTimeRecord = true; //已读取第一次时间记忆
                }

                if(subTime<setTime)
                {
                    subTime = (DateTime.Now - dtRecord).TotalMilliseconds; //获取当前时间与上一次时间的差值
                }

                if (subTime >= setTime) //若差值比设置值大则输出延时到达信号
                {
                    subTime=setTime;
                    timerCheck = true;
                }
            }
            else
            {
                firstTimeRecord = false; //消除第一次获取时间值标志
                timerCheck = false;
                subTime = 0;
            }
        }





        #endregion



    }
}
