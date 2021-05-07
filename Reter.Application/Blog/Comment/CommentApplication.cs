using Reter.Application.Contracts.Blog.Comment;
using Reter.Domain.Blog.CommentAgg;

namespace Reter.Application.Blog.Comment
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
    }
}