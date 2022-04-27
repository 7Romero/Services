using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.API.Infrastructure.Extensions;
using Services.Bll;
using Services.Bll.Interfaces;
using Services.Bll.Services;
using Services.Dal;
using Services.Dal.Interfaces;
using Services.Dal.Repositories;
using Services.Domain.Auth;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// For Entity Framework

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

// Adding Authentication

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 5;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

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

app.UseHttpsRedirection();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();