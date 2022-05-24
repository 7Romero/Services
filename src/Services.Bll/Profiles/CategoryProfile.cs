using AutoMapper;
using Services.Common.Dtos.Category;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryForSectionDto>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
