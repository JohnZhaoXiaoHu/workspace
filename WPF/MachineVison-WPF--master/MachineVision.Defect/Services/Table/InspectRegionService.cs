using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineVision.Defect.Models;
using MachineVision.Defect.Tables;
using MachineVision.Shared2.Services.AutoMapper;
using MachineVision.Shared2.Services.SQL;
using Newtonsoft.Json;

namespace MachineVision.Defect.Services.Table
{
    public class InspectRegionService : BaseSQLService, IBaseSetting<InsectRegionModel>
    {
        private IAppMapper mapper;

        public InspectRegionService(IAppMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// 新增检测区域
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(InsectRegionModel model)
        {
            InspectRegionInfo insectRegion = mapper.Map<InspectRegionInfo>(model);
            insectRegion.CreateTime = DateTime.Now;
            insectRegion.UpdateTime = DateTime.Now;
            return await Sqlite.Insert<InspectRegionInfo>(insectRegion).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 删除检测区域
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int id)
        {
            return await Sqlite
                .Delete<InspectRegionInfo>()
                .Where(i => i.Id == id)
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 更新检测区域参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(InsectRegionModel model)
        {
            InspectRegionInfo insectRegion = mapper.Map<InspectRegionInfo>(model);
            insectRegion.UpdateTime = DateTime.Now;
            insectRegion.RegionInfo = JsonConvert.SerializeObject(model.RegionParamter);
            return await Sqlite
                .Update<InspectRegionInfo>()
                .SetDto(insectRegion)
                .Where(i => i.Id == model.Id)
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 获取检测区域列表
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<InsectRegionModel>> GetListAsync(string word)
        {
            IList<InspectRegionInfo> list = null;
            if (string.IsNullOrEmpty(word))
            {
                list = await Sqlite.Queryable<InspectRegionInfo>().ToListAsync();
            }
            else
            {
                list = await Sqlite.Queryable<InspectRegionInfo>().Where(i=>i.Name.Contains(word)).ToListAsync();
            }
            return mapper.Map<ObservableCollection<InsectRegionModel>>(list);
        }

        /// <summary>
        /// 根据项目id获取检测区域列表
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<InsectRegionModel>> GetListAsync(int projectId)
        {
            IList<InspectRegionInfo> list = null;
           
            list = await Sqlite.Queryable<InspectRegionInfo>().Where(i=>i.ProjectId == projectId).ToListAsync();
            
            return mapper.Map<ObservableCollection<InsectRegionModel>>(list);
        }
    }
}
