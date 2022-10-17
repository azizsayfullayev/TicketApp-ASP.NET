using Serilog;
using TicketApp.WebApi.Commons.Exceptions;
using TicketApp.WebApi.Commons.Security;
using TicketApp.WebApi.Interfaces.Managers;
using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.Models;
using TicketApp.WebApi.ViewModels.Users;

namespace TicketApp.WebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly IFileService _fileService;
        private readonly IAuthManager _authManager;

        public AccountService(IUserRepository repository, IFileService fileService, IAuthManager authManager)
        {
            _repository = repository;
            _fileService = fileService;
            _authManager = authManager;
        }
        public async Task<UserTokenViewModel> LoginAsync(UserLoginVeiwModel userLoginViewModel)
        {
            var user = await _repository.FindByEmailAsync(userLoginViewModel.Email);
            if (user is null) throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Email is wrong!");

            var hasherResult = PasswordHasher.Verify(userLoginViewModel.Password, user.Salt, user.PasswordHash);
            if (hasherResult is false) throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Password is wrong!");

            var getUser = (UserTokenViewModel)user;
            getUser.Token = _authManager.GenerateToken(user);

            if (user.Role == Enums.UserRole.Admin)
            {
                getUser.IsAdmin = true;
            }
            else
            {
                getUser.IsAdmin = false;
            }
            return getUser;

        }

        public async Task<UserViewModel> RegistrAsync(UserCreateViewModel userCreateViewModel)
        {
            var validateUser = await _repository.FindByEmailAsync(userCreateViewModel.Email);
            if (validateUser is not null) throw new StatusCodeException(System.Net.HttpStatusCode.Conflict, "This email is already exist");

            
            var user = (User)userCreateViewModel;
            
            var hasherResult = PasswordHasher.Hash(userCreateViewModel.Password);
            user.PasswordHash = hasherResult.Hash;
            user.Salt = hasherResult.Salt;
            
            user.Role = Enums.UserRole.User;
            await _repository.CreateAsync(user);

            var newUser = (UserViewModel)user;
            return newUser;
        }
        public async Task<UserViewModel> RegistrAsAdminAsync(UserCreateViewModel userCreateViewModel)
        {
            var validateUser = await _repository.FindByEmailAsync(userCreateViewModel.Email);
            if (validateUser is not null) throw new StatusCodeException(System.Net.HttpStatusCode.Conflict, "This email is already exist");


            var user = (User)userCreateViewModel;
            
            var hasherResult = PasswordHasher.Hash(userCreateViewModel.Password);
            user.PasswordHash = hasherResult.Hash;
            user.Salt = hasherResult.Salt;

            user.Role = Enums.UserRole.Admin;
            await _repository.CreateAsync(user);

            var newUser = (UserViewModel)user;


            return newUser;
        }

    }
}
