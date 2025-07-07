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

        #region �ѹ������Ͻ�����
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// ��ק�����������¼�
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
        /// ��ק���õ�������ɵ��¼�
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

            flowNode.NodeLinkStartClick += FlowNode_NodeLinkStartClick; //�ڵ����߿�ʼ�¼�
            flowNode.NodeLinkEndClick += FlowNode_NodeLinkEndClick; //�ڵ����߽����¼�
            flowNode.MouseDoubleClick += FlowNode_MouseDoubleClick; //�ڵ�˫���¼�
            flowNode.DeleNode_Click += FlowNode_DeleNode_Click; //�ڵ�ɾ���¼�
            flowNode.DeleInputLink_Click += FlowNode_DeleInputLink_Click; //�ڵ���������ɾ���¼�
            flowNode.DeleOutputLink_Click += FlowNode_DeleOutputLink_Click; //�ڵ��������ɾ���¼�

            flowDic[tabControl1.SelectedTab].Add(flowNode); //�ѽڵ���ӵ���ǰ���̵��ֵ��ֵ
            panel.Controls.Add(flowNode);
        }

        #endregion





        #region �ڵ����˫���¼�
        private void FlowNode_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            var node = sender as FlowNode;
            if (node != null)
            {
                //��ȡ��Ӧ�Ĳ������,�򿪲������
                IPlugin pluginService = PluginFactory.GetPluginService(node);
                pluginService.ShowPluginWindow(node);

                //���ݽڵ������������֮���ߵĺ����ڵ���������
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


        #region �ڵ�ɾ���¼�
        private void FlowNode_DeleNode_Click(object? sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("ȷ��Ҫɾ���ýڵ���", "��ʾ", MessageBoxButtons.OKCancel);
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


        #region �ڵ���������ɾ���¼�

        private void DeleteNodeInputLink(FlowNode node)
        {
            if (node != null)
            {
                if (node.InputPathInfo != null)
                {
                    //���������Ϣ
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

        #region �ڵ��������ɾ���¼�
        private void DeleteNodeOutputLink(FlowNode node)
        {
            if (node != null)
            {
                if (node.OutputPathInfos.Count > 0)
                {
                    //���������Ϣ
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
        /// �洢��ǰ������������Ϣ�����̽ڵ㼯����Ϣ���̰߳�ȫ�������ֵ�
        /// </summary>
        private OrderedSafeDictionary<TabPage, List<FlowNode>> flowDic =
            new OrderedSafeDictionary<TabPage, List<FlowNode>>();

        #region  �ڵ�֮�������

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
                int x = panel.Left + panel.Width / 2; //�ҵ���������������panel�����ĵ�����
                int y = panel.Top; //e.Top�����������Ͻ������������panel��������
                currentLinkInfo.EndPoint = flowPanel.PointToClient(
                    contentPanel.PointToScreen(new Point(x, y)) //�����������Ͻ������������panel������ת��Ϊ�������Ļ������,��ת��Ϊ����ڹ�����������
                );
                currentLinkInfo.StartNode.OutputPathInfos.Add(currentLinkInfo);
                currentLinkInfo.EndNode.InputPathInfo = currentLinkInfo;

                //����ʼ�ڵ������������ݸ��յ�����������
                currentLinkInfo.EndNode.InputParam = currentLinkInfo.StartNode.OutputParam;

                //��¼�Ѿ����ӵĽڵ���Ϣ
                //flowNodeList.Add(currentLinkInfo.StartNode);



                //ͨ��Invalidate����������Mypanel��Paint�¼������ػ�
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


        #region  ���̽ڵ������ػ��¼�

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


        #region �ڵ��������ڲ����ƶ�
        /// <summary>
        ///���̽ڵ���갴���¼�
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
        /// ��ȡ���ڵ�
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
        /// ���̽ڵ�����ƶ��¼�
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
                    SetNodeNewPosion(node, control, e); //���ýڵ���λ��

                    //�����ǰ�ڵ�����������ڵ������,�ı���֮��ص����ߵ���λ��
                    SetNodeLinkNewPosion(node);

                    //���ýڵ�������ߵ���λ��
                    SetNodeLinkNewPosion(node);
                }
            }
        }

        /// <summary>
        /// �������̽ڵ����λ��
        /// </summary>
        /// <param name="node">��ǰ�����̽ڵ�</param>
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
        /// ���ýڵ������ߵ���λ��
        /// </summary>
        /// <param name="node">��ǰ�����̽ڵ�</param>
        private void SetNodeLinkNewPosion(FlowNode node)
        {
            var nodePanel = node.Parent as MyPanel;
            if (node.InputPathInfo != null) //�����ǰ�ڵ��������·��,�ı��·�����յ�����
            {
                //��ȡTop�������������Ļ������
                var endPointFromScreen = node.GetTopConnectorScreenPoint();

                //��Top�������������Ļ������ת��ΪTop�����������nodePanel������
                var endPoint = nodePanel.PointToClient(endPointFromScreen);

                node.InputPathInfo.EndPoint = endPoint;
            }
            if (node.OutputPathInfos.Count > 0) //�����ǰ�ڵ�������·��,�ı��������·�����������
            {
                foreach (var outputInfo in node.OutputPathInfos)
                {
                    //��ȡBottom�������������Ļ������
                    var startPointFromScreen = node.GetBottomConnectorScreenPoint();

                    //��Bottom�������������Ļ������ת��ΪBottom�����������nodePanel������
                    var startPoint = nodePanel.PointToClient(startPointFromScreen);
                    outputInfo.StartPoint = startPoint;
                }
            }

            //�ػ�
            nodePanel.Invalidate();
        }

        #endregion





        #region  ��������¼�
        private void FormMain_Load(object sender, EventArgs e)
        {
            //������нڵ�
            treeView1.Nodes.Clear();

            //��ȡ���в�����������
            var dic = PluginFactory.GetAllPluginCategoryAndName();
            var rootNodeNames = dic.Keys.ToList();

            //�����в�������Ϊ����㣬��ÿ������µĲ����Ϊ�ӽڵ㣬��ӵ�����
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

            tabControl1.Controls.Clear(); //�����������ѡ�
            tabControl1.ContextMenuStrip = contextMenuStrip1; //��������ѡ��Ҽ��˵�

            PluginFactory.PluginViewAction += PluginFactory_PluginViewAction;

            PluginFactory.PluginMessageAction += PluginFactory_PluginMessageAction;

            dgvLog.AutoGenerateColumns = false;
        }

        #endregion

        #region ��������¼�
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

        #region ����ɾ���¼�
        private void menuItem_DeleteFlow_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl1.SelectedTab;
            var result = MessageBox.Show("�Ƿ�ȷ��ɾ����ǰ����", "��ʾ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                flowDic.Remove(selectedPage);
                tabControl1.Controls.Remove(selectedPage);
            }
        }
        #endregion


        #region  �������ί��,��ͼ��ʾ���������ɺ�Ķ���
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


        #region �������ί��,���������ɺ������־
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
