using Newtonsoft.Json;
using OrdrdApi.DTO;

namespace OrdrdApi.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string BreakStart { get; set; } = string.Empty;
        public string BreakFinish { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsDeliveryEnabled { get; set; }
        public bool IsOrderingActive { get; set; }
        public string Currency { get; set; } = "€";

        // Foreign keys
        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public int UserId { get; set; }
        public User? User { get; set; }

        //ER Relations
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Item> Items { get; set; } = new List<Item>();

        public static Restaurant FromRestaurantDto(RestaurantDto restaurantDto)
        {
            return new Restaurant
            {
                RestaurantId= restaurantDto.Id,
                Name= restaurantDto.Name,
                LogoUrl= restaurantDto.LogoUrl,
                OpenTime= restaurantDto.OpenTime,
                CloseTime = restaurantDto.CloseTime ,
                BreakStart= restaurantDto.BreakStart,
                BreakFinish= restaurantDto.BreakFinish,
                Email= restaurantDto.Email,
                Phone= restaurantDto.Phone,
                IsDeliveryEnabled= restaurantDto.IsDeliveryEnabled,
                IsOrderingActive= restaurantDto.IsOrderingActive,
                Currency= restaurantDto.Currency,
                UserId = restaurantDto.UserId
            };
        }
    }
}