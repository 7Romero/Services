using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Skill;

namespace Services.API.Controllers
{
    [Route("api/skill")]
    public class SkillController : AppBaseController
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpGet("{id}")]
        public async Task<SkillDto> GetSkill(Guid id)
        {
            var skillDto = await _skillService.GetSkill(id);

            return skillDto;
        }
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateSkill(SkillForUpdateDto skillForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skillDto = await _skillService.CreateSkill(skillForUpdateDto);

            return CreatedAtAction(nameof(GetSkill), new { id = skillDto.Id }, skillDto);
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateSkill(Guid id, SkillForUpdateDto skillForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _skillService.UpdateSkill(id, skillForUpdateDto);

            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task DeleteSkill(Guid id)
        {
            await _skillService.DeleteSkill(id);
        }
    }
}
