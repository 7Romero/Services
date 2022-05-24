using Services.Common.Dtos.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Order
{
    public class OrderWithApplicationDto
    {
        public Guid Id { get; set; }
        public List<ApplicationDto> Applications { get; set; }
    }
}
