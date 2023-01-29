using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MenuGroup { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int PosNumber { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public List<OptionDto> Options { get; set; } = new List<OptionDto>();

        public static ItemDto FromItem(Item item)
        {
            List<OptionDto> options = new List<OptionDto>();
            item.Options.ForEach(option => options.Add(OptionDto.FromOption(option)));
            
            return new ItemDto
            {
                Id = item.ItemId, 
                Name = item.Name,
                MenuGroup = item.MenuGroup,
                Description = item.Description,
                Price = item.Price,
                PosNumber= item.PosNumber,
                ImageUrl = item.ImageUrl,
                CreatedAt = item.CreatedAt,
                UserId = item.UserId,
                RestaurantId = item.RestaurantId,
                Options = options
            };
        }
    }
}
