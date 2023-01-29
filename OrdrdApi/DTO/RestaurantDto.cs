namespace OrdrdApi.DTO
{
    public class RestaurantDto
    {
        public int Id { get; set; }
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
        public int UserId { get; set; }

        public static RestaurantDto FromRestaurant(Restaurant restaurant)
        {
            return new RestaurantDto
            {
                Id = restaurant.RestaurantId,
                Name = restaurant.Name,
                LogoUrl = restaurant.LogoUrl,
                OpenTime = restaurant.OpenTime,
                CloseTime = restaurant.CloseTime,
                BreakStart = restaurant.BreakStart,
                BreakFinish = restaurant.BreakFinish,
                Email = restaurant.Email,
                Phone = restaurant.Phone,
                IsDeliveryEnabled = restaurant.IsDeliveryEnabled,
                IsOrderingActive = restaurant.IsOrderingActive,
                Currency = restaurant.Currency,
                UserId = restaurant.UserId

            };
        }

    }
}
