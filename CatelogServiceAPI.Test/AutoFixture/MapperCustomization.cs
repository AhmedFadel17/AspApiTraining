using AutoFixture;
using AutoMapper;
using CatalogServiceApi.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Test.AutoFixture;

public class MapperCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        var mapper = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
           
        }).CreateMapper();

        fixture.Customize<IMapper>(x => x.FromFactory(() => mapper));
    }
}
