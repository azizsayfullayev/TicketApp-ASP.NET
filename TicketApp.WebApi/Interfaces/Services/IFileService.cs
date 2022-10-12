using TicketApp.WebApi.ViewModels.Users;

namespace TicketApp.WebApi.Interfaces.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile image);
    }
}
