using System.Collections.Generic;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.Blog.Article;

namespace Reter.Domain.Blog.ArticleAgg
{
    public interface IArticleRepository:IRepository<string,Article>
    {
        public List<ArticleViewModel> GetAll();
    }
}