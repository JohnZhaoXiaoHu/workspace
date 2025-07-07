using System.Drawing.Drawing2D;
using System.Drawing;
using Zhaoxi.NewVision.Editor.mycontrols;
using Zhaoxi.NewVision.Editor.helper;

namespace Zhaoxi.NewVision.Editor
{
    public partial class MainForm : Form
    {
        private bool isDrawing;
        private Point p1;
        private Point p2;
        private Point p3;
        private Point p4;
        private Point startPoint;
        private DrawState drawState = DrawState.Normal;
        private FlowNode node2;
        private int nodeNum;
        private FlowNode node1;
        private Pen pen;

        public MainForm()
        {
            InitializeComponent();
            // 自定义箭头样式
            var lineCap = new AdjustableArrowCap(5,5, true);
            // 初始化绘制画笔
            pen = new Pen(Color.Teal, 3)
            {
                CustomEndCap = lineCap
            };
        }
        #region 窗口初始化时候执行
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 隐藏工具菜单
            pl_ImgHandle.Visible = false;
            pl_Model.Visible = false;
        }
        #endregion
        #region 功能菜单的隐藏与显示实现
        private void lb_ImgHandle_Click(object sender, EventArgs e)
        {
            pl_ImgHandle.Visible = !pl_ImgHandle.Visible;
        }

        private void lb_Model_Click(object sender, EventArgs e)
        {
            pl_Model.Visible = !pl_Model.Visible;
        }
        #endregion
        #region 功能菜单按下鼠标左键进行拖拽准备
        private void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender is Label)
                {
                    Label lbl = (Label)sender;
                    lbl.DoDragDrop(lbl, DragDropEffects.Move);
                }
            }
        }
        #endregion
        #region 设置拖拽控件到编辑区域上面显示样式
        private void pl_flowregion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        #endregion
        #region 拖拽到目标区域位置完成后需要处理逻辑
        private void pl_flowregion_DragDrop(object sender, DragEventArgs e)
        {
            // 容器
            var container = sender as Panel;
            // 获取传递拖拽对象
            var dragObj = e.Data.GetData(typeof(Label)) as Label;
            // 创建自定义用户控件
            var node = new FlowNode { NodeName = dragObj.Text };
            // 循环给FlowNode用户控件中每个子控件注册一个鼠标事件
            MouseEventHelper.RegistryMouseEvent(node, NodeMouseDown, MouseEventName.MouseDown);
            MouseEventHelper.RegistryMouseEvent(node, NodeMouseMove, MouseEventName.MouseMove);
            MouseEventHelper.RegistryMouseEvent(node, NodeMouseUp, MouseEventName.MouseUp);
            MouseEventHelper.RegistryMouseEvent(node, NodeClick, MouseEventName.MouseDown);
            // 设置位置
            node.Location = container.PointToClient(new Point(e.X, e.Y));
            // 添加到容器中
            container.Controls.Add(node);
        }

        

        /// <summary>
        /// 鼠标按下的时候，表示需要移动流程节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void NodeMouseDown(object sender, MouseEventArgs e)
        {
            // 记录下当前鼠标的位置
            startPoint = new Point(e.X, e.Y);
        }

        private void NodeMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                // 获取当前节点[子控件]
                var currentControl = sender as Control;
                // 获取当前节点
                var currentNode = currentControl.Parent as FlowNode;
                // 获取当前节点移动偏移
                int left = currentNode.Left + (e.X - startPoint.X);
                int top = currentNode.Top + (e.Y - startPoint.Y);
                // 做位置的判断，不能超出边界
                int width = currentNode.Width;
                int height = currentNode.Height;
                // 获取容器的区域
                var rect = currentNode.Parent.ClientRectangle;
                // 限制范围
                left = left < 0 ? 0 : (left+width > rect.Width) ? rect.Width - width : left;
                top = top < 0 ? 0 : (top + height > rect.Height) ? rect.Height - height : top;
                // 设置当前节点位置
                currentNode.Left = left;
                currentNode.Top = top;

                // 手动重绘编辑区域
                currentNode.Parent.Invalidate();
            }
        }
        private void NodeMouseUp(object sender, MouseEventArgs e)
        {
            startPoint = default;
        }

        /// <summary>
        /// 实现两个节点直接连线功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void NodeClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawState == DrawState.DrawLine) 
            {
                // 获取当前点击控件
                var currentControl = sender as Control;
                if (nodeNum == 0)
                {
                    if (currentControl.Parent != null)
                    {
                        node1 = currentControl.Parent as FlowNode;
                        nodeNum = 1;
                    }
                    else
                    {
                        MessageBox.Show("请选择第一个流程节点");
                    }
                }
                else if (nodeNum == 1) 
                {
                    if (currentControl.Parent != null)
                    {
                        node2 = currentControl.Parent as FlowNode;
                        if (node1 != node2) 
                        {
                            // 把节点关系建立起来
                            node1.NextNodeId = node2.NodeId;
                            node2.PreNodeId = node1.NodeId;

                            // 绘制节点间连线操作
                            var pe = new PaintEventArgs(pl_flowregion.CreateGraphics(), new Rectangle());
                            DrawPointToPointLine(node1, node2, pe);
                            // 重置连线状态
                            drawState = DrawState.Normal;
                            nodeNum = 0;
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("请选择第二个流程节点");
                    }
                }
            }
        }
        /// <summary>
        /// 定义绘制连线放心的枚举
        /// </summary>
        enum LineForward
        {
            L_R,
            R_L,
            U_D,
            D_U
        }

        /// <summary>
        /// 绘制连线的实现方法- 判断连线位置
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DrawPointToPointLine(FlowNode ctl1, FlowNode ctl2, PaintEventArgs e)
        {
            // 定义2个点对象变量
            Point p1, p2;
            //左到右
            if (Math.Abs(ctl2.Location.X - ctl1.Location.X) > Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.X >= ctl1.Location.X)
            {
                p1 = new Point(ctl1.Location.X + ctl1.Width + 1, ctl1.Location.Y + ctl1.Height / 2);
                p2 = new Point(ctl2.Location.X - 1, ctl2.Location.Y + ctl2.Height / 2);
                DrawJoinLine(p1, p2, LineForward.L_R, e);
            }
            //右到左
            else if (Math.Abs(ctl2.Location.X - ctl1.Location.X) > Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.X < ctl1.Location.X)
            {
                p1 = new Point(ctl1.Location.X - 1, ctl1.Location.Y + ctl1.Height / 2);
                p2 = new Point(ctl2.Location.X + ctl2.Width + 1, ctl2.Location.Y + ctl2.Height / 2);
                DrawJoinLine(p1, p2, LineForward.R_L, e);
            }
            //上到下
            else if (Math.Abs(ctl2.Location.X - ctl1.Location.X) <= Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.Y >= ctl1.Location.Y)
            {

                p1 = new Point(ctl1.Location.X + ctl1.Width / 2, ctl1.Location.Y + ctl1.Height + 1);
                p2 = new Point(ctl2.Location.X + ctl1.Width / 2, ctl2.Location.Y - 1);
                DrawJoinLine(p1, p2, LineForward.U_D, e);
            }
            //下到上
            else if (Math.Abs(ctl2.Location.X - ctl1.Location.X) < Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.Y < ctl1.Location.Y)
            {
                p1 = new Point(ctl1.Location.X + ctl1.Width / 2, ctl1.Location.Y - 1);
                p2 = new Point(ctl2.Location.X + ctl2.Width / 2, ctl2.Location.Y + ctl2.Height + 1);
                DrawJoinLine(p1, p2, LineForward.D_U, e);

            }
        }

        /// <summary>
        /// 绘制两个点之间的连线
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="forward"></param>
        private void DrawJoinLine(Point p1, Point p2, LineForward forward, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // 这个才是核心
            g.SmoothingMode = SmoothingMode.HighQuality;

            Point inflectPoint1;
            Point inflectPoint2;
            if (forward == LineForward.L_R || forward == LineForward.R_L)
            {
                inflectPoint1 = new Point((p1.X + p2.X) / 2, p1.Y);
                inflectPoint2 = new Point((p1.X + p2.X) / 2, p2.Y);

            }
            else
            {
                inflectPoint1 = new Point(p1.X, (p1.Y + p2.Y) / 2);
                inflectPoint2 = new Point(p2.X, (p1.Y + p2.Y) / 2);
            }

            Point[] points = [p1, inflectPoint1, inflectPoint2, p2];

            g.DrawLines(pen, points);

        }

        #endregion
        #region 编辑器容器重绘的事件
        private void pl_flowregion_Paint(object sender, PaintEventArgs e)
        {
            var currentControl = sender as Control;
            // 把所有节点的关系连线绘制出来
            DrawAllLines(currentControl, e);
        }

        private void DrawAllLines(Control control, PaintEventArgs e)
        {
            // 获取当前流程编辑区域中所有流程节点
            var nodes = control.Controls.OfType<FlowNode>();
            foreach (var node1 in nodes) 
            {
                foreach (var node2 in nodes)
                {
                    // 判断从属关系
                    if (node1.NextNodeId != null && node1.NextNodeId == node2.NodeId) 
                    {
                        if (node1 != node2) 
                        {
                            // 绘制连线
                            DrawPointToPointLine(node1, node2, e);
                        }
                    }
                }
            }
        }
        #endregion
        #region 右键连线执行逻辑
        private void tm_link_Click(object sender, EventArgs e)
        {
            // 把绘制状态修改为连线状态
            drawState = DrawState.DrawLine;
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Label panel = sender as Label;
            using (Pen pen = new Pen(Color.AliceBlue, 3)) // 设置边框颜色和宽度
            {
                e.Graphics.DrawRectangle(pen, 0, panel.Height - 1, panel.Width - 1, panel.Height - 1);
            }
        }
    }

    enum DrawState 
    {
        Normal,
        DrawLine
    }
}
