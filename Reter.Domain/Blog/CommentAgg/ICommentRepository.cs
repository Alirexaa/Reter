using System.Collections.Generic;

namespace Reter.Domain.Blog.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);

    }
}