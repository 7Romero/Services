using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.User;

public class UserAuthDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
