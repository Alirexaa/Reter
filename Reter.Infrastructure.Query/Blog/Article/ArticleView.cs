using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.Query.Blog.Article
{
    public class ArticleView : IArticleView
    {
        private readonly ReterDbContext _reterDbContext;

        public ArticleView(ReterDbContext reterDbContext)
        {
            _reterDbContext = reterDbContext;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _reterDbContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
                {
                    Id = x.Id,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationTime = x.CreationTime.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    Title = x.Title,
                    Image = x.Image,
                })
                .ToList();
        }
    }
}