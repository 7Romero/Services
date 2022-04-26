using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string NickName { get; set; } = string.Empty;
    //public string FirstName { get; set; } = string.Empty;
    //public string LastName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public float Rating { get; set; }
}
