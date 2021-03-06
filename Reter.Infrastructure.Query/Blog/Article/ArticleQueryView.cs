using System.Collections.Generic;
using Reter.Infrastructure.Query.Blog.Comment;

namespace Reter.Infrastructure.Query.Blog.Article
{
    public class ArticleQueryView
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string CreationTime { get; set; }
        public string ArticleCategory { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public List<CommentQueryView> Comments  { get; set; }
        public string CommentCount { get; set; }
    }
}