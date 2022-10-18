using TicketApp.WebApi.DbContexts;
using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            await _appDbContext.AddAsync(ticket);
            await _appDbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var ticket = await _appDbContext.Tickets.FindAsync(id);

            if (ticket is not null)
            {
                _appDbContext.Remove(ticket);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IQueryable<Ticket>> GetAllAsync()
        {
            return _appDbContext.Tickets;
        }

        public async Task<Ticket?> GetAsync(long id)
        {
            var ticket = await _appDbContext.Tickets.FindAsync(id);

            if (ticket is not null)
            {
                return ticket;
            }
            return null;
        }

        public async Task<Ticket> UpdateAsync(long id, Ticket ticket)
        {
            ticket.Id = id;
            _appDbContext.Update(ticket);
            await _appDbContext.SaveChangesAsync();

            return ticket;
        }
    }
}
