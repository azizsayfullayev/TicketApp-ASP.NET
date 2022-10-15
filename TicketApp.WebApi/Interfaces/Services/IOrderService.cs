using TicketApp.WebApi.Commons.Utils;
using TicketApp.WebApi.ViewModels.Orders;

namespace TicketApp.WebApi.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllAsync(long userId);

        Task<(int statusCode, OrderViewModel order, string message)> GetAsync(long id);

        Task<(int statusCode, string message)> CreateAsync(OrderCreateViewModel orderCreateViewModel);

        Task<(int statusCode, string message)> UpdateAsync(long id, OrderCreateViewModel orderCreateViewModel);

        Task<(int statusCode, string message)> DeleteAsync(long id);
    }
}
