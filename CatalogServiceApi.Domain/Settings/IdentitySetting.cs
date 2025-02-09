
namespace CatalogServiceApi.Domain.Settings
{
    public class IdentitySetting
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string GrantType { get; set; }
        public List<TestUser> TestUsers { get; set; }
    }

    public class TestUser
    {
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
