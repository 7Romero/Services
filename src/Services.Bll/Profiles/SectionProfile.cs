using AutoMapper;
using Services.Common.Dtos.Section;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>();
            CreateMap<SectionForUpdateDto, Section>();
        }
    }
}
