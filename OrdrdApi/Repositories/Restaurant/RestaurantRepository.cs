namespace OrdrdApi.Repositories.RestaurantRepo
{
    public class RestaurantRepository: IRestaurantRepository
    {
        private readonly DataContext context;

        public RestaurantRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            await context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<List<Restaurant>> GetAllUserRestaurantsAsync(int userId)
        {
            
            var restaurantList = await context.Restaurants.Where(u => u.User.UserId == userId).ToListAsync();
            return restaurantList;
        }

        public async Task<Restaurant?> GetRestaurantAsync(int id)
        {
            var restaurant = await context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return null;
            }
            return restaurant;
        }

        public async Task UpdateRestaurantOrderingActiveAsync(int id, bool isOrderingActive)
        {
            var restaurant = await context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                throw new NullReferenceException("This restaurant doesn't exist in the database");
            }

            restaurant.IsOrderingActive = isOrderingActive;
            await context.SaveChangesAsync();
        }

        public async Task<Restaurant> UpdateRestaurantSettingsAsync(Restaurant restaurant)
        {
            var restaurantDb = await context.Restaurants.FindAsync(restaurant.RestaurantId);

            if (restaurant == null)
            {
                throw new NullReferenceException("This restaurant doesn't exist in the database");
            }

            restaurantDb.Name = restaurant.Name;
            restaurantDb.LogoUrl = restaurant.LogoUrl;
            restaurantDb.OpenTime = restaurant.OpenTime;
            restaurantDb.CloseTime = restaurant.CloseTime;
            restaurantDb.BreakStart = restaurant.BreakStart;
            restaurantDb.BreakFinish = restaurant.BreakFinish;
            restaurantDb.Email = restaurant.Email;
            restaurantDb.Phone = restaurant.Phone;
            restaurantDb.IsDeliveryEnabled = restaurant.IsDeliveryEnabled;
            restaurantDb.IsOrderingActive = restaurant.IsOrderingActive;
            restaurantDb.Currency = restaurant.Currency;

            await context.SaveChangesAsync();

            return restaurantDb;
        }
    }
}
