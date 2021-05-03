using System.Collections.Generic;
using System.Linq;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.Blog.Repositories
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly ReterDbContext _reterDbContext;

        public ArticleCategoryRepository(ReterDbContext reterDbContext)
        {
            _reterDbContext = reterDbContext;
        }

        public void Add(ArticleCategory entity)
        {
            _reterDbContext.ArticleCategories.Add(entity);
            _reterDbContext.SaveChanges();
        }

        public List<ArticleCategory> GetAll()
        {
            return _reterDbContext.ArticleCategories.OrderByDescending(x=>x.CreationTime).ToList();
        }
    }
}