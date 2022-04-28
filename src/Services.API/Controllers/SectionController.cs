using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Section;

namespace Services.API.Controllers
{
    [Route("api/section")]
    public class SectionController : AppBaseController
    {
        private readonly ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        [HttpGet("{id}")]
        public async Task<SectionDto> GetSection(Guid id)
        {
            var rectionDto = await _sectionService.GetSection(id);
            return rectionDto;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(SectionForUpdateDto rectionForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rectionDto = await _sectionService.CreateSection(rectionForUpdateDto);

            return CreatedAtAction(nameof(GetSection), new { id = rectionDto.Id }, rectionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, SectionForUpdateDto rectionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sectionService.UpdateSection(id, rectionDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(Guid id)
        {
            await _sectionService.DeleteSection(id);
        }
    }
}
