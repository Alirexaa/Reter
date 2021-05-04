using System;
using System.Reflection.Metadata.Ecma335;
using Reter.Domain.Blog.ArticleCategoryAgg;

namespace Reter.Domain.Blog.ArticleAgg
{
    public class Article
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationTime { get; private set; }
        public string ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
            
        }

        public Article(string title, string shortDescription, string content, string image, string articleCategoryId)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Image = image;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationTime = DateTime.Now;
        }

        public void Edit(string title,string shortDescription,string content, string image,string articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            Image = image;
            ArticleCategoryId = articleCategoryId;
        }
    }
}