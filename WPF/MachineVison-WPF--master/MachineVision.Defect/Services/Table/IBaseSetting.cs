using MachineVision.Defect.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Services.Table
{
    public interface IBaseSetting<T> where T : class
    {
        public  Task<int> InsertAsync(T model);

        public Task<int> DeleteAsync(int id);

        public Task<int> UpdateAsync(T model);

        public Task<ObservableCollection<T>> GetListAsync(string word);

    }
}
