using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reter.Application.Contracts.Blog.Article;
using Reter.Application.Contracts.Blog.Article.Commands;
using Reter.Application.Contracts.Blog.ArticleCategory;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.ArticleManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        [BindProperty]
        public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }


        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(string id)
        {
            ArticleCategories = _articleCategoryApplication.List().Select(x => new SelectListItem(x.Title, x.Id))
                .ToList();
            Article = _articleApplication.Get(id);

        }

        public RedirectToPageResult OnPost(EditArticle command)
        {
            _articleApplication.Edit(command);
            return RedirectToPage("./List");
        }
    }
}