using EventNews.API.Abstractions;
using EventNews.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EventNews.API.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<NewsImage> NewsImages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Region> Regions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<News>().HasQueryFilter(x=>x.State != Models.Enums.EItemStates.Deleted);

            base.OnModelCreating(modelBuilder);
        }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        int IApplicationDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}