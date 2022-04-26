using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Section : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Category>? Category { get; set; }
    }
}
