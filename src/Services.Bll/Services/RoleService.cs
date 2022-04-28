using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Role;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> repository, IMapper mapper)
        {
            _roleManager = repository;
            _mapper = mapper;
        }
        public async Task<RoleDto> CreateRole(RoleForUpdateDto roleForUpdateDto)
        {
            var role = _mapper.Map<Role>(roleForUpdateDto);
            await _roleManager.CreateAsync(role);

            var roleDto = _mapper.Map<RoleDto>(role);

            return roleDto;
        }

        public async Task DeleteRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
        }

        public async Task<RoleDto> GetRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var roleDto = _mapper.Map<RoleDto>(role);

            return roleDto;
        }

        public async Task UpdateRole(Guid id, RoleForUpdateDto roleForUpdateDto)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            _mapper.Map(roleForUpdateDto, role);
            await _roleManager.UpdateAsync(role);
        }
    }
}
