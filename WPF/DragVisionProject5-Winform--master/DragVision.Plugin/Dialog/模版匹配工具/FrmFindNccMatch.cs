using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class FrmFindNccMatch : Form
    {
        public FrmFindNccMatch(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HObject image;
        private HWindow hWindow;
        private List<HObject> nccMatchContourList = new List<HObject>();
        private List<MatchResultParam> matchResultList = new List<MatchResultParam>();

        private void FrmFindNccMatch_Load(object sender, EventArgs e)
        {
            hWindow = halconDisplayControl1.GetHWindow();
            dgMatchResult.AutoGenerateColumns = false;
            if (node.InputParam != null && node.InputParam.ImageParam != null)
            {
                image = node.InputParam.ImageParam;

                hWindow.DispObj(image);
            }
        }

        /// <summary>
        /// 查找匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFindMatch_Click(object sender, EventArgs e)
        {
            if (node.InputParam.HandleParam != null)
            {
                FindNccMatchParam param = new FindNccMatchParam();
                param.AngleStart = new HTuple(double.Parse(textAngleStart.Text)).TupleRad();
                param.AngleExtent = new HTuple(double.Parse(textAngleExtend.Text)).TupleRad();
                param.MinScore = double.Parse(textMinScore.Text);
                param.NumMatches = int.Parse(textNumMatch.Text);
                param.MaxOverlap = double.Parse(textMaxOverlap.Text);
                param.SubPixel = cbSubpixel.Text;
                param.NumLevels = int.Parse(cbNumLevels.Text);

                HTuple rows = new HTuple();
                HTuple columns = new HTuple();
                HTuple angles = new HTuple();
                HTuple scores = new HTuple();

                double timeSpend = await TimeSpanHelper.GetTimeSpanAsync(() =>
                {
                    HOperatorSet.FindNccModel(
                        image,
                        node.InputParam.HandleParam,
                        param.AngleStart,
                        param.AngleExtent,
                        param.MinScore,
                        param.NumMatches,
                        param.MaxOverlap,
                        param.SubPixel,
                        param.NumLevels,
                        out rows,
                        out columns,
                        out angles,
                        out scores
                    );
                });
                textMatchTimeSpan.Text = timeSpend.ToString()+"ms";


                //获取Ncc模板区域
                HOperatorSet.GetNccModelRegion(out HObject nccModelRegion, node.InputParam.HandleParam);

               

                //提取模板区域的轮廓
                HOperatorSet.GenContourRegionXld(
                    nccModelRegion,
                    out HObject contours,
                    "border"
                );

                HOperatorSet.SetColor(hWindow, "green");
                HOperatorSet.SetDraw(hWindow, "margin");

                matchResultList.Clear();
                nccMatchContourList.Clear();

                if (scores.DArr.Length > 0)
                {
                    textMatchedNum.Text = scores.DArr.Length.ToString();
                    for (int i = 0; i < scores.DArr.Length; i++)
                    {
                        matchResultList.Add(
                            new MatchResultParam()
                            {
                                Row = rows.DArr[i],
                                Column = columns.DArr[i],
                                Angle = angles.DArr[i],
                                Score = scores.DArr[i]
                            }
                        );

                        //仿射变换
                        HOperatorSet.VectorAngleToRigid(
                            0,
                            0,
                            0,
                            rows[i],
                            columns[i],
                            angles[i],
                            out HTuple homMat2D
                        );

                        HOperatorSet.AffineTransContourXld(
                            contours,
                            out HObject contoursAffineTrans,
                            homMat2D
                        );

                        //保存所有的轮廓结果
                        nccMatchContourList.Add(contoursAffineTrans);

                        //显示仿射变换后的模板区域轮廓
                        hWindow.DispObj(contoursAffineTrans);
                    }
                }

                dgMatchResult.DataSource = null;
                dgMatchResult.DataSource = matchResultList;
            }
        }

        /// <summary>
        /// 执行完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if (nccMatchContourList.Count > 0)
            {
                node.OutputParam.ImageParam = image;
                List<HObject> list = new List<HObject>();
                list.Add(image);
                list.AddRange(nccMatchContourList);
                PluginFactory.PluginViewAction?.Invoke(list);
                PluginFactory.PluginMessageAction?.Invoke("NCC模版匹配完成");
                MessageBox.Show("NCC模版匹配完成");
            }
        }
    }
}
