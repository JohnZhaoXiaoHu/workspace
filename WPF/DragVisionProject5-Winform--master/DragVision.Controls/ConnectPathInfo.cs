using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Controls
{
    /// <summary>
    /// 连接路径信息类
    /// </summary>
    public class ConnectPathInfo
    {
        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public FlowNode StartNode { get; set; }


        public FlowNode EndNode { get; set; }
    }
}
