using CatalogServiceApi.Domain.Enums;
//using CatalogServiceApi.Domain.Models.Auth;

namespace CatalogServiceApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid(); 
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty; 
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Customer; 
        public bool IsActive { get; set; } = true;
        public DateTime? DeletedAt { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 

        //public ICollection<UserSession> Sessions { get; set; } = new List<UserSession>();
        //public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    }
}
