using Services.Common.Dtos.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationDto> GetApplication(Guid id);

        Task<ApplicationDto> CreateApplication(ApplicationForUpdateDto applicationForUpdateDto, Guid userId);

        Task UpdateApplication(Guid id, ApplicationForUpdateDto applicationForUpdateDto);

        Task DeleteApplication(Guid id);
    }
}
