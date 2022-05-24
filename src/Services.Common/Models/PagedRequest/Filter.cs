using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Models.PagedRequest
{
    public class Filter
    {
        public FilterComparisonOperators ComparisonOperators { get; set; }
        public string Path { get; set; }
        public string Value { get; set; }
    }
}
