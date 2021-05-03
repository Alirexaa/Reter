using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.ArticleCategory;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {

        }

        public RedirectToPageResult OnPost(CreateArticleCategory command)
        {
            _articleCategoryApplication.Create(command);
           return RedirectToPage("./list");
        }
    }
}
