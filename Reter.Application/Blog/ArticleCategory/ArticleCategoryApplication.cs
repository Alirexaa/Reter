using System.Collections.Generic;
using Reter.Application.Contracts.Blog;
using Reter.Application.Contracts.Blog.ArticleCategory;

namespace Reter.Application.Blog.ArticleCategory
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        public List<ArticleCategoryViewModel> ArticleCategoryViewModels()
        {
            //Connect to Db , Map DbModel To ViewModel
            return new List<ArticleCategoryViewModel>();
        }
    }
}