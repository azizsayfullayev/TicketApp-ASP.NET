using System.ComponentModel.DataAnnotations;
using TicketApp.WebApi.Models;
namespace TicketApp.WebApi.ViewModels.Orders
{
    public class OrderCreateViewModel
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long TicketId{ get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; } = false;
        public string CardNumber { get; set; } = String.Empty;

        
        public static implicit operator Models.Order(OrderCreateViewModel orderCreateViewModel)
        {
            return new Models.Order()
            {
                UserId = orderCreateViewModel.UserId,
                TicketId = orderCreateViewModel.TicketId,
                Date = orderCreateViewModel.Date,
                CardNumber = orderCreateViewModel.CardNumber,
                IsPaid = orderCreateViewModel.IsPaid,
                
            };
        }

    }
}
