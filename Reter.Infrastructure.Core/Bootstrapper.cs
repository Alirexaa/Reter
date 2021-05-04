using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reter.Application.Contracts.Blog.ArticleCategory;
using Reter.Domain.Blog.ArticleCategoryAgg;
using Reter.Infrastructure.EFCore.Blog.Repositories;
using Reter.Infrastructure.EFCore.DbContexts;
using Reter.Application.Blog.ArticleCategory;
using Reter.Domain.Blog.ArticleCategoryAgg.Services;

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
        }
    }
    
}
