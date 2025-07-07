using GYBase;
using GYPlugin;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zhaoxi.NewVision.Editor.helper;
using Zhaoxi.Vision.Flow.Proj.VFrame;

namespace Zhaoxi.NewVision.Editor.mycontrols
{
    public partial class FlowNode : UserControl
    {
        // 定义当前节点的ID
        public string NodeId { get; set; } = Guid.NewGuid().ToString();
        // 定义上一个节点属性
        public string PreNodeId { get; set; }

        // 定义下一个节点属性
        public string NextNodeId { get; set; }
        // 定义用户控件的标题属性
        [Category("自定义流程控件")]
        public string NodeName { get => lbTitle.Text; set => lbTitle.Text = value; }

        // 定义流程节点的输入与输出
        public HObject Input;
        public HObject Output;
        public HTuple[] InputTuple;
        public HTuple[] OutputTuple;

        public HObject[] Outputs { get; internal set; }
        public HTuple[] RoiOutput { get; internal set; }

        public FlowNode()
        {
            InitializeComponent();
        }
        #region 注册流程节点的双击事件
        private void FlowNode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //// 获取当前点击节点的前置节点（父节点）
            //FlowNode parentNode = FlowNodeTool.GetPreNode(this);
            //// 知道你点击那个节点,就是当前节点，节点名称就知道了
            //switch (NodeName) 
            //{
            //    case "图像采集":
            //        new LoadImageFrm(parentNode, this).ShowDialog();
            //        break;
            //    case "绘制ROI":
            //        new DrawROIFrm(this).ShowDialog();
            //        break;
            //    case "新建模板":
            //        new CreateModelFrm(this).ShowDialog();
            //        break;
            //}

            // 节点的名称和插件对应key是对应的
            var pluginInfo = PluginInstall.pluginDic[NodeName];
            // 获取插件类型
            var type = pluginInfo.PluginType;
            // 通过反射创建对应实例
            var pluginInstance = (IPluginBase)Activator.CreateInstance(type);
            // 运行对应插件窗口
            pluginInstance.RunForm();
            
        }
        #endregion

    }
}
