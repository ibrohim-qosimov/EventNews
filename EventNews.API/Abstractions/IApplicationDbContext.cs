using EventNews.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EventNews.API.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<News> News { get; set; }
        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
        int SaveChanges();
    }
}
