using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Public.Framework.Infrastructure;
using Reter.Domain.Blog.CommentAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.Blog.Repositories
{
    public class CommentRepository:BaseRepository<string,Comment>,ICommentRepository
    {
        private readonly ReterDbContext _context;

        public CommentRepository(ReterDbContext context) : base(context)
        {
            _context = context;
        }

        public  List<Comment> GetAll()
        {
           return _context.Comments.Include(x=>x.Article).ToList();
        }

    }
}