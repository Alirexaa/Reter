using System.Collections.Generic;
using System.Linq;
using Public.Framework.Infrastructure;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.Blog.Repositories
{
    public class ArticleCategoryRepository:BaseRepository<string,ArticleCategory>,IArticleCategoryRepository
    {
        private readonly ReterDbContext _reterDbContext;

        public ArticleCategoryRepository(ReterDbContext reterDbContext):base(reterDbContext)
        {
            _reterDbContext = reterDbContext;
        }


        public List<ArticleCategory> GetAll()
        {
            return _reterDbContext.ArticleCategories.OrderByDescending(x=>x.CreationTime).ToList();
        }



        
    }
}