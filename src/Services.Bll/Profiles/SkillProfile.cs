using AutoMapper;
using Services.Common.Dtos.Skill;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillForUpdateDto, Skill>();
        }
    }
}
