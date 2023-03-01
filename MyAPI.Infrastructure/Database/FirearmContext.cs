using Microsoft.EntityFrameworkCore;
using MyAPI.Infrastructure.Database.Entities;

namespace MyAPI.Infrastructure.Database
{
    public sealed class FirearmContext : DbContext
    {
        public DbSet<Firearm> Firearms { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<FirearmType> FirearmType { get; set; }
        public DbSet<Caliber> Calibers { get; set; }
        public DbSet<Ammunition> Ammunition { get; set; }

        public  FirearmContext(DbContextOptions<FirearmContext> options) : base(options)
        {
            
        }
        
    }
}
