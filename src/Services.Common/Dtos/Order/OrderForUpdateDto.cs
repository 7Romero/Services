using Services.Common.Dtos.Skill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Order
{
    public class OrderForUpdateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public decimal SuggestedPrice { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}