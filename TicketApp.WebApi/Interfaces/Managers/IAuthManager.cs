using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Interfaces.Managers
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
