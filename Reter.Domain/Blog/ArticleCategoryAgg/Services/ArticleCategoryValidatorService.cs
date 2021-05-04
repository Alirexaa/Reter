using System;
using Reter.Domain.Blog.ArticleCategoryAgg.Exceptions;

namespace Reter.Domain.Blog.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
                throw new DuplicatedRecordException("this record already exists in database");
        }

      
    }
}