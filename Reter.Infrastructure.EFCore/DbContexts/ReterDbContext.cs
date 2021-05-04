using Microsoft.EntityFrameworkCore;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Infrastructure.EFCore.Mapping;

namespace Reter.Infrastructure.EFCore.DbContexts
{
    public class ReterDbContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles{ get; set; }
        public ReterDbContext(DbContextOptions<ReterDbContext> opt):base(opt)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}