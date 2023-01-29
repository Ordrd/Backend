using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.DTO
{
    public class OrderChoiceDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int ChoiceId { get; set; }
        public int OrderOptionId { get; set; }

        public static OrderChoiceDto FromChoice(OrderChoice choice)
        {
            return new OrderChoiceDto
            {
                Id = choice.OrderChoiceId,
                Quantity = choice.Quantity,
                UserId = choice.UserId,
                ChoiceId = choice.ChoiceId,
                OrderOptionId = choice.OrderOptionId
            };
        }
    }
}
