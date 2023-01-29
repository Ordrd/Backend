using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class OrderChoice
    {
        public int OrderChoiceId { get; set; }
        public int Quantity { get; set; }

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ChoiceId { get; set; }
        public Choice? Choice { get; set; }
        public int OrderOptionId { get; set; }
        public OrderOption? OrderOption { get; set; }

        public static OrderChoice FromOrderChoiceDto(OrderChoiceDto orderChoiceDto)
        {
            return new OrderChoice
            {
                OrderChoiceId = orderChoiceDto.Id,
                Quantity= orderChoiceDto.Quantity,
                UserId= orderChoiceDto.UserId,
                ChoiceId = orderChoiceDto.ChoiceId,
                OrderOptionId= orderChoiceDto.OrderOptionId,
            };
        }
        
    }
}
