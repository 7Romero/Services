using AutoMapper;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Application;
using Services.Common.Exceptions;
using Services.Dal.Interfaces;
using Services.Domain;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> CreateApplication(ApplicationForUpdateDto applicationForUpdateDto, Guid userId)
        {
            var user = await _genericRepository.GetById<User>(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            var application = _mapper.Map<Application>(applicationForUpdateDto);
            application.UserId = userId;

            _genericRepository.Add(application);
            await _genericRepository.SaveChangesAsync();

            var applicationDto = _mapper.Map<ApplicationDto>(application);

            return applicationDto;
        }

        public async Task DeleteApplication(Guid id)
        {
            var application = await _genericRepository.GetById<Application>(id);
            CheckExist(application);

            await _genericRepository.Delete<Application>(id);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task<ApplicationDto> GetApplication(Guid id)
        {
            var application = await _genericRepository.GetById<Application>(id);
            CheckExist(application);

            var applicationDto = _mapper.Map<ApplicationDto>(application);

            return applicationDto;
        }
        public async Task<ApplicationDto> GetApplicationByOrderId(Guid id, Guid userId)
        {
            var user = await _genericRepository.GetById<User>(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }  
            var application = await _genericRepository.GetFirstWithInclude<Application>(x => x.OrderId == id && x.UserId == userId, x => x.User);

            var applicationDto = _mapper.Map<ApplicationDto>(application);

            return applicationDto;
        }

        public async Task<List<ApplicationDto>> GetApplicationsByOrderId(Guid id)
        {
            var application = await _genericRepository.GetByWhereWithInclude<Application>(x => x.OrderId == id, x => x.User);

            var applicationDto = _mapper.Map<List<ApplicationDto>>(application);

            return applicationDto;
        }

        public async Task UpdateApplication(Guid id, ApplicationForUpdateDto applicationForUpdateDto)
        {
            var application = await _genericRepository.GetById<Application>(id);
            CheckExist(application);

            _mapper.Map(applicationForUpdateDto, application);

            await _genericRepository.SaveChangesAsync();
        }

        private static void CheckExist(Application? application)
        {
            if (application == null)
            {
                throw new ValidationException("Application not found");
            }
        }
    }
}
