using GYBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPlugin.GrabImage
{
    [Category("图像采集")]
    [DisplayName("本地采集")]
    public class GrabImagePlugin : AbstractPlugin
    {
        public override void RunPlugin()
        {
            MessageBox.Show("本地采集执行");
        }

        public override void RunForm()
        {
            var frm = new GrabImageView();
            frm.ShowDialog();
        }
    }
}
