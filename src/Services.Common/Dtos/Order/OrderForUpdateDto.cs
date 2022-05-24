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
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public decimal SuggestedPrice { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
