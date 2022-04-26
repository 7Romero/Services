using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid SectionId { get; set; }
        public Section Section { get; set; } = null!;
        public List<Order>? Orders { get; set; }
    }
}
