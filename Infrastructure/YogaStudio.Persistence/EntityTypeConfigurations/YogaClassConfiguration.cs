using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaStudio.Domain;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class YogaClassConfiguration : IEntityTypeConfiguration<YogaClass>
    {
        public void Configure(EntityTypeBuilder<YogaClass> builder)
        {
            builder.ToTable("Classes");
            builder.HasKey(c => c.Id).IsClustered(true);
            builder.HasMany(c => c.Subscriptions)
                .WithMany(s => s.Classes)
                .UsingEntity(e => e.ToTable("Orders"));
        }
    }
}
