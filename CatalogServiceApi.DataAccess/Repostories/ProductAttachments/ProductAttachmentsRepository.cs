using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using CatalogServiceApi.DataAccess.Extensions;

namespace CatalogServiceApi.DataAccess.Repostories.ProductAttachments
{
    public class ProductAttachmentsRepository : BaseRepository<ProductAttachment>, IProductAttachmentsRepository
    {
        public ProductAttachmentsRepository(ApplicationDbContext context) : base(context) { }

        // LINQ Method Syntax
        public async Task<IEnumerable<ProductAttachment>> GetByBrandNameLinqAsync(string name)
        {
            var attachments = await _dbSet.Where(x => x.BrandName.Contains(name)).ToListAsync();
            return attachments;
        }

        // Dynamic LINQ
        public async Task<IEnumerable<ProductAttachment>> GetByBrandNameDLinqAsync(string name)
        {
            return await _dbSet
                .Where($"BrandName.Contains(@0)", name)
                .ToListAsync();
        }



        // Dynamic Expressions
        public async Task<IEnumerable<ProductAttachment>> GetByBrandNameDEAsync(string name)
        {
            var parameter = Expression.Parameter(typeof(ProductAttachment), "a");
            var property = Expression.Property(parameter, "BrandName");
            var constant = Expression.Constant(name);
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containsExpression = Expression.Call(property, containsMethod, constant);
            var lambda = Expression.Lambda<Func<ProductAttachment, bool>>(containsExpression, parameter);

            return await _dbSet.Where(lambda).ToListAsync();
        }

        // Extension Methods
        public async Task<IEnumerable<ProductAttachment>> GetByBrandNameEMAsync(string name)
        {
            return await _dbSet.FilterByBrandName(name).ToListAsync();
        }



        public async Task<ProductAttachment> GetByIdWithProductAsync(int id)
        {
            return await _dbSet
                .Include(pa => pa.Product) 
                .FirstOrDefaultAsync(pa => pa.Id == id);
        }

        public async Task<IEnumerable<ProductAttachment>> GetAllWithFiltersAsync
            (string name, string productName, decimal minProductPrice, int minDiscount, string categoryName)
        {
            return await _dbSet.FilterByBrandName(name)
                .FilterByProductName(productName)
                .FilterByCategoryName(categoryName)
                .FilterByMinProductPrice(minProductPrice)
                .FilterByMinDiscountPercentage(minDiscount)
                .Include(pa => pa.Product)
                .ToListAsync();
        }
    }
    
}
