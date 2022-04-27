using Microsoft.AspNetCore.Identity;
using Services.Domain.Auth;

namespace Services.Dal.Seed
{
    public class RolesSeed
    {
        public static async Task Seed(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new List<Role>()
                {
                    new Role { Name = "User" },
                    new Role { Name = "Moderator" },
                    new Role { Name = "Administrator" },
                    new Role { Name = "Owner" },
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

            }
        }
    }
}
