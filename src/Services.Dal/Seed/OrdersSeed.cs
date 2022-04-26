using Services.Domain;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Seed
{
    public class OrdersSeed
    {
        public static async Task Seed(AppDbContext context)
        {
            if (!context.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order
                    {
                        Title = "Test Order Nr 1",
                        Description = "This is description for order nr 1",
                        SuggestedPrice = 999,
                        Category = context.Categories.First(c => c.Name == "Filling sites"),
                        User = context.Users.First(u => u.UserName == "admin"),
                        Skills = context.Skills.Where(c => c.Name.StartsWith("C")).ToList(),
                    },
                    new Order
                    {
                        Title = "Test Order Nr 2",
                        Description = "This is description for order nr 2",
                        SuggestedPrice = 888,
                        Category = context.Categories.First(c => c.Name == "Cartography"),
                        User = context.Users.First(u => u.UserName == "admin"),
                        Skills = context.Skills.Where(c => c.Name.StartsWith("R")).ToList(),
                    },
                    new Order
                    {
                        Title = "Test Order Nr 3",
                        Description = "This is description for order nr 3",
                        SuggestedPrice = 656,
                        Category = context.Categories.First(c => c.Name == "Cartography"),
                        User = context.Users.First(u => u.UserName == "admin"),
                        Skills = context.Skills.Where(c => c.Name.StartsWith("S")).ToList(),
                    },
                    new Order
                    {
                        Title = "Test Order Nr 4",
                        Description = "This is description for order nr 4",
                        SuggestedPrice = 300,
                        Category = context.Categories.First(c => c.Name == "Animation"),
                        User = context.Users.First(u => u.UserName == "admin"),
                        Skills = context.Skills.Where(c => c.Name.StartsWith("G")).ToList(),
                    },
                    new Order
                    {
                        Title = "Test Order Nr 5",
                        Description = "This is description for order nr 5",
                        SuggestedPrice = 120,
                        Category = context.Categories.First(c => c.Name == "Animation"),
                        User = context.Users.First(u => u.UserName == "admin"),
                        Skills = context.Skills.Where(c => c.Name.StartsWith("J")).ToList(),
                    },

                };

                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
