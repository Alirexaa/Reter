namespace Reter.Application.Contracts.Blog.Comment
{
    public class CommentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string CreationTime { get; set; }
        public int Status { get; set; }
        public string Article { get; set; }
        public string ArticleId { get; set; }

    }
}