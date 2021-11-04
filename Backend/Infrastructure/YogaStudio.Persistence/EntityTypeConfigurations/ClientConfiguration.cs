using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaStudio.Domain;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id).IsClustered(true);
            builder.HasMany(c => c.Subscriptions)
                .WithOne(s => s.Client)
                .HasForeignKey(s => s.ClientId);
                //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
