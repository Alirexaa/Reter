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
            Save();
        }

        public List<ArticleCategory> GetAll()
        {
            return _reterDbContext.ArticleCategories.OrderByDescending(x=>x.CreationTime).ToList();
        }

        public ArticleCategory Get(string id)
        {
            return _reterDbContext.ArticleCategories.FirstOrDefault(x => x.Id==id);
        }

        public void Save()
        {
            _reterDbContext.SaveChanges();
        }

        public bool Exists(string title)
        {
           return _reterDbContext.ArticleCategories.Any(x=>x.Title == title);
        }
    }
}