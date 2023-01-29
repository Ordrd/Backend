using OrdrdApi.Repositories.OrderRepo;

namespace OrdrdApi.Services.HistoryServ
{
    public class HistoryService : IHistoryService
    {
        private readonly IOrderRepository orderRepository;

        public HistoryService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<List<Order>> FindInHistoryAsync(int restaurantId, string search)
        {
            List<Order> result = await orderRepository.FindInOrderHistoryAsync(restaurantId, search);
            return result;
        }

        public async Task<List<Order>> GetHistoryAsync(int restaurantId, int page, int pageSize)
        {
            List<Order> result = await orderRepository.GetOrderHistoryAsync(restaurantId, page, pageSize);
            return result;
        }
    }
}
