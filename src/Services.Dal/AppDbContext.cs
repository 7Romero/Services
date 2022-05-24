using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Services.Domain;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal;

public class AppDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    private readonly string _connectionString = @"Server=network\SQLEXPRESS;Database=ServicesDB;Trusted_Connection=True;";
    public AppDbContext()
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    //public DbSet<User> Users { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Section> Sections { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<Application> Applications { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
        modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
        modelBuilder.Entity<UserToken>().ToTable("UserToken");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
