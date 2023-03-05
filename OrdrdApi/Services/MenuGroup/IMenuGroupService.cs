using OrdrdApi.DTO;
using OrdrdApi.Models;

namespace OrdrdApi.Services.MenuGroupServ
{
    public interface IMenuGroupService
    {
        Task<List<MenuGroupDto>> GetAllMenuGroupsAsync();
        Task<MenuGroupDto> CreateMenuGroupAsync(MenuGroupDto menuGroupDTO);
        Task UpdateMenuGroupAsync(MenuGroupDto menuGroupDTO);
        Task DeleteMenuGroupAsync(int menuGroupId);
    }
}
