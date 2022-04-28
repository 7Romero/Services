using AutoMapper;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Category;
using Services.Dal.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateCategory(CategoryForUpdateDto categoryForUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryForUpdateDto);
            _genericRepository.Add(category);
            await _genericRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task DeleteCategory(Guid id)
        {
            await _genericRepository.Delete<Category>(id);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetCategory(Guid id)
        {
            var category = await _genericRepository.GetByIdWithInclude<Category>(id, category => category.Section);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task UpdateCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto)
        {
            var category = await _genericRepository.GetById<Category>(id);
            _mapper.Map(categoryForUpdateDto, category);
            await _genericRepository.SaveChangesAsync();
        }
    }
}
