﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reter.Domain.Blog.ArticleAgg;

namespace Reter.Infrastructure.EFCore.Mapping.Blog
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.Content);
            builder.Property(x => x.Image);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.CreationTime);
            builder.Property(x => x.ArticleCategoryId);

            builder.HasOne(x => x.ArticleCategory)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.ArticleCategoryId);

            builder.HasMany(x => x.Comments).
                WithOne(x => x.Article).
                HasForeignKey(x => x.ArticleId);
        }
    }
}