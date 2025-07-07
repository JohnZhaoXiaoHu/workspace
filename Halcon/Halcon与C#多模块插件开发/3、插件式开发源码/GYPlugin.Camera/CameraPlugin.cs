using GYBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPlugin.Camera
{
    [Category("图像采集")]
    [DisplayName("相机采集")]
    public class CameraPlugin : AbstractPlugin
    {
        public override void RunPlugin()
        {
            MessageBox.Show("相机采集执行");
        }

        public override void RunForm()
        {
            new CameraView().ShowDialog();
        }
    }
}
