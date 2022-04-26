using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Seed
{
    public class SkillSeed
    {
        public static async Task Seed(AppDbContext context)
        {
            if (!context.Skills.Any())
            {
                var skills = new List<Skill>
                {
                    new Skill { Name = "C#"},
                    new Skill { Name = "JavaScript"},
                    new Skill { Name = "Swift"},
                    new Skill { Name = "Ruby"},
                    new Skill { Name = "Rust"},
                    new Skill { Name = "Scala"},
                    new Skill { Name = "Go"},
                    new Skill { Name = "Elm"},
                };

                foreach (var skill in skills)
                {
                    context.Skills.Add(skill);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
