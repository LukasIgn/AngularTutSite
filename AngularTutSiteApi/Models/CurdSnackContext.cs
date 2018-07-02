using Microsoft.EntityFrameworkCore;

namespace AngularTutSiteApi.Models
{
    public class CurdSnackContext : DbContext
    {
        public CurdSnackContext(DbContextOptions<CurdSnackContext> options)
            : base(options)
        {
        }

        public DbSet<CurdSnack> CurdSnacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurdSnack>().ToTable("CurdSnacks");
        }

    }
}
