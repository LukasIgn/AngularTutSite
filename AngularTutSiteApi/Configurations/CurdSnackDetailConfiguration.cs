using AngularTutSiteApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularTutSiteApi.Configurations
{
    public class CurdSnackDetailConfiguration : IEntityTypeConfiguration<CurdSnackDetail>
    {
        public void Configure(EntityTypeBuilder<CurdSnackDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CurdSnack)
                .WithOne(x => x.Detail)
                .HasForeignKey<CurdSnack>(x => x.DetailId);

            builder.ToTable("CurdSnackDetail");
        }
    }
}
