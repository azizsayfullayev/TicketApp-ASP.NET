using TicketApp.WebApi.Models;
using TicketApp.WebApi.ViewModels.Orders;

namespace TicketApp.WebApi.ViewModels.Orders
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string? CardNumber { get; set; }


        public static implicit operator OrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                TicketId = order.TicketId,
                Date = order.Date,
                CardNumber = order.CardNumber,
                IsPaid = order.IsPaid
            };
        }
    }
}
