using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync(long UserId);

        Task<Order> CreateAsync(Order order);

        Task<Order?> GetAsync(long id);

        Task<bool> DeleteAsync(long id);

        Task<Order> UpdateAsync(long id, Order order);
    }
}
