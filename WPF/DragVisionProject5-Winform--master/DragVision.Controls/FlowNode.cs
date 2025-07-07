using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragVision.Controls
{
    [Category("自定义控件")]
    [Description("流程节点")]
    public partial class FlowNode : UserControl
    {
        public FlowNode()
        {
            InitializeComponent();
        }

        private void FlowNode_Load(object sender, EventArgs e)
        {

            SetConnectorVisible(false);

            //顶部连接器鼠标进入事件
            panelTop.MouseEnter += (s, e) =>
            {
                SetConnectorVisible(true);
            };

            //底部连接器鼠标进入事件
            panelBottom.MouseEnter += (s, e) =>
            {
                SetConnectorVisible(true);
            };

            //内容栏容器鼠标进入事件
            panelContent.MouseEnter += (s, e) =>
            {
                SetConnectorVisible(true);
            };

            //内容栏容器鼠标离开事件
            panelContent.MouseLeave += (s, e) =>
            {
                if (!IsConnetorVisible)
                {
                    SetConnectorVisible(false);
                }
            };

            //底部连接器鼠标按下事件
            panelBottom.MouseDown += (s, e) =>
            {
                NodeLinkStartClick?.Invoke(s, e);
            };

            //顶部连接器鼠标按下事件
            panelTop.MouseDown += (s, e) =>
            {
                NodeLinkEndClick?.Invoke(s, e);
            };

            #region 传递鼠标双击事件
            panelContent.MouseDoubleClick += (s, e) =>
            {
                this.MouseDoubleClick?.Invoke(this, e);
            };

            panelState.MouseDoubleClick += (s, e) =>
            {
                this.MouseDoubleClick?.Invoke(this, e);
            };

            labFlowName.MouseDoubleClick += (s, e) =>
            {
                this.MouseDoubleClick?.Invoke(this, e);
            };
            #endregion
        }

        //设置连接器的可见性
        private void SetConnectorVisible(bool visible)
        {
            if (visible)
            {
                panelTop.BackColor = Color.RosyBrown;
                panelBottom.BackColor = Color.RosyBrown;

            }
            else
            {
                panelTop.BackColor = Color.Transparent;
                panelBottom.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// 获取顶部连接点屏幕坐标
        /// </summary>
        /// <returns></returns>
        public Point GetTopConnectorScreenPoint()
        {
            //Left和Top是是相对于父控件的位置
            int x = panelTop.Left + panelTop.Width / 2;
            int y = panelTop.Top;
            return panelContent.PointToScreen(new Point(x, y));
        }

        /// <summary>
        /// 获取底部连接点屏幕坐标
        /// </summary>
        /// <returns></returns>
        public Point GetBottomConnectorScreenPoint()
        {
            //Left和Top是是相对于父控件的位置
            int x = panelBottom.Left + panelBottom.Width / 2;
            int y = panelBottom.Top + panelBottom.Height;
            return panelContent.PointToScreen(new Point(x, y));
        }

        #region 自定义事件
        /// <summary>
        /// 开始连线事件
        /// </summary>
        [Category("自定义事件")]
        [Description("开始连线事件")]
        public MouseEventHandler NodeLinkStartClick { get; set; }

        /// <summary>
        /// 结束连线事件
        /// </summary>
        [Category("自定义事件")]
        [Description("结束连线事件")]
        public MouseEventHandler NodeLinkEndClick { get; set; }

        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        public MouseEventHandler MouseDoubleClick { get; set; }


        /// <summary>
        /// 删除当前节点事件
        /// </summary>
        public EventHandler DeleNode_Click { get; set; }

        /// <summary>
        /// 删除输入连线事件
        /// </summary>
        public EventHandler DeleInputLink_Click { get; set; }

        /// <summary>
        /// 删除输出连线事件
        /// </summary>
        public EventHandler DeleOutputLink_Click { get; set; }
        #endregion


        #region 自定义属性
        private string flowNodeName;

        [Category("自定义属性")]
        [Description("流程名称")]
        public string FlowNodeName
        {
            get { return flowNodeName; }
            set
            {
                flowNodeName = value;
                labFlowName.Text = value;
            }
        }

        private Color stateColor;



        [Category("自定义属性")]
        [Description("状态颜色")]
        public Color StateColor
        {
            get { return stateColor; }
            set
            {
                stateColor = value;
                panelState.BackColor = stateColor;
            }
        }

        private bool isConnetorVisible;



        [Category("自定义属性")]
        [Description("是否显示连接点")]
        public bool IsConnetorVisible
        {
            get { return isConnetorVisible; }
            set
            {
                isConnetorVisible = value;

            }
        }


        #endregion


        #region 右键上下文菜单对应事件
        private void 删除当前节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleNode_Click?.Invoke(this, e);
        }

        private void 删除输入连线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleInputLink_Click?.Invoke(this, e);
        }

        private void 删除输出连线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleOutputLink_Click?.Invoke(this, e);
        }



        #endregion

        #region 属性


        /// <summary>
        /// 输入连接点信息
        /// </summary>
        public ConnectPathInfo InputPathInfo { get; set; }

        /// <summary>
        /// 输出连接点信息列表
        /// </summary>
        public List<ConnectPathInfo> OutputPathInfos { get; set; } = new List<ConnectPathInfo>();

        /// <summary>
        /// 节点输入参数
        /// </summary>
        public FlowNodeParam InputParam { get; set; } = new FlowNodeParam();

        /// <summary>
        /// 节点输出参数
        /// </summary>
        public FlowNodeParam OutputParam { get; set; } = new FlowNodeParam();
        #endregion

    }
}
