using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragVision.Controls;

namespace DragVision.Shared.Helper
{
    /// <summary>
    /// 点连接成路径帮助类
    /// </summary>
    public class PointLinkToPathHelper
    {
        /// <summary>
        /// 绘制路径
        /// </summary>
        /// <param name="startPoint2">起始点</param>
        /// <param name="endPoint2">终点</param>
        /// <param name="e">绘制事件</param>
        public static void DrawPath(Point startPoint2, Point endPoint2, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // 启用抗锯齿

            // 计算中间转折点（图示中的直角转折）
            Point midPoint = new Point(endPoint2.X, startPoint2.Y); // 先水平后垂直

            GraphicsPath path = new GraphicsPath();

            // 创建两段式折线路径
            path.AddLine(startPoint2, midPoint); // 水平段
            path.AddLine(midPoint, endPoint2); // 垂直段

            // 绘制深绿色路径（线宽2px更符合图示比例）
            using (Pen pathPen = new Pen(Color.FromArgb(0, 100, 0), 2))
            {
                pathPen.LineJoin = LineJoin.Round; // 圆角连接点
                e.Graphics.DrawPath(pathPen, path);
            }

            // 绘制终点箭头（适配最后线段方向）
            using (Pen arrowPen = new Pen(Color.FromArgb(0, 100, 0), 2))
            {
                // 计算最后一段的角度
                float angle = (float)Math.Atan2(endPoint2.Y - midPoint.Y, endPoint2.X - midPoint.X);

                // 创建方向自适应的箭头
                arrowPen.CustomEndCap = new AdjustableArrowCap(8, 8);
                e.Graphics.DrawLine(arrowPen, midPoint, endPoint2); // 仅绘制带箭头的最后一段
            }
        }

        /// <summary>
        /// 绘制路径
        /// </summary>
        /// <param name="startPoint2">起点坐标</param>
        /// <param name="endPoint2">终点坐标</param>
        /// <param name="e">绘制事件</param>
        /// <param name="allNodes">流程内所有的连接结点</param>
        public static void DrawPath(
            Point startPoint2,
            Point endPoint2,
            PaintEventArgs e,
            List<FlowNode> allNodes
        )
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // 抗锯齿

            // 简单的自动避障逻辑
            Point controlPoint1,
                controlPoint2;
            bool isCollision = false;
            foreach (var node in allNodes)
            {
                // 检查连线是否会穿过节点
                if (IsLineIntersectingRectangle(startPoint2, endPoint2, node.Bounds))
                {
                    isCollision = true;
                    break;
                }
            }

            if (isCollision)
            {
                // 如果有碰撞，调整控制点以避开节点
                controlPoint1 = new Point(
                    startPoint2.X + (endPoint2.X - startPoint2.X) / 2,
                    startPoint2.Y - 50
                );
                controlPoint2 = new Point(
                    startPoint2.X + (endPoint2.X - startPoint2.X) / 2,
                    endPoint2.Y + 50
                );
            }
            else
            {
                // 没有碰撞，正常设置控制点
                controlPoint1 = new Point(
                    startPoint2.X + (endPoint2.X - startPoint2.X) / 2,
                    startPoint2.Y
                );
                controlPoint2 = new Point(
                    startPoint2.X + (endPoint2.X - startPoint2.X) / 2,
                    endPoint2.Y
                );
            }

            GraphicsPath path = new GraphicsPath();

            // 使用贝塞尔曲线添加路径
            path.AddBezier(startPoint2, controlPoint1, controlPoint2, endPoint2);

            // 绘制绿色路径，边框2px，这里示例为绿色
            using (Pen pathPen = new Pen(Color.FromArgb(0, 100, 0), 2))
            {
                pathPen.LineJoin = LineJoin.Round; // 圆角连接
                e.Graphics.DrawPath(pathPen, path);
            }

            // 在终点绘制圆圈
            int circleRadius = 8;
            Rectangle circleRect = new Rectangle(
                endPoint2.X - circleRadius,
                endPoint2.Y - circleRadius,
                circleRadius * 2,
                circleRadius * 2
            );
            using (Brush circleBrush = new SolidBrush(Color.FromArgb(0, 100, 0)))
            {
                e.Graphics.FillEllipse(circleBrush, circleRect);
            }
        }

        /// <summary>
        /// 检查线段是否与矩形相交
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        private static bool IsLineIntersectingRectangle(Point p1, Point p2, Rectangle rect)
        {
            // 检查线段的端点是否在矩形内
            if (rect.Contains(p1) || rect.Contains(p2))
            {
                return true;
            }

            // 检查线段是否与矩形的四条边相交
            Point[] rectPoints =
            {
                new Point(rect.Left, rect.Top),
                new Point(rect.Right, rect.Top),
                new Point(rect.Right, rect.Bottom),
                new Point(rect.Left, rect.Bottom)
            };

            for (int i = 0; i < 4; i++)
            {
                Point p3 = rectPoints[i];
                Point p4 = rectPoints[(i + 1) % 4];
                if (IsIntersecting(p1, p2, p3, p4))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 检查两条线段是否相交
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        private static bool IsIntersecting(Point p1, Point p2, Point p3, Point p4)
        {
            int orientation1 = Orientation(p1, p2, p3);
            int orientation2 = Orientation(p1, p2, p4);
            int orientation3 = Orientation(p3, p4, p1);
            int orientation4 = Orientation(p3, p4, p2);

            if (orientation1 != orientation2 && orientation3 != orientation4)
            {
                return true;
            }

            return false;
        }

        // 计算三个点的方向
        private static int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0)
            {
                return 0; // 共线
            }
            return (val > 0) ? 1 : 2; // 顺时针或逆时针
        }
    }
}
