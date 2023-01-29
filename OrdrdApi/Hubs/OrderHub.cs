using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using OrdrdApi.DTO;
using System.Collections.Concurrent;

namespace OrdrdApi.Hubs
{
    public class OrderHub: Hub
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<AdminOrderDto>> restaurantQueues;
        protected IHubContext<OrderHub> context;

        public OrderHub(IHubContext<OrderHub> context)
        {
            restaurantQueues = new ConcurrentDictionary<string, ConcurrentQueue<AdminOrderDto>>();
            this.context = context;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendOrderToQueue(AdminOrderDto order)
        {
            if (!restaurantQueues.TryGetValue(order.RestaurantId.ToString(), out var queue))
            {
                queue = new ConcurrentQueue<AdminOrderDto>();
                restaurantQueues.TryAdd(order.RestaurantId.ToString(), queue);
            }
            queue.Enqueue(order);
            await context.Clients.Group(order.RestaurantId.ToString()).SendAsync("NewOrder", order);

        }
        public async Task SubscribeToRestaurant(int restaurantId)
        {
            await context.Groups.AddToGroupAsync(Context.ConnectionId, restaurantId.ToString());
        }
        public async Task UnsubscribeFromRestaurant(int restaurantId)
        {
            await context.Groups.RemoveFromGroupAsync(Context.ConnectionId, restaurantId.ToString());
        }

    }
}
