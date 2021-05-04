using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Domain.Blog.ArticleCategoryAgg;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication= articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }

        public RedirectToPageResult OnPostRemove(string id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./list");
        }

        public RedirectToPageResult OnPostActivate(string id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("./list");
        }
    }
}
