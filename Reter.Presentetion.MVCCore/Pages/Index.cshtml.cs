using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Infrastructure.Query.Blog.Article;

namespace Reter.Presentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleView _articleView;
        public List<ArticleQueryView> Article { get; set; }
        public IndexModel(IArticleView articleView)
        {
            _articleView = articleView;
        }


        public void OnGet()
        {
            Article = _articleView.GetArticles();
        }
    }
}
