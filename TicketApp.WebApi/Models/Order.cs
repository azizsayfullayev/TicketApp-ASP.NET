namespace TicketApp.WebApi.Models
{
    public class Order

    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string? CardNumber { get; set; }

    }
}
