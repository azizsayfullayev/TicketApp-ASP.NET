using System.Net;
using TicketApp.WebApi.Commons.Exceptions;
using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.Models;
using TicketApp.WebApi.ViewModels.Orders;
using TicketApp.WebApi.ViewModels.Tickets;

namespace TicketApp.WebApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository orderRepository)
        {
            _repository= orderRepository;
        }
        public async Task<(int statusCode, string message)> CreateAsync(OrderCreateViewModel orderCreateViewModel)
        {
            var order = (Order)orderCreateViewModel;
            order.Date = DateTime.UtcNow;
            await _repository.CreateAsync(order);
            return (statusCode: 200, message: "");
        }

        public async Task<(int statusCode, string message)> DeleteAsync(long id)
        {
            var order = _repository.GetAsync(id);
            if (order is null) return(statusCode: 404, message:"Order not found");

            else
            {
                await _repository.DeleteAsync(id);
                return (statusCode: 200, message: "");
            }
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync(long userId)
        {
            var orders = await _repository.GetAllAsync(userId);
            
            if (orders is not null)
            {
                var orderList = new List<OrderViewModel>();
                foreach(var order in orders)
                {
                    var orderNew = (OrderViewModel)order;
                    orderList.Add(orderNew);
                }
                return orderList;
            }
            return Enumerable.Empty<OrderViewModel>();
        }

        public async Task<(int statusCode, OrderViewModel order, string message)> GetAsync(long id)
        {
            var orderNew = await  _repository.GetAsync(id);


            if (orderNew is not null) return (statusCode: 200, order: (OrderViewModel)orderNew, message: "");
            return (statusCode: 404, order: (OrderViewModel)new Order(), message: "Order not found");
        }

        public async Task<(int statusCode, string message)> UpdateAsync(long id, OrderCreateViewModel orderCreateViewModel)
        {
            var order = _repository.GetAsync(id);

            
            if (order is not null)
            {
                var orderNew = (Order)orderCreateViewModel;
                await _repository.UpdateAsync(id, orderNew);

                return (statusCode: 200, message: "");
            }
            return (statusCode: 404, message:"Order not found");
        }
    }
}
