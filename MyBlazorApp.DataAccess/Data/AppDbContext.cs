using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Model.Entities;

namespace MyBlazorApp.DataAccess.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ProductModel> Products { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<RefreshTokenModel> RefreshTokens { get; set; }
    public DbSet<UserRoleModel> UserRoles { get; set; }
    public DbSet<RoleModel> Roles { get; set; }
}
