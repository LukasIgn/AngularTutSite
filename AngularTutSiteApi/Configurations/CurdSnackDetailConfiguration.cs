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
            builder.ToTable("CurdSnackDetail");
        }
    }
}
