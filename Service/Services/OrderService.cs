using Market.Domain.Entites;
using Market.Service.DTOs.OrderDtos;
using Market.Service.Exceptions;
using Market.Service.Interfaces;

namespace Market.Service.Services;

public class OrderService : IOrderService
{
    private readonly List<Order> orders = new List<Order>();
    private long nextId = 1;

    public async Task<bool> RemoveAsync(long id)
    {
        var orderToRemove = orders.FirstOrDefault(o => o.Id == id);
        if (orderToRemove != null)
        {
            orders.Remove(orderToRemove);
            return true;
        }
        throw new MarketException(404, "Order is not found");
    }

    public async Task<OrderForResultDto> RetrieveIdAsync(long id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            return new OrderForResultDto()
            {
                Id = order.Id,
                Customer = order.Customer,
                Products = order.Products,
                TotalPrice = order.TotalPrice
            };
        }
        throw new MarketException(404, "Order is not found");
    }

    public async Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync()
    {
        var orderDtos = orders.Select(order => new OrderForResultDto()
        {
            Id = order.Id,
            Customer = order.Customer,
            Products = order.Products,
            TotalPrice = order.TotalPrice
        });
        return orderDtos;
    }

    public async Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
    {
        var newOrder = new Order
        {
            Id = nextId++,
            Customer = dto.Customer,
            TotalPrice = dto.TotalPrice,
            Products = new List<Product>()
        };
        orders.Add(newOrder);

        return new OrderForResultDto()
        {
            Id = newOrder.Id,
            Customer = newOrder.Customer,
            Products = newOrder.Products,
            TotalPrice = newOrder.TotalPrice
        };
    }
}
