namespace OrdrdApi.DTO
{
    public class AdminOrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public int OrderTime { get; set; }
        public double OrderPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public List<AdminOrderItemDto> OrderItems { get; set; } = new List<AdminOrderItemDto>();

        public static AdminOrderDto FromOrder(Order order)
        {
            List<AdminOrderItemDto> items = new List<AdminOrderItemDto>();
            order.OrderItems.ForEach(item => items.Add(AdminOrderItemDto.FromItem(item)));

            return new AdminOrderDto
            {
                Id = order.OrderId,
                CustomerName = order.CustomerName,
                CustomerPhone = order.CustomerPhone,
                Status = order.Status,
                OrderType = order.OrderType,
                OrderTime = order.OrderTime,
                OrderPrice= order.OrderPrice,
                CreatedAt= order.CreatedAt,
                UserId = order.UserId,
                RestaurantId = order.RestaurantId,
                OrderItems = items
            };
        }
    }
}
