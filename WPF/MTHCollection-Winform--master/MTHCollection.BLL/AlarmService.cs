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
    /// 报警溯源服务类
    /// </summary>
    public class AlarmService : BaseSQLService
    {

        public async Task<int> InsertAsync(AlarmModel model)
        {
           return await Sqlite.Insertable<AlarmModel>(model).ExecuteCommandAsync();
        }

        public async Task<IList<AlarmModel>> GetListAsync(
            string alarmType,
            DateTime startTime,
            DateTime endTime
        )
        {
            IList<AlarmModel> list = null;
            if (alarmType == "全部")
            {
                list = await Sqlite
                    .Queryable<AlarmModel>()
                    .Where(a => a.AlarmTime >= startTime && a.AlarmTime <= endTime)
                    .ToListAsync();
            }
            else
            {
                list = await Sqlite
                    .Queryable<AlarmModel>()
                    .Where(a =>
                        a.AlarmTime >= startTime
                        && a.AlarmTime <= endTime
                        && a.AlarmType == alarmType
                    )
                    .ToListAsync();
            }
            return list;
        }

        public async Task<IList<AlarmModel>> GetListAsync()
        {
            return await Sqlite.Queryable<AlarmModel>().ToListAsync();
        }
    }
}
