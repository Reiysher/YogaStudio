using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Domain;

namespace YogaStudio.Application.Common
{
    // TODO: Or UoW?
    public interface IYogaStudioDbContext
    {
        DbSet<YogaClass> Classes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
