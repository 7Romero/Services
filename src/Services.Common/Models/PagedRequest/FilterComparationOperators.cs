using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Models.PagedRequest
{
    public enum FilterComparisonOperators
    {
        StringEquals,
        StringContains,
        NumberEquals,
        NotNumberEquals,
    }
}
