using AutoMapper;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Section;
using Services.Dal.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class SectionService : ISectionService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public SectionService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<SectionDto> CreateSection(SectionForUpdateDto sectionForUpdateDto)
        {
            var section = _mapper.Map<Section>(sectionForUpdateDto);
            _genericRepository.Add(section);
            await _genericRepository.SaveChangesAsync();

            var sectionDto = _mapper.Map<SectionDto>(section);

            return sectionDto;
        }

        public async Task DeleteSection(Guid id)
        {
            await _genericRepository.Delete<Section>(id);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task<SectionDto> GetSection(Guid id)
        {
            var section = await _genericRepository.GetById<Section>(id);
            var sectionDto = _mapper.Map<SectionDto>(section);
            return sectionDto;
        }

        public async Task UpdateSection(Guid id, SectionForUpdateDto sectionForUpdateDto)
        {
            var section = await _genericRepository.GetById<Section>(id);
            _mapper.Map(sectionForUpdateDto, section);
            await _genericRepository.SaveChangesAsync();
        }
    }
}
