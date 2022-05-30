using Services.Common.Dtos.Application;
using Services.Common.Dtos.Category;
using Services.Common.Dtos.Skill;
using Services.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get;set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal SuggestedPrice { get; set; }
        public UserDto User { get; set; }
        public UserDto? Freelancer { get; set; }
        public Guid CategoryId { get; set; }
    }
}
