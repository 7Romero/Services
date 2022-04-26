using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.User;

public class UserForUpdateDto
{
    //public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public decimal Balance { get; set; }
    [Required]
    public float Rating { get; set; }
}
