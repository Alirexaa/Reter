using System.Collections.Generic;

namespace Reter.Infrastructure.Query.Blog.Article
{
    public interface IArticleView
    {
        List<ArticleQueryView> GetArticles();

    }
}