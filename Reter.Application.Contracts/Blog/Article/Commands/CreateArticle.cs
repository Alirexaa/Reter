namespace Reter.Application.Contracts.Blog.Article.Commands
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string ArticleCategoryId  { get; set; }
    }
}