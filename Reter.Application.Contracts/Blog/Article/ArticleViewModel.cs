namespace Reter.Application.Contracts.Blog.Article
{
    public class ArticleViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CreationTime { get; set; }
        public string ArticleCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}