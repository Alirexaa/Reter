using System;

namespace Reter.Domain.Blog.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationTime { get; private set; }

        public ArticleCategory(string title, string description)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            IsDeleted = false;
            CreationTime = DateTime.Now;
        }
    }
}