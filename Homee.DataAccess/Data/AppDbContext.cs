using Homee.Models;
using Homee.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homee.DataAccess.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Device> Devices { get; set; }
}
