namespace OrdrdApi.DTO
{
    public class OrderOptionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public int OrderItemId { get; set; }
        public List<OrderChoiceDto> Choices { get; set; } = new List<OrderChoiceDto>();

        public static OrderOptionDto FromOption(OrderOption option)
        {
            List<OrderChoiceDto> choices = new List<OrderChoiceDto>();
            option.OrderChoices.ForEach(choice => choices.Add(OrderChoiceDto.FromChoice(choice)));

            return new OrderOptionDto
            {
                Id = option.OrderOptionId,
                UserId = option.UserId,
                OptionId = option.OptionId,
                OrderItemId = option.OrderItemId,
                Choices = choices
            };
        }
    }
}
