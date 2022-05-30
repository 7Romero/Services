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
    [MinLength(5)]
    [MaxLength(20)]
    public string Username { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Password { get; set; }
}
