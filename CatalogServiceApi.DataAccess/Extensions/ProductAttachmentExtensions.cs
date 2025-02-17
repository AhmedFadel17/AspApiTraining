using CatalogServiceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.DataAccess.Extensions
{
    public static class ProductAttachmentExtensions
    {
        public static IQueryable<ProductAttachment> FilterByBrandName(this IQueryable<ProductAttachment> query, string name)
        {
            return query.Where(a => a.BrandName.Contains(name));
        }

        

        public static IQueryable<ProductAttachment> FilterByProductName(this IQueryable<ProductAttachment> query, string name)
        {
            return query.Where(a => a.Product.Name.Contains(name));
        }

        public static IQueryable<ProductAttachment> FilterByCategoryName(this IQueryable<ProductAttachment> query, string name)
        {
            return query.Where(a => a.Product.Category.Name.Contains(name));
        }

        public static IQueryable<ProductAttachment> FilterByMinDiscountPercentage(this IQueryable<ProductAttachment> query,decimal min)
        {
            return query.Where(a => a.DiscountPercentage >= min);
        }

        public static IQueryable<ProductAttachment> FilterByMinProductPrice(this IQueryable<ProductAttachment> query,decimal min)
        {
            return query.Where(a => a.Product.Price >= min);
        }
    }
}
