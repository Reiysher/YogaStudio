using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Domain;

namespace YogaStudio.Application.Interfaces
{
    public interface IYogaStudioDbContext
    {
        DbSet<YogaClass> Classes { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Mentor> Mentors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
