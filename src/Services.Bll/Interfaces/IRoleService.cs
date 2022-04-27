using Services.Common.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDto> GetRole(Guid id);

        Task<RoleDto> CreateRole(RoleForUpdateDto roleDto);

        Task UpdateRole(Guid id, RoleForUpdateDto roleDto);

        Task DeleteRole(Guid id);
    }
}
