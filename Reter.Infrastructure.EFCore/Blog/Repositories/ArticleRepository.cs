using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reter.Application.Contracts.Blog.Article;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Infrastructure.EFCore.DbContexts;

namespace Reter.Infrastructure.EFCore.Blog.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly ReterDbContext _reterDbContext;

        public ArticleRepository(ReterDbContext reterDbContext)
        {
            _reterDbContext = reterDbContext;
        }

        public List<ArticleViewModel> GetList()
        {
            return _reterDbContext.Articles.Include(x=>x.ArticleCategory).Select(x=> new ArticleViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationTime = x.CreationTime.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title
                    
            }).ToList();
        }

        public Article Get(string id)
        {
            return _reterDbContext.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Article entity)
        {
            _reterDbContext.Articles.Add(entity);
            Save();
        }

        public void Save()
        {
            _reterDbContext.SaveChanges();
        }
    }
}