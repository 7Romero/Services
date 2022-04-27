using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Auth;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public decimal Balance { get; set; }
    public string AvatarLink { get; set; }
}
