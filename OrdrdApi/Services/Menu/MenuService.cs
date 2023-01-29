using OrdrdApi.Models;
using OrdrdApi.Repositories.MenuRepo;
using System.Drawing.Printing;

namespace OrdrdApi.Services.MenuServ
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<Item> CreateMenuItemAsync(Item item)
        {
            await menuRepository.CreateMenuItemAsync(item);
            return item;
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            await menuRepository.DeleteMenuItemAsync(itemId);
        }

        public async Task<List<Item>> FindInMenuAsync(int restaurantId, string search)
        {
            List<Item> result = await menuRepository.FindInMenuAsync(restaurantId, search);
            return result;
        }

        public async Task<List<Item>> GetMenuAsync(int restaurantId, int page, int pageSize)
        {
            List<Item> result = await menuRepository.GetMenuAsync(restaurantId, page, pageSize);
            return result;
        }

        public async Task<List<IGrouping<string, Item>>> GetPortalMenuAsync(int restaurantId)
        {
            List<IGrouping<string, Item>> result = await menuRepository.GetPortalMenuAsync(restaurantId);
            return result;
        }

        public async Task UpdateMenuItemAsync(Item item)
        {
            await menuRepository.UpdateMenuItemAsync(item);
        }
    }
}
