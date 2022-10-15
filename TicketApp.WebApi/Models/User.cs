using System.Security.Cryptography.X509Certificates;
using TicketApp.WebApi.Enums;

namespace TicketApp.WebApi.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string? ImagePath { get; set; } = String.Empty;

        public string PasswordHash { get; set; } = String.Empty;

        public string Salt { get; set; } = String.Empty;

        public UserRole Role { get; set; }
    }
}
