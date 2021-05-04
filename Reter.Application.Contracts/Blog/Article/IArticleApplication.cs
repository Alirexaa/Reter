using System.Collections.Generic;
using Reter.Application.Contracts.Blog.Article.Commands;

namespace Reter.Application.Contracts.Blog.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
    }
}