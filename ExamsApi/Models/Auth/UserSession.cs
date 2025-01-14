using System.Text.Json.Serialization;

namespace ExamsApi.Models.Auth
{
    public class UserSession
    {
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public string JwtToken { get; set; } = string.Empty; // JWT Token
        public DateTime ExpiresAt { get; set; } // Expiration Timestamp
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Creation Timestamp

        // Navigation Property
        [JsonIgnore]
        public User User { get; set; } = null!;
    }
}
