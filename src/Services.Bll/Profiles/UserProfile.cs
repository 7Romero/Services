using AutoMapper;
using Services.Common.Dtos.User;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}
