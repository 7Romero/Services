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
        Task<UserDto> GetUser(string userName);

        Task<UserDto> CreateUser(UserForUpdateDto userForUpdateDto);

        Task UpdateUser(Guid id, UserForUpdateDto userForUpdateDto);

        Task UpdateUserImg(Guid id, UserImgLoadDto userForUpdateDto);

        Task DeleteUser(Guid id);
    }
}
