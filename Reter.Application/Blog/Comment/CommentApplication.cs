using System.Collections.Generic;
using System.Globalization;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.Comment;
using Reter.Application.Contracts.Blog.Comment.Commands;
using Reter.Domain.Blog.CommentAgg;

namespace Reter.Application.Blog.Comment
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComment command)
        {
            _unitOfWork.BeginTran();
            var comment =
                new Domain.Blog.CommentAgg.Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _unitOfWork.CommitTran();
        }

        public void Delete(string id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Cancel();
           _unitOfWork.CommitTran();
        }
    }
}