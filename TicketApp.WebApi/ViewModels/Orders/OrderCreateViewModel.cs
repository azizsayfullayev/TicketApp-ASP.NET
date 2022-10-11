using System.ComponentModel.DataAnnotations;
using TicketApp.WebApi.Models;
namespace TicketApp.WebApi.ViewModels.Orders
{
    public class OrderCreateViewModel
    {
        [Required]
        public string TicketName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; } = false;
        public string? CardNumber { get; set; }

        
        public static implicit operator Models.Order(OrderCreateViewModel orderCreateViewModel)
        {
            return new Models.Order()
            {
                
            };
        }

    }
}
