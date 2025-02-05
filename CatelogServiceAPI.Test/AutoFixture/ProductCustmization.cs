using AutoFixture;
using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Models;
using CatelogServiceAPI.Test.Featrues.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CatelogServiceAPI.Test.AutoFixture
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

            fixture.Customize<PriceRange>(composer =>
            {
                return composer
                    .With(pr => pr.Min, 100)
                    .With(pr => pr.Max, 50); 
            });
        }
    }
}
