using Microsoft.EntityFrameworkCore;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;
using YogaStudio.Persistence.EntityTypeConfigurations;

namespace YogaStudio.Persistence
{
    public class YogaStudioDbContext : DbContext, IYogaStudioDbContext
    {
        public DbSet<YogaClass> Classes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Mentor> Mentors { get; set; }

        public YogaStudioDbContext(DbContextOptions<YogaStudioDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new YogaClassConfiguration());
            builder.ApplyConfiguration(new SubscriptionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
