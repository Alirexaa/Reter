using System.Collections.Generic;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.Comment.Commands;

namespace Reter.Application.Contracts.Blog.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment command);
        List<CommentViewModel> GetComments();
        void Confirm(string id);
        void Delete(string id);
    }
}