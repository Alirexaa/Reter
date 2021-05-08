using System.Collections.Generic;
using System.Globalization;
using Public.Framework.Infrastructure;
using Reter.Application.Contracts.Blog.Article;
using Reter.Application.Contracts.Blog.Article.Commands;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Domain.Blog.ArticleAgg.Services;

namespace Reter.Application.Blog.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _articleValidatorService;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
            _unitOfWork = unitOfWork;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Domain.Blog.ArticleAgg.Article(command.Title, command.ShortDescription, command.Content,
                command.Image, command.ArticleCategoryId, _articleValidatorService);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Content, command.Image,
                command.ArticleCategoryId);
            _unitOfWork.CommitTran();
        }

        public EditArticle Get(string id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle()
            {
                Title = article.Title,
                ArticleCategoryId = article.ArticleCategoryId,
                Content = article.Content,
                Id = article.Id,
                Image = article.Image,
                ShortDescription = article.ShortDescription,
            };
        }

        public void Remove(string id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Delete();
            _unitOfWork.CommitTran();
        }

        public void Activate(string id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }
    }
}