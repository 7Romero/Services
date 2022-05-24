using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Order : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal SuggestedPrice { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public User User { get; set; } = null!;
        public List<Skill> Skills { get; set; } = null!;
        public List<Application> Applications { get; set; } = null!;
    }
}
