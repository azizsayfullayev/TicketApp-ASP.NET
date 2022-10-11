namespace TicketApp.WebApi.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TicketName { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string? CardNumber { get; set; }

    }
}
