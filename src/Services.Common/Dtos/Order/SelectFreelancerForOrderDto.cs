using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Order
{
    public class SelectFreelancerForOrderDto
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid FreelancerId { get; set; }
    }
}
