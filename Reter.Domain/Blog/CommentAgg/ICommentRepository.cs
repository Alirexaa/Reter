using System.Collections.Generic;
using Public.Framework.Infrastructure;

namespace Reter.Domain.Blog.CommentAgg
{
    public interface ICommentRepository: IRepository<string, Comment>
    {

        List<Comment> GetAll();
    }
}