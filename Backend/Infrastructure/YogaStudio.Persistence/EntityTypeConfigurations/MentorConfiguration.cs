using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using YogaStudio.Domain;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
            builder.HasKey(m => m.Id).IsClustered(true);
            builder.HasMany(m => m.Classes)
                .WithOne(c => c.Mentor)
                .HasForeignKey(c => c.MentorId);
            builder.HasData(
                new Mentor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "",
                    LastName = "",
                    PhoneNumber = "",
                });
        }
    }
}
