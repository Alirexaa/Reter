using System.Collections.Generic;
using Public.Framework.Infrastructure;

namespace Reter.Domain.Blog.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository:IRepository<string,ArticleCategory>
    { public List<ArticleCategory> GetAll();
    }
}