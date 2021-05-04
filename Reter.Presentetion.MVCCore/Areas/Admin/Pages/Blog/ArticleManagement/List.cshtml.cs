using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Blog.Article;
using Reter.Application.Contracts.Blog.Article;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }

        public RedirectToPageResult OnPostActivate(string id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostRemove(string id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./List");
        }
    }
}
