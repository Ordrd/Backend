using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class OrderOption
    {
        public int OrderOptionId { get; set; }

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }
        public int OptionId { get; set; }
        public Option? Option { get; set; }
        public int OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }

        //ER Relations
        public List<OrderChoice> OrderChoices { get; set; } = new List<OrderChoice>();

        public static OrderOption FromOrderOptionDto(OrderOptionDto orderOptionDto)
        {
            List<OrderChoice> orderChoices = new List<OrderChoice>();
            orderOptionDto.Choices.ForEach(orderChoice => orderChoices.Add(OrderChoice.FromOrderChoiceDto(orderChoice)));

            return new OrderOption
            {
                OrderOptionId = orderOptionDto.Id,
                UserId = orderOptionDto.UserId,
                OptionId = orderOptionDto.OptionId,
                OrderChoices = orderChoices
            };
        }
    }
}
