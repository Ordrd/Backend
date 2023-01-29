using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Pending;
        public string OrderType { get; set; } = string.Empty;
        public int OrderTime { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public double OrderPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        //ER Relations
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public static Order FromOrderDto(OrderDto orderDto)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            orderDto.OrderItems.ForEach(orderItem => orderItems.Add(OrderItem.FromOrderItemDto(orderItem)));
            return new Order
            {
                OrderId = orderDto.Id,
                CustomerName = orderDto.CustomerName,
                CustomerPhone = orderDto.CustomerPhone,
                OrderType = orderDto.OrderType,
                OrderTime = orderDto.OrderTime,
                OrderPrice = orderDto.OrderPrice,
                UserId = orderDto.UserId,
                RestaurantId = orderDto.RestaurantId,
                OrderItems = orderItems
            };
        }
    }

    public enum Status
    {
        Pending,
        Rejected,
        InProgress,
        Done
    }
}
