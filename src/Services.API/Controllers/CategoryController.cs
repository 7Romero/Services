using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Category;

namespace Services.API.Controllers
{
    [Route("api/category")]
    public class CategoryController : AppBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("{id}")]
        public async Task<CategoryDto> GetCategory(Guid id)
        {
            var categoryDto = await _categoryService.GetCategory(id);
            return categoryDto;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryForUpdateDto categoryForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryDto = await _categoryService.CreateCategory(categoryForUpdateDto);

            return CreatedAtAction(nameof(GetCategory), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.UpdateCategory(id, categoryForUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategory(Guid id)
        {
            await _categoryService.DeleteCategory(id);
        }
    }
}
