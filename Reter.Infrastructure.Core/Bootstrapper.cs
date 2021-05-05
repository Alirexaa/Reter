using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reter.Application.Blog.Article;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Infrastructure.EFCore.Blog.Repositories;
using Reter.Infrastructure.EFCore.DbContexts;
using Reter.Application.Blog.ArticleCategory;
using Reter.Application.Contracts.Blog.Article;
using Reter.Domain.Blog.ArticleAgg;
using Reter.Domain.Blog.ArticleAgg.Services;
using Reter.Domain.Blog.ArticleCategoryAgg.Services;
using Reter.Infrastructure.Query.Blog.Article;

namespace Reter.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddDbContext<ReterDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleValidatorService, ArticleValidatorService>();
            services.AddTransient<IArticleView, ArticleView>();
        }
    }
    
}
