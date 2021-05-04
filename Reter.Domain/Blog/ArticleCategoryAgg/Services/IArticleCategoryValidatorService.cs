namespace Reter.Domain.Blog.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string title);
    }
}