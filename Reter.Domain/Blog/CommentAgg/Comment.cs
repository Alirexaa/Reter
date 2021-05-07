using System;
using Reter.Domain.Blog.ArticleAgg;

namespace Reter.Domain.Blog.CommentAgg
{
    public class Comment
    {
        public string  Id { get; private set; }
        public string  Name { get; private set; }
        public string  Email { get; private set; }
        public string  Message { get; private set; }
        public int  Status { get; private set; } // 0 : new Comment , 1 : Confirm , 2 : Canceled
        public DateTime  CreationTime { get; private set; }
        public string  ArticleId { private set; get; }
        public Article Article { get; private set; }


        protected Comment()
        {
            
        }
        public Comment(string name, string email, string message, string articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            Status = Statuses.New;
            CreationTime = DateTime.Now;
        }

        
    }
}