using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.ViewModels.Users;

namespace TicketApp.WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService service)
        {
            this._service = service;
        }

        [HttpPost("registr"), AllowAnonymous]
        public async Task<IActionResult> RegistrAsync([FromForm] UserCreateViewModel userCreateViewModel)
        => Ok(await _service.RegistrAsync(userCreateViewModel));
        [HttpPost("registrasadmin"), AllowAnonymous]
        public async Task<IActionResult> RegistrAsAdminAsync([FromForm] UserCreateViewModel userCreateViewModel)
        => Ok(await _service.RegistrAsAdminAsync(userCreateViewModel));

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] UserLoginVeiwModel userLoginViewModel)
            => Ok(new { Token = await _service.LoginAsync(userLoginViewModel) });
    }
}
