namespace TicketApp.WebApi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Price { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
