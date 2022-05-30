using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.Stripe
{
    public class StripeDto
    {
        public string Id { get; set; }
        public int Amount { get; set; }
    }
}
