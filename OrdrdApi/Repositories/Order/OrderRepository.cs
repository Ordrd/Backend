using OrdrdApi.Hubs;

namespace OrdrdApi.Repositories.OrderRepo
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DataContext context;

        public OrderRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            var result = await context.Orders
                .OrderByDescending(x => x.OrderId)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.OrderOptions)
                    .ThenInclude(orderOption => orderOption.OrderChoices)
                    .ThenInclude(orderChoice => orderChoice.Choice)

                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Item)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Order>> GetOrdersInProgressAsync(int restaurantId)
        {
            List<Order> result = await context.Orders
                .Where(item => item.RestaurantId == restaurantId && item.Status == Status.InProgress)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.OrderOptions)
                    .ThenInclude(orderOption => orderOption.OrderChoices)
                    .ThenInclude(orderChoice => orderChoice.Choice)

                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Item)
                    
                .ToListAsync();
            return result;
        }

        public async Task<List<Order>> GetOrdersInQueueAsync(int restaurantId)
        {
            List<Order> result = await context.Orders
                .Where(item => item.RestaurantId == restaurantId && item.Status == Status.Pending)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.OrderOptions)
                    .ThenInclude(orderOption => orderOption.OrderChoices)
                    .ThenInclude(orderChoice => orderChoice.Choice)

                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Item)

                .ToListAsync();
            return result;
        }

        public async Task<Order?> GetOrderAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<Order> UpdateOrderStatusAsync(int id, Status status, int? waitingTime)
        {
            var order = await context.Orders.FindAsync(id);

            if(order == null)
            {
                throw new NullReferenceException("This order doesn't exist in the database");
            }

            order.Status = status;
            if (status == Status.InProgress && waitingTime != null) {
                order.OrderTime = waitingTime.Value;
            }

            await context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> FindInOrderHistoryAsync(int restaurantId, string search)
        {
            List<Order> result = await context.Orders
                .Where(item => item.RestaurantId == restaurantId && item.CustomerName.Contains(search) && item.Status == Status.Done)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.OrderOptions)
                    .ThenInclude(orderOption => orderOption.OrderChoices)
                    .ThenInclude(orderChoice => orderChoice.Choice)

                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Item)
                .ToListAsync();
            return result;
        }

        public async Task<List<Order>> GetOrderHistoryAsync(int restaurantId, int page, int pageSize)
        {
            var skipSize = page != 0 ? page - 1 : 0;
            List<Order> menu = await context.Orders
                .Where(item => item.RestaurantId == restaurantId && item.Status == Status.Done).Skip(skipSize * pageSize).Take(pageSize)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.OrderOptions)
                    .ThenInclude(orderOption => orderOption.OrderChoices)
                    .ThenInclude(orderChoice => orderChoice.Choice)

                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Item)
                .ToListAsync();

            return menu;
        }
    }
}
