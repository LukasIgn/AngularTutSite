using AngularTutSiteApi.Configurations;
using AngularTutSiteApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngularTutSiteApi.Contexts
{
    public class CurdSnackContext : DbContext
    {
        public CurdSnackContext(DbContextOptions<CurdSnackContext> options)
            : base(options)
        {
        }

        public DbSet<CurdSnack> CurdSnacks { get; set; }

        public DbSet<CurdSnackDetail> CurdSnackDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurdSnackConfiguration());
            modelBuilder.ApplyConfiguration(new CurdSnackDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
