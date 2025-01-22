using ExamsApi.Domain.Enums;
using ExamsApi.Domain.Models.Auth;

namespace ExamsApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; } // Primary Key
        public Guid PublicId { get; set; } = Guid.NewGuid(); // Unique Public Identifier
        public string Username { get; set; } = string.Empty; // Unique Username
        public string Email { get; set; } = string.Empty; // Unique Email
        public string Password { get; set; } = string.Empty; // Hashed Password
        public string FirstName { get; set; } = string.Empty; // First Name
        public string LastName { get; set; } = string.Empty; // Last Name
        public UserRole Role { get; set; } = UserRole.User; // User Role
        public bool IsActive { get; set; } = true; // Active Status
        public DateTime? DeletedAt { get; set; } // Creation Timestamp
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Creation Timestamp
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Last Update Timestamp
        // Navigation Properties
        public ICollection<UserSession> Sessions { get; set; } = new List<UserSession>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    }
}
