using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Domain.Blog.ArticleCategoryAgg;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategory> ArticleCategories { get; set; }
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ListModel(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryRepository.GetAll();
        }
    }
}
