using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public List<Comment> GetAll()
        {
           return _context.Comments.Include(x=>x.Article).ToList();
        }

        public Comment Get(string id)
        {
            return _context.Comments.Include(x=>x.Article).FirstOrDefault(x => x.Id == id);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}