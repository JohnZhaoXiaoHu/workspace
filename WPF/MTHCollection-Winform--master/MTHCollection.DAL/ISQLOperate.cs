using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.DAL
{
    public interface ISQLOperate<T> where T : class
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">要插入的实体模型</param>
        /// <returns></returns>
        public Task<int> InsertAsync(T model);


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">数据表的主键</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model">要修改的实体模型</param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(T model);


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="word">查询关键词</param>
        /// <returns></returns>
        public Task<IList<T>> GetListAsync(string? word);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync(int id);

    }
}
