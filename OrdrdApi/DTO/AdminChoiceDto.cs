using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.DTO
{
    public class AdminChoiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public static AdminChoiceDto FromChoice(Choice choice, int quantity)
        {
            return new AdminChoiceDto
            {
                Id = choice.ChoiceId,
                Name = choice.Name,
                Price = choice.Price,
                Quantity = quantity
            };
        }
    }
}
