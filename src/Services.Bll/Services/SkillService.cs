using AutoMapper;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Skill;
using Services.Dal.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class SkillService : ISkillService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public SkillService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<SkillDto> CreateSkill(SkillForUpdateDto skillForUpdateDto)
        {
            var skill = _mapper.Map<Skill>(skillForUpdateDto);
            _genericRepository.Add(skill);
            await _genericRepository.SaveChangesAsync();

            var skillDto = _mapper.Map<SkillDto>(skill);

            return skillDto;
        }

        public async Task DeleteSkill(Guid id)
        {
            await _genericRepository.Delete<Skill>(id);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task<SkillDto> GetSkill(Guid id)
        {
            var skill = await _genericRepository.GetById<Skill>(id);
            var skillDto = _mapper.Map<SkillDto>(skill);
            return skillDto;
        }

        public async Task UpdateSkill(Guid id, SkillForUpdateDto skillForUpdateDto)
        {
            var skill = await _genericRepository.GetById<Skill>(id);
            _mapper.Map(skillForUpdateDto, skill);
            await _genericRepository.SaveChangesAsync();
        }
    }
}
