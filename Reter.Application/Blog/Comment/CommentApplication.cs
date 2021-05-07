using System.Collections.Generic;
using System.Globalization;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.Comment;
using Reter.Application.Contracts.Blog.Comment.Commands;
using Reter.Domain.Blog.CommentAgg;

namespace Reter.Application.Blog.Comment
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment =
                new Domain.Blog.CommentAgg.Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.CreateAndSave(comment);
        }

        public List<CommentViewModel> GetComments()
        {
            var comments = _commentRepository.GetAll();
            var result = new List<CommentViewModel>();
            foreach (var comment in comments)
            {
                result.Add(new CommentViewModel()
                {
                    Id = comment.Id,
                    Name = comment.Name,
                    Email = comment.Email,
                    Message = comment.Message,
                    CreationTime = comment.CreationTime.ToString(CultureInfo.InvariantCulture),
                    Status = comment.Status,
                    Article = comment.Article.Title,
                    ArticleId = comment.ArticleId
                });
            }

            return result;
        }

        public void Confirm(string id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Delete(string id)
        {
            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _commentRepository.Save();
        }
    }
}