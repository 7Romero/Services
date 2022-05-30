using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public async Task UpdateUserImg(Guid id, UserImgLoadDto userForUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            CheckExist(user);

            if (user.AvatarLink != null)
            {
                DeleteImage(user.AvatarLink);
            }

            user.AvatarLink = await SaveImage(userForUpdateDto.file);

            await _userManager.UpdateAsync(user);
        }

        private async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

            var imagePath = Path.Combine(Directory.GetCurrentDirectory() + @"\Resources\AvatarImg", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        private void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory() + @"\Resources\AvatarImg", imageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
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
