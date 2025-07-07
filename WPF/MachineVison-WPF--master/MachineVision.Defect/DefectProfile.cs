using AutoMapper;
using MachineVision.Defect.Models;
using MachineVision.Defect.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect
{
    public class DefectProfile:Profile
    {
        public DefectProfile()
        {
            base.CreateMap<ProjectInfo, ProjectModel>().ReverseMap();
            base.CreateMap<InspectRegionInfo,InsectRegionModel>().ReverseMap();
        }
    }
}
