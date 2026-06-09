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
        DbSet<FileEntity> Files { get; set; }
        DbSet<NewsImage> NewsImages { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<ApplicationForm> ApplicationForms { get; set; }
        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
        int SaveChanges();
    }
}
