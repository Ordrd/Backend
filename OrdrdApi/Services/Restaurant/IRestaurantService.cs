using OrdrdApi.Repositories.RestaurantRepo;

namespace OrdrdApi.Services.RestaurantServ
{
    public interface IRestaurantService
    {
        Task<Restaurant?> GetRestaurantAsync(int id);
        Task<List<Restaurant>> GetAllUserRestaurantsAsync(int userId);
        Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantOrderingActiveAsync(int id, bool isOrderingActive);
        Task<Restaurant> UpdateRestaurantSettingsAsync(Restaurant restaurant);
    }
}
