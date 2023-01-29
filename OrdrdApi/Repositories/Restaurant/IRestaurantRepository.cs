namespace OrdrdApi.Repositories.RestaurantRepo
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetRestaurantAsync(int id);
        Task<List<Restaurant>> GetAllUserRestaurantsAsync(int userId);
        Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantOrderingActiveAsync(int id, bool isOrderingActive);
        Task<Restaurant> UpdateRestaurantSettingsAsync(Restaurant restaurant);
    }
}
