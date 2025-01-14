using System.Text.Json.Serialization;

namespace ExamsApi.Models.Auth
{
    public class PasswordReset
    {
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public string Token { get; set; } = string.Empty; // Reset Token
        public DateTime ExpiresAt { get; set; } // Expiration Timestamp

        // Navigation Property
        [JsonIgnore]
        public User User { get; set; } = null!;
    }
}
