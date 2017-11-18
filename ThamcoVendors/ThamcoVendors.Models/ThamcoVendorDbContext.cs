using Microsoft.EntityFrameworkCore;

namespace ThamcoVendors.Models
{
    public class ThamcoVendorDbContext : DbContext
    {
        public ThamcoVendorDbContext(DbContextOptions<ThamcoVendorDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>()
                .HasKey(b => b.Name);

        }
    }
}
