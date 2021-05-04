using System.Collections.Generic;
using System.Globalization;
using Reter.Application.Contracts.Blog;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.ArticleCategory.Commands;
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

        public List<ArticleCategoryViewModel> List()
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

        public void Add(CreateArticleCategory command)
        {
            var articleCategory =
                new Domain.Blog.ArticleCategoryAgg.ArticleCategory(command.Title, command.Description);
            _articleCategoryRepository.Add(articleCategory);

        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Edit(command.Title,command.Description);
            _articleCategoryRepository.Save();
        }

        public EditArticleCategory Get(string id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new EditArticleCategory()
            {
                Id = articleCategory.Id,
                Description = articleCategory.Description,
                Title = articleCategory.Title,
            };
        }

        public void Remove(string id)
        {
           var articleCategory =  _articleCategoryRepository.Get(id);
           articleCategory.Remove();
           _articleCategoryRepository.Save();
        }

        public void Activate(string id)
        {
          var articleCategory=  _articleCategoryRepository.Get(id);
          articleCategory.Activate();
          _articleCategoryRepository.Save(); 
        }
    }
}