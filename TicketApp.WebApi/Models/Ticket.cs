namespace TicketApp.WebApi.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EventDate { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty; 
        public string Location { get; set; } = string.Empty;
        public int Price { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = String.Empty;

    }
}
