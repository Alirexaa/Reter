using System.Collections.Generic;

namespace Reter.Domain.Blog.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);
        List<Comment> GetAll();
        Comment Get(string id);
        void Save();
    }
}