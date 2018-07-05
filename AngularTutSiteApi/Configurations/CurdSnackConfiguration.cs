using AngularTutSiteApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularTutSiteApi.Configurations
{
    public class CurdSnackConfiguration : IEntityTypeConfiguration<CurdSnack>
    {
        public void Configure(EntityTypeBuilder<CurdSnack> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CurdSnack");
        }
    }
}
