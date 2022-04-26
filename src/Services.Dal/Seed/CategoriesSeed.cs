using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Seed
{
    public class CategoriesSeed
    {
        public static async Task Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    //
                    //  Site Administation
                    //
                    new Category
                    {
                        Name = "Filling sites",
                        Section = context.Sections.First(s => s.Name == "Site administration"),
                    },                    
                    new Category
                    {
                        Name = "System administration",
                        Section = context.Sections.First(s => s.Name == "Site administration"),
                    },                    
                    new Category
                    {
                        Name = "Support service",
                        Section = context.Sections.First(s => s.Name == "Site administration"),
                    },
                    //
                    //  Architecture and Engineering
                    //
                    new Category
                    {
                        Name = "Architecture of buildings",
                        Section = context.Sections.First(s => s.Name == "Architecture and Engineering"),
                    },                   
                    new Category
                    {
                        Name = "Interiors and Exteriors",
                        Section = context.Sections.First(s => s.Name == "Architecture and Engineering"),
                    },                    
                    new Category
                    {
                        Name = "Cartography",
                        Section = context.Sections.First(s => s.Name == "Architecture and Engineering"),
                    },                    
                    new Category
                    {
                        Name = "Landscaping",
                        Section = context.Sections.First(s => s.Name == "Architecture and Engineering"),
                    },                    
                    new Category
                    {
                        Name = "Mechanical engineering",
                        Section = context.Sections.First(s => s.Name == "Architecture and Engineering"),
                    },                    
                    new Category
                    {
                        Name = "Drawings and Diagrams",
                        Section = context.Sections.First(s => s.Name == "Architecture and Engineering"),
                    },
                    //
                    //  Audio and Video
                    //
                    new Category
                    {
                        Name = "Animation",
                        Section = context.Sections.First(s => s.Name == "Audio and Video"),
                    },                    
                    new Category
                    {
                        Name = "Audio editing",
                        Section = context.Sections.First(s => s.Name == "Audio and Video"),
                    },                    
                    new Category
                    {
                        Name = "Video editing",
                        Section = context.Sections.First(s => s.Name == "Audio and Video"),
                    },                    
                    new Category
                    {
                        Name = "Music and Sounds",
                        Section = context.Sections.First(s => s.Name == "Audio and Video"),
                    },                    
                    new Category
                    {
                        Name = "Voice acting",
                        Section = context.Sections.First(s => s.Name == "Audio and Video"),
                    },
                    new Category
                    {
                        Name = "Presentations",
                        Section = context.Sections.First(s => s.Name == "Audio and Video"),
                    },
                    //
                    //  Web Design & Interfaces
                    //
                    new Category 
                    {
                        Name = "Banners",
                        Section = context.Sections.First(s => s.Name == "Web Design & Interfaces"),
                    },
                    new Category 
                    {
                        Name = "Design of interfaces and games",
                        Section = context.Sections.First(s => s.Name == "Web Design & Interfaces"),
                    },
                    new Category 
                    {
                        Name = "Mobile application design",
                        Section = context.Sections.First(s => s.Name == "Web Design & Interfaces"),
                    },
                    new Category 
                    {
                        Name = "Website design",
                        Section = context.Sections.First(s => s.Name == "Web Design & Interfaces"),
                    },
                    new Category 
                    {
                        Name = "Icons and Pixel Art",
                        Section = context.Sections.First(s => s.Name == "Web Design & Interfaces"),
                    },
                    //
                    //  Web sites
                    //
                    new Category 
                    {
                        Name = "HTML layout",
                        Section = context.Sections.First(s => s.Name == "Web sites"),
                    },
                    new Category 
                    {
                        Name = "Web programming",
                        Section = context.Sections.First(s => s.Name == "Web sites"),
                    },
                    new Category 
                    {
                        Name = "Online shopping",
                        Section = context.Sections.First(s => s.Name == "Web sites"),
                    },
                    new Category 
                    {
                        Name = "Websites on a turnkey basis",
                        Section = context.Sections.First(s => s.Name == "Web sites"),
                    },
                    new Category 
                    {
                        Name = "Management systems (CMS)",
                        Section = context.Sections.First(s => s.Name == "Web sites"),
                    },
                    new Category 
                    {
                        Name = "Website testing",
                        Section = context.Sections.First(s => s.Name == "Web sites"),
                    },
                    //
                    //  Graphics and Photography
                    //
                    new Category 
                    {
                        Name = "3D graphics",
                        Section = context.Sections.First(s => s.Name == "Graphics and Photography"),
                    },
                    new Category 
                    {
                        Name = "Illustrations and Drawings",
                        Section = context.Sections.First(s => s.Name == "Graphics and Photography"),
                    },
                    new Category 
                    {
                        Name = "Photo processing",
                        Section = context.Sections.First(s => s.Name == "Graphics and Photography"),
                    },
                    new Category 
                    {
                        Name = "Photographing",
                        Section = context.Sections.First(s => s.Name == "Graphics and Photography"),
                    },
                    new Category 
                    {
                        Name = "Fonts",
                        Section = context.Sections.First(s => s.Name == "Graphics and Photography"),
                    },
                    //
                    //  Printing and Identity
                    //
                    new Category 
                    {
                        Name = "Layout printing",
                        Section = context.Sections.First(s => s.Name == "Printing and Identity"),
                    },
                    new Category 
                    {
                        Name = "Product design",
                        Section = context.Sections.First(s => s.Name == "Printing and Identity"),
                    },
                    new Category 
                    {
                        Name = "Logos and Signs",
                        Section = context.Sections.First(s => s.Name == "Printing and Identity"),
                    },
                    new Category 
                    {
                        Name = "Outdoor advertising",
                        Section = context.Sections.First(s => s.Name == "Printing and Identity"),
                    },
                    new Category 
                    {
                        Name = "Form style",
                        Section = context.Sections.First(s => s.Name == "Printing and Identity"),
                    },
                    //
                    //  Software programming
                    //
                    new Category 
                    {
                        Name = "1C programming",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },                 
                    new Category 
                    {
                        Name = "Database",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },
                    new Category 
                    {
                        Name = "Mobile applications",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },
                    new Category 
                    {
                        Name = "Application software",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },
                    new Category 
                    {
                        Name = "Game development",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },
                    new Category 
                    {
                        Name = "System Programming",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },
                    new Category 
                    {
                        Name = "Software testing",
                        Section = context.Sections.First(s => s.Name == "Software programming"),
                    },
                    //
                    //  Website promotion (SEO)
                    //
                    new Category 
                    {
                        Name = "Contextual advertising",
                        Section = context.Sections.First(s => s.Name == "Website promotion (SEO)"),
                    },
                    new Category 
                    {
                        Name = "Marketing analysis",
                        Section = context.Sections.First(s => s.Name == "Website promotion (SEO)"),
                    },
                    new Category 
                    {
                        Name = "Search engines (SEO)",
                        Section = context.Sections.First(s => s.Name == "Website promotion (SEO)"),
                    },
                    new Category 
                    {
                        Name = "Social networks (SMM and SMO)",
                        Section = context.Sections.First(s => s.Name == "Website promotion (SEO)"),
                    },
                    //
                    //  Texts and Translations
                    //
                    new Category 
                    {
                        Name = "Copywriting",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Naming and Slogans",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Selling texts",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Editing and Proofreading",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Rewriting",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Poems, Songs and Prose",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Scenarios",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    new Category 
                    {
                        Name = "Transcription",
                        Section = context.Sections.First(s => s.Name == "Texts and Translations"),
                    },
                    //
                    //  Administration and Management
                    //
                    new Category 
                    {
                        Name = "Recruitment (HR)",
                        Section = context.Sections.First(s => s.Name == "Administration and Management"),
                    },
                    new Category 
                    {
                        Name = "Sales management",
                        Section = context.Sections.First(s => s.Name == "Administration and Management"),
                    },
                    new Category 
                    {
                        Name = "Project management",
                        Section = context.Sections.First(s => s.Name == "Administration and Management"),
                    },
                    //
                    //  Study and Tutoring
                    //
                    new Category 
                    {
                        Name = "Controls, Tasks and Tests",
                        Section = context.Sections.First(s => s.Name == "Study and Tutoring"),
                    },
                    new Category 
                    {
                        Name = "Laboratory works",
                        Section = context.Sections.First(s => s.Name == "Study and Tutoring"),
                    },
                    new Category 
                    {
                        Name = "Abstracts, Coursework and Diplomas",
                        Section = context.Sections.First(s => s.Name == "Study and Tutoring"),
                    },
                    new Category 
                    {
                        Name = "Lessons and Tutoring",
                        Section = context.Sections.First(s => s.Name == "Study and Tutoring"),
                    },
                    //
                    //  Economics and Law
                    //
                    new Category 
                    {
                        Name = "Accounting services",
                        Section = context.Sections.First(s => s.Name == "Economics and Law"),
                    },
                    new Category 
                    {
                        Name = "Financial services",
                        Section = context.Sections.First(s => s.Name == "Economics and Law"),
                    },
                    new Category 
                    {
                        Name = "Legal services",
                        Section = context.Sections.First(s => s.Name == "Economics and Law"),
                    },
                };

                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}