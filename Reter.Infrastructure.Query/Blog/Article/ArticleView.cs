using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reter.Domain.Blog.CommentAgg;
using Reter.Infrastructure.EFCore.DbContexts;
using Reter.Infrastructure.Query.Blog.Comment;

namespace Reter.Infrastructure.Query.Blog.Article
{
    public class ArticleView : IArticleView
    {
        private readonly ReterDbContext _reterDbContext;

        public ArticleView(ReterDbContext reterDbContext)
        {
            _reterDbContext = reterDbContext;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _reterDbContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
                {
                    Id = x.Id,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationTime = x.CreationTime.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    Title = x.Title,
                    Image = x.Image,
                    CommentCount = x.Comments.Count(comment=>comment.Status == Statuses.Confirm).ToString(),
                })
                .ToList();
        }

        public ArticleQueryView GetArticle(string id)
        {
            return _reterDbContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
            {

                Id = x.Id,
                ArticleCategory = x.ArticleCategory.Title,
                CreationTime = x.CreationTime.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Image = x.Image,
                Content = x.Content,
                CommentCount = x.Comments.Count(comment => comment.Status == Statuses.Confirm).ToString(),
                Comments = MapComments(x.Comments.Where(comment=>comment.Status==Statuses.Confirm)),
            }).FirstOrDefault(x=>x.Id==id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Domain.Blog.CommentAgg.Comment> comments)
        {
           return comments.Select(x => new CommentQueryView()
            {
                Name = x.Name,
                Message = x.Message,
                CreationTime = x.CreationTime.ToString(CultureInfo.InvariantCulture),
            }).ToList();
        }
    }
}