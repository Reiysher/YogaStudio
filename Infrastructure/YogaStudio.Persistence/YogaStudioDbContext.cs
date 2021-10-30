using Microsoft.EntityFrameworkCore;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;
using YogaStudio.Persistence.EntityTypeConfigurations;

namespace YogaStudio.Persistence
{
    public class YogaStudioDbContext : DbContext, IYogaStudioDbContext
    {
        public DbSet<YogaClass> Classes { get; set; }

        public YogaStudioDbContext(DbContextOptions<YogaStudioDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new YogaClassConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
