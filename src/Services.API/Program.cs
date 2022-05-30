using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Services.API.Infrastructure.Extensions;
using Services.Bll;
using Services.Bll.Interfaces;
using Services.Bll.Services;
using Services.Common.Models.Stripe;
using Services.Dal;
using Services.Dal.Interfaces;
using Services.Dal.Repositories;
using Services.Domain.Auth;
using Stripe;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// For Entity Framework

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

// Stripe

StripeConfiguration.ApiKey = configuration.GetValue<string>("stripe:SecretKey");
builder.Services.Configure<StripeSettings>(configuration.GetSection("stripe"));

// Adding Authentication

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 5;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });

builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, Services.Bll.Services.OrderService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

var authOptions = builder.Services.ConfigureAuthOptions(configuration);
builder.Services.AddJwtAuthentication(authOptions);
builder.Services.AddSwagger(configuration);

builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));

var app = builder.Build();

await app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandling();
app.UseDbTransaction();

app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
