using Services.Common.Dtos.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface ISkillService
    {
        Task<SkillDto> GetSkill(Guid id);

        Task<SkillDto> CreateSkill(SkillForUpdateDto skillForUpdateDto);

        Task UpdateSkill(Guid id, SkillForUpdateDto skillForUpdateDto);

        Task DeleteSkill(Guid id);
    }
}
