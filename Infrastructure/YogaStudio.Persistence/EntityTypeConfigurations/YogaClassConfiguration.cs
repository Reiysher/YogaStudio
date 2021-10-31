﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaStudio.Domain;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class YogaClassConfiguration : IEntityTypeConfiguration<YogaClass>
    {
        public void Configure(EntityTypeBuilder<YogaClass> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id)
                .IsUnique()
                .IsClustered();
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.YogaClass)
                .HasForeignKey(o => o.YogaClassId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
