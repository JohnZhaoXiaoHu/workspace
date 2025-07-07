using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared2.Services.AutoMapper
{
    public interface IAppMapper
    {
        public IMapper Current { get;}

        public T Map<T>(object source);
    }

    public class AppMapper:IAppMapper
    {
        public AppMapper()
        {
            var config = new MapperConfiguration(config =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                config.AddMaps(assemblies);
            });
            Current = config.CreateMapper();
        }

        public IMapper Current { get; }

        public T Map<T>(object source) => Current.Map<T>(source);
       
    }
}
