using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Application : BaseEntity
    {
        public string Description{ get; set; }
        public decimal SuggestedPrice { get; set; }
        public int SuggestedTime { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
