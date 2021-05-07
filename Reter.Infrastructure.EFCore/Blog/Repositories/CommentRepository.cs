using Reter.Domain.Blog.CommentAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.Blog.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly ReterDbContext _context;

        public CommentRepository(ReterDbContext context)
        {
            _context = context;
        }
    }
}