namespace OrdrdApi.DTO
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public List<OrderOptionDto> OrderOptions { get; set; } = new List<OrderOptionDto>();

        public static OrderItemDto FromItem(OrderItem item)
        {
            List<OrderOptionDto> options = new List<OrderOptionDto>();
            item.OrderOptions.ForEach(option => options.Add(OrderOptionDto.FromOption(option)));

            return new OrderItemDto
            {
                Id = item.OrderItemId,
                Quantity = item.Quantity,
                UserId = item.UserId,
                OrderId = item.OrderId,
                ItemId = item.ItemId,
                OrderOptions = options
            };
        }
    }
}
