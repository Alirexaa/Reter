namespace Reter.Application.Contracts.Blog.Comment.Commands
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string ArticleId { get; set; }
    }
}