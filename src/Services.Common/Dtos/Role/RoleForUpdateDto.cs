using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Role
{
    public class RoleForUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
