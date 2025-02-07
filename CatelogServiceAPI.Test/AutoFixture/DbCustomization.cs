using AutoFixture;
using CatalogServiceApi.DataAccess.Data;
using CatalogServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;

namespace CatalogServiceApi.Test.AutoFixture
{
    public class DbCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            fixture.Customize<ApplicationDbContext>(x => x.FromFactory(() => context));
        }
    }
}
