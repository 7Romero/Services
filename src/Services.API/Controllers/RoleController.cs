﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Role;

namespace Services.API.Controllers
{
    [Route("api/role")]
    public class RoleController : AppBaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<RoleDto> GetRole(Guid id)
        {
            var roleDto = await _roleService.GetRole(id);

            return roleDto;
        }
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateRole(RoleForUpdateDto roleForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleDto = await _roleService.CreateRole(roleForUpdateDto);

            return CreatedAtAction(nameof(GetRole), new { id = roleDto.Id }, roleDto);
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateRole(Guid id, RoleForUpdateDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _roleService.UpdateRole(id, roleDto);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task DeleteRole(Guid id)
        {
            await _roleService.DeleteRole(id);
        }
    }
}
