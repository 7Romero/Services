using Services.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(Guid id);

        Task<UserDto> CreateUser(UserForUpdateDto userForUpdateDto);

        Task UpdateUser(Guid id, UserForUpdateDto userForUpdateDto);

        Task DeleteUser(Guid id);
    }
}
