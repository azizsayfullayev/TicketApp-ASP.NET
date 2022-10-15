using TicketApp.WebApi.Models;
namespace TicketApp.WebApi.ViewModels.Tickets
{
    public class TicketViewModel
    {
        public long Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Description {get;set;} = string.Empty;
        public DateTime Created { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Price { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public static implicit operator TicketViewModel(Ticket ticket)
        {
            return new TicketViewModel()
            {
                Id = ticket.Id,
                Name = ticket.Name,
                Description = ticket.Description,
                Created = ticket.Created,
                StartDate = ticket.StartDate,
                Location = ticket.Location,
                Price = ticket.Price,
                PhoneNumber = ticket.PhoneNumber,
                ImageUrl = ticket.ImagePath
            };
        }
    }
}
