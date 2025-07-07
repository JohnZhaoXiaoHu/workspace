using System;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using DragVision.Controls;
using DragVision.Plugin;
using DragVision.Plugin.Service;
using DragVision.Shared.Extensions;
using DragVision.Shared.Helper;
using DragVision.Shared.Models;
using DragVision.Start.Dialog;
using HalconDotNet;

namespace DragVision.Start
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region 把工具箱拖进容器
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// 拖拽进入容器的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelFlow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// 拖拽放置到容器完成的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelFlow_DragDrop(object sender, DragEventArgs e)
        {
            var item = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            FlowNode flowNode = new FlowNode();
            flowNode.FlowNodeName = item.Text;
            var panel = sender as MyPanel;
            flowNode.Location = panel.PointToClient(new Point(e.X, e.Y));

            RegisterMouseEventHandlerHelper.RegisterMouseEventHandler(
                flowNode,
                flowNode_MouseDown,
                MouseEventType.MouseDown
            );

            RegisterMouseEventHandlerHelper.RegisterMouseEventHandler(
                flowNode,
                flowNode_MouseMove,
                MouseEventType.MouseMove
            );

            flowNode.NodeLinkStartClick += FlowNode_NodeLinkStartClick; //节点连线开始事件
            flowNode.NodeLinkEndClick += FlowNode_NodeLinkEndClick; //节点连线结束事件
            flowNode.MouseDoubleClick += FlowNode_MouseDoubleClick; //节点双击事件
            flowNode.DeleNode_Click += FlowNode_DeleNode_Click; //节点删除事件
            flowNode.DeleInputLink_Click += FlowNode_DeleInputLink_Click; //节点输入连线删除事件
            flowNode.DeleOutputLink_Click += FlowNode_DeleOutputLink_Click; //节点输出连线删除事件

            flowDic[tabControl1.SelectedTab].Add(flowNode); //把节点添加到当前流程的字典的值
            panel.Controls.Add(flowNode);
        }

        #endregion





        #region 节点鼠标双击事件
        private void FlowNode_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            var node = sender as FlowNode;
            if (node != null)
            {
                //获取相应的插件服务,打开插件窗口
                IPlugin pluginService = PluginFactory.GetPluginService(node);
                pluginService.ShowPluginWindow(node);

                //传递节点输出参数到与之连线的后续节点的输入参数
                if (node.OutputPathInfos.Count > 0)
                {
                    foreach (var pathInfo in node.OutputPathInfos)
                    {
                        pathInfo.EndNode.InputParam = node.OutputParam;
                    }
                }
            }
        }

        #endregion


        #region 节点删除事件
        private void FlowNode_DeleNode_Click(object? sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("确定要删除该节点吗？", "提示", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                var node = sender as FlowNode;
                DeleteNodeInputLink(node);
                DeleteNodeOutputLink(node);
                flowDic[tabControl1.SelectedTab].Remove(node);
                var nodePanel = node.Parent as MyPanel;
                nodePanel.Controls.Remove(node);
            }
        }

        #endregion


        #region 节点输入连线删除事件

        private void DeleteNodeInputLink(FlowNode node)
        {
            if (node != null)
            {
                if (node.InputPathInfo != null)
                {
                    //清除连线信息
                    node.InputPathInfo.StartNode.OutputPathInfos.Remove(node.InputPathInfo);
                    node.InputPathInfo = null;
                    var nodePanel = node.Parent as MyPanel;
                    nodePanel.Invalidate();
                }
            }
        }

        private void FlowNode_DeleInputLink_Click(object? sender, EventArgs e)
        {
            var node = sender as FlowNode;

            DeleteNodeInputLink(node);
        }

        #endregion

        #region 节点输出连线删除事件
        private void DeleteNodeOutputLink(FlowNode node)
        {
            if (node != null)
            {
                if (node.OutputPathInfos.Count > 0)
                {
                    //清除连线信息
                    foreach (var pathInfo in node.OutputPathInfos)
                    {
                        pathInfo.EndNode.InputPathInfo = null;
                    }
                    node.OutputPathInfos.Clear();
                    var nodePanel = node.Parent as MyPanel;
                    nodePanel.Invalidate();
                }
            }
        }

        private void FlowNode_DeleOutputLink_Click(object? sender, EventArgs e)
        {
            var node = sender as FlowNode;
            DeleteNodeOutputLink(node);
        }

        #endregion


        private bool isLink = false;

        private ConnectPathInfo currentLinkInfo = null;

        // private List<FlowNode> flowNodeList = new List<FlowNode>();

        /// <summary>
        /// 存储当前已连线流程信息和流程节点集合信息的线程安全的有序字典
        /// </summary>
        private OrderedSafeDictionary<TabPage, List<FlowNode>> flowDic =
            new OrderedSafeDictionary<TabPage, List<FlowNode>>();

        #region  节点之间的连线

        private void FlowNode_NodeLinkStartClick(object? sender, MouseEventArgs e)
        {
            var panel = sender as Panel;
            var node = GetParentFlowNode(panel);
            currentLinkInfo = new ConnectPathInfo();
            if (node != null)
            {
                node.IsConnetorVisible = true;
                currentLinkInfo.StartNode = node;
                var flowPanel = node.Parent as MyPanel;
                var contentPanel = panel.Parent as Panel;
                int x = panel.Left + panel.Width / 2;
                int y = panel.Top + panel.Height;
                currentLinkInfo.StartPoint = flowPanel.PointToClient(
                    contentPanel.PointToScreen(new Point(x, y))
                );
                isLink = true;
            }
        }

        private void FlowNode_NodeLinkEndClick(object? sender, MouseEventArgs e)
        {
            var panel = sender as Panel;
            var endNode = GetParentFlowNode(panel);
            if (
                currentLinkInfo != null
                && endNode != null
                && endNode != currentLinkInfo.StartNode
                && isLink
            )
            {
                endNode.IsConnetorVisible = true;
                currentLinkInfo.EndNode = endNode;
                var flowPanel = endNode.Parent as MyPanel;
                var contentPanel = panel.Parent as Panel;
                int x = panel.Left + panel.Width / 2; //找到连接器相对于外层panel的中心点坐标
                int y = panel.Top; //e.Top是连接器左上角相对于它所属panel的纵坐标
                currentLinkInfo.EndPoint = flowPanel.PointToClient(
                    contentPanel.PointToScreen(new Point(x, y)) //把连接器左上角相对于它所属panel的坐标转换为相对于屏幕的坐标,再转换为相对于工作区的坐标
                );
                currentLinkInfo.StartNode.OutputPathInfos.Add(currentLinkInfo);
                currentLinkInfo.EndNode.InputPathInfo = currentLinkInfo;

                //将起始节点的输出参数传递给终点结点的输入参数
                currentLinkInfo.EndNode.InputParam = currentLinkInfo.StartNode.OutputParam;

                //记录已经连接的节点信息
                //flowNodeList.Add(currentLinkInfo.StartNode);



                //通过Invalidate方法，触发Mypanel的Paint事件进行重绘
                flowPanel.Invalidate();
            }
            else
            {
                isLink = false;
                currentLinkInfo.StartNode.IsConnetorVisible = false;
                currentLinkInfo = null;
            }
        }

        #endregion


        #region  流程节点容器重绘事件

        private void panelFlow_Paint(object? sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            if (isLink && flowDic[tabControl1.SelectedTab].Count > 0)
            {
                foreach (var item in flowDic[tabControl1.SelectedTab])
                {
                    if (item.OutputPathInfos.Count > 0)
                    {
                        foreach (var pathInfo in item.OutputPathInfos)
                        {
                            //PointLinkToPathHelper.DrawPath(pathInfo.StartPoint, pathInfo.EndPoint, e);

                            PointLinkToPathHelper.DrawPath(
                                pathInfo.StartPoint,
                                pathInfo.EndPoint,
                                e,
                                flowDic[tabControl1.SelectedTab]
                            );
                        }
                    }
                }
            }
        }

        #endregion


        #region 节点在容器内部的移动
        /// <summary>
        ///流程节点鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowNode_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var control = sender as Control;

                if (control != null)
                {
                    control.Capture = true;
                }
            }
        }

        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private FlowNode GetParentFlowNode(Control control)
        {
            if (control.Parent is FlowNode)
            {
                return control.Parent as FlowNode;
            }
            else
            {
                return GetParentFlowNode(control.Parent);
            }
        }

        /// <summary>
        /// 流程节点鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowNode_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var control = sender as Control;
                var node = GetParentFlowNode(control);

                if (node != null)
                {
                    SetNodeNewPosion(node, control, e); //设置节点新位置

                    //如果当前节点存在与其他节点的连线,改变与之相关的连线的新位置
                    SetNodeLinkNewPosion(node);

                    //设置节点相关连线的新位置
                    SetNodeLinkNewPosion(node);
                }
            }
        }

        /// <summary>
        /// 设置流程节点的新位置
        /// </summary>
        /// <param name="node">当前的流程节点</param>
        /// <param name="control"></param>
        /// <param name="e"></param>
        private void SetNodeNewPosion(FlowNode node, Control control, MouseEventArgs e)
        {
            var panel = node.Parent as MyPanel;
            node.Left += e.X - control.Width / 2;

            if (node.Left < 0)
                node.Left = 0;
            if (node.Left > panel.Width - node.Width)
                node.Left = panel.Width - node.Width;
            node.Top += e.Y - control.Height / 2;

            if (node.Top < 0)
                node.Top = 0;

            if (node.Top > panel.Height - node.Height)
                node.Top = panel.Height - node.Height;
        }

        /// <summary>
        /// 设置节点连接线的新位置
        /// </summary>
        /// <param name="node">当前的流程节点</param>
        private void SetNodeLinkNewPosion(FlowNode node)
        {
            var nodePanel = node.Parent as MyPanel;
            if (node.InputPathInfo != null) //如果当前节点存在输入路径,改变该路径的终点坐标
            {
                //获取Top连接器相对于屏幕的坐标
                var endPointFromScreen = node.GetTopConnectorScreenPoint();

                //将Top连接器相对于屏幕的坐标转换为Top连接器相对于nodePanel的坐标
                var endPoint = nodePanel.PointToClient(endPointFromScreen);

                node.InputPathInfo.EndPoint = endPoint;
            }
            if (node.OutputPathInfos.Count > 0) //如果当前节点存在输出路径,改变所有输出路径的起点坐标
            {
                foreach (var outputInfo in node.OutputPathInfos)
                {
                    //获取Bottom连接器相对于屏幕的坐标
                    var startPointFromScreen = node.GetBottomConnectorScreenPoint();

                    //将Bottom连接器相对于屏幕的坐标转换为Bottom连接器相对于nodePanel的坐标
                    var startPoint = nodePanel.PointToClient(startPointFromScreen);
                    outputInfo.StartPoint = startPoint;
                }
            }

            //重绘
            nodePanel.Invalidate();
        }

        #endregion





        #region  窗体加载事件
        private void FormMain_Load(object sender, EventArgs e)
        {
            //清空所有节点
            treeView1.Nodes.Clear();

            //获取所有插件分类和名称
            var dic = PluginFactory.GetAllPluginCategoryAndName();
            var rootNodeNames = dic.Keys.ToList();

            //把所有插件类别作为根结点，把每个类别下的插件作为子节点，添加到树中
            foreach (var rootNodeName in rootNodeNames)
            {
                TreeNode treeNode = new TreeNode(rootNodeName);
                treeView1.Nodes.Add(treeNode);

                foreach (var childNodeName in dic[rootNodeName])
                {
                    TreeNode childNode = new TreeNode(childNodeName) { ImageIndex = 1 };
                    treeNode.Nodes.Add(childNode);
                }
            }

            tabControl1.Controls.Clear(); //清空所有流程选项卡
            tabControl1.ContextMenuStrip = contextMenuStrip1; //设置流程选项卡右键菜单

            PluginFactory.PluginViewAction += PluginFactory_PluginViewAction;

            PluginFactory.PluginMessageAction += PluginFactory_PluginMessageAction;

            dgvLog.AutoGenerateColumns = false;
        }

        #endregion

        #region 添加流程事件
        private void btnAddFlow_Click(object sender, EventArgs e)
        {
            FrmAddFow frmAddFow = new FrmAddFow();
            var dialogResult = frmAddFow.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string pageName = frmAddFow.Tag.ToString();
                TabPage tabPage = new TabPage(pageName);
                MyPanel myPanel = new MyPanel();
                myPanel.Dock = DockStyle.Fill;
                myPanel.DragEnter += panelFlow_DragEnter;
                myPanel.DragDrop += panelFlow_DragDrop;
                myPanel.Paint += panelFlow_Paint;
                myPanel.AllowDrop = true;
                tabPage.Controls.Add(myPanel);
                //tabPage.ContextMenuStrip = contextMenuStrip1;

                flowDic.Add(tabPage, new List<FlowNode>());

                tabControl1.TabPages.Add(tabPage);
            }
        }

        #endregion

        #region 流程删除事件
        private void menuItem_DeleteFlow_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl1.SelectedTab;
            var result = MessageBox.Show("是否确认删除当前流程", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                flowDic.Remove(selectedPage);
                tabControl1.Controls.Remove(selectedPage);
            }
        }
        #endregion


        #region  插件服务委托,视图显示插件服务完成后的对象
        private void PluginFactory_PluginViewAction(List<HObject> hobjectList)
        {
            HWindow hWindow = halconDisplayControl1.GetHWindow();
            hWindow.ClearWindow();
            HOperatorSet.SetColor(hWindow, "red");
            if (hobjectList != null && hobjectList.Count > 0)
            {
                foreach (var hObject in hobjectList)
                {
                    hWindow.DispObj(hObject);
                }
            }
        }
        #endregion


        #region 插件服务委托,插件服务完成后添加日志
        private List<LogModel> logList = new List<LogModel>();

        private void PluginFactory_PluginMessageAction(string message)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            logList.Add(new LogModel() { Time = currentTime, Message = message });
            dgvLog.DataSource = null;
            dgvLog.DataSource = logList;
        }
        #endregion
    }
}
