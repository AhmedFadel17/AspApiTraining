﻿using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.Domain.Settings;
using CatalogServiceApi.IntegrationTest.Extensions;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json.Serialization;

namespace CatalogServiceApi.IntegrationTest.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly IdentitySetting _settings;
        private readonly IMemoryCache _cache;

        public AuthService(IdentitySetting identitySetting, IMemoryCache memoryCache)
        {
            _settings = identitySetting;
            _client = new HttpClient();
            _cache = memoryCache;
        }



        // I memory cache
        public async Task<string> GetTokenAsync(UserRole role)
        {
            string cacheKey = $"AuthToken_{role}";

            if (_cache.TryGetValue(cacheKey, out string cachedToken))
            {
                return cachedToken;
            }
            var user = _settings.TestUsers.FirstOrDefault(u => u.Role == role.ToString());

            if (user == null)
                throw new ArgumentException("Invalid role provided", nameof(role));

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.Url}/connect/token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id",_settings.ClientId },
                    { "grant_type", _settings.GrantType },
                    { "username", user.Username },
                    { "client_secret", _settings.ClientSecret },
                    {"password",user.Password },
                    { "scope", _settings.Scope }
                })
            };

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsJsonAsync<TokenResponse>();
            string token = result.access_token;
            _cache.Set(cacheKey, token, TimeSpan.FromHours(1));
            return token;
        }
    }

    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string access_token { get; set; }
    }
}
