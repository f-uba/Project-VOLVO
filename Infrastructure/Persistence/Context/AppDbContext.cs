using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Chassis> Chassis => Set<Chassis>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Chassis)
                .WithOne(c => c.Vehicle)
                .HasForeignKey<Chassis>(c => c.VehicleId)
                .IsRequired();

            modelBuilder.Entity<Chassis>()
                .HasIndex(c => new { c.Series, c.Number })
                .IsUnique();
        }
    }
}
