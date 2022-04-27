using AutoMapper;
using Services.Common.Dtos.Role;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleForUpdateDto, Role>();
        }
    }
}
