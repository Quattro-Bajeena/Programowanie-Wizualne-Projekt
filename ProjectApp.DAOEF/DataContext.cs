using Microsoft.EntityFrameworkCore;
using OleszekMowinski.ProjectApp.DAOSQL.DataObjects;
using System.Reflection;

namespace OleszekMowinski.ProjectApp.DAOSQL
{
    public class DataContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string absolutePath = Path.Combine(currentPath, "OleszekMowinskiDatabase.db");
            string connectionString = "Data Source=" + absolutePath;
            optionsBuilder.UseSqlite(connectionString);
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
