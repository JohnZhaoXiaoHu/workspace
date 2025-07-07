using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.NewVision.Editor.helper
{
    public class FlowNodeTool
    {
        /// <summary>
        /// 获取所有的流程节点列表
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static List<FlowNode> GetNodes(Control control) 
        {
            // 获取控件上面所有子控件
            var controls = control.Controls;
            // 获取所有FlowNode类的控件
            var nodes = controls.OfType<FlowNode>().ToList();

            return nodes;
        }

        /// <summary>
        /// 获取当前节点的前置节点
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public static FlowNode GetPreNode(FlowNode currentNode) 
        {
            var nodes = GetNodes(currentNode.Parent);
            var nodeArray = nodes.Where(n=>n.NodeId == currentNode.PreNodeId).ToArray();

            if (nodeArray.Length > 0) 
            {
                return nodeArray.First();
            }

            return null;
            
        }

        /// <summary>
        /// 获取当前节点的后置节点
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public static FlowNode GetNextNode(FlowNode currentNode)
        {
            var nodes = GetNodes(currentNode.Parent);
            var nodeArray = nodes.Where(n => n.NodeId == currentNode.NextNodeId).ToArray();

            if (nodeArray.Length > 0)
            {
                return nodeArray.First();
            }

            return null;

        }
    }
}
