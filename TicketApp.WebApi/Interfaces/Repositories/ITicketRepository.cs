using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IQueryable<Ticket>> GetAllAsync();

        Task<Ticket> CreateAsync(Ticket ticket);

        Task<Ticket?> GetAsync(long id);

        Task<bool> DeleteAsync(long id);

        Task<Ticket> UpdateAsync(long id, Ticket ticket);
    }
}
