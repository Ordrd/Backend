using OrdrdApi.Models;
using OrdrdApi.Repositories.RestaurantRepo;

namespace OrdrdApi.Services.RestaurantServ
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant)
        {
            await restaurantRepository.CreateRestaurantAsync(restaurant);
            return restaurant;
        }

        public async Task<List<Restaurant>> GetAllUserRestaurantsAsync(int userId)
        {
            var restaurantList = await restaurantRepository.GetAllUserRestaurantsAsync(userId);
            return restaurantList;
        }

        public async Task<Restaurant?> GetRestaurantAsync(int id)
        {
            var restaurant = await restaurantRepository.GetRestaurantAsync(id);
            return restaurant;
        }

        public async Task UpdateRestaurantOrderingActiveAsync(int id, bool isOrderingActive) 
        { 
            await restaurantRepository.UpdateRestaurantOrderingActiveAsync(id, isOrderingActive); 
        }

        public async Task<Restaurant> UpdateRestaurantSettingsAsync(Restaurant restaurant)
        {
            await restaurantRepository.UpdateRestaurantSettingsAsync(restaurant);
            return restaurant;
        }
    }
}
