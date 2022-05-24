using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Application
{
    public class ApplicationForUpdateDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal SuggestedPrice { get; set; }
        [Required]
        public int SuggestedTime { get; set; }
        [Required]
        public Guid OrderId { get; set; }
    }
}
