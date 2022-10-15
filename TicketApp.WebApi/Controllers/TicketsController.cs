using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketApp.WebApi.Commons.Utils;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.ViewModels.Tickets;

namespace TicketApp.WebApi.Controllers
{
    [Route("api/ticekts")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ticketService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _ticketService.GetAsync(id);
            return StatusCode(result.statusCode, result.ticket);
        }

        [HttpPost, Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] TicketCreateViewModel ticketCreate)
        {
            var result = await _ticketService.CreateAsync(ticketCreate);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] TicketCreateViewModel ticketCreate )
        {
            var result = await _ticketService.UpdateAsync(id, ticketCreate);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpDelete("{id}"), Authorize("Admin")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _ticketService.DeleteAsync(id);
            return StatusCode(result.statusCode, result.message);
        }
    }
}
