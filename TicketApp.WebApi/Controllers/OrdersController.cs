using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketApp.WebApi.Commons.Helpers;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.ViewModels.Orders;

namespace TicketApp.WebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetAllasync()
        {

            return Ok(await _orderService.GetAllAsync(long.Parse(HttpContext.User.FindFirst("Id").Value)));
        }
        [HttpGet("{id}"), Authorize(Roles ="User, Admin")]
        public async Task<IActionResult>GetAsync(long id)
        {
            var order = await _orderService.GetAsync(id);
            return StatusCode(order.statusCode,order.order);
        }
        [HttpPost, Authorize(Roles ="User, Admin")]
        public async Task<IActionResult> CreateAsync([FromForm]OrderCreateViewModel orderCreateViewModel)
        {
            var res = await _orderService.CreateAsync(orderCreateViewModel);
            return StatusCode(res.statusCode,res.message);
        }
        [HttpPut("{id}"), Authorize(Roles ="User, Admin")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] OrderCreateViewModel orderCreate)
        {
            var result = await _orderService.UpdateAsync(id, orderCreate);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpDelete("{id}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _orderService.DeleteAsync(id);
            return StatusCode(result.statusCode, result.message);
        }

    }
}
