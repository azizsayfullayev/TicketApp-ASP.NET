using TicketApp.WebApi.ViewModels.Users;

namespace TicketApp.WebApi.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<UserViewModel> RegistrAsync(UserCreateViewModel userCreateViewModel);
        public Task<UserTokenViewModel> LoginAsync(UserLoginVeiwModel userLoginViewModel);
        public Task<UserViewModel> RegistrAsAdminAsync(UserCreateViewModel userCreateViewModel); 
    }
}
