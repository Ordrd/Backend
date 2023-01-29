using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdrdApi.DTO;
using OrdrdApi.Models;
using OrdrdApi.Services.RestaurantServ;
using OrdrdApi.Services.UserServ;

namespace OrdrdApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService restaurantService;
        private readonly IUserService userService;

        public RestaurantController(IRestaurantService restaurantService, IUserService userService)
        {
            this.restaurantService = restaurantService;
            this.userService = userService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<RestaurantDto?>> GetRestaurant(int id)
        {
            var result = await restaurantService.GetRestaurantAsync(id);
            return Ok(RestaurantDto.FromRestaurant(result));
        }

        [Route("user")]
        [HttpGet]
        public async Task<ActionResult<List<RestaurantDto>>> GetAllUserRestaurants(int userId)
        {
            var result = await restaurantService.GetAllUserRestaurantsAsync(userId);
            List<RestaurantDto> restaurantDtos = new List<RestaurantDto>();
            result.ForEach(restaurant => restaurantDtos.Add(RestaurantDto.FromRestaurant(restaurant)));
            return Ok(restaurantDtos);
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> CreateRestaurant(RestaurantDto restaurant)
        {
            var restaurantMap = Restaurant.FromRestaurantDto(restaurant);
            var result = await restaurantService.CreateRestaurantAsync(restaurantMap);
            return Ok(result);
        }

        [Route("{id}/ordering")]
        [HttpPut]
        public async Task<ActionResult> UpdateRestaurantOrderingActive(int id, bool isOrderingActive)
        {
            await restaurantService.UpdateRestaurantOrderingActiveAsync(id, isOrderingActive);
            return Ok();
        }

        [Route("settings")]
        [HttpPut]
        public async Task<ActionResult> UpdateRestaurantSettings(RestaurantDto restaurant)
        {
            var restaurantMap = Restaurant.FromRestaurantDto(restaurant);
            await restaurantService.UpdateRestaurantSettingsAsync(restaurantMap);
            return Ok();
        }
    }
}