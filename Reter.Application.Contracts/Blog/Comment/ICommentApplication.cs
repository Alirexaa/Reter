using Reter.Application.Contracts.Blog.Comment.Commands;

namespace Reter.Application.Contracts.Blog.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment command);
    }
}