using HslCommunication.Secs.Types;
using MTHCollection.Controls;
using MTHCollection.Models;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHCollection.Project.Dialog
{
    public partial class FrmUpdateParam : UIForm
    {
        public FrmUpdateParam()
        {
            InitializeComponent();
        }

        THSetBaseControl currentControl = null;
        private void FrmUpdateParam_Load(object sender, EventArgs e)
        {
            THSetBaseControl control=(this.Tag as THSetBaseControl);
            currentControl=control;
            labParamName.Text = control?.Title;
            labCurrentValue.Text = control?.CurrentValue.ToString();
        }

       private object GetRealVaribleValue(string value)
        {
            string varibleName = currentControl.BindingVarName;
            VaribleModel model = CommonParam.CurrentDevice.GetVarible(varibleName);
            short realvalue = (short)(float.Parse(value) / model.Scale - model.Offset);
            return realvalue;
            
        }

        private void btn_SureUpdate_Click(object sender, EventArgs e)
        {
            if(currentControl!=null)
            {
               string varibleName = currentControl.BindingVarName;
               try
                {
                    object value = GetRealVaribleValue(tbUpdateValue.Text.Trim());
                    bool result = CommonParam.WriteData(varibleName, value);
                    if (result)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("写入失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("写入失败"+ex.Message);
                }
            }
        }

       
    }
}
