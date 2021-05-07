using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Public.Framework.Domain;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Domain.Blog.ArticleCategoryAgg.Services;

namespace Reter.Domain.Blog.ArticleCategoryAgg
{
    public class ArticleCategory: DomainBase<string>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; private set; }
        protected ArticleCategory()
        {
            
        }
        public ArticleCategory(string title, string description,IArticleCategoryValidatorService service)
        {
            GuardAgainstEmptyTitle(title);
            service.CheckThatThisRecordAlreadyExists(title);
            GuardAgainstEmptyDescription(description);

            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            IsDeleted = false;
            Articles = new List<Article>();

        }

        public void Edit(string title,string description)
        {
            GuardAgainstEmptyTitle(title);
            GuardAgainstEmptyDescription(description);
            Title = title;
            Description = description;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title is null or empty");
        }
        public void GuardAgainstEmptyDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException($"{nameof(description)} is null or empty");
        }
    }
}