using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Public.Framework.Domain;
using Reter.Domain.Blog.ArticleAgg.Services;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Domain.Blog.CommentAgg;

namespace Reter.Domain.Blog.ArticleAgg
{
    public class Article:DomainBase<string>
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }
        public bool IsDeleted { get; private set; }
        public string ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        protected Article()
        {
            
        }

        public Article(string title, string shortDescription, string content, string image, string articleCategoryId,IArticleValidatorService service)
        {
            ValidateArgument(title, articleCategoryId);
            service.CheckThatThisRecordAlreadyExists(title);
            Id = Guid.NewGuid().ToString();
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Image = image;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            Comments = new List<Comment>();
        }

        private static void ValidateArgument(string title, string articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException();
            if (articleCategoryId == "0")
                throw new ArgumentOutOfRangeException();
        }

        public void Edit(string title,string shortDescription,string content, string image,string articleCategoryId)
        {
            ValidateArgument(title, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Image = image;
            ArticleCategoryId = articleCategoryId;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}