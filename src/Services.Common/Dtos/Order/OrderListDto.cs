using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Order
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal SuggestedPrice { get; set; }
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
    }
}
