using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.Common.Dtos.User;

public class UserForUpdateDto
{
    [Required]
    public string DescriptionTitle { get; set; }
    [Required]
    public string Description { get; set; }
}
