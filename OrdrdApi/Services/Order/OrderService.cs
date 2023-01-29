using OrdrdApi.DTO;
using OrdrdApi.Hubs;
using OrdrdApi.Models;
using OrdrdApi.Repositories.OrderRepo;
using OrdrdApi.Repositories.RestaurantRepo;
using OrdrdApi.Services.Infrastructure;
using System.Drawing;

namespace OrdrdApi.Services.OrderServ
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IInfrastructureService infrastructureService;
        private readonly OrderHub orderHub;

        public OrderService(IOrderRepository orderRepository, IInfrastructureService infrastructureService, IRestaurantRepository restaurantRepository, OrderHub orderHub)
        {
            this.orderRepository = orderRepository;
            this.infrastructureService = infrastructureService;
            this.restaurantRepository = restaurantRepository;
            this.orderHub = orderHub;
        }

        public async Task<Order> CreateOrderAsync(OrderDto order)
        {
            var orderMap = Order.FromOrderDto(order);
            var result = await orderRepository.CreateOrderAsync(orderMap);
            var orderAdmin = AdminOrderDto.FromOrder(result);
            await orderHub.SendOrderToQueue(orderAdmin);
            return result;
        }

        public async Task AcceptOrderAsync(int orderId, int waitingTime)
        {
            var order = await orderRepository.GetOrderAsync(orderId);
            var restaurantId = order.RestaurantId;
            await orderRepository.UpdateOrderStatusAsync(orderId, Status.InProgress, waitingTime);

            var restaurant = await restaurantRepository.GetRestaurantAsync(restaurantId);

            var message = string.Format("Dear {0}, your order has been processed and will be ready for pickup in aproximately {1} minutes. Thak you for your order. \n\n Your {2}", order.CustomerName, waitingTime, restaurant.Name ??= "");
            await infrastructureService.SendSmsMessageAsync(order.CustomerPhone, message, "Your order has been processed.");
        }

        public async Task DeclineOrderAsync(int orderId, string reason)
        {
            var order = await orderRepository.GetOrderAsync(orderId);
            var restaurantId = order.RestaurantId;
            await orderRepository.UpdateOrderStatusAsync(orderId, Status.Rejected);
            var restaurant = await restaurantRepository.GetRestaurantAsync(restaurantId);

            var message = string.Format("Dear {0}, unfortunately we had to decline your order, becuse {1}. Sorry for the inconvinience. \n\n Your {2}", order.CustomerName, reason, restaurant.Name ??= "");
            await infrastructureService.SendSmsMessageAsync(order.CustomerPhone, message, "Bad news about your order.");

        }

        public async Task FinishOrderAsync(int orderId)
        {
            var order = await orderRepository.GetOrderAsync(orderId);
            var restaurantId = order.RestaurantId;
            await orderRepository.UpdateOrderStatusAsync(orderId, Status.Done);

            var restaurant = await restaurantRepository.GetRestaurantAsync(restaurantId);

            var message = string.Format("Dear {0}, your order is finished and ready for pickup. \n\n Your {1}", order.CustomerName, restaurant.Name ??= "");
            await infrastructureService.SendSmsMessageAsync(order.CustomerPhone, message, "Your order is finished!");
        }

        public async Task<List<Order>> GetOrdersInProgressAsync(int restaurantId)
        {
            var result = await orderRepository.GetOrdersInProgressAsync(restaurantId);
            return result;
        }

        public async Task<List<Order>> GetOrdersInQueueAsync(int restaurantId)
        {
            var result = await orderRepository.GetOrdersInQueueAsync(restaurantId);
            return result;
        }
    }
}
