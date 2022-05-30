using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Models.Stripe
{
    public class StripeSettings
    {
        public string PublicKey { get; set; } = String.Empty;
        public string WHSecret { get; set; } = String.Empty;
    }
}
