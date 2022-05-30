using Services.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Application
{
    public class ApplicationDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal SuggestedPrice { get; set; }
        public int SuggestedTime { get; set; }
        public UserDto User { get; set; }
        public Guid OrderId { get; set; }
    }
}
