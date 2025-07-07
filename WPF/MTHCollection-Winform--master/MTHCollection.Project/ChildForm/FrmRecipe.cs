using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTHCollection.BLL;
using MTHCollection.Common;
using MTHCollection.Controls;
using MTHCollection.Models;
using VaribleConfig.DAL.Helper;

namespace MTHCollection.Project.ChildForm
{
    public partial class FrmRecipe : UserControl
    {
        public FrmRecipe()
        {
            InitializeComponent();
        }

        private void FrmRecipe_Load(object sender, EventArgs e)
        {
            dgRecipe.AutoGenerateColumns = false;
            recipeInfoList = recipeManager.GetAllRecipeInfo();
            dgRecipe.DataSource = null;
            dgRecipe.DataSource = recipeInfoList;

            CommonParam.CurrentRecipeInfo = recipeManager.GetCurrentRecipeInfo();
            tbCurrentRecipeName.Text=CommonParam.CurrentRecipeInfo.RecipeName;
            Refresh(CommonParam.CurrentRecipeInfo);

  
            for(int i=0;i<dgRecipe.Rows.Count;i++)
            {
                if (dgRecipe.Rows[i].Cells["RecipeName"].Value.ToString() == CommonParam.CurrentRecipeInfo.RecipeName)
                {
                    dgRecipe.Rows[i].Selected = true;
                }
            }
        }

        private List<RecipeInfoModel> recipeInfoList = new List<RecipeInfoModel>();
        private RecipeManager recipeManager = new RecipeManager();

        #region 新增配方
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            List<RecipeModel> recipeList = new List<RecipeModel>();
            recipeList.Add(recipeControl1.BindingRecipe);
            recipeList.Add(recipeControl2.BindingRecipe);
            recipeList.Add(recipeControl3.BindingRecipe);
            recipeList.Add(recipeControl4.BindingRecipe);
            recipeList.Add(recipeControl5.BindingRecipe);
            recipeList.Add(recipeControl6.BindingRecipe);

            RecipeInfoModel recipeInfo = new RecipeInfoModel()
            {
                RecipeIndex = recipeInfoList.Count + 1,
                RecipeName = tbRecipeName.Text,
                RecipeList = recipeList,
            };

            //检查配方名称是否重复
            if (recipeManager.IsExitRecipeName(recipeInfoList, recipeInfo.RecipeName))
            {
                MessageBox.Show("配方名称重复，请重新输入");
                return;
            }

            //todo:将配方信息保存到Json文件
            try
            {
                bool b = recipeManager.AddRecipeInfo(recipeInfoList, recipeInfo);
                if (b)
                {
                    dgRecipe.DataSource= null;
                    dgRecipe.DataSource = recipeInfoList;

                }
                else
                {
                    MessageBox.Show("配方添加失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 删除配方
        private void btnDeleteRecipe_Click(object sender, EventArgs e) 
        {
            string infoName = dgRecipe.CurrentRow.Cells["RecipeName"].Value.ToString();
            try
            {
                recipeManager.DeleteRecipeInfo(recipeInfoList, infoName);
                dgRecipe.DataSource = null;
                dgRecipe.DataSource = recipeInfoList;
                Refresh(recipeInfoList[0]);
                dgRecipe.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 更新配方
        private void btnUpdateRecipe_Click(object sender, EventArgs e) 
        {
            int rowIndex = dgRecipe.CurrentRow.Index;
            string infoName = dgRecipe.CurrentRow.Cells["RecipeName"].Value.ToString();
            var info = recipeManager.GetRecipeInfoByName(recipeInfoList, infoName);
            if(info != null)
            {
                try
                {
                    RecipeInfoModel updateInfo = new RecipeInfoModel()
                    {
                        RecipeIndex = info.RecipeIndex,
                        RecipeName = info.RecipeName,
                        RecipeList = new List<RecipeModel>()
                        {
                            recipeControl1.BindingRecipe,
                            recipeControl2.BindingRecipe,
                            recipeControl3.BindingRecipe,
                            recipeControl4.BindingRecipe,
                            recipeControl5.BindingRecipe,
                            recipeControl6.BindingRecipe
                        }
                    };
                    

                    recipeManager.UpdateRecipeInfo(recipeInfoList, updateInfo);
                    dgRecipe.DataSource = null;
                    dgRecipe.DataSource = recipeInfoList;
                    dgRecipe.Rows[rowIndex].Selected = true;
                    Refresh(updateInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 应用配方
        private bool WriteData(VaribleModel model,object value)
        {
            bool result = false;
            if(model != null)
            {
                short realValue=Convert.ToInt16((float)value/model.Scale-model.Offset);
                result=CommonParam.WriteData(model.VaribleName, realValue);
            }
            return result;
        }
        private async void btnApplyRecipe_Click(object sender, EventArgs e) 
        {
           
            foreach (var control in this.Controls)
            {               
                if(control is RecipeControl recipeControl)
                {
                   await Task.Run(() =>
                    {
                        var varibleTH = CommonParam.CurrentDevice.GetVarible(recipeControl.THeighBindingVarName);
                        var varibleTW = CommonParam.CurrentDevice.GetVarible(recipeControl.TLowBindingVarName);
                        var varibleHuH = CommonParam.CurrentDevice.GetVarible(recipeControl.HuHeightBindingVarName);
                        var varibleHuL = CommonParam.CurrentDevice.GetVarible(recipeControl.HuLowBindingVarName);
                        var varibleTAlarmUse= CommonParam.CurrentDevice.GetVarible(recipeControl.TAlarmUseBindingVarName);
                        var varibleHuAlarmUse = CommonParam.CurrentDevice.GetVarible(recipeControl.HAlarmUseBindingVarName);
                        WriteData(varibleTH, recipeControl.BindingRecipe.TemperatureHeigh);
                        WriteData(varibleTW, recipeControl.BindingRecipe.TemperatureLow);
                        WriteData(varibleHuH, recipeControl.BindingRecipe.HumidityHeght);
                        WriteData(varibleHuL, recipeControl.BindingRecipe.HumidityLow);
                        float tAlarmUseValue= recipeControl.BindingRecipe.IsTemperatureAlarmUse ? 1 : 0;
                        WriteData(varibleTAlarmUse, tAlarmUseValue);
                        float hAlarmUseValue = recipeControl.BindingRecipe.IsHumidityAlarmUse ? 1 : 0;
                        WriteData(varibleHuAlarmUse, hAlarmUseValue);

                    });
                    
                }
                            
            }
            
            MessageBox.Show("配方应用成功");
            string recipeName = dgRecipe.CurrentRow.Cells["RecipeName"].Value.ToString();
            var info = recipeManager.GetRecipeInfoByName(recipeInfoList, recipeName);
            CommonParam.CurrentRecipeInfo = info;
        }
        #endregion

        #region 绘制表格单元格颜色
        private void dgRecipe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewHelper.DgvStyle(
                dgRecipe,
                Color.FromArgb(4, 21, 65),
                Color.FromArgb(4, 21, 65),
                Color.FromArgb(4, 21, 65)
            );
        }

        #endregion


        #region 刷新配方显示
        private void Refresh(RecipeInfoModel info)
        {
            if (info != null)
            {
                tbCurrentRecipeName.Text = info.RecipeName;
                if (info.RecipeList != null)
                {
                    recipeControl1.BindingRecipe = info.RecipeList[0];
                    recipeControl2.BindingRecipe = info.RecipeList[1];
                    recipeControl3.BindingRecipe = info.RecipeList[2];
                    recipeControl4.BindingRecipe = info.RecipeList[3];
                    recipeControl5.BindingRecipe = info.RecipeList[4];
                    recipeControl6.BindingRecipe = info.RecipeList[5];
                }
            }
        }
        #endregion


        #region 表格单元格点击事件
        private void dgRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string infoName = dgRecipe.CurrentRow.Cells["RecipeName"].Value.ToString();
            var info = recipeManager.GetRecipeInfoByName(recipeInfoList, infoName);
            Refresh(info);
            
        }
        #endregion
    }
}
