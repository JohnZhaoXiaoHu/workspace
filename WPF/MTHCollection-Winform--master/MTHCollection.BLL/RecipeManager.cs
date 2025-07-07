using System.Security.Cryptography.Pkcs;
using MTHCollection.Models;
using VaribleConfig.DAL.Helper;

namespace MTHCollection.BLL
{
    public class RecipeManager
    {
        private string recipeBasePath = AppDomain.CurrentDomain.BaseDirectory + "//Recipe//";

        /// <summary>
        /// 配方名称是否已经存在
        /// </summary>
        /// <param name="recipeInfoList">要添加的配方信息列表</param>
        /// <param name="recipeName">配方名称</param>
        /// <returns></returns>
        public bool IsExitRecipeName(List<RecipeInfoModel> recipeInfoList, string recipeName)
        {
            var recipeInfo = recipeInfoList.Find(r => r.RecipeName == recipeName);
            return recipeInfo != null;
        }

        /// <summary>
        /// 添加配方信息
        /// </summary>
        /// <param name="recipeInfoList"></param>
        /// <param name="addRecipeInfo"></param>
        public bool AddRecipeInfo(
            List<RecipeInfoModel> recipeInfoList,
            RecipeInfoModel addRecipeInfo
        )
        {
            recipeInfoList.Add(addRecipeInfo);
            bool result = false;
            if (!File.Exists(recipeBasePath))
            {
                Directory.CreateDirectory(recipeBasePath);
            }
            try
            {
                new JsonFileHelper().SerializeAndSave(
                    recipeInfoList,
                    recipeBasePath + "AllRecipe.Json"
                );
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("添加配方信息失败" + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取所有配方信息
        /// </summary>
        /// <returns></returns>
        public List<RecipeInfoModel> GetAllRecipeInfo()
        {
            var list = new JsonFileHelper().DeserializeAndLoad<List<RecipeInfoModel>>(
                recipeBasePath + "AllRecipe.Json"
            );
            return list;
        }

        /// <summary>
        /// 根据配方名称获取配方信息
        /// </summary>
        /// <param name="recipeInfoList"></param>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        public RecipeInfoModel GetRecipeInfoByName(List<RecipeInfoModel> recipeInfoList, string recipeName)
        {
            return recipeInfoList.Find(r => r.RecipeName == recipeName);
        }

        /// <summary>
        /// 保存当前配方信息
        /// </summary>
        /// <param name="info"></param>
        public void SaveCurrentRecipeInfo(RecipeInfoModel info)
        {
            new JsonFileHelper().SerializeAndSave(info, recipeBasePath + "CurrentRecipe.Json");
        }

        /// <summary>
        /// 获取当前配方信息
        /// </summary>
        /// <returns></returns>
        public RecipeInfoModel GetCurrentRecipeInfo()
        {
            return new JsonFileHelper().DeserializeAndLoad<RecipeInfoModel>(recipeBasePath + "CurrentRecipe.Json");
        }

        /// <summary>
        /// 删除配方信息
        /// </summary>
        /// <param name="recipeInfoList"></param>
        /// <param name="recipeName"></param>
        public void DeleteRecipeInfo(List<RecipeInfoModel> recipeInfoList, string recipeName)
        {
            var recipeInfo = recipeInfoList.Find(r => r.RecipeName == recipeName);
            recipeInfoList.Remove(recipeInfo);
            try
            {
                new JsonFileHelper().SerializeAndSave(recipeInfoList, recipeBasePath + "AllRecipe.Json");
            }
            catch (Exception ex)
            {
                throw new Exception("删除配方信息失败" + ex.Message);
            }
            
        }

        /// <summary>
        /// 修改配方信息
        /// </summary>
        /// <param name="recipeInfoList"></param>
        /// <param name="updateRecipeInfo"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateRecipeInfo(List<RecipeInfoModel> recipeInfoList, RecipeInfoModel updateRecipeInfo)
        {
            var Info = recipeInfoList.Find(r => r.RecipeName == updateRecipeInfo.RecipeName);
            if( Info != null)
            {
                recipeInfoList[recipeInfoList.IndexOf(Info)] = updateRecipeInfo;
            }
            try
            {
                new JsonFileHelper().SerializeAndSave(recipeInfoList, recipeBasePath + "AllRecipe.Json");
            }
            catch (Exception ex)
            {
                throw new Exception("修改配方信息失败" + ex.Message);
            }
        }
    }
}
