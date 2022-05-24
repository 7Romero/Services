using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Services.Bll.Interfaces;
using Services.Common.Dtos.User;
using Services.Common.Exceptions;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUser(UserForUpdateDto userForUpdateDto)
        {
            var user = _mapper.Map<User>(userForUpdateDto);
            await _userManager.CreateAsync(user);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            CheckExist(user);

            await _userManager.DeleteAsync(user);
        }

        public async Task<UserDto> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            CheckExist(user);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task UpdateUser(Guid id, UserForUpdateDto userForUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            CheckExist(user);

            _mapper.Map(userForUpdateDto, user);

            await _userManager.UpdateAsync(user);
        }
        private static void CheckExist(User? user)
        {
            if (user == null)
            {
                throw new ValidationException("User not found");
            }
        }
    }
}
