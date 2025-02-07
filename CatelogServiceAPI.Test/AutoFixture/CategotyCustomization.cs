using AutoFixture;
using CatalogServiceApi.Domain.Models;

namespace CatalogServiceApi.Test.AutoFixture
{
    public class CategotyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            

            fixture.Customize<Category>(composer =>
            {
                return composer
                    .With(t => t.Products, new List<Product> {});

            });

        }
    }
}
