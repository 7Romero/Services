﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Category
{
    public class CategoryForUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid SectionId { get; set; }
    }
}
