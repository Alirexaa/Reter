using Reter.Domain.Blog.ArticleCategoryAgg.Exceptions;

namespace Reter.Domain.Blog.ArticleAgg.Services
{
    public class ArticleValidatorService:IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleRepository.Exists(title))
                throw new DuplicatedRecordException("this record already exists in database");
        }
    }
}