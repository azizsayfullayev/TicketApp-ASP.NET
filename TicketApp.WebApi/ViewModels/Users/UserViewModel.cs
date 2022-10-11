using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.ViewModels.Users
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;


        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ImageUrl = user.ImagePath
            };
        }
    }
}
