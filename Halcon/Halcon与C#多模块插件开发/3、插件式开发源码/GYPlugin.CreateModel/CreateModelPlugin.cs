using GYBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPlugin.CreateModel
{
    [Category("形状模板匹配")]
    [DisplayName("模板创建")]
    public class CreateModelPlugin : AbstractPlugin
    {
        public override void RunForm()
        {
            var frm = new CreateModelView();
            frm.ShowDialog();
        }

        public override void RunPlugin()
        {
            MessageBox.Show("插件执行->模板创建");
        }
    }
}
