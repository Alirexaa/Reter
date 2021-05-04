using System.Collections.Generic;

namespace Reter.Domain.Blog.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Add(ArticleCategory entity);
        List<ArticleCategory> GetAll();
        ArticleCategory Get(string id);
        void Save();
        bool Exists(string title);
    }
}