namespace OrdrdApi.DTO
{
    public class AdminOrderItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PosNumber { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public List<AdminChoiceDto> OrderChoices { get; set; } = new List<AdminChoiceDto>();

        public static AdminOrderItemDto FromItem(OrderItem item)
        {
            List<AdminChoiceDto> choices = new List<AdminChoiceDto>();
            item.OrderOptions.ForEach(option =>
            option.OrderChoices.ForEach(choice =>
            {
                if (choice.Choice != null)
                {
                    if (choice.Choice.Price != null)
                    {
                        choices.Add(AdminChoiceDto.FromChoice(choice.Choice, choice.Quantity));
                    }
                }
            }));

            return new AdminOrderItemDto
            {
                Id = item.OrderItemId,
                Name = item.Item.Name,
                PosNumber = item.Item.PosNumber,
                Quantity = item.Quantity,
                UserId = item.UserId,
                OrderId = item.OrderId,
                ItemId = item.ItemId,
                OrderChoices = choices
            };
        }
    }
}

