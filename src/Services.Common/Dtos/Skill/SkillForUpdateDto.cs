using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Skill
{
    public class SkillForUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
