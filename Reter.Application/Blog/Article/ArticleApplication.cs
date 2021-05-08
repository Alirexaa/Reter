﻿using System.Collections.Generic;
using System.Globalization;
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
        public ArticleApplication(IArticleRepository articleRepository,IArticleValidatorService articleValidatorService)
        {
            _articleRepository = articleRepository;
            _articleValidatorService = articleValidatorService;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticle command)
        {
            var article = new Domain.Blog.ArticleAgg.Article(command.Title, command.ShortDescription, command.Content,
                command.Image, command.ArticleCategoryId,_articleValidatorService);
            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Content, command.Image,
                command.ArticleCategoryId);
            //_articleRepository.Save();
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
            var article = _articleRepository.Get(id);
            article.Delete();
            //_articleRepository.Save();
        }

        public void Activate(string id)
        {

            var article = _articleRepository.Get(id);
            article.Activate();
            //_articleRepository.Save();
        }
    }
}