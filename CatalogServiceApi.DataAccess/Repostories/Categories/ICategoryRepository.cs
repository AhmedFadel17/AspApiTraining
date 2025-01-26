﻿using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.DataAccess.Repostories.Categories
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetAllCategoriesWithProductsAsync();
    }
}
