using System.ComponentModel.DataAnnotations;

namespace Services.Common.Dtos.User;

public class UserForUpdateDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public decimal Balance { get; set; }
}
