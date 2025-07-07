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
            // �Զ����ͷ��ʽ
            var lineCap = new AdjustableArrowCap(5,5, true);
            // ��ʼ�����ƻ���
            pen = new Pen(Color.Teal, 3)
            {
                CustomEndCap = lineCap
            };
        }
        #region ���ڳ�ʼ��ʱ��ִ��
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ���ع��߲˵�
            pl_ImgHandle.Visible = false;
            pl_Model.Visible = false;
        }
        #endregion
        #region ���ܲ˵�����������ʾʵ��
        private void lb_ImgHandle_Click(object sender, EventArgs e)
        {
            pl_ImgHandle.Visible = !pl_ImgHandle.Visible;
        }

        private void lb_Model_Click(object sender, EventArgs e)
        {
            pl_Model.Visible = !pl_Model.Visible;
        }
        #endregion
        #region ���ܲ˵�����������������ק׼��
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
        #region ������ק�ؼ����༭����������ʾ��ʽ
        private void pl_flowregion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        #endregion
        #region ��ק��Ŀ������λ����ɺ���Ҫ�����߼�
        private void pl_flowregion_DragDrop(object sender, DragEventArgs e)
        {
            // ����
            var container = sender as Panel;
            // ��ȡ������ק����
            var dragObj = e.Data.GetData(typeof(Label)) as Label;
            // �����Զ����û��ؼ�
            var node = new FlowNode { NodeName = dragObj.Text };
            // ѭ����FlowNode�û��ؼ���ÿ���ӿؼ�ע��һ������¼�
            MouseEventHelper.RegistryMouseEvent(node, NodeMouseDown, MouseEventName.MouseDown);
            MouseEventHelper.RegistryMouseEvent(node, NodeMouseMove, MouseEventName.MouseMove);
            MouseEventHelper.RegistryMouseEvent(node, NodeMouseUp, MouseEventName.MouseUp);
            MouseEventHelper.RegistryMouseEvent(node, NodeClick, MouseEventName.MouseDown);
            // ����λ��
            node.Location = container.PointToClient(new Point(e.X, e.Y));
            // ��ӵ�������
            container.Controls.Add(node);
        }

        

        /// <summary>
        /// ��갴�µ�ʱ�򣬱�ʾ��Ҫ�ƶ����̽ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void NodeMouseDown(object sender, MouseEventArgs e)
        {
            // ��¼�µ�ǰ����λ��
            startPoint = new Point(e.X, e.Y);
        }

        private void NodeMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                // ��ȡ��ǰ�ڵ�[�ӿؼ�]
                var currentControl = sender as Control;
                // ��ȡ��ǰ�ڵ�
                var currentNode = currentControl.Parent as FlowNode;
                // ��ȡ��ǰ�ڵ��ƶ�ƫ��
                int left = currentNode.Left + (e.X - startPoint.X);
                int top = currentNode.Top + (e.Y - startPoint.Y);
                // ��λ�õ��жϣ����ܳ����߽�
                int width = currentNode.Width;
                int height = currentNode.Height;
                // ��ȡ����������
                var rect = currentNode.Parent.ClientRectangle;
                // ���Ʒ�Χ
                left = left < 0 ? 0 : (left+width > rect.Width) ? rect.Width - width : left;
                top = top < 0 ? 0 : (top + height > rect.Height) ? rect.Height - height : top;
                // ���õ�ǰ�ڵ�λ��
                currentNode.Left = left;
                currentNode.Top = top;

                // �ֶ��ػ�༭����
                currentNode.Parent.Invalidate();
            }
        }
        private void NodeMouseUp(object sender, MouseEventArgs e)
        {
            startPoint = default;
        }

        /// <summary>
        /// ʵ�������ڵ�ֱ�����߹���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void NodeClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawState == DrawState.DrawLine) 
            {
                // ��ȡ��ǰ����ؼ�
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
                        MessageBox.Show("��ѡ���һ�����̽ڵ�");
                    }
                }
                else if (nodeNum == 1) 
                {
                    if (currentControl.Parent != null)
                    {
                        node2 = currentControl.Parent as FlowNode;
                        if (node1 != node2) 
                        {
                            // �ѽڵ��ϵ��������
                            node1.NextNodeId = node2.NodeId;
                            node2.PreNodeId = node1.NodeId;

                            // ���ƽڵ�����߲���
                            var pe = new PaintEventArgs(pl_flowregion.CreateGraphics(), new Rectangle());
                            DrawPointToPointLine(node1, node2, pe);
                            // ��������״̬
                            drawState = DrawState.Normal;
                            nodeNum = 0;
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("��ѡ��ڶ������̽ڵ�");
                    }
                }
            }
        }
        /// <summary>
        /// ����������߷��ĵ�ö��
        /// </summary>
        enum LineForward
        {
            L_R,
            R_L,
            U_D,
            D_U
        }

        /// <summary>
        /// �������ߵ�ʵ�ַ���- �ж�����λ��
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DrawPointToPointLine(FlowNode ctl1, FlowNode ctl2, PaintEventArgs e)
        {
            // ����2����������
            Point p1, p2;
            //����
            if (Math.Abs(ctl2.Location.X - ctl1.Location.X) > Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.X >= ctl1.Location.X)
            {
                p1 = new Point(ctl1.Location.X + ctl1.Width + 1, ctl1.Location.Y + ctl1.Height / 2);
                p2 = new Point(ctl2.Location.X - 1, ctl2.Location.Y + ctl2.Height / 2);
                DrawJoinLine(p1, p2, LineForward.L_R, e);
            }
            //�ҵ���
            else if (Math.Abs(ctl2.Location.X - ctl1.Location.X) > Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.X < ctl1.Location.X)
            {
                p1 = new Point(ctl1.Location.X - 1, ctl1.Location.Y + ctl1.Height / 2);
                p2 = new Point(ctl2.Location.X + ctl2.Width + 1, ctl2.Location.Y + ctl2.Height / 2);
                DrawJoinLine(p1, p2, LineForward.R_L, e);
            }
            //�ϵ���
            else if (Math.Abs(ctl2.Location.X - ctl1.Location.X) <= Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.Y >= ctl1.Location.Y)
            {

                p1 = new Point(ctl1.Location.X + ctl1.Width / 2, ctl1.Location.Y + ctl1.Height + 1);
                p2 = new Point(ctl2.Location.X + ctl1.Width / 2, ctl2.Location.Y - 1);
                DrawJoinLine(p1, p2, LineForward.U_D, e);
            }
            //�µ���
            else if (Math.Abs(ctl2.Location.X - ctl1.Location.X) < Math.Abs(ctl2.Location.Y - ctl1.Location.Y) && ctl2.Location.Y < ctl1.Location.Y)
            {
                p1 = new Point(ctl1.Location.X + ctl1.Width / 2, ctl1.Location.Y - 1);
                p2 = new Point(ctl2.Location.X + ctl2.Width / 2, ctl2.Location.Y + ctl2.Height + 1);
                DrawJoinLine(p1, p2, LineForward.D_U, e);

            }
        }

        /// <summary>
        /// ����������֮�������
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="forward"></param>
        private void DrawJoinLine(Point p1, Point p2, LineForward forward, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // ������Ǻ���
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
        #region �༭�������ػ���¼�
        private void pl_flowregion_Paint(object sender, PaintEventArgs e)
        {
            var currentControl = sender as Control;
            // �����нڵ�Ĺ�ϵ���߻��Ƴ���
            DrawAllLines(currentControl, e);
        }

        private void DrawAllLines(Control control, PaintEventArgs e)
        {
            // ��ȡ��ǰ���̱༭�������������̽ڵ�
            var nodes = control.Controls.OfType<FlowNode>();
            foreach (var node1 in nodes) 
            {
                foreach (var node2 in nodes)
                {
                    // �жϴ�����ϵ
                    if (node1.NextNodeId != null && node1.NextNodeId == node2.NodeId) 
                    {
                        if (node1 != node2) 
                        {
                            // ��������
                            DrawPointToPointLine(node1, node2, e);
                        }
                    }
                }
            }
        }
        #endregion
        #region �Ҽ�����ִ���߼�
        private void tm_link_Click(object sender, EventArgs e)
        {
            // �ѻ���״̬�޸�Ϊ����״̬
            drawState = DrawState.DrawLine;
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Label panel = sender as Label;
            using (Pen pen = new Pen(Color.AliceBlue, 3)) // ���ñ߿���ɫ�Ϳ��
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
