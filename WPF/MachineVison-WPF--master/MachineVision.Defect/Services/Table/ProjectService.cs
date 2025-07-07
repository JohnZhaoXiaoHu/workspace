using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineVision.Defect.Models;
using MachineVision.Defect.Services.Table;
using MachineVision.Defect.Tables;
using MachineVision.Shared2.Services.AutoMapper;
using MachineVision.Shared2.Services.SQL;
using Newtonsoft.Json;

namespace MachineVision.Defect.Service
{
    public class ProjectService : BaseSQLService,IBaseSetting<ProjectModel>
    {
        private IAppMapper mapper;

        public ProjectService(IAppMapper appMapper)
        {
            mapper = appMapper;
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(ProjectModel model)
        {
            ProjectInfo project = mapper.Map<ProjectInfo>(model);
            return await Sqlite.Insert<ProjectInfo>(project).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int id)
        {
            return await Sqlite.Delete<ProjectInfo>().Where(p => p.Id == id).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(ProjectModel model)
        {
            int row = 0;
            try
            {
                ProjectInfo project = mapper.Map<ProjectInfo>(model);
                var result = await Sqlite
                    .Select<ProjectInfo>()
                    .Where(p => p.Id == model.Id)
                    .FirstAsync();
                project.UpdateTime = DateTime.Now;
                project.ReferPointInfo = JsonConvert.SerializeObject(model.ReferPointParamtter);

                if (result != null)
                    row = await Sqlite
                        .Update<ProjectInfo>()
                        .SetDto(project)
                        .Where(p => p.Id == model.Id)
                        .ExecuteAffrowsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"修改数据时发生错误:{ex.Message}");
            }
            return row;
        }

        public async Task<ObservableCollection<ProjectModel>> GetListAsync(string word)
        {
            IList<ProjectInfo> projectList = new ObservableCollection<ProjectInfo>();
            if (string.IsNullOrEmpty(word))
            {
                projectList = await Sqlite.Queryable<ProjectInfo>().ToListAsync();
            }
            else
            {
                projectList = await Sqlite
                    .Queryable<ProjectInfo>()
                    .Where(p => p.Name.Contains(word))
                    .ToListAsync();
            }
            var list = mapper.Map<ObservableCollection<ProjectModel>>(projectList);
            return list;
        }
    }
}
