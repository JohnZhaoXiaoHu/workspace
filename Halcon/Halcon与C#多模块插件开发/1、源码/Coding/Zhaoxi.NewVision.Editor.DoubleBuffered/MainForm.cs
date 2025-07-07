namespace Zhaoxi.NewVision.Editor
{
    public partial class MainForm : Form
    {
        private bool isDrawing;
        private Point p1;
        private Point p2;
        private Point p3;
        private Point p4;
        public MainForm()
        {
            InitializeComponent();
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

            // 生成label
            var newLb = new Label();
            newLb.MouseDown += NewLb_MouseDown;
            newLb.MouseMove += NewLb_MouseMove;
            newLb.Size = new Size(150, 40);
            newLb.Text = dragObj.Text;
            newLb.TextAlign = ContentAlignment.MiddleCenter;
            newLb.BackColor = Color.Teal;
            newLb.ForeColor = Color.WhiteSmoke;
            newLb.Location = container.PointToClient(new Point(e.X, e.Y));
            // 添加到容器中
            container.Controls.Add(newLb);
        }
        #endregion
        #region 编辑容器中节点移动逻辑
        private void NewLb_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 获取当前移动控件
                var currentControl = sender as Control;
                currentControl.Left += e.X - currentControl.Width / 2;
                currentControl.Top += e.Y - currentControl.Height / 2;
                // 更新两个节点间连线
                UpdateLinkLine();

                // 手动触发重绘
                pl_flowregion.Invalidate();
            }
        }

        /// <summary>
        /// 更新连线的位置方法
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateLinkLine()
        {
            if (isDrawing) 
            {
                // 获取到需要绘制连线的两个点，其实就是编辑器中两个节点中心位置
                var items = pl_flowregion.Controls;
                var nodes = items.OfType<Label>();
                var n1 = nodes.ElementAt(0);
                var n2 = nodes.ElementAt(1);
                var n3 = nodes.ElementAt(2);
                var n4 = nodes.ElementAt(3);
                // 获取当前控件中心位置
                p1 = nodes.ElementAt(0).Location + new Size(n1.Width / 2, n1.Height / 2);
                p2 = nodes.ElementAt(1).Location + new Size(n2.Width / 2, n2.Height / 2);
                p3 = nodes.ElementAt(2).Location + new Size(n3.Width / 2, n3.Height / 2);
                p4 = nodes.ElementAt(3).Location + new Size(n4.Width / 2, n4.Height / 2);
            }

        }


        #endregion
        #region 鼠标按下时候
        private void NewLb_MouseDown(object sender, MouseEventArgs e)
        {
            var currentControl = sender as Control;
            currentControl.Capture = true;
        }
        #endregion
        #region 编辑器容器重绘的事件
        private void pl_flowregion_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            // 如果你是绘制状态，就会两个节点的连线
            if (isDrawing)
            {
                e.Graphics.DrawLine(new Pen(Brushes.Red, 10), p1, p2);
                e.Graphics.DrawLine(new Pen(Brushes.Red, 10), p2, p3);
                e.Graphics.DrawLine(new Pen(Brushes.Red, 10), p3, p4);
            }
        }
        #endregion
        #region 右键连线执行逻辑
        private void tm_link_Click(object sender, EventArgs e)
        {
            isDrawing = true;
        }
        #endregion

    }
}
