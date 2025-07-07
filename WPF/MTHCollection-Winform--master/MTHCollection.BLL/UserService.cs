using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTHCollection.DAL;
using MTHCollection.Models;

namespace MTHCollection.BLL
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : BaseSQLService, ISQLOperate<UserModel>
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(UserModel model)
        {
            return await Sqlite.Insertable<UserModel>(model).ExecuteCommandAsync();
        }

        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await Sqlite
                .Deleteable<UserModel>()
                .Where(u => u.Id == id)
                .ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 删除所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsync()
        {
            return await Sqlite.Deleteable<UserModel>().ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(UserModel model)
        {
            return await Sqlite.Updateable<UserModel>(model).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await Sqlite.Queryable<UserModel>().FirstAsync(u => u.Id == id);
        }

        /// <summary>
        /// 根据关键字获取用户列表
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public async Task<IList<UserModel>> GetListAsync(string? word)
        {
            IList<UserModel> list = null;
            if (string.IsNullOrEmpty(word))
            {
                list =await Sqlite.Queryable<UserModel>().ToListAsync();
            }
            else
            {
                list =await Sqlite.Queryable<UserModel>().Where(u => u.UserName.Equals(word)).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> isExitUserName(string userName)
        {
            var model = await Sqlite.Queryable<UserModel>().FirstAsync(u => u.UserName == userName);
            return (model != null);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<UserModel> LoginAsync(string userName, string password)
        {
            var model= await Sqlite.Queryable<UserModel>().FirstAsync(u => u.UserName == userName && u.Password == password);
            return model;
        }
    }
}
