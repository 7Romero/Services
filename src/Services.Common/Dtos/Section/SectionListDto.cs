using Services.Common.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Section
{
    public class SectionListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CategoryForSectionDto> Category { get; set; }
    }
}
