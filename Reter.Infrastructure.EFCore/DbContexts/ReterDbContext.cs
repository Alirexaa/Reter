using Microsoft.EntityFrameworkCore;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Domain.Blog.CommentAgg;
using Reter.Infrastructure.EFCore.Mapping.Blog;

namespace Reter.Infrastructure.EFCore.DbContexts
{
    public class ReterDbContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Domain.UserAgg.User> Users { get; set; }

        public ReterDbContext(DbContextOptions<ReterDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);


            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new CommentMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}