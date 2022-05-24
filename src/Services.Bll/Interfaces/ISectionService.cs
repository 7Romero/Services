using Services.Common.Dtos.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface ISectionService
    {
        Task<SectionDto> GetSection(Guid id);
        Task<List<SectionListDto>> GetAllSection();

        Task<SectionDto> CreateSection(SectionForUpdateDto sectionForUpdateDto);

        Task UpdateSection(Guid id, SectionForUpdateDto sectionForUpdateDto);

        Task DeleteSection(Guid id);
    }
}
