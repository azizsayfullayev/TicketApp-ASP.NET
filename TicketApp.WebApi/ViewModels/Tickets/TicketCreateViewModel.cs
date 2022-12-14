using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations;
using TicketApp.WebApi.Commons.Attributes;
using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.ViewModels.Tickets;

public class TicketCreateViewModel
{
    [Required(ErrorMessage ="Ticket name is requiresd")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage ="Description is required")]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string EventDate { get; set; } = string.Empty;
    [Required]
    public string StartTime { get; set; } = string.Empty;
    [Required]
    public string EndTime { get; set; } = string.Empty;
    [Required]
    public string Location { get; set; } = string.Empty;
    [Required]
    public int Price { get; set; }
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "Image is required")]
    [DataType(DataType.Upload)]
    [MaxFileSize(3)]
    [AllowedFileExtension(new string[] { ".jpg", ".png" ,".jpeg"})]
    public IFormFile Image { get; set; } = null!;

    public static implicit operator Ticket(TicketCreateViewModel ticketCreateViewModel)
    {
        return new Ticket()
        {
            Name = ticketCreateViewModel.Name,
            Description = ticketCreateViewModel.Description,
            EventDate = ticketCreateViewModel.EventDate,
            StartTime = ticketCreateViewModel.StartTime,
            EndTime = ticketCreateViewModel.EndTime,
            Location = ticketCreateViewModel.Location,
            Price = ticketCreateViewModel.Price,
            PhoneNumber = ticketCreateViewModel.PhoneNumber
        };
    }
}