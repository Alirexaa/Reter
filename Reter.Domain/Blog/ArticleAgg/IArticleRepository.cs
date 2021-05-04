﻿using System.Collections.Generic;
using Reter.Application.Contracts.Blog.Article;

namespace Reter.Domain.Blog.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        Article Get(string id);
    }
}