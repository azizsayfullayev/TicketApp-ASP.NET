using TicketApp.WebApi.ViewModels.Orders;
using TicketApp.WebApi.ViewModels.Tickets;

namespace TicketApp.WebApi.Interfaces.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketViewModel>> GetAllAsync();

        Task<(int statusCode, TicketViewModel ticket, string message)> GetAsync(long id);

        Task<(int statusCode, string message)> CreateAsync(TicketCreateViewModel ticketCreateViewModel);

        Task<(int statusCode, string message)> UpdateAsync(long id, TicketCreateViewModel ticketCreateViewModel);

        Task<(int statusCode, string message)> DeleteAsync(long id);
    }
}
