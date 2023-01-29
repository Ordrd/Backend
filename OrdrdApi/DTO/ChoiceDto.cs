using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.DTO
{
    public class ChoiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Price { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }

        public static ChoiceDto FromChoice(Choice choice)
        {
            return new ChoiceDto
            {
                Id = choice.ChoiceId,
                Name = choice.Name,
                Price = choice.Price,
                UserId = choice.UserId,
                OptionId = choice.OptionId
            };
        }
    }
}
