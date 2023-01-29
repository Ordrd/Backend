﻿using OrdrdApi.Models;

namespace OrdrdApi.Services.MenuServ
{
    public interface IMenuService
    {
        Task<List<Item>> GetMenuAsync(int restaurantId, int page, int pageSize);
        Task<List<IGrouping<string, Item>>> GetPortalMenuAsync(int restaurantId);
        Task<List<Item>> FindInMenuAsync(int restaurantId, string search);
        Task<Item> CreateMenuItemAsync(Item item);
        Task UpdateMenuItemAsync(Item item);
        Task DeleteMenuItemAsync(int itemId);
    }
}
