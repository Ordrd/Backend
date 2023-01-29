using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Price { get; set; }

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }
        public int OptionId { get; set; }
        public Option? Option { get; set; }

        //ER Relations
        public List<OrderChoice> OrderChoices { get; set; } = new List<OrderChoice>();

        public static Choice FromChoiceDto(ChoiceDto choice)
        {
            return new Choice
            {
                ChoiceId = choice.Id,
                Name = choice.Name,
                Price = choice.Price,
                UserId = choice.UserId,
            };
        }
    }
}
