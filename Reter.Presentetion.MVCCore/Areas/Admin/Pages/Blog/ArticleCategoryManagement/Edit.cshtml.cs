using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.ArticleCategory.Commands;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(string id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
