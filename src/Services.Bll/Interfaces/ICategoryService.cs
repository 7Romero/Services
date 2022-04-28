using Services.Common.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategory(Guid id);

        Task<CategoryDto> CreateCategory(CategoryForUpdateDto categoryForUpdateDto);

        Task UpdateCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto);

        Task DeleteCategory(Guid id);
    }
}