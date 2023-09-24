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
    public DbSet<DeviceState> DeviceStates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Device>().HasData(
            new Device
            {
                Id = 1,
                Name = "Living Room Light",
                DeviceType = "Light",
                Location = "Living Room"
            },
            new Device { Id = 2, Name = "Thermostat", DeviceType = "Thermostat", Location = "Bedroom" },
            new Device { Id = 3, Name = "Kitchen Light", DeviceType = "Light", Location = "Kitchen" },
            new Device { Id = 4, Name = "Bedroom Lamp", DeviceType = "Light", Location = "Bedroom" },
            new Device { Id = 5, Name = "Security Camera 1", DeviceType = "Camera", Location = "Front Door" },
            new Device { Id = 6, Name = "Security Camera 2", DeviceType = "Camera", Location = "Backyard" },
            new Device { Id = 7, Name = "Motion Sensor 1", DeviceType = "Motion Sensor", Location = "Hallway" },
            new Device { Id = 8, Name = "Fire Alarm", DeviceType = "Alarm", Location = "Living Room" },
            new Device { Id = 9, Name = "Smart Lock", DeviceType = "Lock", Location = "Front Door" },
            new Device { Id = 10, Name = "Smart Plug 1", DeviceType = "Smart Plug", Location = "Living Room" },
            new Device { Id = 11, Name = "Smart Plug 2", DeviceType = "Smart Plug", Location = "Bedroom" },
            new Device { Id = 12, Name = "Smart TV", DeviceType = "Smart TV", Location = "Living Room" },
            new Device { Id = 13, Name = "Smart Fridge", DeviceType = "Smart Appliance", Location = "Kitchen" },
            new Device { Id = 14, Name = "Garage Door Opener", DeviceType = "Garage Door Opener", Location = "Garage" },
            new Device { Id = 15, Name = "Temperature Sensor 1", DeviceType = "Temperature Sensor", Location = "Living Room" },
            new Device { Id = 16, Name = "Temperature Sensor 2", DeviceType = "Temperature Sensor", Location = "Bedroom" },
            new Device { Id = 17, Name = "Humidity Sensor 1", DeviceType = "Humidity Sensor", Location = "Bathroom" },
            new Device { Id = 18, Name = "Humidity Sensor 2", DeviceType = "Humidity Sensor", Location = "Kitchen" },
            new Device { Id = 19, Name = "Window Blinds", DeviceType = "Blinds", Location = "Living Room" }
            );
    }
}
