using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DescriptionTitle { get; set; }
    public string Description { get; set; }
    public string AvatarLink { get; set; }
    public DateTime RegistrationDate { get; set; }
}
