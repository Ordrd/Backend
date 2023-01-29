using OrdrdApi.DTO;

namespace OrdrdApi.Services.OrderServ
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDto order);
        Task<List<Order>> GetOrdersInProgressAsync(int restaurantId);
        Task<List<Order>> GetOrdersInQueueAsync(int restaurantId);
        Task AcceptOrderAsync(int orderId, int waitingTime);
        Task DeclineOrderAsync(int orderId, string reason);
        Task FinishOrderAsync(int orderId);
    }
}
