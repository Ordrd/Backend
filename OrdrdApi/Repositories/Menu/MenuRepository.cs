using OrdrdApi.Models;
using Polly;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace OrdrdApi.Repositories.MenuRepo
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DataContext context;

        public MenuRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Item> CreateMenuItemAsync(Item item)
        {

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            var itemDb = await context.Items.FindAsync(itemId);
            if (itemDb != null)
            {
                context.Items.Remove(itemDb);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Item>> FindInMenuAsync(int restaurantId, string search)
        {
            List<Item> result = await context.Items.Where(item => item.Restaurant.RestaurantId == restaurantId && item.Name.Contains(search)).ToListAsync();
            return result;
        }

        public async Task<List<Item>> GetMenuAsync(int restaurantId, int page, int pageSize)
        {
            var skipSize = page != 0 ? page - 1 : 0; 
            List<Item> menu = await context.Items
                .Where(item => item.Restaurant.RestaurantId == restaurantId)
                .Skip(skipSize * pageSize)
                .Take(pageSize)
                .Include(item => item.Options)
                    .ThenInclude(option => option.Choices)
                .Include(item => item.User)
                .Include(item => item.Restaurant)
                .ToListAsync();

            return menu;
        }

        public async Task<List<IGrouping<string, Item>>> GetPortalMenuAsync(int restaurantId)
        {
            List<IGrouping<string, Item>> result = await context.Items
                .Where(item => item.Restaurant.RestaurantId == restaurantId)
                .Include(item => item.Options)
                    .ThenInclude(option => option.Choices)
                .Include(item => item.User)
                .Include(item => item.Restaurant)
                .GroupBy(item => item.MenuGroup)
                .ToListAsync();
            return result;
        }
        public async Task UpdateMenuItemAsync(Item item)
        {
            var itemDb = await context.Items.FindAsync(item.ItemId);
            if (itemDb != null)
            {
                itemDb.Name = item.Name;
                itemDb.MenuGroup = item.MenuGroup;
                itemDb.Price = item.Price;
                itemDb.PosNumber = item.PosNumber;
                itemDb.ImageUrl = item.ImageUrl;
                itemDb.Options = item.Options;
            }

            await context.SaveChangesAsync();
        }
    }
}
