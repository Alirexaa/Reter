using System.Collections.Generic;

namespace Reter.Domain.Blog.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Create(ArticleCategory entity);
        List<ArticleCategory> GetAll();
    }
}