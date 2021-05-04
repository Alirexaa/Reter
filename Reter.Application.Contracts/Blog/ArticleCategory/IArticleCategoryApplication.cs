using System.Collections.Generic;
using Reter.Application.Contracts.Blog.ArticleCategory.Commands;

namespace Reter.Application.Contracts.Blog.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Add(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        EditArticleCategory Get(string id);
        void Remove(string id);
        void Activate(string id);


    }
}
