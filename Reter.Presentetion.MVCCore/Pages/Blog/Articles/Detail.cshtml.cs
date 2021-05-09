using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Contracts.Blog.Comment;
using Reter.Application.Contracts.Blog.Comment.Commands;
using Reter.Infrastructure.Query.Blog.Article;

namespace Reter.Presentation.MVCCore.Pages.Blog.Articles
{
    public class DetailModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleView _articleView;
        private readonly ICommentApplication _commentApplication;


        public DetailModel(IArticleView articleView, ICommentApplication commentApplication)
        {
            _articleView = articleView;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Article = _articleView.GetArticle(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./detail");
        }
    }
}
