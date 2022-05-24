using AutoMapper;
using Services.Common.Dtos.Application;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationDto>();
            CreateMap<ApplicationForUpdateDto, Application>();
        }
    }
}
