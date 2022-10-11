using System.ComponentModel.DataAnnotations;
using TicketApp.WebApi.Commons.Attributes;

namespace TicketApp.WebApi.ViewModels.Users
{
    public class UserLoginVeiwModel
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Please enter valid email")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}
