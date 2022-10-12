using Microsoft.EntityFrameworkCore;
using TicketApp.WebApi.DbContexts;
using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Order> CreateAsync(Order order)
        {
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var order = await _appDbContext.Orders.FindAsync(id);

            if (order is not null)
            {
                _appDbContext.Orders.Remove(order);
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(long userId)
        {
            var orders = await _appDbContext.Orders.Where(x=> x.UserId == userId).ToListAsync();

            if (orders is not null)
            {
                return orders;
            }
            return null;
        }

        public async Task<Order?> GetAsync(long id)
        {
            var order = await _appDbContext.Orders.FindAsync(id);

            if (order is not null)
            {
                return order;
            }

            return null;
        }

        public async Task<Order> UpdateAsync(long id, Order order)
        {
            order.Id = id;
            _appDbContext.Update(order);
            await _appDbContext.SaveChangesAsync();

            return order;

        }
    }
}
