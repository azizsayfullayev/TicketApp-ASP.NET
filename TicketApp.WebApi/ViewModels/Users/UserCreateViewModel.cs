using System.ComponentModel.DataAnnotations;
using TicketApp.WebApi.Commons.Attributes;
using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.ViewModels.Users
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
                    ErrorMessage = "Please enter valid first name. " +
                    "Name must be contains only letters or ' character")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Please enter valid email")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Upload)]
        [MaxFileSize(3)]
        [AllowedFileExtensionAttribute(new string[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        
        public string Password { get; set; } = string.Empty;


        public static implicit operator User(UserCreateViewModel userCreateViewModel)
        {
            return new User()
            {
                
                Name = userCreateViewModel.Name,
                Email = userCreateViewModel.Email
            };
        }
    }
}

