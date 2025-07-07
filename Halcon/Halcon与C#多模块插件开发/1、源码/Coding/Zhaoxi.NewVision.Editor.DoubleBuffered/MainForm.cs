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

            // ����label
            var newLb = new Label();
            newLb.MouseDown += NewLb_MouseDown;
            newLb.MouseMove += NewLb_MouseMove;
            newLb.Size = new Size(150, 40);
            newLb.Text = dragObj.Text;
            newLb.TextAlign = ContentAlignment.MiddleCenter;
            newLb.BackColor = Color.Teal;
            newLb.ForeColor = Color.WhiteSmoke;
            newLb.Location = container.PointToClient(new Point(e.X, e.Y));
            // ��ӵ�������
            container.Controls.Add(newLb);
        }
        #endregion
        #region �༭�����нڵ��ƶ��߼�
        private void NewLb_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // ��ȡ��ǰ�ƶ��ؼ�
                var currentControl = sender as Control;
                currentControl.Left += e.X - currentControl.Width / 2;
                currentControl.Top += e.Y - currentControl.Height / 2;
                // ���������ڵ������
                UpdateLinkLine();

                // �ֶ������ػ�
                pl_flowregion.Invalidate();
            }
        }

        /// <summary>
        /// �������ߵ�λ�÷���
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateLinkLine()
        {
            if (isDrawing) 
            {
                // ��ȡ����Ҫ�������ߵ������㣬��ʵ���Ǳ༭���������ڵ�����λ��
                var items = pl_flowregion.Controls;
                var nodes = items.OfType<Label>();
                var n1 = nodes.ElementAt(0);
                var n2 = nodes.ElementAt(1);
                var n3 = nodes.ElementAt(2);
                var n4 = nodes.ElementAt(3);
                // ��ȡ��ǰ�ؼ�����λ��
                p1 = nodes.ElementAt(0).Location + new Size(n1.Width / 2, n1.Height / 2);
                p2 = nodes.ElementAt(1).Location + new Size(n2.Width / 2, n2.Height / 2);
                p3 = nodes.ElementAt(2).Location + new Size(n3.Width / 2, n3.Height / 2);
                p4 = nodes.ElementAt(3).Location + new Size(n4.Width / 2, n4.Height / 2);
            }

        }


        #endregion
        #region ��갴��ʱ��
        private void NewLb_MouseDown(object sender, MouseEventArgs e)
        {
            var currentControl = sender as Control;
            currentControl.Capture = true;
        }
        #endregion
        #region �༭�������ػ���¼�
        private void pl_flowregion_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            // ������ǻ���״̬���ͻ������ڵ������
            if (isDrawing)
            {
                e.Graphics.DrawLine(new Pen(Brushes.Red, 10), p1, p2);
                e.Graphics.DrawLine(new Pen(Brushes.Red, 10), p2, p3);
                e.Graphics.DrawLine(new Pen(Brushes.Red, 10), p3, p4);
            }
        }
        #endregion
        #region �Ҽ�����ִ���߼�
        private void tm_link_Click(object sender, EventArgs e)
        {
            isDrawing = true;
        }
        #endregion

    }
}
