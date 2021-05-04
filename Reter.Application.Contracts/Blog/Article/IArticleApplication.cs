using System.Collections.Generic;

namespace Reter.Application.Contracts.Blog.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
    }
}