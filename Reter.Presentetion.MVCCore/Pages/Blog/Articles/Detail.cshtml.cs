using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Infrastructure.Query.Blog.Article;

namespace Reter.Presentation.MVCCore.Pages.Blog.Article
{
    public class DetailModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleView _articleView;

        public DetailModel(IArticleView articleView)
        {
            _articleView = articleView;
        }

        public void OnGet(string id)
        {
            Article = _articleView.GetArticle(id);
        }
    }
}
