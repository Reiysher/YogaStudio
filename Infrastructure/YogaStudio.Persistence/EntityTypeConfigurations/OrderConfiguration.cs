using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaStudio.Domain;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id)
                .IsUnique()
                .IsClustered();
            builder.HasOne(o => o.Subscription)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SubscriptionId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(o => o.YogaClass)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.YogaClassId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
