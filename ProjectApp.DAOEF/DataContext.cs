using Microsoft.EntityFrameworkCore;
using OleszekMowinski.ProjectApp.DAOSQL.DataObjects;

namespace OleszekMowinski.ProjectApp.DAOSQL
{
    public class DataContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProjectApp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>()
                .Ignore(a => a.ManufacturerId);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(a => a.Airplanes)
                .WithOne(a => a.Manufacturer)
                .HasForeignKey(a => a.ManufacturerIdEF);

            base.OnModelCreating(modelBuilder);
        }
    }
}
