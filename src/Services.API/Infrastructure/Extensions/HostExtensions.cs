using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Dal;
using Services.Dal.Seed;
using Services.Domain.Auth;

namespace Services.API.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    context.Database.Migrate();

                    await UsersSeed.Seed(userManager);
                    await SkillSeed.Seed(context);
                    await SectionsSeed.Seed(context);
                    await CategoriesSeed.Seed(context);
                    await OrdersSeed.Seed(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }
}
