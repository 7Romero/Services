using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Application;
using System.Security.Claims;

namespace Services.API.Controllers
{
    [Route("api/application")]
    public class ApplicationController : AppBaseController
    {
        private readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{id}")]
        public async Task<ApplicationDto> GetApplication(Guid id)
        {
            var applicationDto = await _applicationService.GetApplication(id);

            return applicationDto;
        }

        [HttpGet("order/{id}")]
        public async Task<ApplicationDto> GetApplicationByOrderId(Guid id)
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var applicationDto = await _applicationService.GetApplicationByOrderId(id, userId);

            return applicationDto;
        }

        [HttpGet("allForOrder/{id}")]
        public async Task<List<ApplicationDto>> GetApplicationsByOrderId(Guid id)
        {
            var applicationDto = await _applicationService.GetApplicationsByOrderId(id);

            return applicationDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationForUpdateDto applicationForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var applicationDto = await _applicationService.CreateApplication(applicationForUpdateDto, userId);

            return CreatedAtAction(nameof(GetApplication), new { id = applicationDto.Id }, applicationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(Guid id, ApplicationForUpdateDto applicationForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _applicationService.UpdateApplication(id, applicationForUpdateDto);

            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task DeleteApplication(Guid id)
        {
            await _applicationService.DeleteApplication(id);
        }
    }
}
