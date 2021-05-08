using System.Collections.Generic;
using System.Globalization;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.Blog;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.ArticleCategory.Commands;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Domain.Blog.ArticleCategoryAgg.Services;

namespace Reter.Application.Blog.ArticleCategory
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
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
            _unitOfWork.BeginTran();
            var articleCategory =
                new Domain.Blog.ArticleCategoryAgg.ArticleCategory(command.Title, command.Description, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Edit(command.Title, command.Description);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }

        public void Activate(string id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _unitOfWork.CommitTran();
        }
    }
}