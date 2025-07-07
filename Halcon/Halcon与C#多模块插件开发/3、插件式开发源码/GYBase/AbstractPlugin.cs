using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYBase
{
    /// <summary>
    /// 虚方法需要给到子类重写
    /// </summary>
    public abstract class AbstractPlugin : IPluginBase
    {
        public virtual long ElseTime()
        {
            throw new NotImplementedException();
        }

        public virtual void RunForm()
        {
            throw new NotImplementedException();
        }

        public virtual void RunPlugin()
        {
            throw new NotImplementedException();
        }
    }
}
