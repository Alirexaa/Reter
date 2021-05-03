using System.Collections.Generic;
using System.Globalization;
using Reter.Application.Contracts.Blog;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Domain.Blog.ArticleCategoryAgg;

namespace Reter.Application.Blog.ArticleCategory
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> ArticleCategoryViewModels()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {

                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    CreationTime = articleCategory.CreationTime.ToString(CultureInfo.InvariantCulture),
                    Description = articleCategory.Description,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                });
            }


            return result;
        }
    }
}