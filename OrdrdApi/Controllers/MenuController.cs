using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdrdApi.DTO;
using OrdrdApi.Models;
using OrdrdApi.Services.MenuServ;
using OrdrdApi.Services.RestaurantServ;
using OrdrdApi.Services.UserServ;

namespace OrdrdApi.Controllers
{
    [Route("api/menu")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService menuService;
        private readonly IUserService userService;
        private readonly IRestaurantService restaurantService;

        public MenuController(IMenuService menuService, IUserService userService, IRestaurantService restaurantService)
        {
            this.menuService = menuService;
            this.userService = userService;
            this.restaurantService = restaurantService;
        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> GetMenu(int restaurantId, int page = 0, int pageSize = 20)
        {
            var result = await menuService.GetMenuAsync(restaurantId, page, pageSize);
            List<ItemDto> itemDtos = new List<ItemDto>();
            result.ForEach(restaurant => itemDtos.Add(ItemDto.FromItem(restaurant)));
            return itemDtos;
        }

        [AllowAnonymous]
        [Route("portal")]
        [HttpGet]
        public async Task<ActionResult<Dictionary<string, List<ItemDto>>>> GetPortalMenu(int restaurantId)
        {
            var result = await menuService.GetPortalMenuAsync(restaurantId);
            Dictionary<string, List<ItemDto>> dict = new Dictionary<string, List<ItemDto>>();
            foreach (var group in result)
            {
                List<ItemDto> itemDtos = new List<ItemDto>();
                group.ToList().ForEach(item => itemDtos.Add(ItemDto.FromItem(item)));
                dict.Add(group.Key, itemDtos);
            } 

            return dict;
        }

        [Route("find")]
        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> FindInMenu(int restaurantId, string search)
        {
            var result = await menuService.FindInMenuAsync(restaurantId, search);
            List<ItemDto> itemDtos = new List<ItemDto>();
            result.ForEach(restaurant => itemDtos.Add(ItemDto.FromItem(restaurant)));
            return itemDtos;
        }

        [Route("item")]
        [HttpPost]
        public async Task<ActionResult<Item>> CreateMenuItem(ItemDto item)
        {
            var itemMap = Item.FromItemDto(item);
            return await menuService.CreateMenuItemAsync(itemMap);
        }

        [Route("item")]
        [HttpPut]
        public async Task<ActionResult> UpdateMenuItem(ItemDto item)
        {
            var itemMap = Item.FromItemDto(item);
            await menuService.UpdateMenuItemAsync(itemMap);
            return Ok();
        }

        [Route("item")]
        [HttpDelete]
        public async Task<ActionResult> DeleteMenuItem(int itemId)
        {
            await menuService.DeleteMenuItemAsync(itemId);
            return Ok();
        }

    }
}
