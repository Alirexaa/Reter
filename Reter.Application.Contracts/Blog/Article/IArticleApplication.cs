using System;
using System.Collections.Generic;
using Reter.Application.Contracts.Blog.Article.Commands;

namespace Reter.Application.Contracts.Blog.Article
{
    public interface IArticleApplication:IDisposable
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle Get(string id);
        void Remove(string id);
        void Activate(string id);
    }
}