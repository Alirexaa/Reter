using Reter.Application.Contracts.Blog.Comment;
using Reter.Application.Contracts.Blog.Comment.Commands;
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

        public void Add(AddComment command)
        {
            var comment = new Domain.Blog.CommentAgg.Comment(command.Name,command.Email,command.Message,command.ArticleId);
            _commentRepository.CreateAndSave(comment);
        }
    }
}