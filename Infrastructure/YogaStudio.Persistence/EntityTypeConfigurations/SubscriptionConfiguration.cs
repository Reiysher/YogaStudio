﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaStudio.Domain;

namespace YogaStudio.Persistence.EntityTypeConfigurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id)
                .IsUnique()
                .IsClustered();
            //builder.HasMany(s => s.Classes)
            //    .WithMany(c => c.Subscriptions)
            //    .UsingEntity(e => e.ToTable("Orders"));
        }
    }
}
