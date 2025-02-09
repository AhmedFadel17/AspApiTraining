using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Domain.Enums;
using CatalogServiceApi.IntegrationTest.Extensions;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CatalogServiceApi.IntegrationTest.Services
{
    public class AuthService
    {
        private readonly HttpClient _client;
        private readonly string _identityServerUrl;

        // Static constructor to load configuration once
        public AuthService()
        {
            //_identityServerUrl = configuration.GetValue<string>("IdentityUrl");
            _identityServerUrl = "https://localhost:7092";
            _client =new HttpClient();
        }

        private static readonly Dictionary<UserRole, (string username, string password)> TestUsers =
            new()
            {
                { UserRole.Manager, ("ahmedfadel", "Ahmed2_") },
                { UserRole.Customer, ("test_customer_2", "Customer33_") },
                { UserRole.Store, ("test_store_3", "Store2_") }
            };
        public async Task<string> GetTokenAsync(UserRole role)
        {
            if (!TestUsers.TryGetValue(role, out var user))
                throw new ArgumentException("Invalid role provided", nameof(role));

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_identityServerUrl}/connect/token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id","client2" },
                    { "grant_type", "password" },
                    { "username", user.username },
                    { "client_secret", "78195A38-7268-7268-8F2E-8F4EB3FECF34" },
                    {"password",user.password },
                    { "scope", "scope1" }
                })
            };

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsJsonAsync<TokenResponse>();
            return result.access_token;
        }
    }

    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string access_token { get; set; }
    }
}
