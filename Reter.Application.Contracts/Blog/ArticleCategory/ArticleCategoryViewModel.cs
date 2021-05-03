namespace Reter.Application.Contracts.Blog.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}