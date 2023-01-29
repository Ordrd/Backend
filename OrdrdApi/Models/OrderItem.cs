using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        //ER Relations
        public List<OrderOption> OrderOptions { get; set; } = new List<OrderOption>();

        public static OrderItem FromOrderItemDto(OrderItemDto orderItemDto)
        {
            List<OrderOption> orderOptions = new List<OrderOption>();
            orderItemDto.OrderOptions.ForEach(orderOption => orderOptions.Add(OrderOption.FromOrderOptionDto(orderOption)));

            return new OrderItem
            {
                OrderItemId = orderItemDto.Id,
                Quantity = orderItemDto.Quantity,
                UserId = orderItemDto.UserId,
                ItemId = orderItemDto.ItemId,
                OrderId = orderItemDto.OrderId,
                OrderOptions= orderOptions
            };
        }
    }
}
