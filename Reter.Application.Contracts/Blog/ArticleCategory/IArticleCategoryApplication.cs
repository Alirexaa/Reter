﻿using System.Collections.Generic;

namespace Reter.Application.Contracts.Blog.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> ArticleCategoryViewModels();
    }
}