using KeyboardComponentCatalog.DataStores.Configurations;
using KeyboardComponentCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyboardComponentCatalog.DataStores
{
    public class KeyboardComponentCatalogContext : DbContext
    {
        public KeyboardComponentCatalogContext(DbContextOptions<KeyboardComponentCatalogContext> options) : base(options)
        {
        }
        
        public DbSet<Case> CaseDb { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CaseConfig());
        }
    }  
}