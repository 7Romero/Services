using AutoMapper;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Category;
using Services.Common.Exceptions;
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
            CheckSection(categoryForUpdateDto.SectionId);

            var category = _mapper.Map<Category>(categoryForUpdateDto);
            _genericRepository.Add(category);
            await _genericRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task DeleteCategory(Guid id)
        {

            var category = await _genericRepository.GetById<Category>(id);
            CheckExist(category);

            await _genericRepository.Delete<Category>(id);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetCategory(Guid id)
        {
            var category = await _genericRepository.GetByIdWithInclude<Category>(id, category => category.Section);
            CheckExist(category);

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task UpdateCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto)
        {
            var category = await _genericRepository.GetById<Category>(id);
            CheckExist(category);
            CheckSection(categoryForUpdateDto.SectionId);

            _mapper.Map(categoryForUpdateDto, category);

            await _genericRepository.SaveChangesAsync();
        }
        private static void CheckExist(Category? category)
        {
            if (category == null)
            {
                throw new ValidationException("Category not found");
            }
        }
        private async void CheckSection(Guid id)
        {
            var section = await _genericRepository.GetById<Section>(id);
            if (section == null)
            {
                throw new ValidationException("Section not found");
            }
        }
    }
}
