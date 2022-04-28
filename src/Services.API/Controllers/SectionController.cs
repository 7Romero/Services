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
            var sectionDto = await _sectionService.GetSection(id);
            return sectionDto;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSection(SectionForUpdateDto sectionForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sectionDto = await _sectionService.CreateSection(sectionForUpdateDto);

            return CreatedAtAction(nameof(GetSection), new { id = sectionDto.Id }, sectionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(Guid id, SectionForUpdateDto sectionForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sectionService.UpdateSection(id, sectionForUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteSection(Guid id)
        {
            await _sectionService.DeleteSection(id);
        }
    }
}
