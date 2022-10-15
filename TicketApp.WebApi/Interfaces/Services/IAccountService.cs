using TicketApp.WebApi.ViewModels.Users;

namespace TicketApp.WebApi.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<bool> RegistrAsync(UserCreateViewModel userCreateViewModel);
        public Task<string> LoginAsync(UserLoginVeiwModel userLoginViewModel);
        public Task<bool> RegistrAsAdminAsync(UserCreateViewModel userCreateViewModel); 
    }
}
