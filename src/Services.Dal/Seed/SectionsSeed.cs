using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Seed
{
    public class SectionsSeed
    {
        public static async Task Seed(AppDbContext context)
        {
            if (!context.Sections.Any())
            {
                var sections = new List<Section>
                {
                    new Section { Name = "Site administration"},
                    new Section { Name = "Architecture and Engineering"},
                    new Section { Name = "Audio and Video"},
                    new Section { Name = "Web Design & Interfaces"},
                    new Section { Name = "Web sites"},
                    new Section { Name = "Graphics and Photography"},
                    new Section { Name = "Printing and Identity"},
                    new Section { Name = "Software programming"},
                    new Section { Name = "Website promotion (SEO)"},
                    new Section { Name = "Texts and Translations"},
                    new Section { Name = "Administration and Management"},
                    new Section { Name = "Study and Tutoring"},
                    new Section { Name = "Economics and Law"},
                };

                foreach (var section in sections)
                {
                    context.Sections.Add(section);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
