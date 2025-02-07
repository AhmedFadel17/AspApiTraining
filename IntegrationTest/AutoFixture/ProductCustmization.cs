using AutoFixture;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Models;

namespace CatalogServiceAPI.IntegrationTest.AutoFixture
{
    
    public class ProductCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<ProductResponseDto>(composer =>
            {
                return composer
                    .With(t => t.Name, "Fadel Co");
                    
            });

            fixture.Customize<Product>(composer =>
            {
                return composer
                    .With(t => t.Category, new Category { Name="Cat1" });

            });
            
        }
    }
}
