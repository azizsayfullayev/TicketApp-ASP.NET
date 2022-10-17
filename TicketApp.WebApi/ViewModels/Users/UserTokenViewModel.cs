using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.ViewModels.Users
{
    public class UserTokenViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }

        public static implicit operator UserTokenViewModel(User user)
        {
            return new UserTokenViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                
            };
        }
    }
}
