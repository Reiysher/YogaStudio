using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;
using YogaStudio.Persistence.EntityTypeConfigurations;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id).IsUnique().IsClustered();
        }
    }
}
