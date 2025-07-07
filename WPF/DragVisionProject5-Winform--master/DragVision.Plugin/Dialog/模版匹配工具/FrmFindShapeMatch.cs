using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragVision.Controls;
using DragVision.Plugin.Params.模版匹配;
using DragVision.Shared.Helper;
using HalconDotNet;

namespace DragVision.Plugin.Dialog.模版匹配工具
{
    public partial class FrmFindShapeMatch : Form
    {
        public FrmFindShapeMatch(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HObject image;
        private HObject matchContours;
        private HWindow hWindow;
        private List<HObject> matchContoursList = new List<HObject>();

        private void FrmFindShapeMatch_Load(object sender, EventArgs e)
        {
            dgMatchResult.AutoGenerateColumns = false;
            if (node.InputParam != null && node.InputParam.ImageParam != null)
            {
                image = node.InputParam.ImageParam;
                hWindow = halconDisplayControl1.GetHWindow();
                hWindow.DispObj(image);
            }
        }

        private async void btnFindMatch_Click(object sender, EventArgs e)
        {
            if (node.InputParam.HandleParam != null)
            {
                FindShapeMatchParam param = new FindShapeMatchParam();
                param.AngleStart = new HTuple(double.Parse(textAngleStart.Text)).TupleRad();
                param.AngleExtent = new HTuple(double.Parse(textAngleExtend.Text)).TupleRad();
                param.MinScore = double.Parse(textMinScore.Text);
                param.NumMatches = int.Parse(textNumMatch.Text);
                param.MaxOverlap = double.Parse(textMaxOverlap.Text);
                param.SubPixel = cbSubpixel.Text;
                param.NumLevels = int.Parse(cbNumLevels.Text);
                param.Greediness = double.Parse(textGridness.Text);

                List<MatchResultParam> resultParams = new List<MatchResultParam>();
                HTuple rows = null;
                HTuple columns = null;
                HTuple angles = null;
                HTuple scores = null;
                double timeSpend = 0;

                
                //查找匹配结果并计算耗时
                timeSpend =await TimeSpanHelper.GetTimeSpanAsync(() =>
                {
                    HOperatorSet.FindShapeModel(
                        image,
                        node.InputParam.HandleParam,
                        param.AngleStart,
                        param.AngleExtent,
                        param.MinScore,
                        param.NumMatches,
                        param.MaxOverlap,
                        param.SubPixel,
                        param.NumLevels,
                        param.Greediness,
                        out rows,
                        out columns,
                        out angles,
                        out scores
                    );
                });

                
                
                //显示匹配耗时
                textMatchTimeSpan.Text = timeSpend.ToString()+"ms";

                //获取匹配结果轮廓
                HOperatorSet.GetShapeModelContours(
                    out matchContours,
                    node.InputParam.HandleParam,
                    1
                );

                //显示匹配个数
                textMatchedNum.Text = scores.DArr.Length.ToString();

                HOperatorSet.SetColor(hWindow, "green");

                resultParams.Clear();
                matchContoursList.Clear();

                //将匹配结果显示到表格中
                for (int i = 0; i < scores.DArr.Length; i++)
                {
                    resultParams.Add(
                        new MatchResultParam()
                        {
                            Row = rows.DArr[i],
                            Column = columns.DArr[i],
                            Angle = angles.DArr[i],
                            Score = scores.DArr[i]
                        }
                    );

                    //仿射变换
                    HOperatorSet.HomMat2dIdentity(out HTuple homMat2D);
                    HOperatorSet.HomMat2dTranslate(homMat2D, rows[i], columns[i], out homMat2D);
                    HOperatorSet.HomMat2dRotate(
                        homMat2D,
                        angles[i],
                        rows[i],
                        columns[i],
                        out homMat2D
                    );
                    HOperatorSet.AffineTransContourXld(
                        matchContours,
                        out HObject transContours,
                        homMat2D
                    );
                    matchContoursList.Add(transContours);
                    //显示匹配结果轮廓
                    hWindow.DispObj(transContours);
                }

                dgMatchResult.DataSource = null;
                dgMatchResult.DataSource = resultParams;
            }
        }

        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if (matchContoursList.Count > 0)
            {
                List<HObject> list = new List<HObject>();
                list.Add(image);
                list.AddRange(matchContoursList);
                PluginFactory.PluginViewAction?.Invoke(list);
                PluginFactory.PluginMessageAction?.Invoke("形状模版匹配查找完成");
                MessageBox.Show("形状模板匹配查找完成");
            }
        }
    }
}
