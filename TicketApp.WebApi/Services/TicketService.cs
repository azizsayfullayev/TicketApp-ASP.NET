using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.Models;
using TicketApp.WebApi.ViewModels.Tickets;
using TicketApp.WebApi.ViewModels.Users;

namespace TicketApp.WebApi.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IFileService _fileService;

        public TicketService(ITicketRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }
        public async Task<(int statusCode, string message)> CreateAsync(TicketCreateViewModel ticketCreateViewModel)
        {
            Ticket ticket = (Ticket)ticketCreateViewModel;

            if (ticketCreateViewModel.Image is not null)
            {
                ticket.ImagePath = await _fileService.SaveImageAsync(ticketCreateViewModel.Image);
                
            }
            await _repository.CreateAsync(ticket);
            return (statusCode: 200, message: "");
        }

        public async Task<(int statusCode, string message)> DeleteAsync(long id)
        {
            var ticket = await _repository.GetAsync(id);
            if (ticket is null) return (statusCode: 404, message: "Todo not found");
            else
            {
                await _repository.DeleteAsync(id);
                return (statusCode: 200, message: "");
            }
        }

        public async Task<IEnumerable<TicketViewModel>> GetAllAsync()
        {
            var tickets = await _repository.GetAllAsync();
            var ticketViewModels = new List<TicketViewModel>();
            foreach(var ticket in tickets)
            {
                var ticketViewModel = (TicketViewModel)ticket;
                ticketViewModels.Add(ticketViewModel);

            }
            return ticketViewModels;
        }

        public async Task<(int statusCode, TicketViewModel ticket, string message)> GetAsync(long id)
        {
            var ticket = await _repository.GetAsync(id);

            if (ticket is null) return (statusCode: 404, ticket: (TicketViewModel)new Ticket(), message: "Ticket not found");
            else return (statusCode: 200, ticket: (TicketViewModel)ticket, message: "");            
        }

        public async Task<(int statusCode, string message)> UpdateAsync(long id, TicketCreateViewModel ticketCreateViewModel)
        {
            var ticket = await _repository.GetAsync(id);

            if (ticket is null) return (statusCode: 404,  message: "Ticket not found");
            else
            {
                var ticketNew = (Ticket)ticketCreateViewModel;
                
                await _repository.UpdateAsync(id, ticketNew);
                return (statusCode: 200, message: "");
            }
            
        }
    }
}
