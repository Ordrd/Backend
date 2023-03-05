using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdrdApi.DTO;
using OrdrdApi.Services.MenuGroupServ;

namespace OrdrdApi.Controllers
{
    [Route("api/menu")]
    [ApiController]
    [Authorize]
    public class MenuGroupController : ControllerBase
    {
        private readonly IMenuGroupService menuGroupService;


        public MenuGroupController(IMenuGroupService menuGroupService)
        {
            this.menuGroupService = menuGroupService;
        }

        [Route("all")]
        [HttpPost]
        public async Task<ActionResult<List<MenuGroupDto>>> GetMenuGroups()
        {
            return await menuGroupService.GetAllMenuGroupsAsync();
        }

        [Route("group")]
        [HttpPost]
        public async Task<ActionResult<MenuGroupDto>> CreateMenuGroup(MenuGroupDto group)
        {

            return await menuGroupService.CreateMenuGroupAsync(group);
        }

        [Route("group")]
        [HttpPut]
        public async Task<ActionResult> UpdateMenuGroup(MenuGroupDto group)
        {
            await menuGroupService.UpdateMenuGroupAsync(group);
            return Ok();
        }

        [Route("group")]
        [HttpDelete]
        public async Task<ActionResult> DeleteMenuGroup(int menuGroupId)
        {
            await menuGroupService.DeleteMenuGroupAsync(menuGroupId);
            return Ok();
        }
    }
}

