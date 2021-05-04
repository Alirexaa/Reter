using System.Collections.Generic;
using System.Globalization;
using Reter.Application.Contracts.Blog.Article;
using Reter.Domain.Blog.ArticleAgg;

namespace Reter.Application.Blog.Article
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}