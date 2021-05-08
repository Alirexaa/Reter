using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.Blog.Article;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.Blog.Repositories
{
    public class ArticleRepository:BaseRepository<string,Article>, IArticleRepository
    {
        private readonly ReterDbContext _reterDbContext;

        public ArticleRepository(ReterDbContext reterDbContext):base(reterDbContext)
        {
            _reterDbContext = reterDbContext;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _reterDbContext.Articles.Include(x=>x.ArticleCategory).Select(x=> new ArticleViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationTime = x.CreationTime.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title
                    
            }).ToList();
        }

    }
}