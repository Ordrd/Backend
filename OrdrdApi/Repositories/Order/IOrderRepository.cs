using System.Threading.Tasks;

namespace OrdrdApi.Repositories.OrderRepo
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersInProgressAsync(int restaurantId);
        Task<List<Order>> GetOrdersInQueueAsync(int restaurantId);
        Task<Order> GetOrderAsync(int id);
        Task<Order> UpdateOrderStatusAsync(int id, Status status, int? waitingTime = null);
        Task<List<Order>> GetOrderHistoryAsync(int restaurantId, int page, int pageSize);
        Task<List<Order>> FindInOrderHistoryAsync(int restaurantId, string search);
    }
}
