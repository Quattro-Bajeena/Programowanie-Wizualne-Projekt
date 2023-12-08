using Microsoft.EntityFrameworkCore;
using OleszekMowinski.ProjectApp.DAOEF.DataObjects;

namespace OleszekMowinski.ProjectApp.DAOEF
{
    public class DataContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProjectApp.db");
        }
    }
}
