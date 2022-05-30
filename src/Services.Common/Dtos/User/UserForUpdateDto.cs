using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.Common.Dtos.User;

public class UserForUpdateDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(120)]
    public string DescriptionTitle { get; set; }
    [Required]
    [MinLength(1)]
    public string Description { get; set; }
}
