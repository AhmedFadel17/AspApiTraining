﻿using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace CatalogServiceApi.WebUi.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ServiceProviderExtensions
    {
        public static T GetJsonSection<T>(this IConfiguration configuration, string key)
        {
            var valueObject = configuration.GetSection(key).Get<T>();

            // try to get configuration from environment variable
            if (valueObject is null)

                return JsonSerializer.Deserialize<T>(configuration.GetSection(key)?.Value);

            return valueObject;
        }
    }
}
