using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
       
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int PosNumber { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Foreign keys
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public int MenuGroupId { get; set; }
        public virtual MenuGroup? MenuGroup { get; set; }

        //ER Relations
        public List<Option> Options { get; set; } = new List<Option>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public static Item FromItemDto(ItemDto itemDto)
        {
            List<Option> options = new List<Option>();
            itemDto.Options.ForEach(option => options.Add(Option.FromOptionDto(option)));
            return new Item
            {
                ItemId = itemDto.Id,
                Name = itemDto.Name,
                MenuGroupId = itemDto.MenuGroupId,
                Description = itemDto.Description,
                Price = itemDto.Price,
                PosNumber = itemDto.PosNumber,
                ImageUrl = itemDto.ImageUrl,
                UserId = itemDto.UserId,
                RestaurantId = itemDto.RestaurantId,
                Options = options
            };
        }
    }
}