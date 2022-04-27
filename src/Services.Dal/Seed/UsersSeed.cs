using Microsoft.AspNetCore.Identity;
using Services.Dal.Repositories;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Seed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@onlinebookshop.com",
                };
                await userManager.CreateAsync(user, "Admin1!");

                var roles = roleManager.Roles.ToList();

                foreach (var role in roles)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
            }
        }
    }
}
