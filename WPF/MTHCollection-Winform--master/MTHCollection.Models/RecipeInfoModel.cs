using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Models
{
    /// <summary>
    /// 配方信息实体
    /// </summary>
    public class RecipeInfoModel
    {
        /// <summary>
        /// 配方序号
        /// </summary>
        public int RecipeIndex { get; set; }

        /// <summary>
        /// 配方名称
        /// </summary>
        public string RecipeName { get; set; }

        /// <summary>
        /// 配方列表
        /// </summary>
        public List<RecipeModel> RecipeList { get; set; }
    }
}
