using System.Text.Json.Serialization;

namespace ExamsApi.Models.Auth
{
    public class AuditLog
    {
        public int Id { get; set; } // Primary Key
        public int? UserId { get; set; } // Foreign Key (Nullable for system actions)
        public string Action { get; set; } = string.Empty; // Action Description
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp

        // Navigation Property
        [JsonIgnore]
        public User? User { get; set; }
    }
}
