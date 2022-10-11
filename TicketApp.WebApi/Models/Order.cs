namespace TicketApp.WebApi.Models
{
    public class Order

    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string? CardNumber { get; set; }

    }
}
