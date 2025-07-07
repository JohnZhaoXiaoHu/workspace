using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTHCollection.DAL;
using MTHCollection.Models;

namespace MTHCollection.BLL
{
    public class RealTimeDataService : BaseSQLService
    {
        public async Task<int> InsertAsync(RealTimeDataModel model)
        {
            return await Sqlite.Insertable<RealTimeDataModel>(model).ExecuteCommandAsync();
        }

        public async Task<IList<RealTimeDataModel>> GetListAsync()
        {
            return await Sqlite.Queryable<RealTimeDataModel>().ToListAsync();
        }

        public async Task<IList<RealTimeDataModel>> GetListAsync(
            DateTime startTime,
            DateTime endTime
        )
        {
            return await Sqlite
                .Queryable<RealTimeDataModel>()
                .Where(r => r.InsertTime >= startTime && r.InsertTime <= endTime)
                .ToListAsync();
        }
    }
}
